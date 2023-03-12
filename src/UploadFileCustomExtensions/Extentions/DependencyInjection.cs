using EFCoreGeneric.Infrastructure.Interfaces;
using EFCoreGeneric.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using UploadFileCustomExtensions.BusinessLayer.Mappers;
using UploadFileCustomExtensions.BusinessLayer.Services;
using UploadFileCustomExtensions.DataAccessLayer;
using UploadFileCustomExtensions.DataAccessLayer.Services;
using UploadFileCustomExtensions.StorageProviders.Storage;

namespace UploadFileCustomExtensions.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddStorageProviderService(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddFileSystemStorageProvider(options =>
        {
            options.StorageFolder = Configuration.GetSection("AppSettings").GetValue<string>("StorageFolder");
        });

        return services;
    }

    public static IServiceCollection AddDataAccessLayerRegistration(this IServiceCollection services)
    {
        services
            .AddScoped<DbContext, UploadFilesDbContext>()
            .AddScoped(typeof(IUnitOfWork<,>), typeof(UnitOfWork<,>))
            .AddScoped(typeof(IDatabaseRepository<,>), typeof(DatabaseRepository<,>))
            .AddScoped(typeof(ICommandRepository<,>), typeof(CommandRepository<,>));

        return services;
    }

    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

        services
            .AddTransient<IImageService, ImageService>()
            .AddTransient<IDatabaseService, DatabaseService>();

        return services;
    }
}