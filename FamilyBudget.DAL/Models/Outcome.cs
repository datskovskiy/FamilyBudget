using System;

namespace FamilyBudget.DAL.Models
{
    public class Outcome
    {
        public long OutcomeId { get; set; }

        public int CashAccountId { get; set; }

        public int OutcomeCategoryId { get; set; }

        public int CurrencyId { get; set; }

        public string OutcomeOwner { get; set; }

        public string OutcomeName { get; set; }

        public string OutcomeDescription { get; set; }

        public DateTime OutcomeDate { get; set; }

        public int OutcomeSum { get; set; }

        public bool TransferBetweenAccounts { get; set; }

        public virtual CashAccount CashAccount { get; set; }

        public virtual OutcomeCategory OutcomeCategory { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
