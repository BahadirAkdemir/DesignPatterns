using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager();
            cm.Save();
            Console.ReadLine();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logging");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICache
    {
        public void Cache()
        {
            Console.WriteLine("Caching");
        }
    }

    internal interface ICache
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Authorize");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        /* private ILogging _logging;
         private ICache _caching;
         private IAuthorize _authorize;*/

        private CrossCuttingConcernsFacade _crosscuttingconcernsfacade;
        public CustomerManager(/*ILogging logging, ICache caching, IAuthorize authorize*/)
        {
            _crosscuttingconcernsfacade = new CrossCuttingConcernsFacade();
            /*_logging = logging;
            _caching = caching;
            _authorize = authorize;*/
        }

        public void Save()
        {
            _crosscuttingconcernsfacade.logging.Log();
            _crosscuttingconcernsfacade.caching.Cache();
            _crosscuttingconcernsfacade.authorize.CheckUser();
            /*_logging.Log();
            _caching.Cache();
            _authorize.CheckUser();*/

            Console.WriteLine("SAVED");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging logging;
        public ICache caching;
        public IAuthorize authorize;

        public CrossCuttingConcernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
        }
    }
}
