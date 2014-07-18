using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using NwServiceLib.Models;

namespace NwServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service : IService
    {
        public List<Customer> GetCustomers()
        {
            using (var context = new sampleContext())
            {
                var data = from c in context.Customers select c;
                return data.ToList<Customer>();
            }
        }

        public List<Employee> GetEmployees(DateTime? birth, DateTime? hire)
        {
            using (var context = new sampleContext())
            {
                var data = from c in context.Employees select c;
                if (birth != null)
                    data = from c in data where c.BirthDate == birth select c;
                if (hire != null)
                    data = from c in data where c.HireDate == hire select c;
                return data.ToList<Employee>();
            }
        }
    }
}
