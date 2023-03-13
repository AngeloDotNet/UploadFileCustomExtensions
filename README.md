# Upload Files Custom Extensions

If you like this repository, please drop a :star: on Github!


## Installation

The library is available on [NuGet](https://www.nuget.org/packages/UploadFileCustomExtensions) or run the following command in the .NET CLI:

```bash
dotnet add package UploadFileCustomExtensions
```


## Configuration to add to the appsettings.json file

```json
"AppSettings": {
  "StorageFolder": ""
}
```


## Registering services at Startup

```csharp
public Startup(IConfiguration configuration)
{
  Configuration = configuration;
}

public IConfiguration Configuration { get; }
	
public void ConfigureServices(IServiceCollection services)
{
  services.AddBusinessLayerServices();  
  services.AddDataAccessLayerRegistration();

  services.AddStorageProviderService(Configuration);
}
```


## Example of the image request

```csharp
public class ImageRequest
{
    public IFormFile File { get; set; }
    public string Description { get; set; }
}
```


## To keep in mind

At the moment this library only allows uploading images to file systems (supported extensions: jpeg, png)


## Contributing

Contributions and/or suggestions are always welcome.


## Inspired by

[Marco Minerva Project](https://github.com/marcominerva/WebApiUploaderSample)