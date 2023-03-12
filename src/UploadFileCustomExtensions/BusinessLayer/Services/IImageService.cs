using UploadFileCustomExtensions.BusinessLayer.Models;
using UploadFileCustomExtensions.Shared.Models;

namespace UploadFileCustomExtensions.BusinessLayer.Services;

public interface IImageService
{
    Task<List<ImageResponse>> GetImagesAsync();
    Task<(Stream Stream, string ContentType)?> GetImageAsync(Guid id);
    Task<bool> UploadAsync(StreamFileContent content);
    Task<bool> DeleteAsync(Guid id);
}