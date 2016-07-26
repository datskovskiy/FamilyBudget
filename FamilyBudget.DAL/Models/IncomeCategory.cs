using System.Collections.Generic;

namespace FamilyBudget.DAL.Models
{
    public class IncomeCategory
    {
        public int IncomeCategoryId { get; set; }

        public string IncomeCategoryOwner { get; set; }

        public string IncomeCategoryName { get; set; }

        public bool Inactive { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Income> Incomes { get; set; }

        public IncomeCategory()
        {
            Incomes = new HashSet<Income>();
        }
    }
}
