using Microsoft.AspNetCore.Mvc;

namespace coreApi_QusAns.Controllers
{
    [Route("/api/[controller]/[Action]")]
    public class TestController : Controller
    {
        [HttpGet (Name ="QtyProjectName")]
        public IActionResult QtyProjectName()
        {
            return Ok("success");
        }
        [HttpGet(Name ="employName")]

        public IActionResult employName()
        {
            return Ok( new
            {
                name = "nurnoby" , 
                status= "success"
            });
        }

    }
}
