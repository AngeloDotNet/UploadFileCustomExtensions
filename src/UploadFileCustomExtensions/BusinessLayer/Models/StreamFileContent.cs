namespace UploadFileCustomExtensions.BusinessLayer.Models;

public class StreamFileContent
{
    public StreamFileContent(Stream content, string contentType, string fileName, int length, string description)
    {
        Content = content;
        ContentType = contentType;
        FileName = fileName;
        Length = length;
        Description = description;
    }

    public Stream Content { get; }
    public string ContentType { get; }
    public string FileName { get; }
    public int Length { get; }
    public string Description { get; }
}