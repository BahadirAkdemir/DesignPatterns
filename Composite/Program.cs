using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Employee bahadir = new Employee();
            bahadir.Name = "Bahadır";

            Employee zeynep = new Employee();
            zeynep.Name = "Zeynep";

            zeynep.AddSubordinate(bahadir);

            Employee kerem = new Employee();
            kerem.Name = "Kerem";
            zeynep.AddSubordinate(kerem);

            Employee yusuf = new Employee();
            yusuf.Name = "Yusuf";
            bahadir.AddSubordinate(yusuf);

            Contractor orkun = new Contractor { Name = "Orkun" };
            kerem.AddSubordinate(orkun);

            Console.WriteLine(zeynep.Name);
            foreach (Employee manager in zeynep)
            {
                Console.WriteLine("    "+manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("        " + employee.Name);
                }

            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
