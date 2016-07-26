using System.Data.Entity.ModelConfiguration;
using FamilyBudget.Constants.DbConstants;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Configuration
{
    public class CashAccountConfiguration: EntityTypeConfiguration<CashAccount>
    {
        public CashAccountConfiguration()
        {
            ToTable(DbTablesNames.CashAccounts);
            HasKey(p => p.CashAccountId);
            Property(p => p.CashAccountName).IsRequired().HasMaxLength(DbLengthString.ShortString);
            Property(p => p.CashAccountDescription).HasMaxLength(DbLengthString.LongString);
            HasRequired(p => p.ApplicationUser).WithMany(p => p.CashAccounts).HasForeignKey(p => p.CashAccountOwner);
            HasRequired(p => p.DefaultCurrency).WithMany(p => p.CashAccounts).HasForeignKey(p => p.CurrencyId);
        }
    }
}
