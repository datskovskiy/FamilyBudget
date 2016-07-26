using FamilyBudget.DAL.Contracts;
using FamilyBudget.DAL.Infrastructure;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Repositories
{
    public class OutcomeCategoryRepository : RepositoryBase<OutcomeCategory>, IOutcomeCategoryRepository
    {
        public OutcomeCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IOutcomeCategoryRepository : IRepository<OutcomeCategory>
    {
    }
}