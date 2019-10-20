using System;
using System.Collections.Generic;
using System.Text;

namespace BankyApp.Entities
{
 public   class Transaction
    {
        public Guid TransactionId { get; set; }

        public Guid  AccountId { get; set; }
        public Guid BankId { get; set; }
        public DateTime OccurrenceDate { get; set; }
        public string Description { get; set; }
        public decimal  Amount { get; set; }
    }
}
