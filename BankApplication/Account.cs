using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public abstract class Account  
    {
        protected int account_number;
        protected string account_holder_name;
        protected double balance;
        protected static int acc_no_generater = 0;

        public delegate void MyDelegate(double amt);

        public abstract int OpenAccount(string name, double amount);

        public abstract bool WithdrawAmount(double amount, int account_number, MyDelegate del);

        public virtual bool Deposit(double amount, int acc_number, MyDelegate del)
        {
            if (amount > 0) { 
                balance += amount;
                del(balance);
                return true;
            }
            else
            {
                return false;            
            }
        }
        public string CloseAccount(int account_number)
        {
            return "Your Account has been Closed!";
        }
        public double CHECKBALANCE {
            get
            {
                return balance;
            } 
        }

        public int ACCOUNTNUMBER {
            get
            {
                return account_number;
            }
        }
    }
}
