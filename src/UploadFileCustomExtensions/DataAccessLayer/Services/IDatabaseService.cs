using UploadFileCustomExtensions.DataAccessLayer.Entities;

namespace UploadFileCustomExtensions.DataAccessLayer.Services;

public interface IDatabaseService
{
    Task<List<ImageEntity>> GetListItemAsync();
    Task<ImageEntity> GetItemAsync(Guid id);
    Task CreateItemAsync(ImageEntity item);
    Task UpdateItemAsync(ImageEntity item);
    Task DeleteItemAsync(ImageEntity item);
}