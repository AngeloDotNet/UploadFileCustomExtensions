namespace UploadFileCustomExtensions.DataAccessLayer.Services;

public interface IDatabaseImageService
{
    Task<List<ImageEntity>> GetListImagesAsync();
    Task<ImageEntity> GetImageAsync(Guid id);
    Task CreateImageAsync(ImageEntity item);
    Task UpdateImageAsync(ImageEntity item);
    Task DeleteImageAsync(ImageEntity item);
}