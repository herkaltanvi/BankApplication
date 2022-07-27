using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication;

namespace BankApplicationDashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0, array_counter = 0, array_index;
            Console.WriteLine("BANK APPLICATION");
            ArrayList accounts = new ArrayList();
            Account acc = null;
            Account.MyDelegate del = new Account.MyDelegate(NotifyFunc); 
            
            while(option!=6)
            {
                Console.Write("1. Open Account\n2. Deposit Amount\n3. Withdraw Amount\n4. Check Balance\n5. Close Account\n6. Exit\nEnter your option : ");
                option = Convert.ToInt32(Console.ReadLine());
                int acc_number = 0;
                switch (option)
                {
                    case 1:
                        Console.Write("Select type of account\n1. Savings Account\n2. Current Account\n3. Fixed Deposit\nEnter the option : ");
                        int opening_option = Convert.ToInt32(Console.ReadLine());
                        double amount;
                        string name;
                        
                        switch (opening_option)
                        {
                            case 1:
                                acc = new Savings();
                                Console.WriteLine("To open your Savings Account enter the following details:");
                                break;
                            case 2:
                                acc = new Current();
                                Console.WriteLine("To open your Current Account enter the following details:");
                                break;
                            case 3:
                                acc= new FixedDeposit();
                                Console.WriteLine("To open your Fixed Desposit Account enter the following details:");
                                
                                break;
                        }
                        accounts.Add(acc);
                        Console.Write("Enter your Full Name : ");
                        name = Console.ReadLine();
                        Console.Write("Enter Amount : ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        int res = acc.OpenAccount(name, amount);
                        if (res > 0)
                        {
                            Console.WriteLine("Your Account is Successfully Opened with the Account No. {0}", res);
                        }
                        array_counter++;
                        break;

                    case 2:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the amount you want to deposit : ");
                        double deposit_amount = Convert.ToDouble(Console.ReadLine());
                        acc = GetAccountNo(acc_number, accounts);
                        if (acc != null) { 
                        bool res_deposit = acc.Deposit(deposit_amount, acc_number, del);
                        if (res_deposit)
                        {
                            Console.WriteLine("The amount of Rs. {0}/- is successfully deposited.", deposit_amount);
                            //Console.WriteLine("Your updated balance is Rs. {0}", accounts[array_index].CHECKBALANCE);
                        }
                        else
                        {
                            Console.WriteLine("Sorry! We were unable to deposit the amount of Rs. {0}/-. Please try again!", deposit_amount);
                        }
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }
                        break;

                    case 3:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the amount you want to withdraw : ");
                        double withdraw_amount = Convert.ToDouble(Console.ReadLine());
                        acc = GetAccountNo(acc_number, accounts);
                        if (acc != null)
                        {
                            bool res_withdraw = acc.WithdrawAmount(withdraw_amount, acc_number, del);
                            if (res_withdraw)
                            {
                                Console.WriteLine("The amount of Rs. {0}/- is successfully withdrawed.", withdraw_amount);
                                //Console.WriteLine("Your updated balance is Rs. {0}", accounts[array_index].CHECKBALANCE);
                            }
                            else
                            {
                                Console.WriteLine("Sorry! We were unable to withdraw the amount of Rs. {0}/-. Please try again!", withdraw_amount);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }
                        break;

                    case 4:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());
                        acc = GetAccountNo(acc_number, accounts);
                        if (acc != null)
                        {
                            Console.WriteLine("Your balance is Rs. {0}/-", acc.CHECKBALANCE);
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }
                        break;

                    case 5:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());
                        acc = GetAccountNo(acc_number, accounts);
                        if (acc != null)
                        {
                            accounts.Remove(acc);
                            Console.WriteLine("Your account has been closed. Thank for banking with us!");
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }
                        break;
                    
                    case 6:
                        break;
                }
                Console.WriteLine("--------------------------------------------");

            }
            
        }

        static int searchArrayIndex(int acc_number, Account[] accounts)
        {
            for (int i = 0; i < 10; i++)
            {
                Account temp = accounts[i];
                if (temp.ACCOUNTNUMBER == acc_number)
                {
                    return i;
                }
            }
            return -1;
        }
        static void NotifyFunc(double amt)
        {
            Console.WriteLine("Your updated balance is Rs. {0}", amt);
        }

        static Account GetAccountNo(int acc_no, ArrayList accounts)
        {
            IEnumerator e;
            e = accounts.GetEnumerator();
            while (e.MoveNext())
            {
                Account temp = (Account)e.Current;
                if (temp.ACCOUNTNUMBER == acc_no)
                {
                    return temp;
                }
            }
            return null;
        }


    }
}

/*namespace BankApplicationDashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0, array_counter = 0;
            Console.WriteLine("BANK APPLICATION");
            Account[] accounts = new Account[10];

            while (option != 6)
            {
                Console.Write("1. Open Account\n2. Deposit Amount\n3. Withdraw Amount\n4. Check Balance\n5. Close Account\n6. Exit\nEnter your option : ");
                option = Convert.ToInt32(Console.ReadLine());
                int acc_number = 0;
                switch (option)
                {
                    case 1:
                        Console.Write("Select type of account\n1. Savings Account\n2. Current Account\n3. Fixed Deposit\nEnter the option : ");
                        int opening_option = Convert.ToInt32(Console.ReadLine());
                        double amount;
                        string name;

                        switch (opening_option)
                        {
                            case 1:
                                accounts[array_counter] = new Savings();
                                Console.WriteLine("To open your Savings Account enter the following details:");
                                break;
                            case 2:
                                accounts[array_counter] = new Current();
                                Console.WriteLine("To open your Current Account enter the following details:");
                                break;
                            case 3:
                                accounts[array_counter] = new FixedDeposit();
                                Console.WriteLine("To open your Fixed Desposit Account enter the following details:");

                                break;
                        }
                        Console.Write("Enter your Full Name : ");
                        name = Console.ReadLine();
                        Console.Write("Enter Amount : ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        int res = accounts[array_counter].OpenAccount(name, amount);
                        if (res > 0)
                        {
                            Console.WriteLine("Your Account is Successfully Opened with the Account No. {0}", res);
                        }
                        array_counter++;
                        break;

                    case 2:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the amount you want to deposit : ");
                        double deposit_amount = Convert.ToDouble(Console.ReadLine());
                        bool res_deposit = accounts[acc_number - 1].Deposit(deposit_amount, acc_number);
                        if (res_deposit)
                        {
                            Console.WriteLine("The amount of Rs. {0}/- is successfully deposited.", deposit_amount);
                            Console.WriteLine("Your updated balance is Rs. {0}", accounts[acc_number - 1].CHECKBALANCE);
                        }
                        else
                        {
                            Console.WriteLine("Sorry! We were unable to deposit the amount of Rs. {0}/-. Please try again!", deposit_amount);
                        }
                        break;

                    case 3:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the amount you want to withdraw : ");
                        double withdraw_amount = Convert.ToDouble(Console.ReadLine());
                        bool res_withdraw = accounts[acc_number - 1].WithdrawAmount(withdraw_amount, acc_number);
                        if (res_withdraw)
                        {
                            Console.WriteLine("The amount of Rs. {0}/- is successfully withdrawed.", withdraw_amount);
                            Console.WriteLine("Your updated balance is Rs. {0}", accounts[acc_number - 1].CHECKBALANCE);
                        }
                        else
                        {
                            Console.WriteLine("Sorry! We were unable to withdraw the amount of Rs. {0}/-. Please try again!", withdraw_amount);
                        }
                        break;

                    case 4:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Your balance is Rs. {0}/-", accounts[acc_number - 1].CHECKBALANCE);
                        break;

                    case 5:
                        Console.Write("Enter the account number : ");
                        acc_number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Your account has been closed. Thank for banking with us!");
                        break;

                    case 6:
                        break;
                }
                Console.WriteLine("--------------------------------------------");
            }
        }
    }
}*/
