using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observe
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver:Observer 
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer: The price changed");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employe: ");
        }
    }
}
