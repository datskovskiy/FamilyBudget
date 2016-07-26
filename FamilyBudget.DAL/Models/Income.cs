using System;

namespace FamilyBudget.DAL.Models
{
    public class Income
    {
        public long IncomeId { get; set; }

        public int CashAccountId { get; set; }

        public int IncomeCategoryId { get; set; }

        public int CurrencyId { get; set; }

        public string IncomeOwner { get; set; }

        public string IncomeName { get; set; }

        public string IncomeDescription { get; set; }

        public DateTime IncomeDate { get; set; }

        public int IncomeSum { get; set; }

        public bool TransferBetweenAccounts { get; set; }

        public virtual CashAccount CashAccount { get; set; }

        public virtual IncomeCategory IncomeCategory { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
