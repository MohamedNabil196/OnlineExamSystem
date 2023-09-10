using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Models
{
	public enum Gender
	{
		Male = 1,
		Female = 2
	
	}
	public enum TypeOfQuestion
	{
		TFQuestion = 1,
		FillInBlank=2,
		MultiChoice= 3,
		EssayQuation=4
	}
    public enum OptionsOfAnswer
    {
        Option1 = 1,
        Option2 = 2,
        Option3 = 3,
        Option4 = 4
    }
}
