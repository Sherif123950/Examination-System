using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class BaseQuestion
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answers[] AnswersList { get; set; }
        public Answers RightAnswer { get; set; }
        public BaseQuestion(string header, string body, int mark, int AnswerID, string AnswerText,int Size)
        {
            this.Header = header;
            this.Body = body;
            this.Mark = mark;
            this.AnswersList = new Answers[Size];
            this.RightAnswer = new Answers(AnswerID, AnswerText);
        }
    }
}
