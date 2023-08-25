using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Examination_System
{
    internal class Subject
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public FinalExam FExam { get; set; }
        public PracticalExam PExam { get; set; }
        public Subject(int id,string name)
        {
            Id = id;
            Name = name;
        }
        public void CreateExam()
        {
            int ExamType;
            int ExamTime;
            int NumberOfQuestions;
            do
            {
            Console.Write("Please Enter The Type Of The Exam You Want To Create ( 1 for practical ,2 fot final ) :");
            } while (!(int.TryParse(Console.ReadLine(),out ExamType))||!(ExamType==1|| ExamType == 2));
            do
            {
                Console.Write("Please Enter The Time Of The Exam In Minutes : ");
            } while (!int.TryParse(Console.ReadLine(), out ExamTime)); 
            do
            {
                Console.Write("Please Enter The Number Of Questions You Want To Create : ");
            } while (!int.TryParse(Console.ReadLine(), out NumberOfQuestions));
            Console.Clear();
            if (ExamType==1)
            {
                PExam = new PracticalExam(ExamTime, NumberOfQuestions);
                for (int i=0;i<NumberOfQuestions;i++)
                {
                    int Mark;
                    int RAnswer;
                    Answers[] Answers = new Answers[3];
                    Console.WriteLine("MCQuestion");
                    Console.WriteLine("Please Enter the Body Of The Question");
                    string body = Console.ReadLine();
                    Console.WriteLine("The Choices Of Question");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"Please Enter The Choice Number {j + 1} : ");
                        string Ans = Console.ReadLine();
                        Answers Choice = new Answers(j + 1, Ans);
                        Answers[j] = Choice;
                    }
                    do
                    {
                        Console.Write("Please Specify The Right Choice for Question : ");
                    } while (!int.TryParse(Console.ReadLine(), out RAnswer));
                    do
                    {
                        Console.WriteLine("Please Enter The Mark Of The Quesiton :");
                    } while (!int.TryParse(Console.ReadLine(), out Mark));
                    Answers RightAnswer = Answers[RAnswer - 1];
                    MCQuestion mCQuestion = new MCQuestion("MCQ Question", body, Mark, RightAnswer.AnswerId, RightAnswer.AnswerText);
                    mCQuestion.AnswersList = Answers;
                    PExam.MCQuestions[i] = mCQuestion;
                    //intialize MCQuestion obj
                    Console.Clear();
                }
            }
            else if (ExamType==2)
            {
                FExam = new FinalExam(ExamTime,NumberOfQuestions);
                int QuestionType;
                for (int i = 1; i <= NumberOfQuestions; i++)
                {
                      do
                      {
                              Console.Write($"Please Choose The Type Of Question Number({i})  (1 for true or false || 2 for MCQ) :");
                      } while (!int.TryParse(Console.ReadLine(),out QuestionType)|| !(QuestionType == 1 || QuestionType == 2));
                      Console.Clear();
                      if (QuestionType==1)
                      {
                        int Mark;
                        int RightAnswer; 
                        Console.WriteLine("True Or False Question");
                        Console.WriteLine("Please Enter The Body Of The Question : ");
                        string body=Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Please Enter The Mark Of The Quesiton :");
                        } while (!int.TryParse(Console.ReadLine(),out Mark));
                        do
                        {
                            Console.WriteLine("Please Enter The Right Answer Of The Quesiton (1 for True 2 for false ):");
                        } while (!int.TryParse(Console.ReadLine(), out RightAnswer)|| !(RightAnswer == 1 || RightAnswer == 2));
                        //create TOFQuestion object here
                        if (RightAnswer==1)
                        {
                            TOFQuestion tOF = new TOFQuestion("True Or False Question", body, Mark, 1, "True");
                            tOF.AnswersList[0] = new Answers(1, "True");
                            tOF.AnswersList[1] = new Answers(2, "False");
                            FExam.TOFQuestions[i-1]=tOF;
                        }
                        else if (RightAnswer==2)
                        {
                            TOFQuestion tOF = new TOFQuestion("True Or False Question", body, Mark, 2, "False");
                            tOF.AnswersList[0] = new Answers(1, "True");
                            tOF.AnswersList[1] = new Answers(2, "False");
                            FExam.TOFQuestions[i-1] = tOF;
                        }
                        Console.Clear();
                      }
                    else if (QuestionType == 2)
                      {
                        int Mark;
                        int RAnswer;
                        Answers[] Answers =new Answers[3];
                        Console.WriteLine("MCQuestion");
                        Console.WriteLine("Please Enter the Body Of The Question");
                        string body=Console.ReadLine();
                        Console.WriteLine("The Choices Of Question");
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write($"Please Enter The Choice Number {j+1} : ");
                            string Ans = Console.ReadLine();
                            Answers Choice = new Answers(j + 1, Ans);
                            Answers[j] = Choice;
                        }
                        do
                        {
                            Console.Write("Please Specify The Right Choice for Question : ");
                        } while (!int.TryParse(Console.ReadLine(), out RAnswer));
                        do
                        {
                            Console.WriteLine("Please Enter The Mark Of The Quesiton :");
                        } while (!int.TryParse(Console.ReadLine(), out Mark));
                        Answers RightAnswer =Answers[RAnswer - 1];
                        MCQuestion mCQuestion = new MCQuestion("MCQ Question",body,Mark,RightAnswer.AnswerId,RightAnswer.AnswerText);
                        mCQuestion.AnswersList=Answers;
                        FExam.MCQuestions[i - 1] = mCQuestion;
                        //intialize MCQuestion obj
                        Console.Clear();
                      }
                }
            }
        }
        
        
    }
}
