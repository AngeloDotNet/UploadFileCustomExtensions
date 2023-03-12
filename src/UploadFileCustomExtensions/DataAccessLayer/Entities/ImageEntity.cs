namespace UploadFileCustomExtensions.DataAccessLayer.Entities;

public class ImageEntity : IEntity<Guid>
{
    //public ImageEntity(string path, int length, string description)
    //{
    //    Id = SequentialGuidGenerator.Instance.NewGuid();
    //    ChangePath(path);
    //    ChangeLength(length);
    //    ChangeDescription(description);
    //}

    public Guid Id { get; set; }
    public string Path { get; set; }
    public int Length { get; set; }
    public string Description { get; set; }

    //public void ChangePath(string newPath)
    //{
    //    if (string.IsNullOrWhiteSpace(newPath))
    //    {
    //        throw new ArgumentException("The path is required");
    //    }

    //    Path = newPath;
    //}

    //public void ChangeLength(int? newLength)
    //{
    //    if (newLength == null)
    //    {
    //        return;
    //    }

    //    Length = newLength ?? 0;
    //}

    //public void ChangeDescription(string newDescription)
    //{
    //    if (string.IsNullOrWhiteSpace(newDescription))
    //    {
    //        throw new ArgumentException("The description is required");
    //    }

    //    Description = newDescription;
    //}
}