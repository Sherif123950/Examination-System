using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam:Exam
    {
        public MCQuestion[] MCQuestions { get; set; }
        public PracticalExam(int time, int numberOfQuesitons) : base(time, numberOfQuesitons)
        {
            MCQuestions = new MCQuestion[numberOfQuesitons];
        }
        public override void ShowExam()
        {
            int GradeCounter = 0;
            int ExamGrade = 0;
            int UserAnswer;
            Answers[] userAnswer = new Answers[NumberOfQuestions];
            for (int i = 0; i < this.NumberOfQuestions; i++)
            {
                
                
                Console.WriteLine(this.MCQuestions[i].ToString());
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out UserAnswer) || !(UserAnswer == 1 || UserAnswer == 2 || UserAnswer == 3));
                if (UserAnswer == this.MCQuestions[i].RightAnswer.AnswerId)
                {
                    GradeCounter += this.MCQuestions[i].Mark;
                }
                for (int j = 1; j < 4; j++)
                {
                    if (UserAnswer == this.MCQuestions[i].AnswersList[j - 1].AnswerId)
                    {
                        userAnswer[i] = this.MCQuestions[i].AnswersList[j - 1];
                    }
                }
                ExamGrade += this.MCQuestions[i].Mark; 
                Console.WriteLine("********************************************************");
            }
            Console.Clear();
            Console.WriteLine("Your Answers :"); 
            for (int i = 0; i < this.NumberOfQuestions; i++)
            {
                Console.WriteLine($"Q{i+1})       {this.MCQuestions[i].Body} : {userAnswer[i].AnswerText}");
            }
            Console.WriteLine($"Your Exam Grade is {GradeCounter} from {ExamGrade}");
        }
    }
}
