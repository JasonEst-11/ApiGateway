using Microsoft.AspNetCore.Mvc;

namespace Service2.Controllers;

[ApiController]
[Route("vehicle")]
public class VehicleController : ControllerBase
{
  private static List<string> vehicles = new List<string> { "car1", "car2" };
  private readonly ILogger<VehicleController> _logger;

  public VehicleController(ILogger<VehicleController> logger)
  {
    _logger = logger;
  }

  [HttpGet("GetAll")]
  public IEnumerable<string> GetAll()
  {
    return vehicles;
  }

  [HttpPost("Add")]
  public IActionResult Add([FromBody] string vehicle)
  {
    vehicles.Add(vehicle);
    return Ok("Vehicle added succesfully");
  }
}
