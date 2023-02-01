using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    public class Client
    {
        ////id, name, surname, age, salary, BankCard bankAccount

        private int ID = 0;

        public int id;

        public Client(string name, string surname, int age, double salary, BankCard bankAccount)
        {
            id = ++ID;
            this.name=name;
            this.surname=surname;
            this.age=age;
            this.salary=salary;
            this.bankAccount=bankAccount;
        }

        public string name { get; set; }
        
        public string surname { get; set; }

        public int age { get; set; }
        public  double  salary { get; set; }
        public BankCard bankAccount { get; set; }
    }
}
