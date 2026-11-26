using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_4.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string Note { get; set; }

        public TransactionType TransactionType { get; set; }

        // Foreign Key
        public string AccountNumber { get; set; }

        // Navigation Property
        public Account Account { get; set; }
    }
}
