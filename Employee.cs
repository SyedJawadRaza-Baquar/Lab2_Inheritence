using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Inheritance.Entities
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;
        protected string phone;
        protected string birthdate;
        protected string jobname;
        protected long SIN;

        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Address { get { return address; } }
        public string Phone { get { return phone; } }
        public string Birthdate { get { return birthdate; } }
        public string Jobname { get { return jobname; } }
        public long Sin { get { return SIN; } }

        public Employee() { }

        public Employee(string id, string name, string address, string phone, string birthdate, string jobname, long SIN)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.birthdate = birthdate;
            this.jobname = jobname;
            this.SIN = SIN;
        }

        public virtual double CalcWeeklyPay()
        {
            return 0;
        }
    }
}
