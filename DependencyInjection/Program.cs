using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<NHProductDal>().InSingletonScope();
            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();

            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();

    }

    class EFProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save eith EF");
        }
    }

    class NHProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save eith NH");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal produdctDal)
        {
            _productDal = produdctDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }
}
