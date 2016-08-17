namespace UtilityPay.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using UtilityPay.Interfaces;

    public class UtilityServiceAccountContext : DbContext
    {
        // Your context has been configured to use a 'UtilityServiceAccount' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UtilityPay.Models.UtilityServiceAccount' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UtilityServiceAccount' 
        // connection string in the application configuration file.
        public UtilityServiceAccountContext()
            : base("DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ApplicationUser> Consumer { get; set; }
    }

    public class UtilityServiceAccountModel : IUtilityServiceAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }

        public int ConsumerId { get; set; }
        public virtual Consumer Consumer { get; set; }
    }

}