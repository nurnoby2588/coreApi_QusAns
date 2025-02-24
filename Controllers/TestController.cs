using coreApi_QusAns.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace coreApi_QusAns.Controllers
{
    [Route("/api/[controller]/[Action]")]
    public class TestController : Controller
    {
        //private readonly BaseQuestion _baseQuestion;

        //public TestController(BaseQuestion baseQuestion)
        //{
        //    _baseQuestion = baseQuestion;
        //}

        [HttpGet (Name ="ListQuestion")]
        public IActionResult ListQuestion([FromBody]BaseQuestion baseQuestion, string category)
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
        [HttpPost(Name ="QuestionList")]
        public IActionResult QuestionList() {
           
            List<BaseQuestion> baseQuestions = BaseQuestion.listQuestion();
            return Ok(new
            {
                output = baseQuestions,
                status = "success"
            });
        }
        [HttpGet("quesNo")]
        public IActionResult QuestionList([Required] int questionId) {
            BaseQuestion? singleQuestion = BaseQuestion.singleQuestion(questionId);
            return Ok(new
            {
                output = singleQuestion,
            });
        }
    }

    
}
