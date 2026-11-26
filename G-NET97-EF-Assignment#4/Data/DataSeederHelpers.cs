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
        }
    }
}