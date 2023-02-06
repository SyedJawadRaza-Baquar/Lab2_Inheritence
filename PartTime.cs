using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public double Rate { get { return rate; } }
        public double Hours { get { return hours; } }

        public PartTime(string id, string name, string address, double rate, double hours, string phone, string birthdate, string jobname, long SIN)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hours = hours;
            this.phone = phone;
            this.birthdate = birthdate;
            this.jobname = jobname;
            this.SIN = SIN;
        }

            public override double CalcWeeklyPay()
            {
                double weeklyPay = 0;
                weeklyPay = this.rate * this.hours;
                return weeklyPay;
            }
    }
}
