using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NwServiceLib.Models.Mapping;

namespace NwServiceLib.Models
{
    public partial class sampleContext : DbContext
    {
        static sampleContext()
        {
            Database.SetInitializer<sampleContext>(null);
        }

        public sampleContext()
            : base("Name=sampleContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
        }
    }
}
