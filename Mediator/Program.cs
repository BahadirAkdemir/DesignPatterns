using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher zeynep = new Teacher(mediator);
            zeynep.Name = "Zeynep";
            mediator.Teacher = zeynep;

            mediator.Students = new List<Student>();
            Student bahadir = new Student(mediator);
            bahadir.Name = "Bahadır";
            mediator.Students.Add(bahadir);

            Student firdevs = new Student(mediator);
            firdevs.Name = "Şahane Firdevs";
            mediator.Students.Add(firdevs);

            Student gokcen = new Student(mediator);
            gokcen.Name = "Gökçen";
            mediator.Students.Add(gokcen);

            zeynep.SendNewImageUrl("slide1.png");

            Console.WriteLine("---------------");

            bahadir.Mediator.SendQuestion("How do you feel when operating a brain surgery?", bahadir);
            zeynep.Mediator.SendAnswer("It feels like to answer you, troublesome and tiresome.", bahadir,zeynep);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        public Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher " + Name + " changed slide");
            Mediator.UpdateImage(url);
        }

        internal void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher Recieved The Question \"{0}\"  to  Student {1}", question, student.Name);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher's answer {0}, to {1}", answer, student.Name);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; internal set; }

        internal void RecieveImage(string url)
        {
            Console.WriteLine(Name + " has recieved the image: " + url);
        }

        internal void ReceiveAnswer(string answer)
        {
            Console.WriteLine(Name + " received answer: " + answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer (string answer , Student student,Teacher teacher)
        {
            student.ReceiveAnswer(answer);
            teacher.AnswerQuestion(answer, student);
        }
    } 
}
