using G_NET97_EF_Assignment_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_4.Configurations
{
    internal class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            #region Primary Key

            builder.HasKey(CA => new
            {
                CA.CustomerId,
                CA.AccountNumber
            });

            #endregion

            #region Relationships

            // Customer - CustomerAccount
            builder.HasOne(CA => CA.Customer)
                   .WithMany(C => C.CustomerAccounts)
                   .HasForeignKey(CA => CA.CustomerId);

            // Account - CustomerAccount
            builder.HasOne(CA => CA.Account)
                   .WithMany(A => A.CustomerAccounts)
                   .HasForeignKey(CA => CA.AccountNumber);

            #endregion
        }
    }
}
