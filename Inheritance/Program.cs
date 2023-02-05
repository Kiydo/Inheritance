using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance.entities;

namespace Inheritance
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string path = "employees.txt"; // getting the txt file

            string[] lines = File.ReadAllLines(path); // variable for the lines in txt?

            // Lists
            List<Employee> employees = new List<Employee>();
            List<Wages> wageList = new List<Wages>();
            List<PartTime> partList = new List<PartTime>();
            List<Salaried> salaryList = new List<Salaried>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(':'); // splits sections by the ":" character
        

                string id = parts[0]; // first section of array, its id

                string name = parts[1]; // name of the employees

                string firstDigit;

                firstDigit = id.Substring(0, 1); // gets the first digit of the id to determine if part time, full time, or salary

               
                int firstDigitNum = int.Parse(firstDigit); // make into real integer
                if (firstDigitNum >= 0 && firstDigitNum <= 4) 
                {
                    // Salary
                    double salary = double.Parse(parts[7]); // gets the value of the salary of the person

                    Salaried salaried;
                    salaried = new Salaried(id, name, salary); 

                    employees.Add(salaried);
                    salaryList.Add(salaried);
                }
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    // Part Time
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    Wages waged = new Wages(id, name, rate, hours);

                    employees.Add(waged);
                    wageList.Add(waged);


                }
                else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                {
                    // Wage
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    PartTime partTime = new PartTime(id, name, rate, hours);
                   
                    employees.Add(partTime);
                    partList.Add(partTime);


                }
            }
            // OUTPUT

            double averageWeeklyPay = CalcAverageWeeklyPay(employees); // calls method for calculations of average weekly pay 

            Console.WriteLine(string.Format("Average weekly pay: {0:C2}", averageWeeklyPay));

            Employee highestPaidWagedEmployee = FindHighestPaid(employees); // calls method for highest paid for waged employees

            double highestWagedPay = highestPaidWagedEmployee.Pay;

            Console.WriteLine("Highest waged pay: " + highestWagedPay.ToString("C2"));
            Console.WriteLine("Highest waged employee: " + highestPaidWagedEmployee.Name);

            Employee lowestSalariedEmployee = FindLowestPaid(salaryList); // calls method for finding lowest paid of salary employees

            double lowestSalariedPay = lowestSalariedEmployee.Pay;

            Console.WriteLine("Lowest salaried pay: " + lowestSalariedPay.ToString("C2"));
            Console.WriteLine("Lowest salaried pay: " + lowestSalariedEmployee.Name);

            string percentString = FindPayPercentage(employees, wageList, salaryList, partList); // calls method for finding percentage of employees in each category (wage, salary, partime)
            Console.WriteLine(percentString);

        }
            

        private static double CalcAverageWeeklyPay(List<Employee> employees) // Average weekly pay Calculations
        {
            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                if (employee is PartTime partTime)
                {
                    double pay = partTime.Pay;
                    weeklyPaySum += pay;
                }
                else if (employee is Wages waged)
                {
                    double pay = waged.Pay;
                    weeklyPaySum += pay;
                }
                else if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;
                    weeklyPaySum += pay;
                }
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;
            return averageWeeklyPay;
        }

        private static Wages FindHighestPaid(List<Employee> employees) // Find Highest Paid employee for waged workers
        {
            double highestWagedPay = 0;
            Wages highestWagedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages waged)
                {
                    double pay = waged.Pay;

                    if (pay > highestWagedPay)
                    {
                        highestWagedPay = pay;
                        highestWagedEmployee = waged;
                    }
                }
            }
            return highestWagedEmployee;
        }

        public static Salaried FindLowestPaid(List<Salaried> salaryList) // Find Lowest Paidd employee for salary workers
        {
            double lowestSalariedPay = double.MaxValue;

            Salaried lowestSalariedEmployee = null;

            foreach (Salaried salary in salaryList)
            {
                if (salary is Salaried sal)
                {
                    double pay = sal.Pay;

                    if (pay < lowestSalariedPay)
                    {
                        lowestSalariedPay = pay;
                        lowestSalariedEmployee = sal;
                    }
                }
               
            }
            return lowestSalariedEmployee;

        }

        public static string FindPayPercentage(List<Employee> employees, List<Wages> wageList, List<Salaried> salaryList, List<PartTime> partList) // Finds Percentage of workers for each category
        {
            double wageCount = wageList.Count;
            double salaryCount = salaryList.Count;
            double partCount = partList.Count;
            double employeeCount = employees.Count;

            double wagePercent = (wageCount / employeeCount);
            double salaryPercent = (salaryCount / employeeCount);
            double partPercent = (partCount / employeeCount);
            string percentString = "The percentage of Waged employees is " + wagePercent.ToString("P2")+"\nThe percentage of Salaried employees is " + salaryPercent.ToString("P2") + "\nThe percentage of Part Time employees is " + partPercent.ToString("P2");

            return percentString;
            
        }
           
    }
}
