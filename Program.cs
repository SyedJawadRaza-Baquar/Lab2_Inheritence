using Lab2_Inheritance.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] cells = line.Split(':');

                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                string phone = cells[3];
                string sin = cells[4];
                string birthdate = cells[5];
                string jobname = cells[6];

                long SIN = long.Parse(cells[4]);

                string firstDigit = id.Substring(0, 1);

                int firstDigitInt = int.Parse(firstDigit);

                if (firstDigitInt >= 0 && firstDigitInt <=4) 
                {
                    //Salaried
                    string salary = cells[7];

                    double salaryDouble = double.Parse(salary);

                    Salaried salaried = new Salaried(id, name, address, salaryDouble, phone, birthdate, jobname, SIN);
                    employees.Add(salaried);
                }
                else if (firstDigitInt >=5 && firstDigitInt <=7) 
                {
                    //Wage
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Waged waged = new Waged(id, name, address, rateDouble, hoursDouble, phone, birthdate, jobname, SIN);
                    employees.Add(waged);
                }
                else if (firstDigitInt >=8 && firstDigitInt <=9) 
                {
                    //Part time
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    PartTime partTime = new PartTime(id, name, address, rateDouble, hoursDouble, phone, birthdate, jobname, SIN);
                    employees.Add(partTime);
                }
            }

            /*if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")
                {

                }*/

            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                double weeklyPay = employee.CalcWeeklyPay();

                weeklyPaySum += weeklyPay;
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;

            Console.WriteLine("Average weekly pay: " + averageWeeklyPay);

            Waged highestPaidWaged = null;

            foreach (Employee employee in employees)
            {
                if (employee is Waged)
                {
                    Waged waged = (Waged)employee;

                    if (highestPaidWaged == null || waged.CalcWeeklyPay() > highestPaidWaged.CalcWeeklyPay())
                    {
                        highestPaidWaged = waged;
                    }
                }
            }

            Console.WriteLine("Employee " + highestPaidWaged.Name + " is highest paid ($" + highestPaidWaged.CalcWeeklyPay() + ")");

            Salaried lowestPaidSalaried = null;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    Salaried salaried = (Salaried)employee;

                    if (lowestPaidSalaried == null || salaried.CalcWeeklyPay() < lowestPaidSalaried.CalcWeeklyPay())
                    {
                        lowestPaidSalaried = salaried;
                    }
                }
            }

            Console.WriteLine("Employee " + lowestPaidSalaried.Name + " is lowest paid ($" + lowestPaidSalaried.CalcWeeklyPay() + ")");

            int totalEmployees = 0;
            int salariedEmployees = 0;
            int wagedEmployees = 0;
            int partTimeEmployees = 0;

            foreach (Employee employee in employees)
            {
                totalEmployees++;
                if (employee is Salaried)
                {
                    salariedEmployees++;
                }
                else if (employee is Waged)
                {
                    wagedEmployees++;
                }
                else if (employee is PartTime)
                {
                    partTimeEmployees++;
                }
            }

            double salariedEmployeesPercentage = (double)salariedEmployees / totalEmployees * 100;
            double wagedEmployeesPercentage = (double)wagedEmployees / totalEmployees * 100;
            double partTimeEmployeesPercentage = (double)partTimeEmployees / totalEmployees * 100;

            Console.WriteLine("Salaried Percentage : " + salariedEmployeesPercentage + "%");
            Console.WriteLine("Waged Percentage : " + wagedEmployeesPercentage + "%");
            Console.WriteLine("PartTime Percentage : " + partTimeEmployeesPercentage + "%");
        }
    }
}
