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
}