using coreApi_QusAns.Model;
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
            string connString = DBConnection.getDBConstring();
            return Ok( new
            {
                output = connString, 
                status= "success"
            });
        }
        [HttpPost(Name ="SaveName")]
        public IActionResult SaveName([FromBody] BaseQuestion baseQuestion) {
            return Ok(new
            {
                output = baseQuestion.Title,
                status = "success"
            });
        }
    }
}
