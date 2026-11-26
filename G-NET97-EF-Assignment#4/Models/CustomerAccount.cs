using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_4.Models
{
    public class CustomerAccount
    {
        // Composite Primary Key
        public int CustomerId { get; set; }

        public string AccountNumber { get; set; }

        // Relationship Attributes
        public OwnershipType OwnershipType { get; set; }

        public DateTime OwnershipStartDate { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }

        public Account Account { get; set; }
    }
}
