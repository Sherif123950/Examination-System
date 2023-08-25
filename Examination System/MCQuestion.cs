using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQuestion : BaseQuestion
    {
        public MCQuestion(string header, string body, int mark, int AnswerID, string AnswerText) : base(header, body, mark, AnswerID, AnswerText, 3)
        {

        }
        public override string ToString()
        {
            return $"{Header}       Mark({Mark})\n" +
                $"{Body}\n" +
                $"1. {this.AnswersList[0].AnswerText}         2. {this.AnswersList[1].AnswerText}         3.{this.AnswersList[2].AnswerText}\n" +
                $"------------------------------------------------------------";
        }
    }
}
