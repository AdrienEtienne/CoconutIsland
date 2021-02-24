using Microsoft.AspNetCore.Mvc;

namespace CoconutIsland.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class V1Controller : ControllerBase { }
}