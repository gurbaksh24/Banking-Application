using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    enum AccountType
    {
        Savings=1,
        Current=2,
        Demat=3
    }
    class Program
    {
        static AccountDetails accountDetails = new AccountDetails();
        static void Main(string[] args)
        {
            int accountId, depositAmount;
            string accountHolderName, accountType;
            Console.WriteLine("----------------Banking System----------------");
            Console.WriteLine("1. Add Account Details");
            Console.WriteLine("2. Display Account Details");
            Console.WriteLine("3. Search by Account ID");
            Console.WriteLine("4. Deposit");
            Console.WriteLine("5. Withdraw");
            Console.WriteLine("6. Calculate Interest");
            int ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Account Holder Name");
                    accountHolderName = Console.ReadLine();
                    Console.WriteLine("Enter Account Type");
                    accountType = Console.ReadLine();
                    accountDetails.AddAccount(accountId,accountHolderName,accountType);
                    break;
                case 2:
                    accountDetails.DisplayAccount();
                    break;
                case 3:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    accountDetails.SearchById(accountId);
                    break;
                case 4:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Deposit");
                    depositAmount = int.Parse(Console.ReadLine());
                    accountDetails.Deposit(accountId, depositAmount);
                    break;
                case 5:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Amount to be withdrawn");
                    depositAmount = int.Parse(Console.ReadLine());
                    accountDetails.Withdraw(accountId, depositAmount);
                    break;
                case 6:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    float interest=accountDetails.Interest(accountId);
                    if(interest==-1)
                        Console.WriteLine("Not a valid account type for interest");
                    else
                        Console.WriteLine("Interest:"+interest);
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
