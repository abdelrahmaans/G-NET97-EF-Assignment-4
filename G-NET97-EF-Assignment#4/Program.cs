using G_NET97_EF_Assignment_4.Context;
using G_NET97_EF_Assignment_4.Data;
using G_NET97_EF_Assignment_4.Models;
using Microsoft.EntityFrameworkCore;

namespace G_NET97_EF_Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using BankDbContext context = new BankDbContext();

            #region Seeding
            DataSeederHelpers.Seed(context);
            #endregion

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                #region Menu
                Console.WriteLine("========================================");
                Console.WriteLine("       National Bank - Management");
                Console.WriteLine("========================================");
                Console.WriteLine("  1) Add a new Customer");
                Console.WriteLine("  2) Open a new Account for a Customer");
                Console.WriteLine("  3) Update Account Status (Active / Closed)");
                Console.WriteLine("  4) Remove an Account from a Customer");
                Console.WriteLine("  5) List all Customers (with accounts)");
                Console.WriteLine("  0) Exit");
                Console.WriteLine("----------------------------------------");
                Console.Write("  Enter choice: ");
                #endregion

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddCustomer(context);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case 2:
                        OpenAccount(context);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        UpdateAccountStatus(context);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        RemoveAccountFromCustomer(context);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case 5:
                        ListAllCustomers(context);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select from the menu.");
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                }
            }

        }

        #region Add Customer

        static void AddCustomer(BankDbContext context)
        {
            Console.Clear();

            Console.WriteLine("--- Add New Customer ---");

            Console.Write("Full Name    : ");
            string fullName = Console.ReadLine();

            Console.Write("National ID  : ");
            string nationalId = Console.ReadLine();

            Console.Write("Date of Birth: ");
            string dateInput = Console.ReadLine();

            Console.Write("Email        : ");
            string email = Console.ReadLine();

            Console.Write("Phone        : ");
            string phone = Console.ReadLine();

            Console.Write("Address      : ");
            string address = Console.ReadLine();

            Console.WriteLine("Customer Type:");
            Console.WriteLine("    1) Individual");
            Console.WriteLine("    2) Business");
            Console.Write("Choice: ");

            string typeInput = Console.ReadLine();

            // Validation
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(nationalId) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("\nAll fields are required.");
                return;
            }

            if (!DateTime.TryParse(dateInput, out DateTime dateOfBirth))
            {
                Console.WriteLine("\nInvalid Date of Birth.");
                return;
            }

            if (!int.TryParse(typeInput, out int typeChoice) ||
                (typeChoice != 1 && typeChoice != 2))
            {
                Console.WriteLine("\nInvalid Customer Type.");
                return;
            }

            CustomerType customerType;

            if (typeChoice == 1)
            {
                customerType = CustomerType.Individual;
            }
            else
            {
                customerType = CustomerType.Business;
            }

            // Create Customer Object
            Customer customer = new Customer()
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                CustomerType = customerType
            };

            // Add Customer to Database
            context.Customers.Add(customer);

            context.SaveChanges();

            Console.WriteLine($"\nCustomer created successfully. CustomerId = {customer.Id}");
        }

        #endregion

        #region Open Account

        static void OpenAccount(BankDbContext context)
        {
            Console.Clear();

            Console.WriteLine("--- Open New Account ---");

            Console.Write("Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("\nAccount Type:");
            Console.WriteLine("1) Savings");
            Console.WriteLine("2) Current");
            Console.WriteLine("3) Business");
            Console.Write("Choice: ");

            string accountTypeInput = Console.ReadLine();

            Console.Write("Branch Code: ");
            string branchCode = Console.ReadLine();

            Console.Write("Customer ID: ");
            string customerIdInput = Console.ReadLine();

            Console.WriteLine("\nOwnership Role:");
            Console.WriteLine("1) Primary");
            Console.WriteLine("2) CoHolder");
            Console.Write("Choice: ");

            string ownershipInput = Console.ReadLine();

            // Validate required inputs
            if (string.IsNullOrWhiteSpace(accountNumber) ||
                string.IsNullOrWhiteSpace(branchCode))
            {
                Console.WriteLine("\nAccount Number and Branch Code are required.");
                return;
            }

            // Validate Account Type
            if (!int.TryParse(accountTypeInput, out int accountTypeChoice) ||
                accountTypeChoice < 1 || accountTypeChoice > 3)
            {
                Console.WriteLine("\nInvalid Account Type.");
                return;
            }

            // Validate Customer ID
            if (!int.TryParse(customerIdInput, out int customerId))
            {
                Console.WriteLine("\nInvalid Customer ID.");
                return;
            }

            // Validate Ownership Role
            if (!int.TryParse(ownershipInput, out int ownershipChoice) ||
                ownershipChoice < 1 || ownershipChoice > 2)
            {
                Console.WriteLine("\nInvalid Ownership Role.");
                return;
            }

            // Check if Branch exists
            bool branchExists = context.Branches
                .Any(b => b.Code == branchCode);

            if (!branchExists)
            {
                Console.WriteLine("\nBranch not found.");
                return;
            }

            // Check if Customer exists
            bool customerExists = context.Customers
                .Any(c => c.Id == customerId);

            if (!customerExists)
            {
                Console.WriteLine("\nCustomer not found.");
                return;
            }

            // Check if Account Number already exists
            bool accountExists = context.Accounts
                .Any(a => a.AccountNumber == accountNumber);

            if (accountExists)
            {
                Console.WriteLine("\nAccount Number already exists.");
                return;
            }

            // Convert inputs to Enums
            AccountType accountType = (AccountType)accountTypeChoice;
            OwnershipType ownershipType = (OwnershipType)ownershipChoice;

            // Create Account
            Account account = new Account()
            {
                AccountNumber = accountNumber,
                AccountType = accountType,
                BranchCode = branchCode,
                CurrentBalance = 0,
                OpeningDate = DateTime.Now,
                AccountStatus = AccountStatus.Active
            };

            // Create CustomerAccount Relationship
            CustomerAccount customerAccount = new CustomerAccount()
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                OwnershipType = ownershipType,
                OwnershipStartDate = DateTime.Now
            };

            // Save Account and Relationship
            context.Accounts.Add(account);
            context.CustomerAccounts.Add(customerAccount);

            context.SaveChanges();

            Console.WriteLine("\nAccount opened successfully!");
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Customer ID: {customerId}");
        }

        #endregion

        #region Update Account Status

        static void UpdateAccountStatus(BankDbContext context)
        {
            Console.Clear();

            Console.WriteLine("--- Update Account Status ---");

            Console.Write("Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Customer ID: ");
            string customerIdInput = Console.ReadLine();

            // Validate Inputs
            if (string.IsNullOrWhiteSpace(accountNumber) ||
                !int.TryParse(customerIdInput, out int customerId))
            {
                Console.WriteLine("\nInvalid input.");
                return;
            }

            // Find Customer Account
            CustomerAccount customerAccount = context.CustomerAccounts
                .FirstOrDefault(ca =>
                    ca.AccountNumber == accountNumber &&
                    ca.CustomerId == customerId);

            if (customerAccount == null)
            {
                Console.WriteLine("\nAccount not found for this customer.");
                return;
            }

            // Find Account
            Account account = context.Accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("\nAccount not found.");
                return;
            }

            // Toggle Account Status
            if (account.AccountStatus == AccountStatus.Active)
            {
                account.AccountStatus = AccountStatus.Closed;
            }
            else
            {
                account.AccountStatus = AccountStatus.Active;
            }

            context.SaveChanges();

            Console.WriteLine("\nAccount status updated successfully!");
            Console.WriteLine($"New Status: {account.AccountStatus}");
        }

        #endregion

        #region Remove Account from Customer

        static void RemoveAccountFromCustomer(BankDbContext context)
        {
            Console.Clear();

            Console.WriteLine("--- Remove Account from Customer ---");

            Console.Write("Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Customer ID: ");
            string customerIdInput = Console.ReadLine();

            // Validate Inputs
            if (string.IsNullOrWhiteSpace(accountNumber) ||
                !int.TryParse(customerIdInput, out int customerId))
            {
                Console.WriteLine("\nInvalid input.");
                return;
            }

            // Find Customer Account Relationship
            CustomerAccount customerAccount = context.CustomerAccounts
                .FirstOrDefault(ca =>
                    ca.AccountNumber == accountNumber &&
                    ca.CustomerId == customerId);

            if (customerAccount == null)
            {
                Console.WriteLine("\nAccount not found for this customer.");
                return;
            }

            // Remove Relationship
            context.CustomerAccounts.Remove(customerAccount);

            context.SaveChanges();

            Console.WriteLine("\nAccount removed from customer successfully!");
        }

        #endregion

        #region List All Customers

        static void ListAllCustomers(BankDbContext context)
        {
            Console.Clear();

            Console.WriteLine("--- All Customers with Accounts ---\n");

            // Eager Loading
            var customers = context.Customers
                .Include(c => c.CustomerAccounts)
                    .ThenInclude(ca => ca.Account)
                .ToList();

            if (!customers.Any())
            {
                Console.WriteLine("No customers found.");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine("========================================");
                Console.WriteLine($"Customer ID   : {customer.Id}");
                Console.WriteLine($"Full Name     : {customer.FullName}");
                Console.WriteLine($"National ID   : {customer.NationalId}");
                Console.WriteLine($"Email         : {customer.Email}");
                Console.WriteLine($"Phone         : {customer.PhoneNumber}");
                Console.WriteLine($"Address       : {customer.Address}");
                Console.WriteLine($"Customer Type : {customer.CustomerType}");

                Console.WriteLine("\nAccounts:");

                if (!customer.CustomerAccounts.Any())
                {
                    Console.WriteLine("No accounts found for this customer.");
                }
                else
                {
                    foreach (var customerAccount in customer.CustomerAccounts)
                    {
                        Account account = customerAccount.Account;

                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Account Number : {account.AccountNumber}");
                        Console.WriteLine($"Account Type   : {account.AccountType}");
                        Console.WriteLine($"Balance        : {account.CurrentBalance}");
                        Console.WriteLine($"Status         : {account.AccountStatus}");
                        Console.WriteLine($"Branch Code    : {account.BranchCode}");
                        Console.WriteLine($"Ownership Role : {customerAccount.OwnershipType}");
                    }
                }

                Console.WriteLine("========================================\n");
            }
        }

        #endregion

    }
}
