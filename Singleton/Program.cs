using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateSingleton();
        }
    }
    class CustomerManager
    {
        static object _lockObject = new object();
        private static CustomerManager _customerManager;

        private CustomerManager()
        {

        }

        public static CustomerManager CreateSingleton()
        {

            lock (_lockObject)
            {
                if (_customerManager==null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;

        }
        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
