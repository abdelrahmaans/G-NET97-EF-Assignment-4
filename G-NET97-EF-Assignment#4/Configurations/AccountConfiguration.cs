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
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            #region Primary Key

            builder.HasKey(A => A.AccountNumber);

            #endregion

            #region Relationships

            // Account - Transaction (One To Many)
            builder.HasMany(A => A.Transactions)
                   .WithOne(T => T.Account)
                   .HasForeignKey(T => T.AccountNumber);

            #endregion
        }
    }
}
