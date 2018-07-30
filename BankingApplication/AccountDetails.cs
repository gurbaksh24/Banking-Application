using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess;
namespace BankingApplication
{
    class AccountDetails
    {
        static IDatabase databaseAccess;
        static int dbType;
        public AccountDetails()
        { 
            string value = System.Configuration.ConfigurationManager.AppSettings["DbType"].ToString();
            if (value.Equals("ADO"))
            {
                databaseAccess = new DatabaseOperations();
                dbType = 1;
            }
            else if (value.Equals("Entity"))
            {
                databaseAccess = new EntityDatabaseOperations();
                dbType = 2;
            }

        }
        public void AddAccount(int customerId,string customerName,string accountType)
        {
            int responsedData = databaseAccess.InsertUser(customerId,customerName,accountType);
            if(responsedData>0)
                Console.WriteLine("Account Details Inserted Successfully");
            else
                Console.WriteLine("Something went wrong");
        }
        public void DisplayAccount()
        {
            int responsedData = databaseAccess.DisplayDetails();
            if(responsedData==-1)
                Console.WriteLine("No Data Found");
        }
        public void SearchById(int customerId)
        {
            int responsedData = databaseAccess.SearchDetails(customerId);
            if(responsedData==-1)
                Console.WriteLine("No Data Found");
        }
        public void Deposit(int customerId,int amount)
        {
            int responsedData = databaseAccess.UpdateBalance(customerId, amount);
            if (responsedData == -1)
                Console.WriteLine("Not Data Found");
            else
                Console.WriteLine("Amount Deposit");
        }
        public void Withdraw(int customerId,int amount)
        {
            if (dbType == 1)
            {
                int responsedData = databaseAccess.WithdrawBalance(customerId, amount);
                int accountType = databaseAccess.AccountType(customerId);
                if (responsedData == -1)
                    Console.WriteLine("Not Able to Withdraw");
                else
                {
                    if (responsedData < 1000 && accountType == 1)
                    {
                        databaseAccess.UpdateBalance(customerId, amount);
                        Console.WriteLine("You can not withdraw because balance is less than or equal to 1000");
                    }
                    else if (responsedData < 0 && accountType == 2)
                    {
                        databaseAccess.UpdateBalance(customerId, amount);
                        Console.WriteLine("You can not withdraw because balance is less than or equal to 0");
                    }
                    else if (responsedData < -10000 && accountType == 3)
                    {
                        databaseAccess.UpdateBalance(customerId, amount);
                        Console.WriteLine("You can not withdraw because balance is less than or equal to -10000");
                    }

                    else
                        Console.WriteLine("Amount Withdrawn:" + amount);
                }
            }
            else if (dbType == 2)
            {
                int responsedData = databaseAccess.WithdrawBalance(customerId, amount);
                if (responsedData == -1)
                    Console.WriteLine("Insufficient Balance");
            }
        }
        public int GetTotalAmount(int customerId)
        {
            int responsedData = databaseAccess.TotalAmount(customerId);
            if (responsedData == -1)
                return -1;
            else
                return responsedData;
            
        }
        
        
        public float Interest(int customerId)
        {
            if (dbType == 1)
            {
                int totalAmount = GetTotalAmount(customerId);
                int accountType = databaseAccess.AccountType(customerId);
                if (accountType == 1)
                {
                    return (totalAmount * 4 / 100);
                }
                else if (accountType == 2)
                {
                    return (totalAmount * 1 / 100);
                }
                else
                {
                    return -1;
                }
            }
            else if (dbType == 2)
            {
                int responsedData = databaseAccess.Interest(customerId);
                if (responsedData == -1)
                    Console.WriteLine("Invalid Account Type for Interest");
                return 1f;
            }
            else
                return -1;
        }
        
        public int GetAccountType(int customerId)
        {
            int responsedData = databaseAccess.AccountType(customerId);
            if (responsedData == -1)
                return -1;
            else
                return responsedData;

        }
        
    }
}
