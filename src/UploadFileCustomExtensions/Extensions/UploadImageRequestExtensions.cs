namespace UploadFileCustomExtensions.Extensions;

public static class UploadImageRequestExtensions
{
    public static StreamFileContent ToStreamFileContent(this ImageRequest request)
        => new(request.File.OpenReadStream(), request.File.ContentType, request.File.FileName, (int)request.File.Length, request.Description);
}