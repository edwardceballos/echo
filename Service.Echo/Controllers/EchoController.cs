using Microsoft.AspNetCore.Mvc;

namespace Mvct.Sisfv.Service.Echo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
       [HttpGet("{id}")] 
       [Produces("application/json")]
       [ProducesResponseType( typeof(StandardResponse),200)]
       [ProducesResponseType(404)]
        public ActionResult<StandardResponse> Get(int id)
        {
            if (id == -1) return NotFound();
            var serverTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var response = new StandardResponse
            { 
                ServerTimeStamp =serverTimestamp, 
               IsSuccess = true,
               Message = Faker.Lorem.Paragraph()
            };
            return Ok(response);
        }
    }

    public class StandardResponse
    {
        public long ServerTimeStamp { get; set; } 
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
