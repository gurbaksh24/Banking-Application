using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class AccountDetails
    {
        int accountId;
        string accountHolderName;
        string accountType;
        int depositAmount;
        int totalAmount;
        public int GetAccountId()
        {
            return accountId;
        }
        public void SetAccountId(int accountId)
        {
            this.accountId = accountId;
        }
        public string GetAccountHolderName()
        {
            return accountHolderName;
        }
        public void SetAccountHolderName(string accountHolderName)
        {
            this.accountHolderName = accountHolderName;
        }
        public string GetAccountType()
        {
            return accountType;
        }
        public void SetAccountType(string accountType)
        {
            this.accountType = accountType;
        }
        public int GetDepositAmount()
        {
            return depositAmount;
        }
        public void SetDepositAmount(int depositAmount)
        {
            this.depositAmount = depositAmount;
        }
        public int GetTotalAmount()
        {
            return totalAmount;
        }
        public void SetTotalAmount(int totalAmount)
        {
            this.totalAmount = totalAmount;
        }
    }
}
