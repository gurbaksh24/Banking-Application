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
            Console.WriteLine("1. Display Account Details");
            Console.WriteLine("2. Search by Account ID");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Calculate Interest");
            int ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                    Console.WriteLine("Account Id:" + accountDetails.GetAccountId());
                    Console.WriteLine("Account Holder Name:" + accountDetails.GetAccountId());
                    Console.WriteLine("Account Type:" + accountDetails.GetAccountId());
                    Console.WriteLine("Total Deposit:" + accountDetails.GetAccountId());
                    break;
                case 2:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    if(accountId==accountDetails.GetAccountId())
                    {
                        Console.WriteLine("Account Holder Name:" + accountDetails.GetAccountHolderName());
                        Console.WriteLine("Account Type:" + accountDetails.GetAccountType());
                        Console.WriteLine("Account Deposit:" + accountDetails.GetTotalAmount());
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Account Holder Name");
                    accountHolderName = Console.ReadLine();
                    Console.WriteLine("Enter Account Type");
                    accountType = Console.ReadLine();
                    Console.WriteLine("Enter Deposit");
                    depositAmount = int.Parse(Console.ReadLine());
                    accountDetails.SetAccountId(accountId);
                    accountDetails.SetAccountHolderName(accountHolderName);
                    accountDetails.SetAccountType(accountType);
                    accountDetails.SetDepositAmount(depositAmount);
                    break;
                case 4:
                    Console.WriteLine("Enter Account Id");
                    accountId = int.Parse(Console.ReadLine());
                    if(accountId==accountDetails.GetAccountId())
                    {
                        if (accountDetails.GetAccountType().Equals("Savings") && accountDetails.GetTotalAmount() < 1000)
                        {
                            Console.WriteLine("Low Account Balance");
                            Console.WriteLine("Balance Must Be Greater Than 1000");
                            Console.WriteLine("Balance:"+accountDetails.GetTotalAmount());
                            Console.WriteLine("You Can Not Withdraw");
                        }
                        else if (accountDetails.GetAccountType().Equals("Current") && accountDetails.GetTotalAmount() < 0)
                        {
                            Console.WriteLine("Low Account Balance");
                            Console.WriteLine("Balance Must Be Greater Than 0");
                            Console.WriteLine("Balance:" + accountDetails.GetTotalAmount());
                            Console.WriteLine("You Can Not Withdraw");
                        }
                        else if (accountDetails.GetAccountType().Equals("DMAT") && accountDetails.GetTotalAmount() < -10000)
                        {
                            Console.WriteLine("Low Account Balance");
                            Console.WriteLine("Balance Must Be Greater Than -10000");
                            Console.WriteLine("Balance:" + accountDetails.GetTotalAmount());
                            Console.WriteLine("You Can Not Withdraw");
                        }
                        else
                        {
                            Console.WriteLine("Enter Amount To Be Withdrawn");
                            depositAmount = int.Parse(Console.ReadLine());
                            accountDetails.SetTotalAmount(accountDetails.GetTotalAmount() - depositAmount);

                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
