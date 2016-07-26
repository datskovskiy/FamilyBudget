using System.Collections.Generic;

namespace FamilyBudget.DAL.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyShortName { get; set; }

        public ICollection<CashAccount> CashAccounts { get; set; }

        public ICollection<Income> Incomes { get; set; }

        public ICollection<Outcome> Outcomes { get; set; }

        public ICollection<CashAccountBalance> CashAccountBalances { get; set; }

        public Currency()
        {
            CashAccounts = new HashSet<CashAccount>();
            Incomes = new HashSet<Income>();
            Outcomes = new HashSet<Outcome>();
            CashAccountBalances = new HashSet<CashAccountBalance>();
        }
    }
}
