using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DatabaseAccess
{
    interface IDatabase
    {
        SqlConnection Connect();
        int InsertUser(int customerId, string customerName, string accountType);
        int DisplayDetails();
        int SearchDetails(int customerId);
        int UpdateBalance(int customerId,int amount);
        int WithdrawBalance(int customerId, int amount);
    }
}
