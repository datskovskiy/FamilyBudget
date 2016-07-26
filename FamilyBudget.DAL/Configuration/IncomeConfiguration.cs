using System.Data.Entity.ModelConfiguration;
using FamilyBudget.Constants.DbConstants;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Configuration
{
    public class IncomeConfiguration : EntityTypeConfiguration<Income>
    {
        public IncomeConfiguration()
        {
            HasKey(p => p.IncomeId);
            Property(p => p.IncomeName).HasMaxLength(DbLengthString.ShortString);
            Property(p => p.IncomeDescription).HasMaxLength(DbLengthString.NormalString);
            HasRequired(p => p.ApplicationUser).WithMany(p => p.Incomes).HasForeignKey(p => p.IncomeOwner);
            HasRequired(p => p.CashAccount).WithMany(p => p.Incomes).HasForeignKey(p => p.CashAccountId);
            HasRequired(p => p.IncomeCategory).WithMany(p => p.Incomes).HasForeignKey(p => p.IncomeCategoryId);
            HasRequired(p => p.Currency).WithMany(p => p.Incomes).HasForeignKey(p => p.CurrencyId);
        }
    }
}
