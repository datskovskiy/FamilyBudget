using System;
using FamilyBudget.DAL.Repositories;

namespace FamilyBudget.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICashAccountRepository CashAccounts { get; }

        ICurrencyRepository Currencies { get; }

        IOutcomeRepository Outcomes { get; }

        IIncomeRepository Incomes { get; }

        IIncomeCategoryRepository IncomeCategories { get; }

        IOutcomeCategoryRepository OutcomeCategories { get; }

        ICashAccountBalanceRepository CashAccountBalances { get; }

        void Save();
    }
}
