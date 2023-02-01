using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    public class BankCard
    {
        public BankCard(string bankname, string fullname, string pAN16, string pIN, string cVC, string dt, double balance)
        {
            Bankname=bankname;
            Fullname=fullname;
            PAN16=pAN16;
            PIN=pIN;
            CVC=cVC;
            this.dt=dt;
            Balance=balance;
        }

        public string Bankname { get; set; }
        public string Fullname { get; set; }

        public string PAN16 { get; set; }
        public string PIN{get; set;}

        public string CVC { get; set;}

        public string dt { get; set; }

        public double Balance { get; set; }



    }
}
