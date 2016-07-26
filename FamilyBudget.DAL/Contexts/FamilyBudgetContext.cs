using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FamilyBudget.DAL.Configuration;
using FamilyBudget.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyBudget.DAL.Contexts
{
    public class FamilyBudgetContext : IdentityDbContext<ApplicationUser>
    {
        public FamilyBudgetContext()
            : base("name = DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CashAccount> CashAccounts { get; set; }

        public DbSet<OutcomeCategory> OutcomeCategories { get; set; }

        public DbSet<IncomeCategory> IncomeCategories { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Outcome> Outcomes { get; set; }

        public DbSet<CashAccountBalance> CashAccountBalances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();   

            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new CashAccountConfiguration());
            modelBuilder.Configurations.Add(new OutcomeCategoryConfiguration());
            modelBuilder.Configurations.Add(new IncomeCategoryConfiguration());
            modelBuilder.Configurations.Add(new IncomeConfiguration());
            modelBuilder.Configurations.Add(new OutcomeConfiguration());
            modelBuilder.Configurations.Add(new CashAccountBalanceConfiguration());
        }

        public static FamilyBudgetContext Create()
        {
            return new FamilyBudgetContext();
        }
    }
}
