using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DatabaseAccess
{
    public class DatabaseOperations : IDatabase
    {
        public SqlConnection Connect()
        {
            SqlConnection sqlConnection=null;
            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=TAVDESK149;Initial Catalog=Bank;Integrated Security=True";
                sqlConnection.Open();
                return sqlConnection;
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                return sqlConnection;
            }
        }

        public int DisplayDetails()
        {
            SqlConnection sqlConnection = Connect();
            SqlCommand sqlCommand;
            try
            {
                string query = "Select * from Account";
                sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                Console.Write("Customer ID\t");
                Console.Write("Customer Name\t");
                Console.Write("Account Type\t");
                Console.WriteLine("Balance\t");
                while (dr.Read())
                {
                    Console.Write(dr.GetValue(0) + "\t\t");
                    Console.Write(dr.GetValue(1) + "\t\t");
                    Console.Write(dr.GetValue(2) + "\t\t");
                    Console.WriteLine(dr.GetValue(3));
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int InsertUser(int customerId,string customerName,string accountType)
        {
            SqlConnection sqlConnection = Connect();
            SqlCommand sqlCommand;
            try
            {
                string query = "Insert into Account(CustomerID,CustomerName,AccountType,Balance) values(@customerId,@customerName,@accountType,0)";
                sqlCommand = new SqlCommand(query,sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@customerId",customerId));
                sqlCommand.Parameters.Add(new SqlParameter("@customerName", customerName));
                sqlCommand.Parameters.Add(new SqlParameter("@accountType", accountType));
                sqlCommand.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int SearchDetails(int customerId)
        {
            SqlConnection sqlConnection = Connect();
            SqlCommand sqlCommand;
            try
            {
                string query = "Select * from Account where CustomerID=@customerId";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@customerId", customerId));
                SqlDataReader dr = sqlCommand.ExecuteReader();
                Console.Write("Customer ID\t");
                Console.Write("Customer Name\t");
                Console.Write("Account Type\t");
                Console.WriteLine("Balance\t");
                if (dr.Read())
                {
                    Console.Write(dr.GetValue(0) + "\t\t");
                    Console.Write(dr.GetValue(1) + "\t\t");
                    Console.Write(dr.GetValue(2) + "\t\t");
                    Console.WriteLine(dr.GetValue(3));
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int UpdateBalance(int customerId,int amount)
        {
            SqlConnection sqlConnection = Connect();
            SqlCommand sqlCommand;
            try
            {
                string query = "Update Account set Balance=Balance+@amount where CustomerID=@customerId";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@amount", amount));
                sqlCommand.Parameters.Add(new SqlParameter("@customerId", customerId));
                sqlCommand.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int WithdrawBalance(int customerId,int amount)
        {
            SqlConnection sqlConnection = Connect();
            SqlCommand sqlCommand;
            try
            {
                string query = "Update Account set Balance=Balance-@amount where CustomerID=@customerId";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@amount", amount));
                sqlCommand.Parameters.Add(new SqlParameter("@customerId", customerId));
                sqlCommand.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int TotalAmount(int customerId)
        {
            SqlConnection sqlConnection = Connect();
            SqlCommand sqlCommand;
            try
            {
                string query = "Select * from Account where CustomerID=@customerId";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@customerId", customerId));
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    return (int)dr.GetValue(3);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int AccountType(int customerId)
        {
            SqlConnection sqlConnection = Connect();
            SqlCommand sqlCommand;
            try
            {
                string query = "Select * from Account where CustomerID=@customerId";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@customerId", customerId));
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetValue(2).ToString().Equals("Savings"))
                        return 1;
                    else if (dr.GetValue(2).ToString().Equals("Current"))
                        return 2;
                    else
                        return 3;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int Interest(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
