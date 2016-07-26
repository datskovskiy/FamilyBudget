using FamilyBudget.DAL.Models;
using System.Data.Entity.Migrations;

namespace FamilyBudget.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Contexts.FamilyBudgetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contexts.FamilyBudgetContext context)
        {
            context.Currencies.AddOrUpdate(
              x => x.CurrencyId,
              new Currency { CurrencyId = 1, CurrencyName = "Hryvnia", CurrencyShortName = "UAH" },
              new Currency { CurrencyId = 2, CurrencyName = "Dollar", CurrencyShortName = "USD" },
              new Currency { CurrencyId = 3, CurrencyName = "Euro", CurrencyShortName = "EUR" }
            );
        }
    }
}
