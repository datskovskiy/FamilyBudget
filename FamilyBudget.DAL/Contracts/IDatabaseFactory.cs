using FamilyBudget.DAL.Contexts;

namespace FamilyBudget.DAL.Contracts
{
    public interface IDatabaseFactory
    {
        FamilyBudgetContext Get();
    }
}
