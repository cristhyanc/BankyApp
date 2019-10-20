using System;
using System.Collections.Generic;
using System.Text;

namespace BankyApp.Entities
{
    public class Account
    {
        public Bank Bank { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Transaction > Transactions { get; set; }
    }
}
