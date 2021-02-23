using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCommerce.Core.Model
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public TransactionType TrnType { get; set; }

        public decimal LimitAm0 { get; set; } // Ecommerce

        public decimal LimitAm1 { get; set; } // CardPresent

        public decimal AggregateAmount { get; set; }

        public string CreatedDate { get; set; }

    }
}
