namespace UploadFileCustomExtensions.Shared.Models;

public class ImageResponse
{
    public Guid Id { get; set; }
    public string Path { get; set; }
    public int Length { get; set; }
    public string ContentType { get; set; }
    public string Description { get; set; }
}