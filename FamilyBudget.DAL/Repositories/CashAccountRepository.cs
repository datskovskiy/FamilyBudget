using FamilyBudget.DAL.Contracts;
using FamilyBudget.DAL.Infrastructure;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Repositories
{
    public class CashAccountRepository: RepositoryBase<CashAccount>, ICashAccountRepository
    {
        public CashAccountRepository(IDatabaseFactory databaseFactory) 
            :base(databaseFactory)
        {
        }
    }

    public interface ICashAccountRepository : IRepository<CashAccount>
    {
    }
}
