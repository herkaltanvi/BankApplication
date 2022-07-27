using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class Current : Account
    {
        double min_opening_bal = 5000, overdraft_amount = 5000;
        public override int OpenAccount(string name, double amount)
        {
            if (amount >= min_opening_bal)
            {
                acc_no_generater++;
                account_number = acc_no_generater;
                account_holder_name = name;
                balance = amount;
                return account_number;
            }

            else
            {
                return 0;
            }
        }

        public override bool WithdrawAmount(double amount, int acc_number, MyDelegate del)
        {
            if (acc_number >= 0)
            {
                if (balance + overdraft_amount >= amount)
                {
                    balance -= amount;
                    del(balance);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }
    }
}
