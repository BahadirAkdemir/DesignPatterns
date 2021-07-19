using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Author = "Zeynep GÜLTEKİN", Title = "Acımamak", ISBN = "123456789" };
            Thread.Sleep(1000);
            book.ShowBook();


            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();
            Thread.Sleep(1000);

            book.Title = "Acımak";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _ISBN;
        private DateTime _lastEditedDate; 
        public string Title
        {
            get { return _title; }
            set 
            {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return _author; }
            set 
            {
                _author = value;
                SetLastEdited();
            }
        }
        public string ISBN
        {
            get { return _ISBN; }
            set 
            { _ISBN = value;
              SetLastEdited();
            }
        }
        private void SetLastEdited()
        {
            _lastEditedDate = DateTime.UtcNow.AddHours(3);
        }

        public Memento CreateUndo()
        {
            return new Memento(_title, _author, _ISBN, _lastEditedDate);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _ISBN = memento.ISBN;
            _lastEditedDate = memento.LastEditedDate;
            _author = memento.Author;

        }

        public void ShowBook()
        {
            Console.WriteLine(" {0}  {1}  {2}  {3}", ISBN, Title, Author, _lastEditedDate);
        }
    }

    class Memento
    {
        public string Title;
        public string Author;
        public string ISBN;
        public DateTime LastEditedDate;

        public Memento(string title, string author, string ISBN, DateTime lastEditedDate)
        {
            Title = title;
            Author = author;
            this.ISBN = ISBN;
            LastEditedDate = lastEditedDate;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
