using UploadFileCustomExtensions.BusinessLayer.Models;
using UploadFileCustomExtensions.Shared.Models;

namespace UploadFileCustomExtensions.Extentions;

public static class UploadImageRequestExtensions
{
    public static StreamFileContent ToStreamFileContent(this ImageRequest request)
        => new(request.File.OpenReadStream(), request.File.ContentType, request.File.FileName, (int)request.File.Length, request.Description);
}