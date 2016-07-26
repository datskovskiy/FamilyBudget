using System.Data.Entity.ModelConfiguration;
using FamilyBudget.Constants.DbConstants;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Configuration
{
    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            ToTable(DbTablesNames.Currencies);
            HasKey(p => p.CurrencyId);
            Property(p => p.CurrencyName).IsRequired().HasMaxLength(DbLengthString.ShortString);
            Property(p => p.CurrencyShortName).IsRequired().HasMaxLength(DbLengthString.CurrencyShortName);
        }
    }
}
