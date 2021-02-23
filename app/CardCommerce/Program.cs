using System;
using System.Linq;
using CardCommerce.Core.Data;
using CardCommerce.Core.Model;

namespace CardCommerce
{
    class Program
    {
        static void Main(string[] args)
        {
              using var dbContext = new CardDBContext();

            //  dbContext.Database.EnsureCreated();  --> Tables "Card" and "Transaction" have been created in db "CardDb"
            var card1 = new Card()
            {
                CardNumber = "1111111111111111",
                AvailBalance = 1500M
            };

            card1.Trn.Add(new Transaction()
            {
                TrnType = TransactionType.Ecommerce,
                LimitAm0 = 200M,
                LimitAm1 = 0M,
                AggregateAmount = 200M,
                CreatedDate = DateTimeOffset.Now.Date.ToString("yyyy-MM-dd")
            });

            card1.Trn.Add(new Transaction()
            {
                TrnType = TransactionType.CardPresent,
                LimitAm0 = 200M,
                LimitAm1 = 700M,
                AggregateAmount = 900M,
                CreatedDate = DateTimeOffset.Now.Date.ToString("yyyy-MM-dd")
            });
            var tmp_limit0 = card1.Trn.LimitAm0

            dbContext.Add(card1); 
            dbContext.SaveChanges();

            if (card1.Trn.LimitAm0 <= 500M &&)





        }
    }
}
