using System.Collections.Generic;

namespace FamilyBudget.DAL.Models
{
    public class CashAccount
    {
        public int CashAccountId { get; set; }

        public string CashAccountName { get; set; }

        public string CashAccountOwner { get; set; }

        public int CurrencyId { get; set; }

        public int IncomeId { get; set; }

        public bool Closed { get; set; }

        public string CashAccountDescription { get; set; }

        public virtual Currency DefaultCurrency { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Income> Incomes { get; set; }

        public ICollection<Outcome> Outcomes { get; set; }

        public ICollection<CashAccountBalance> CashAccountBalances { get; set; }

        public CashAccount()
        {
            Incomes = new HashSet<Income>();
            Outcomes = new HashSet<Outcome>();
            CashAccountBalances = new HashSet<CashAccountBalance>();
        }
    }
}
