using Microsoft.AspNetCore.Mvc;

namespace DotnetTalkChatGPT.Controllers;


[Route("/api/v1/[controller]")]
[ApiController]
public class MainController : ControllerBase
{


    public MainController() { }



    [HttpGet()]
    public async Task<ActionResult<string>> Hello()
    {
        return Ok();
    }

}
