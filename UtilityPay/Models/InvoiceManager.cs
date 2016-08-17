namespace UtilityPay.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class InvoiceContext : DbContext
    {
        // Your context has been configured to use a 'InvoiceManager' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UtilityPay.Models.InvoiceManager' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InvoiceManager' 
        // connection string in the application configuration file.
        public InvoiceContext()
            : base("DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
    }

    public class InvoiceManager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Consumer> Consumers { get; set; }

        public int GetConsumerCount()
        {
            return Consumers.Count;
        }
            
    }

    public  class Invoice : IInvoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ReferenceNumber { get; set; }

        public virtual List<Bill> Bills { get; set; }
    }
}