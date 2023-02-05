using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.entities
{
    internal class Employee
    {
        protected string id; // id is string because one id starts with 0 and when number starts with 0 it removes it for some reason
        protected string name;
        protected string address;
        protected string phone;
        protected long sin;
        protected string birthdate;
        protected string department;

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public virtual double Pay
        {
            get
            {
                return 0;
            }
        }

        public Employee() // for the other classes
        {

        }

    }
}
