using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;   
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyBudget.DAL.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<CashAccount> CashAccounts { get; set; }

        public ICollection<IncomeCategory> IncomeCategories { get; set; }

        public ICollection<OutcomeCategory> OutcomeCategories { get; set; }

        public ICollection<Income> Incomes { get; set; }

        public ICollection<Outcome> Outcomes { get; set; }

        public ApplicationUser()
        {
            CashAccounts = new HashSet<CashAccount>();
            Incomes = new HashSet<Income>();
            IncomeCategories = new HashSet<IncomeCategory>();
            OutcomeCategories = new HashSet<OutcomeCategory>();
            Outcomes = new HashSet<Outcome>();
        }
    }
}