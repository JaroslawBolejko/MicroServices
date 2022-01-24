namespace MicroServicesWebApi.Profiles;

public class PlatformsProfile : Profile 
{

public PlatformsProfile()
{
    // Source --> Target
    CreateMap<Platform, PlatformReadDto>();
    CreateMap<PlatformCreateDto, Platform>();
}

}
