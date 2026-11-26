using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_4.Models
{
    public enum CustomerType
    {
        Individual,
        Business
    }

    public enum AccountType
    {
        Savings,
        Current,
        Business
    }

    public enum AccountStatus
    {
        Active,
        Closed
    }

    public enum OwnershipType
    {
        Primary,
        CoHolder
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}
