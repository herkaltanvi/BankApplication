using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class FixedDeposit : Account
    {
        static DateTime dateTime;
        int duration = 3;
        double min_opening_balance = 1000;
        
        public override int OpenAccount(string name, double amount)
        {
            if (amount > 0)
            {
                dateTime = DateTime.Now.AddYears(duration);
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
                DateTime current_date = DateTime.Now;
                int val = DateTime.Compare(current_date, dateTime);
                if (val > 0)
                {
                    if (amount <= min_opening_balance)
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
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
