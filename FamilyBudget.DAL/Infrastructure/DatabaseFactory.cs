using FamilyBudget.DAL.Contexts;
using FamilyBudget.DAL.Contracts;

namespace FamilyBudget.DAL.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private FamilyBudgetContext _context;
        public FamilyBudgetContext Get()
        {
            return _context ?? (_context = new FamilyBudgetContext());
        }
        protected override void DisposeCore()
        {
            _context?.Dispose();
        }
    }
}
