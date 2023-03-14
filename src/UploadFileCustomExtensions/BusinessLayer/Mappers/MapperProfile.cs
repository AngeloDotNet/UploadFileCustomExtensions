namespace UploadFileCustomExtensions.BusinessLayer.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ImageEntity, ImageResponse>()
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => MimeMapping.MimeUtility.GetMimeMapping(src.Path)))
            .ReverseMap();
    }
}