using FamilyBudget.DAL.Contracts;
using FamilyBudget.DAL.Infrastructure;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Repositories
{
    public class IncomeCategoryRepository : RepositoryBase<IncomeCategory>, IIncomeCategoryRepository
    {
        public IncomeCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IIncomeCategoryRepository : IRepository<IncomeCategory>
    {
    }
}
