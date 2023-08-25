using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
      
        public abstract void ShowExam();
        public Exam(int time,int NoOfQuestions)
        {
            Time = time;
            NumberOfQuestions = NoOfQuestions;
        }

    }
}
