
using System;

namespace FamilyBudget.DAL.Models
{
    public class CashAccountBalance
    {
        public long CashAccountBalanceId { get; set; }

        public int CashAccountId { get; set; }

        public int CurrencyId { get; set; }

        public DateTime BalanceDate { get; set; }

        public int BalanceSum { get; set; }

        public virtual CashAccount CashAccount { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
