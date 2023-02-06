using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class Waged : Employee
    {
        private double rate;
        private double hours;

        public double Rate { get { return rate; } }
        public double Hours { get { return hours; } }

        public Waged(string id, string name, string address, double rate, double hours, string phone, string birthdate, string jobname, long SIN)
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
            if (this.hours < 40)
            {
                weeklyPay = this.hours * this.rate;
            }
            else
            {
                double overtimeHours = this.hours - 40;
                weeklyPay = 40 * this.rate;

                double overtimePay = overtimeHours * (this.rate * 1.5);

                weeklyPay += overtimePay;
            }
            return weeklyPay;
        }
    }
}
