using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCommerce.Core.Model
{
    public class Card
    {
        public int CardId { get; set; }

        public string CardNumber { get; set; }

        public decimal AvailBalance { get; set; }

        public List<Transaction> Trn { get; set; }

        public Card()
        {
            Trn = new List<Transaction>();
        }

    } 
    

}

