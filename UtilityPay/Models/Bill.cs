namespace UtilityPay.Models
{
    using Interfaces;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BillContext : DbContext
    {
        // Your context has been configured to use a 'Bill' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UtilityPay.Models.Bill' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Bill' 
        // connection string in the application configuration file.
        public BillContext()
            : base("DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<UtilityServiceAccount> UtilityServiceAccounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasRequired(x => x.BillCycle);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Bill : IBill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }

        public int BillCycleId { get; set; }
        public virtual BillCycle BillCycle { get; set; }

        public int UtilityServiceId { get; set; }
        public virtual UtilityServiceAccount UtilityServiceAccount { get; set; }
    }

    public class BillCycle
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}