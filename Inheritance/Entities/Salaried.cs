using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.entities
{
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
        }

        public override double Pay 
        {
            get
            {
                return salary;
            }
        }

        public Salaried(string id, string name, double salary) 
        {
            this.id = id;
            this.name = name;
            this.salary = salary;

        }
    }
}
