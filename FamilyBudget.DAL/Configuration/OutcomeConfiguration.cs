using System.Data.Entity.ModelConfiguration;
using FamilyBudget.Constants.DbConstants;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Configuration
{
    public class OutcomeConfiguration : EntityTypeConfiguration<Outcome>
    {
        public OutcomeConfiguration()
        {
            HasKey(p => p.OutcomeId);
            Property(p => p.OutcomeName).HasMaxLength(DbLengthString.ShortString);
            Property(p => p.OutcomeDescription).HasMaxLength(DbLengthString.NormalString);
            HasRequired(p => p.ApplicationUser).WithMany(p => p.Outcomes).HasForeignKey(p => p.OutcomeOwner);
            HasRequired(p => p.CashAccount).WithMany(p => p.Outcomes).HasForeignKey(p => p.CashAccountId);
            HasRequired(p => p.OutcomeCategory).WithMany(p => p.Outcomes).HasForeignKey(p => p.OutcomeCategoryId);
            HasRequired(p => p.Currency).WithMany(p => p.Outcomes).HasForeignKey(p => p.CurrencyId);
        }
    }
}
