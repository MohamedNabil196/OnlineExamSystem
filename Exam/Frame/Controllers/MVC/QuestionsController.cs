using AutoMapper;
using Dapper;
using Exam.Application.DTOs.DapperDTO;
using Exam.Application.DTOs.ViewModelDTO;
using Exam.Application.IServices;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace Exam.Controllers.MVC
{
	public class QuestionsController : Controller
	{
        private readonly IDbConnection _dbConnection;
        public IQuestionService _QuestionService;
		public IMapper _mapper;
        public QuestionsController(IQuestionService QuestionService, IMapper mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbConnection = new SqlConnection(connectionString);
            _mapper = mapper;
            _QuestionService = QuestionService;
        }
       
        public IActionResult Index()
		{
			return View();
		}
        [HttpGet("")]
        public  IActionResult GetAll(int id)
		{
            id = 1;
            IEnumerable<QuestionDapperDTO> questions = _dbConnection.Query<QuestionDapperDTO>($"SELECT Id,QContent,TypeOfQuestion,answerTF,answerContent FROM Questions where ExaminationId={id}");
          //  var Questions =  _QuestionService.GetAll(1,10);
			return View(questions);
		}
        [HttpGet]
        public IActionResult Get(int id)
        {
         
            IEnumerable<QuestionDapperDTO> questions = _dbConnection.Query<QuestionDapperDTO>($"SELECT Id,QContent,TypeOfQuestion,answerTF,answerContent,Option1,Option2,Option3,Option4 FROM Questions where Id={id}");
            //  var Questions =  _QuestionService.GetAll(1,10);
            return View(questions.FirstOrDefault());
        }


        [HttpGet]
        public async Task<IActionResult> CreateTFQuestion(int id)
        {
            if(id != 0)
            {
                QuestionViewModelTF questionViewModel = new QuestionViewModelTF();
                questionViewModel.ExaminationId = id;
                questionViewModel.TypeOfQuestion = Domain.Models.TypeOfQuestion.TFQuestion;
                return View(questionViewModel);
            }
           
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public async Task<IActionResult> CreateEssayQuestion(int id)
        {
            if (id != 0)
            {
                QuestionViewModelEssay questionViewModel = new QuestionViewModelEssay();
                questionViewModel.ExaminationId = id;
                questionViewModel.TypeOfQuestion = Domain.Models.TypeOfQuestion.EssayQuation;
                return View(questionViewModel);
            }

            return RedirectToAction("Index", "Home");

        }
       
        [HttpGet]
        public async Task<IActionResult> CreateMultiChoice(int id)
        {
            if (id != 0)
            {
                QuestionViewModelMulti questionViewModel = new QuestionViewModelMulti();
                questionViewModel.ExaminationId = id;
                questionViewModel.TypeOfQuestion = Domain.Models.TypeOfQuestion.MultiChoice;
                return View(questionViewModel);
            }

            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> CreateTF(QuestionViewModelTF model)
        {
            if (ModelState.IsValid)
            {
                QuestionViewModel questionViewModel = new QuestionViewModel();
                questionViewModel = _mapper.Map<QuestionViewModel>(model);
                var result = _QuestionService.Create(questionViewModel);
                if (result != null)
                {
                    Question question = new Question();
                    return RedirectToAction("GetAll", "Questions");
                }
               
            }
            return View("CreateTFQuestion", model);
           
        }
        [HttpPost]
        public async Task<IActionResult> CreateEssay(QuestionViewModelEssay model)
        {
            if (ModelState.IsValid)
            {
                QuestionViewModel questionViewModel = new QuestionViewModel();
                questionViewModel = _mapper.Map<QuestionViewModelEssay, QuestionViewModel>(model);
                var result = _QuestionService.Create(questionViewModel);
                if (result != null)
                {
                    Question question = new Question();
                    return RedirectToAction("GetAll", "Questions");
                }

            }
            return View("CreateEssayQuestion", model);

        }
        [HttpPost]
        public async Task<IActionResult> CreateMulti(QuestionViewModelMulti model)
        {
            if (ModelState.IsValid)
            {
                QuestionViewModel questionViewModel = new QuestionViewModel();
                questionViewModel = _mapper.Map<QuestionViewModelMulti, QuestionViewModel>(model);
                var result = _QuestionService.Create(questionViewModel);
                if (result != null)
                {
                    Question question = new Question();
                    return RedirectToAction("GetAll", "Questions");
                }

            }
            return View("CreateMultiChoice", model);

        }


    }
}
