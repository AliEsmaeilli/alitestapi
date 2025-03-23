using Microsoft.AspNetCore.Mvc;

namespace myaz_aci_workshop.Controllers;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{
    public static List<string> Ping { get; set; } = [];

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return Ping;
    }

    [HttpPost]
    public void Post()
    {
        var timestamp = DateTime.Now.Ticks.ToString();
        Ping.Add(timestamp);
    }
}