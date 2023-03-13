using EFCoreGeneric.Infrastructure.Interfaces;
using UploadFileCustomExtensions.DataAccessLayer.Entities;

namespace UploadFileCustomExtensions.DataAccessLayer.Services;

public class DatabaseImageService : IDatabaseImageService
{
    private readonly IUnitOfWork<ImageEntity, Guid> unitOfWork;

    public DatabaseImageService(IUnitOfWork<ImageEntity, Guid> unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<ImageEntity>> GetListImagesAsync()
    {
        var listItem = await unitOfWork.ReadOnly.GetAllAsync();
        return listItem;
    }

    public async Task<ImageEntity> GetImageAsync(Guid id)
    {
        var item = await unitOfWork.ReadOnly.GetByIdAsync(id);
        return item;
    }

    public async Task CreateImageAsync(ImageEntity item)
    {
        await unitOfWork.Command.CreateAsync(item);
    }

    public async Task UpdateImageAsync(ImageEntity item)
    {
        await unitOfWork.Command.UpdateAsync(item);
    }

    public async Task DeleteImageAsync(ImageEntity item)
    {
        await unitOfWork.Command.DeleteAsync(item);
    }
}