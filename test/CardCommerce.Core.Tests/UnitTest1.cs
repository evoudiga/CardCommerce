using System;
using Xunit;
using System.Linq;
using CardCommerce.Core.Data;
using CardCommerce.Core.Model;

namespace CardCommerce.Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            using var dbContext = new CardDBContext();

            var card1 = new Card()
            {
                CardNumber = "1111111111111111",
                AvailBalance = 1500M
            };

            card1.Trn1 = new Transaction()
            {
                TrnType = TransactionType.Ecommerce,
                LimitAm0 = 200M,
                LimitAm1 = 0M,
                AggregateAmount = 200M,
                CreatedDate = DateTimeOffset.Now.Date.ToString("yyyy-MM-dd")
            };

            card1.Trn.Add(new Transaction()
            {
                TrnType = TransactionType.CardPresent,
                LimitAm0 = 200M,
                LimitAm1 = 700M,
                AggregateAmount = 900M,
                CreatedDate = DateTimeOffset.Now.Date.ToString("yyyy-MM-dd")
            });
           

            dbContext.Add(card1);
            dbContext.SaveChanges();

            


        }
    }

    public static bool isGreater(decimal i0, decimal i1, decimal AvailBalance)
    {
        return i > j;
    }
}


