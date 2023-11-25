using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriProductsManagementSystem.Models
{
    public class Deal
    {
        public int DealID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Discount { get; set; }
        public DateTime? ValidityPeriod { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
    }

}
