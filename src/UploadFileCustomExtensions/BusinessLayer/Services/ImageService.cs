using UploadFileCustomExtensions.BusinessLayer.Models;
using UploadFileCustomExtensions.DataAccessLayer.Entities;
using UploadFileCustomExtensions.DataAccessLayer.Services;
using UploadFileCustomExtensions.Shared.Models;
using UploadFileCustomExtensions.StorageProviders.Storage;

namespace UploadFileCustomExtensions.BusinessLayer.Services;

public class ImageService : IImageService
{
    private readonly IDatabaseImageService databaseService;
    private readonly IStorageProvider storageProvider;
    private readonly IMapper mapper;

    public ImageService(IDatabaseImageService databaseService, IStorageProvider storageProvider, IMapper mapper)
    {
        this.databaseService = databaseService;
        this.storageProvider = storageProvider;
        this.mapper = mapper;
    }

    public async Task<List<ImageResponse>> GetImagesAsync()
    {
        var imagesList = await databaseService.GetListImagesAsync();
        var images = mapper.Map<List<ImageResponse>>(imagesList);

        return images;
    }

    public async Task<(Stream Stream, string ContentType)?> GetImageAsync(Guid id)
    {
        var image = await databaseService.GetImageAsync(id);

        if (image == null)
        {
            return null;
        }

        var stream = await storageProvider.ReadAsync(image.Path);

        return (stream, MimeMapping.MimeUtility.GetMimeMapping(image.Path));
    }

    public async Task<bool> UploadImageAsync(StreamFileContent content)
    {
        var path = GetFullPath(content.FileName);

        await storageProvider.SaveAsync(path, content.Content);

        var image = new ImageEntity
        {
            Id = SequentialGuidGenerator.Instance.NewGuid(),
            Path = path,
            Length = content.Length,
            Description = content.Description
        };

        await databaseService.CreateImageAsync(image);

        return true;
    }

    public async Task<bool> DeleteImageAsync(Guid id)
    {
        var image = await databaseService.GetImageAsync(id);

        if (image == null)
        {
            return false;
        }

        await databaseService.DeleteImageAsync(image);
        await storageProvider.DeleteAsync(image.Path);

        return true;
    }

    public static string GetFullPath(string fileName)
    {
        var fullPath = Path.Combine(DateTime.UtcNow.Year.ToString(), DateTime.UtcNow.Month.ToString("00"), fileName);

        return fullPath;
    }
}