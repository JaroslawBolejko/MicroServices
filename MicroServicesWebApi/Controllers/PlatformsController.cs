namespace MicroServicesWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo platformRepo;
    private readonly IMapper mapper;

    public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
    {
        this.platformRepo = platformRepo;
        this.mapper = mapper;
    }
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        System.Console.WriteLine("------>Getting Platforms.....");

        var platformItem = this.platformRepo.GetAllPlatforms();


        return Ok(this.mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }
    [HttpGet]
    [Route("{platformId}", Name="GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int platformId)
    {
        System.Console.WriteLine("------>Getting Platform by Id.....");

        var platformItem = this.platformRepo.GetPlatformById(platformId);
        if (platformItem != null)
        {
            return Ok(this.mapper.Map<PlatformReadDto>(platformItem));

        }
        return NotFound();

    }
    [HttpPost]
    public ActionResult<PlatformCreateDto> CreatePlatform(Platform platform)
    {
        System.Console.WriteLine("------>Creating New Platform");
        this.platformRepo.CreatePlatform(platform);
        return default;
        //return Created();
    }
}