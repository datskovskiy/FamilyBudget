using FamilyBudget.DAL.Contracts;

namespace FamilyBudget.DAL.Infrastructure
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork GetUnitOfWork()
        {
            var context = new DatabaseFactory();
            return new UnitOfWork(context);
        }
    }
}
