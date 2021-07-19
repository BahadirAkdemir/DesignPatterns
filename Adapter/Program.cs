using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new BALogger());

            productManager.Save();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("saved");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }

    class BALogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("{0} is Logged",message);
        }
    }

    //Cant touch because coming from Nuget(e.g.)
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("{0} is Logged log4net", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4net = new Log4Net();
            {
                log4net.LogMessage(message);
            }
        }
    }

}
