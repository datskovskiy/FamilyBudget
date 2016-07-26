namespace FamilyBudget.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashAccountBalance",
                c => new
                    {
                        CashAccountBalanceId = c.Long(nullable: false, identity: true),
                        CashAccountId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        BalanceDate = c.DateTime(nullable: false),
                        BalanceSum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CashAccountBalanceId)
                .ForeignKey("dbo.CashAccounts", t => t.CashAccountId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .Index(t => t.CashAccountId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.CashAccounts",
                c => new
                    {
                        CashAccountId = c.Int(nullable: false, identity: true),
                        CashAccountName = c.String(nullable: false, maxLength: 64),
                        CashAccountOwner = c.String(nullable: false, maxLength: 128),
                        CurrencyId = c.Int(nullable: false),
                        IncomeId = c.Int(nullable: false),
                        Closed = c.Boolean(nullable: false),
                        CashAccountDescription = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CashAccountId)
                .ForeignKey("dbo.AspNetUsers", t => t.CashAccountOwner)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .Index(t => t.CashAccountOwner)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IncomeCategories",
                c => new
                    {
                        IncomeCategoryId = c.Int(nullable: false, identity: true),
                        IncomeCategoryOwner = c.String(nullable: false, maxLength: 128),
                        IncomeCategoryName = c.String(maxLength: 128),
                        Inactive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.IncomeCategoryOwner)
                .Index(t => t.IncomeCategoryOwner);
            
            CreateTable(
                "dbo.Income",
                c => new
                    {
                        IncomeId = c.Long(nullable: false, identity: true),
                        CashAccountId = c.Int(nullable: false),
                        IncomeCategoryId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        IncomeOwner = c.String(nullable: false, maxLength: 128),
                        IncomeName = c.String(maxLength: 64),
                        IncomeDescription = c.String(maxLength: 128),
                        IncomeDate = c.DateTime(nullable: false),
                        IncomeSum = c.Int(nullable: false),
                        TransferBetweenAccounts = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeId)
                .ForeignKey("dbo.AspNetUsers", t => t.IncomeOwner)
                .ForeignKey("dbo.CashAccounts", t => t.CashAccountId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.IncomeCategories", t => t.IncomeCategoryId)
                .Index(t => t.CashAccountId)
                .Index(t => t.IncomeCategoryId)
                .Index(t => t.CurrencyId)
                .Index(t => t.IncomeOwner);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(nullable: false, maxLength: 64),
                        CurrencyShortName = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Outcome",
                c => new
                    {
                        OutcomeId = c.Long(nullable: false, identity: true),
                        CashAccountId = c.Int(nullable: false),
                        OutcomeCategoryId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        OutcomeOwner = c.String(nullable: false, maxLength: 128),
                        OutcomeName = c.String(maxLength: 64),
                        OutcomeDescription = c.String(maxLength: 128),
                        OutcomeDate = c.DateTime(nullable: false),
                        OutcomeSum = c.Int(nullable: false),
                        TransferBetweenAccounts = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OutcomeId)
                .ForeignKey("dbo.AspNetUsers", t => t.OutcomeOwner)
                .ForeignKey("dbo.CashAccounts", t => t.CashAccountId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.OutcomeCategories", t => t.OutcomeCategoryId)
                .Index(t => t.CashAccountId)
                .Index(t => t.OutcomeCategoryId)
                .Index(t => t.CurrencyId)
                .Index(t => t.OutcomeOwner);
            
            CreateTable(
                "dbo.OutcomeCategories",
                c => new
                    {
                        OutcomeCategoryId = c.Int(nullable: false, identity: true),
                        OutcomeCategoryOwner = c.String(nullable: false, maxLength: 128),
                        OutcomeCategoryName = c.String(maxLength: 128),
                        Inactive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OutcomeCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.OutcomeCategoryOwner)
                .Index(t => t.OutcomeCategoryOwner);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CashAccountBalance", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.CashAccountBalance", "CashAccountId", "dbo.CashAccounts");
            DropForeignKey("dbo.CashAccounts", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.CashAccounts", "CashAccountOwner", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Income", "IncomeCategoryId", "dbo.IncomeCategories");
            DropForeignKey("dbo.Income", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Outcome", "OutcomeCategoryId", "dbo.OutcomeCategories");
            DropForeignKey("dbo.OutcomeCategories", "OutcomeCategoryOwner", "dbo.AspNetUsers");
            DropForeignKey("dbo.Outcome", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Outcome", "CashAccountId", "dbo.CashAccounts");
            DropForeignKey("dbo.Outcome", "OutcomeOwner", "dbo.AspNetUsers");
            DropForeignKey("dbo.Income", "CashAccountId", "dbo.CashAccounts");
            DropForeignKey("dbo.Income", "IncomeOwner", "dbo.AspNetUsers");
            DropForeignKey("dbo.IncomeCategories", "IncomeCategoryOwner", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.OutcomeCategories", new[] { "OutcomeCategoryOwner" });
            DropIndex("dbo.Outcome", new[] { "OutcomeOwner" });
            DropIndex("dbo.Outcome", new[] { "CurrencyId" });
            DropIndex("dbo.Outcome", new[] { "OutcomeCategoryId" });
            DropIndex("dbo.Outcome", new[] { "CashAccountId" });
            DropIndex("dbo.Income", new[] { "IncomeOwner" });
            DropIndex("dbo.Income", new[] { "CurrencyId" });
            DropIndex("dbo.Income", new[] { "IncomeCategoryId" });
            DropIndex("dbo.Income", new[] { "CashAccountId" });
            DropIndex("dbo.IncomeCategories", new[] { "IncomeCategoryOwner" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CashAccounts", new[] { "CurrencyId" });
            DropIndex("dbo.CashAccounts", new[] { "CashAccountOwner" });
            DropIndex("dbo.CashAccountBalance", new[] { "CurrencyId" });
            DropIndex("dbo.CashAccountBalance", new[] { "CashAccountId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.OutcomeCategories");
            DropTable("dbo.Outcome");
            DropTable("dbo.Currencies");
            DropTable("dbo.Income");
            DropTable("dbo.IncomeCategories");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CashAccounts");
            DropTable("dbo.CashAccountBalance");
        }
    }
}
