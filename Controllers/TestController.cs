using coreApi_QusAns.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace coreApi_QusAns.Controllers
{
    [Route("/api/[controller]/[Action]")]
    public class TestController : Controller
    {
        [HttpGet (Name ="ListQuestion")]
        public IActionResult ListQuestion([Required]string category)
        {
            return Ok("List Question category "+category);
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
