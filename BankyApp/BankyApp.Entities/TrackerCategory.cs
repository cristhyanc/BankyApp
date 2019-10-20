using System;
using System.Collections.Generic;
using System.Text;

namespace BankyApp.Entities
{
   public class TrackerCategory
    {
        public string Description { get; set; }
        public Guid  CategoryId { get; set; }
        public decimal Amount { get; set; }
               
        public decimal Percentage { get; set; }
    }
}
