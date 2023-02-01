using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    public class Bank
    {
      public List<Client> client = new();
     

        public void showCardBalance(BankCard bankCard)
        {
            Console.WriteLine( bankCard.Balance );
        }
    }
}
