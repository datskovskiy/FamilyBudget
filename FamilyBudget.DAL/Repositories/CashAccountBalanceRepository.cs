using FamilyBudget.DAL.Contracts;
using FamilyBudget.DAL.Infrastructure;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Repositories
{
    public class CashAccountBalanceRepository : RepositoryBase<CashAccountBalance>, ICashAccountBalanceRepository
    {
        public CashAccountBalanceRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface ICashAccountBalanceRepository : IRepository<CashAccountBalance>
    {
    }
}
