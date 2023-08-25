using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TOFQuestion:BaseQuestion
    {
        public TOFQuestion(string header, string body,int mark,int AnswerID,string AnswerText):base(header,  body,  mark,  AnswerID,  AnswerText,2) 
        {
            
        }
        public override string ToString()
        {
            return $"{Header}       Mark({Mark})\n" +
                $"{Body}\n" +
                $"1. True                   2. False\n" +
                $"------------------------------------------------------------";
        }
    }
}
