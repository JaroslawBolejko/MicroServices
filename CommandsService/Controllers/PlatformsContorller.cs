namespace CommandsService.Controllers;

//c jest po to aby odóżniła się sicieżka bo mamy dwa takie same kontrllery
[Route("api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    public PlatformsController()
    {

    }
    [HttpPost]
    public ActionResult TestInboundConnection()
    {
    Console.WriteLine("----> Inbound POST # Command Service");

    return Ok("Inbound test of from Platforms Controller"); 
    }
}