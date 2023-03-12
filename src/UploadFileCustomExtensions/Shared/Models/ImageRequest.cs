using Microsoft.AspNetCore.Mvc.ModelBinding;
using UploadFileCustomExtensions.Filters;

namespace UploadFileCustomExtensions.Shared.Models;

public class ImageRequest
{
    [BindRequired]
    [AllowedExtensions("jpeg", "*.jpg", "*.png")]
    public IFormFile File { get; set; }

    public string Description { get; set; }
}