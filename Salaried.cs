using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary { get { return salary; } }

        public Salaried(string id, string name, string address, double salary, string phone, string birthdate, string jobname, long SIN)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.salary = salary;
            this.phone = phone;
            this.birthdate = birthdate;
            this.jobname = jobname;
            this.SIN = SIN;
        }

        // use this if the fields in employee class are private and not protected and there is no no-args constructor in the employee class
        /*public Salaried(string id, string name, string address, double salary) : base(id, name, address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.salary = salary;
        }*/

        public override double CalcWeeklyPay()
        {
            return this.salary;
        }
    }
}
