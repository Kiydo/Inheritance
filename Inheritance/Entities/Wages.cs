using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.entities
{
  
    internal class Wages : Employee
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
                double pay;
                double rate = this.Rate;
                double hours = this.Hours;

                if(hours > 40)
                {
                    double overtimeHours = hours - 40;
                    double overtimePay = overtimeHours * (rate * 1.5);

                    pay = rate * 40;
                    pay += overtimePay;
                }
                else
                {
                    pay = rate * hours;
                }

                return pay;
            }
        }

        public Wages(string id, string name, double rate, double hours)
        {
            this.id = id; 
            this.name = name;
            this.rate = rate;
            this.hours = hours;

        }

    }
}
