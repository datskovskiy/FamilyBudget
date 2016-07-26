using System.Data.Entity.ModelConfiguration;
using FamilyBudget.Constants.DbConstants;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Configuration
{
    public class OutcomeCategoryConfiguration : EntityTypeConfiguration<OutcomeCategory>
    {
        public OutcomeCategoryConfiguration()
        {
            ToTable(DbTablesNames.OutcomeCategories);
            HasKey(p => p.OutcomeCategoryId);
            Property(p => p.OutcomeCategoryName).HasMaxLength(DbLengthString.NormalString);
            HasRequired(p => p.ApplicationUser).WithMany(p => p.OutcomeCategories).HasForeignKey(p => p.OutcomeCategoryOwner);
        }
    }
}
