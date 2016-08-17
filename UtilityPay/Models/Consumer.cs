namespace UtilityPay.Models
{
    using Interfaces;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ConsumerContext : DbContext
    {
        // Your context has been configured to use a 'Consumer' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UtilityPay.Models.Consumer' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Consumer' 
        // connection string in the application configuration file.
        public ConsumerContext()
            : base("DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Consumer> Consumers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumer>()
                .HasOptional(t => t.User);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Consumer : IConsumer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}