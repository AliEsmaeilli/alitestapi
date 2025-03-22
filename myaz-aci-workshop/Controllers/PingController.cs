using Microsoft.AspNetCore.Mvc;

namespace myaz_aci_workshop.Controllers;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{
    private static readonly string DirectoryPath = Path.Combine(AppContext.BaseDirectory, "times");
    private static readonly string FilePath = Path.Combine(DirectoryPath, "timestamps.txt");

    public PingController()
    {
        Console.WriteLine("ping from controller");
        if (!Directory.Exists(DirectoryPath))
        {
            Directory.CreateDirectory(DirectoryPath);
        }
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        if (!System.IO.File.Exists(FilePath))
        {
            return Enumerable.Empty<string>();
        }
        return System.IO.File.ReadAllLines(FilePath);
    }

    [HttpPost]
    public void Post()
    {
        var timestamp = DateTime.Now.Ticks.ToString();
        System.IO.File.AppendAllText(FilePath, timestamp + "\n");
    }
}