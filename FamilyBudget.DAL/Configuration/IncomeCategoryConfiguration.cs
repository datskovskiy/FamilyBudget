using System.Data.Entity.ModelConfiguration;
using FamilyBudget.Constants.DbConstants;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Configuration
{
    public class IncomeCategoryConfiguration : EntityTypeConfiguration<IncomeCategory>
    {
        public IncomeCategoryConfiguration()
        {
            ToTable(DbTablesNames.IncomeCategories);
            HasKey(p => p.IncomeCategoryId);
            Property(p => p.IncomeCategoryName).HasMaxLength(DbLengthString.NormalString);
            HasRequired(p => p.ApplicationUser).WithMany(p => p.IncomeCategories).HasForeignKey(p => p.IncomeCategoryOwner);
        }
    }
}
