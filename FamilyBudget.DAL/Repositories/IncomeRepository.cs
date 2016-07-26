using FamilyBudget.DAL.Contracts;
using FamilyBudget.DAL.Infrastructure;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Repositories
{
    public class IncomeRepository : RepositoryBase<Income>, IIncomeRepository
    {
        public IncomeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IIncomeRepository : IRepository<Income>
    {
    }
}