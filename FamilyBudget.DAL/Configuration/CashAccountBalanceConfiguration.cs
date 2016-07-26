using System.Data.Entity.ModelConfiguration;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Configuration
{
    public class CashAccountBalanceConfiguration: EntityTypeConfiguration<CashAccountBalance>
    {
        public CashAccountBalanceConfiguration()
        {
            HasKey(p => p.CashAccountBalanceId);
            Property(p => p.BalanceDate).IsRequired();
            HasRequired(p => p.CashAccount).WithMany(p => p.CashAccountBalances).HasForeignKey(p => p.CashAccountId);
            HasRequired(p => p.Currency).WithMany(p => p.CashAccountBalances).HasForeignKey(p => p.CurrencyId);
        }
    }
}
