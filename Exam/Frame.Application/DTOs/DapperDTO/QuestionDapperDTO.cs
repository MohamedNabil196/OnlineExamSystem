using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs.DapperDTO
{
    public class QuestionDapperDTO
    {
        //  Id,QContent,TypeOfQuestion,answerTF
        public int Id { get; set; }
        public string QContent { get; set; }
        public string answerContent { get; set; }
        public int TypeOfQuestion { get; set; }
        public bool answerTF { get; set; }
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }
    }
}
