using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class EntityDatabaseOperations:IDatabase
    {
        static BankEntities bankEntities = new BankEntities();

        static Account account = new Account();
        public SqlConnection Connect()
        {
            throw new NotImplementedException();
        }

        public int DisplayDetails()
        {
            var accounts = bankEntities.Accounts.ToList();

            if (accounts != null)
            {
                Console.WriteLine("Customer ID \t Customer Name \t Account Type \t Balance");
                foreach (var accountData in accounts)
                {
                    Console.Write(accountData.CustomerID + "\t\t");
                    Console.Write(accountData.CustomerName + "\t\t");
                    Console.Write(accountData.AccountType + "\t\t");
                    Console.WriteLine(accountData.Balance);
                }
            }
            else
                return -1;
            return 1;
        }

        public int InsertUser(int customerId, string customerName, string accountType)
        {
            
            account.CustomerID = customerId;
            account.CustomerName = customerName;
            account.AccountType = accountType;
            account.Balance = 0;
            bankEntities.Accounts.Add(account);
            bankEntities.SaveChanges();
            return 1;
        }

        public int SearchDetails(int customerId)
        {
            var search = bankEntities.Accounts.Find(customerId);

            if (search != null)
            {
                Console.WriteLine("Customer ID: " + search.CustomerID);
                Console.WriteLine("Customer Name: " + search.CustomerName);
                Console.WriteLine("Account Type: " + search.AccountType);
                Console.WriteLine("Balance: " + search.Balance);
                return 1;
            }
            else
                return -1;
        }

        public int UpdateBalance(int customerId, int amount)
        {
            var search = bankEntities.Accounts.Find(customerId);
            if (search != null)
            {
                search.Balance = search.Balance + amount;
                bankEntities.SaveChanges();
                return 1;
            }
            else
                return -1;
        }

        public int WithdrawBalance(int customerId, int amount)
        {
            var search = bankEntities.Accounts.Find(customerId);
            if(search!=null)
            {
                if (search.AccountType.Equals("Savings") && search.Balance < 1000)
                    return -1;
                else if (search.AccountType.Equals("Current") && search.Balance < 0)
                    return -1;
                else if (search.AccountType.Equals("DMAT") && search.Balance < -10000)
                    return -1;
                else
                {
                    search.Balance = search.Balance - amount;
                    bankEntities.SaveChanges();
                }
            }
            return 1;
        }
        
        public int Interest(int customerId)
        {
            var search = bankEntities.Accounts.Find(customerId);
            if(search!=null)
            {
                if (search.AccountType.Equals("Savings"))
                    Console.WriteLine("Interest : " + (search.Balance * 4 / 100));
                else if (search.AccountType.Equals("Current"))
                    Console.WriteLine("Interest : " + (search.Balance * 1 / 100));
                else
                {
                    return -1;
                }
            }
            return 1;
        }

        public int AccountType(int customerId)
        {
            throw new NotImplementedException();
        }

        public int TotalAmount(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
