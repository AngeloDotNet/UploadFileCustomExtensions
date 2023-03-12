using EFCoreGeneric.Infrastructure.Interfaces;
using UploadFileCustomExtensions.DataAccessLayer.Entities;

namespace UploadFileCustomExtensions.DataAccessLayer.Services;

public class DatabaseService : IDatabaseService
{
    private readonly IUnitOfWork<ImageEntity, Guid> unitOfWork;

    public DatabaseService(IUnitOfWork<ImageEntity, Guid> unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<ImageEntity>> GetListItemAsync()
    {
        var listItem = await unitOfWork.ReadOnly.GetAllAsync();
        return listItem;
    }

    public async Task<ImageEntity> GetItemAsync(Guid id)
    {
        var item = await unitOfWork.ReadOnly.GetByIdAsync(id);
        return item;
    }

    public async Task CreateItemAsync(ImageEntity item)
    {
        await unitOfWork.Command.CreateAsync(item);
    }

    public async Task UpdateItemAsync(ImageEntity item)
    {
        await unitOfWork.Command.UpdateAsync(item);
    }

    public async Task DeleteItemAsync(ImageEntity item)
    {
        await unitOfWork.Command.DeleteAsync(item);
    }
}