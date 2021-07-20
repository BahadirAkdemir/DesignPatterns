using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(TestLogger.GetLogger());
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log();
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLog");
        }
    }

    class TestLogger : ILogger
    {
        private static TestLogger _testLogger;

        private static object _lock = new object();

        private TestLogger()
        {

        }

        public static TestLogger GetLogger()
        {
            lock (_lock)
            {
                if (_testLogger == null)
                {
                    _testLogger = new TestLogger();
                }
            }
            return _testLogger;
        }
        public void Log()
        {
           
        }
    }

    class CustomerManagerTest
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(TestLogger.GetLogger());
            customerManager.Save();
        }
    }
}
