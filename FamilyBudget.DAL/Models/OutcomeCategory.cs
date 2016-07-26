using System.Collections.Generic;

namespace FamilyBudget.DAL.Models
{
    public class OutcomeCategory
    {
        public int OutcomeCategoryId { get; set; }

        public string OutcomeCategoryOwner { get; set; }

        public string OutcomeCategoryName { get; set; }

        public bool Inactive { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Outcome> Outcomes { get; set; }

        public OutcomeCategory()
        {
            Outcomes = new HashSet<Outcome>();
        }
    }
}
