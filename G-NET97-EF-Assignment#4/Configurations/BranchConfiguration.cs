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
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            #region Primary Key

            builder.HasKey(B => B.Code);

            #endregion

            #region Relationships

            // Branch - Manager
            builder.HasOne(B => B.Manager)
                   .WithOne(M => M.Branch)
                   .HasForeignKey<Manager>(M => M.BranchCode);

            // Branch - Account
            builder.HasMany(B => B.Accounts)
                   .WithOne(A => A.Branch)
                   .HasForeignKey(A => A.BranchCode);

            #endregion
        }
    }
}
