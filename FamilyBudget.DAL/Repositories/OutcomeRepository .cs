using FamilyBudget.DAL.Contracts;
using FamilyBudget.DAL.Infrastructure;
using FamilyBudget.DAL.Models;

namespace FamilyBudget.DAL.Repositories
{
    public class OutcomeRepository : RepositoryBase<Outcome>, IOutcomeRepository
    {
        public OutcomeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IOutcomeRepository : IRepository<Outcome>
    {
    }
}