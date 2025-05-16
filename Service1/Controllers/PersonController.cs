using Microsoft.AspNetCore.Mvc;

namespace Service1.Controllers;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
  public static List<string> people = new List<string> { "Bob", "Jeff" };

  private readonly ILogger<PersonController> _logger;

  public PersonController(ILogger<PersonController> logger)
  {
    _logger = logger;
  }

  [HttpGet("GetAll")]
  public List<string> Get()
  {
    return people;
  }

  [HttpPost("Add")]
  public IActionResult Add([FromBody] string person)
  {
    people.Add(person);
    return Ok("Person added successfully");
  }
}
