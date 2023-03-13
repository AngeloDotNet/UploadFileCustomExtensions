namespace UploadFileCustomExtensions.StorageProviders.Storage;

public static class StorageProviderExtensions
{
    public static IServiceCollection AddFileSystemStorageProvider(this IServiceCollection services, Action<FileSystemStorageSettings> configuration)
    {
        var settings = new FileSystemStorageSettings();
        configuration.Invoke(settings);

        services.AddSingleton(settings);

        services.AddScoped<IStorageProvider, FileSystemStorageProvider>();

        return services;
    }
}