namespace UploadFileCustomExtensions.DataAccessLayer.Entities;

public class ImageEntity
{
    public Guid Id { get; set; }
    public string Path { get; set; }
    public int Length { get; set; }
    public string Description { get; set; }
}