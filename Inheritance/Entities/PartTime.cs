using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public double Rate
        {
            get { return rate; }
        }

        public double Hours
        {
            get { return hours; }
        }

        public override double Pay
        {
            get
            {
                double rate = this.Rate;
                double hours = this.Hours;

                double pay = rate * hours;
                return pay;
            }
        }

        public PartTime(string id, string name, double rate, double hours) 
        {
            this.id = id; 
            this.name = name;
            this.rate = rate;
            this.hours = hours;

        }
    }
}
