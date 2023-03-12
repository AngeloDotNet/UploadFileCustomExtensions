using UploadFileCustomExtensions.BusinessLayer.Models;
using UploadFileCustomExtensions.DataAccessLayer.Entities;
using UploadFileCustomExtensions.DataAccessLayer.Services;
using UploadFileCustomExtensions.Shared.Models;
using UploadFileCustomExtensions.StorageProviders.Storage;

namespace UploadFileCustomExtensions.BusinessLayer.Services;

public class ImageService : IImageService
{
    private readonly IDatabaseService databaseService;
    private readonly IStorageProvider storageProvider;
    private readonly IMapper mapper;

    public ImageService(IDatabaseService databaseService, IStorageProvider storageProvider, IMapper mapper)
    {
        this.databaseService = databaseService;
        this.storageProvider = storageProvider;
        this.mapper = mapper;
    }

    public async Task<List<ImageResponse>> GetImagesAsync()
    {
        var imagesList = await databaseService.GetListItemAsync();

        //var images = new List<ImageResponse>(
        //    imagesList.Select(i => new ImageResponse
        //    {
        //        Id = i.Id,
        //        Path = i.Path,
        //        Length = i.Length,
        //        ContentType = MimeMapping.MimeUtility.GetMimeMapping(i.Path),
        //        Description = i.Description
        //    })
        //    .ToList());

        var images = mapper.Map<List<ImageResponse>>(imagesList);

        return images;
    }

    public async Task<(Stream Stream, string ContentType)?> GetImageAsync(Guid id)
    {
        var image = await databaseService.GetItemAsync(id);

        if (image == null)
        {
            return null;
        }

        var stream = await storageProvider.ReadAsync(image.Path);

        return (stream, MimeMapping.MimeUtility.GetMimeMapping(image.Path));
    }

    public async Task<bool> UploadAsync(StreamFileContent content)
    {
        var path = GetFullPath(content.FileName);

        await storageProvider.SaveAsync(path, content.Content);

        var image = new ImageEntity(path, content.Length, content.Description);

        //var image = new ImageEntity
        //{
        //    Id = SequentialGuidGenerator.Instance.NewGuid(),
        //    Path = path,
        //    Length = content.Length,
        //    Description = content.Description
        //};

        await databaseService.CreateItemAsync(image);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var image = await databaseService.GetItemAsync(id);

        if (image == null)
        {
            return false;
        }

        await databaseService.DeleteItemAsync(image);
        await storageProvider.DeleteAsync(image.Path);

        return true;
    }

    public static string GetFullPath(string fileName)
    {
        var fullPath = Path.Combine(DateTime.UtcNow.Year.ToString(), DateTime.UtcNow.Month.ToString("00"), fileName);

        return fullPath;
    }
}