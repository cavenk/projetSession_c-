using KathiresuCaven_ProjetSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KathiresuCaven_ProjetSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuizExamenContext database;
        public HomeController(QuizExamenContext database)
        {
            this.database = database;   
        }

        public IActionResult Index()
        {
            return View();
        }

        //New quiz page
        public IActionResult NewQuizPage()
        {
            return View();
        }

        public IActionResult CreateQuizAction(string Username, string Email, int QuestionFacile, int QuestionMoyen, int QuestionDifficile)
        {
            List<int> easyQuestionList = database.Question.Where(x => x.CategoryId == 1).Select(x => x.QuestionId).ToList();
            List<int> easyQuestions = getRandomQuestion(QuestionFacile, easyQuestionList);
            List<int> mediumQuestions = getRandomQuestion(
                QuestionMoyen,
                database.Question.Where(x => x.CategoryId == 2).Select(x => x.QuestionId).ToList()
            );
            List<int> hardQuestionsList = getRandomQuestion(
                QuestionDifficile,
                database.Question.Where(x => x.CategoryId == 2).Select(x => x.QuestionId).ToList()
            );

            foreach(int numcer in easyQuestions)
            {
                Debug.WriteLine($"easyquestion: {numcer}");
            }
                

            return RedirectToAction("Index");
        }

        public List<int> getRandomQuestion(int NombreQuestion, List<int> ListQuiz)
        {

            List<int> newList = new List<int>();
            List<int> quizLeft = ListQuiz.ToList();
            
            for(int i = 0; i < NombreQuestion; i++)
            {
                int RandomIndex = new Random().Next(0, quizLeft.Count());
                Debug.WriteLine($"random index = {RandomIndex}");

                newList.Add(quizLeft[RandomIndex]);
                quizLeft.RemoveAt(RandomIndex);

                Debug.WriteLine($"original list sizze: {ListQuiz.Count()}");
                Debug.WriteLine($"quiz left size: {quizLeft.Count()}");

            }

            return newList;







        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
