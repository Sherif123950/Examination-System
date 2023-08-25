using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject Sub1 = new Subject(10, "C#");
            Sub1.CreateExam();
            Console.Clear();
            Console.Write("Do You Want To Start The Exam? (y|n) : ");
            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                if (Sub1.PExam is null)
                    Sub1.FExam.ShowExam();
                else
                    Sub1.PExam.ShowExam();
                Console.WriteLine($"The Elapsed Time : {sw.Elapsed}");

            }
            //Console.WriteLine("Hello, World!");
        }
    }
}