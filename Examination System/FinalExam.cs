using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam:Exam
    {
        public TOFQuestion[] TOFQuestions { get; set; }
        public MCQuestion[] MCQuestions { get; set; }
        public FinalExam(int time,int numberOfQuesitons):base(time,numberOfQuesitons)
        {
            TOFQuestions=new TOFQuestion[numberOfQuesitons];
            MCQuestions=new MCQuestion[numberOfQuesitons];
        }
        public override void ShowExam()
        {
            int ExamGrade = 0;
            int GradeCounter = 0;
            int UserAnswer;
            Answers[] userAnswer=new Answers[NumberOfQuestions];
            for (int i = 0; i < this.NumberOfQuestions; i++)
            {
                if (this.MCQuestions[i] is not null)
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
                }
                else
                { 
                    Console.WriteLine(this.TOFQuestions[i].ToString());
                    do
                    {

                    } while (!(int.TryParse(Console.ReadLine(), out UserAnswer)) || !(UserAnswer == 1 || UserAnswer == 2));
                    if (UserAnswer == this.TOFQuestions[i].RightAnswer.AnswerId)
                    {
                        GradeCounter += this.TOFQuestions[i].Mark;
                    }
                    for (int j = 1; j < 3; j++)
                    {
                        if (UserAnswer == this.TOFQuestions[i].AnswersList[j-1].AnswerId)
                        {
                            userAnswer[i] = this.TOFQuestions[i].AnswersList[j - 1];
                        }
                    }
                    ExamGrade += this.TOFQuestions[i].Mark;
                }
                Console.WriteLine("************************************************************");
            }
            Console.Clear();
            Console.WriteLine("Your Answers :"); ;
            for (int i = 0; i < this.NumberOfQuestions; i++)
            {
                if (this.MCQuestions[i] is not null)
                    Console.WriteLine($"Q{i + 1})       {this.MCQuestions[i].Body} : {userAnswer[i].AnswerText}");
                else
                    Console.WriteLine($"Q{i + 1})       {this.TOFQuestions[i].Body} : {userAnswer[i].AnswerText}");
            }
            Console.WriteLine($"Your Exam Grade is {GradeCounter} from {ExamGrade}");
        }
    }
}
