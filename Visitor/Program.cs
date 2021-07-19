using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager bahadir = new Manager { Name = "Bahadır", Salary = 12500 };

            Manager kerem = new Manager { Name = "Kerem", Salary = 12501 };

            Worker zeynep = new Worker { Name = "Zeynep", Salary = 7500 };

            Worker berna = new Worker { Name = "Berna", Salary = 6531 };

            bahadir.Subordinates.Add(kerem);
            kerem.Subordinates.Add(berna);
            bahadir.Subordinates.Add(zeynep);
            bahadir.Subordinates.Add(berna);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(bahadir);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisior payriseVisitor = new PayriseVisior();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);

            Console.ReadLine();

        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Emmployee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Emmployee = firstEmployee;
        }

        public void Accept(VisitorBase visitorBase)
        {
            Emmployee.Accept(visitorBase);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitorBase);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
        }
    }

    class Manager : EmployeeBase
    {
        public List<EmployeeBase> Subordinates { get; set; }

        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);

            foreach (var subordinate in Subordinates)
            {
                subordinate.Accept(visitorBase);
            }
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);


    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine(worker.Salary + " paid to worker "+worker.Name);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine(manager.Salary + " paid to manager" + manager.Name);
        }
    }
    class PayriseVisior : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine(worker.Salary*2 + " salary increased to worker " + worker.Name);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine(manager.Salary*5 + " salary increased to manager " + manager.Name);
        }
    }

    
}
