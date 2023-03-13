using UploadFileCustomExtensions.BusinessLayer.Models;
using UploadFileCustomExtensions.Shared.Models;

namespace UploadFileCustomExtensions.BusinessLayer.Services;

public interface IImageService
{
    Task<List<ImageResponse>> GetImagesAsync();
    Task<(Stream Stream, string ContentType)?> GetImageAsync(Guid id);
    Task<bool> UploadImageAsync(StreamFileContent content);
    Task<bool> DeleteImageAsync(Guid id);
}