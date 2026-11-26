using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_4.Models
{
    public class Branch
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        // Navigation Properties
        public Manager Manager { get; set; }

        public ICollection<Account> Accounts { get; set; }
            = new List<Account>();
    }
}
