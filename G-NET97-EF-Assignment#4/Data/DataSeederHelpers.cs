using G_NET97_EF_Assignment_4.Context;
using G_NET97_EF_Assignment_4.Models;

namespace G_NET97_EF_Assignment_4.Data
{
    internal static class DataSeederHelpers
    {
        public static void Seed(BankDbContext context)
        {
            #region Branch Seeding

            if (!context.Branches.Any())
            {
                List<Branch> branches = new List<Branch>()
                {
                    new Branch()
                    {
                        Code = "B001",
                        Name = "Cairo Branch",
                        Address = "Nasr City, Cairo",
                        PhoneNumber = "0223456789"
                    },
                    new Branch()
                    {
                        Code = "B002",
                        Name = "Alexandria Branch",
                        Address = "Smouha, Alexandria",
                        PhoneNumber = "0345678901"
                    }
                };

                context.Branches.AddRange(branches);
                context.SaveChanges();
            }

            #endregion

            #region Manager Seeding

            if (!context.Managers.Any())
            {
                List<Manager> managers = new List<Manager>()
                {
                    new Manager()
                    {
                        FullName = "Ahmed Mohamed",
                        Email = "ahmed@bank.com",
                        PhoneNumber = "01012345678",
                        HireDate = new DateTime(2020, 1, 1),
                        BranchCode = "B001"
                    },
                    new Manager()
                    {
                        FullName = "Mohamed Ali",
                        Email = "mohamed@bank.com",
                        PhoneNumber = "01098765432",
                        HireDate = new DateTime(2021, 5, 1),
                        BranchCode = "B002"
                    }
                };

                context.Managers.AddRange(managers);
                context.SaveChanges();
            }

            #endregion

            #region Customer Seeding

            if (!context.CustomerAccounts.Any())
            {
                var customers = context.Customers.ToList();
                var accounts = context.Accounts.ToList();

                if (customers.Count < 2 || accounts.Count < 5)
                {
                    Console.WriteLine("Not enough Customers or Accounts to seed CustomerAccounts.");
                    return;
                }

                List<CustomerAccount> customerAccounts = new List<CustomerAccount>()
    {
        new CustomerAccount()
        {
            CustomerId = customers[0].Id,
            AccountNumber = accounts[0].AccountNumber,
            OwnershipType = OwnershipType.Primary,
            OwnershipStartDate = new DateTime(2024, 1, 10)
        },
        new CustomerAccount()
        {
            CustomerId = customers[0].Id,
            AccountNumber = accounts[1].AccountNumber,
            OwnershipType = OwnershipType.Primary,
            OwnershipStartDate = new DateTime(2024, 2, 15)
        },
        new CustomerAccount()
        {
            CustomerId = customers[1].Id,
            AccountNumber = accounts[2].AccountNumber,
            OwnershipType = OwnershipType.Primary,
            OwnershipStartDate = new DateTime(2024, 3, 20)
        },
        new CustomerAccount()
        {
            CustomerId = customers[1].Id,
            AccountNumber = accounts[3].AccountNumber,
            OwnershipType = OwnershipType.Primary,
            OwnershipStartDate = new DateTime(2024, 4, 5)
        },
        new CustomerAccount()
        {
            CustomerId = customers[0].Id,
            AccountNumber = accounts[4].AccountNumber,
            OwnershipType = OwnershipType.Primary,
            OwnershipStartDate = new DateTime(2024, 5, 12)
        }
    };

                context.CustomerAccounts.AddRange(customerAccounts);
                context.SaveChanges();
            }

            #endregion

            #region Account Seeding

            if (!context.Accounts.Any())
            {
                List<Account> accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = "ACC1001",
                        CurrentBalance = 15000,
                        AccountType = AccountType.Savings,
                        OpeningDate = new DateTime(2024, 1, 10),
                        AccountStatus = AccountStatus.Active,
                        BranchCode = "B001"
                    },
                    new Account()
                    {
                        AccountNumber = "ACC1002",
                        CurrentBalance = 25000,
                        AccountType = AccountType.Current,
                        OpeningDate = new DateTime(2024, 2, 15),
                        AccountStatus = AccountStatus.Active,
                        BranchCode = "B001"
                    },
                    new Account()
                    {
                        AccountNumber = "ACC1003",
                        CurrentBalance = 8000,
                        AccountType = AccountType.Savings,
                        OpeningDate = new DateTime(2024, 3, 20),
                        AccountStatus = AccountStatus.Closed,
                        BranchCode = "B002"
                    },
                    new Account()
                    {
                        AccountNumber = "ACC1004",
                        CurrentBalance = 50000,
                        AccountType = AccountType.Business,
                        OpeningDate = new DateTime(2024, 4, 5),
                        AccountStatus = AccountStatus.Active,
                        BranchCode = "B002"
                    },
                    new Account()
                    {
                        AccountNumber = "ACC1005",
                        CurrentBalance = 12000,
                        AccountType = AccountType.Savings,
                        OpeningDate = new DateTime(2024, 5, 12),
                        AccountStatus = AccountStatus.Active,
                        BranchCode = "B001"
                    }
                };

                context.Accounts.AddRange(accounts);
                context.SaveChanges();
            }

            #endregion

            #region CustomerAccount Seeding

            if (!context.CustomerAccounts.Any())
            {
                var customers = context.Customers.ToList();
                var accounts = context.Accounts.ToList();

                List<CustomerAccount> customerAccounts = new List<CustomerAccount>()
                {
                    new CustomerAccount()
                    {
                        CustomerId = customers.First(c => c.NationalId == "29001011234567").Id,
                        AccountNumber = "ACC1001",
                        OwnershipType = OwnershipType.Primary,
                        OwnershipStartDate = new DateTime(2024, 1, 10)
                    },
                    new CustomerAccount()
                    {
                        CustomerId = customers.First(c => c.NationalId == "29001011234567").Id,
                        AccountNumber = "ACC1002",
                        OwnershipType = OwnershipType.Primary,
                        OwnershipStartDate = new DateTime(2024, 2, 15)
                    },
                    new CustomerAccount()
                    {
                        CustomerId = customers.First(c => c.NationalId == "29505221234567").Id,
                        AccountNumber = "ACC1003",
                        OwnershipType = OwnershipType.Primary,
                        OwnershipStartDate = new DateTime(2024, 3, 20)
                    },
                    new CustomerAccount()
                    {
                        CustomerId = customers.First(c => c.NationalId == "30001011234567").Id,
                        AccountNumber = "ACC1004",
                        OwnershipType = OwnershipType.Primary,
                        OwnershipStartDate = new DateTime(2024, 4, 5)
                    },
                    new CustomerAccount()
                    {
                        CustomerId = customers.First(c => c.NationalId == "29807101234567").Id,
                        AccountNumber = "ACC1005",
                        OwnershipType = OwnershipType.Primary,
                        OwnershipStartDate = new DateTime(2024, 5, 12)
                    },
                    new CustomerAccount()
                    {
                        CustomerId = customers.First(c => c.NationalId == "29505221234567").Id,
                        AccountNumber = "ACC1001",
                        OwnershipType = OwnershipType.CoHolder,
                        OwnershipStartDate = new DateTime(2024, 6, 1)
                    }
                };

                context.CustomerAccounts.AddRange(customerAccounts);
                context.SaveChanges();
            }

            #endregion

            #region Transaction Seeding

            if (!context.Transactions.Any())
            {
                List<Transaction> transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        TransactionDate = new DateTime(2024, 6, 1),
                        Amount = 5000,
                        Note = "Initial Deposit",
                        TransactionType = TransactionType.Deposit,
                        AccountNumber = "ACC1001"
                    },
                    new Transaction()
                    {
                        TransactionDate = new DateTime(2024, 6, 5),
                        Amount = 2000,
                        Note = "Cash Withdrawal",
                        TransactionType = TransactionType.Withdrawal,
                        AccountNumber = "ACC1001"
                    },
                    new Transaction()
                    {
                        TransactionDate = new DateTime(2024, 6, 10),
                        Amount = 10000,
                        Note = "Salary Deposit",
                        TransactionType = TransactionType.Deposit,
                        AccountNumber = "ACC1002"
                    },
                    new Transaction()
                    {
                        TransactionDate = new DateTime(2024, 6, 15),
                        Amount = 1500,
                        Note = "Online Payment",
                        TransactionType = TransactionType.Withdrawal,
                        AccountNumber = "ACC1003"
                    },
                    new Transaction()
                    {
                        TransactionDate = new DateTime(2024, 6, 20),
                        Amount = 20000,
                        Note = "Business Deposit",
                        TransactionType = TransactionType.Deposit,
                        AccountNumber = "ACC1004"
                    },
                    new Transaction()
                    {
                        TransactionDate = new DateTime(2024, 6, 25),
                        Amount = 3000,
                        Note = "Cash Withdrawal",
                        TransactionType = TransactionType.Withdrawal,
                        AccountNumber = "ACC1005"
                    }
                };

                context.Transactions.AddRange(transactions);
                context.SaveChanges();
            }

            #endregion
        }
    }
}