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

            var card1 = new Card();
            card1.CardNumber = "1111111111111111";
            card1.AvailBalance = 1500M;
            
            dbContext.Add(card1);
            dbContext.SaveChanges();

            var Trn1 = new Transaction();
            Trn1.TrnType = TransactionType.Ecommerce;
            Trn1.LimitAm0 = 200M;
            Trn1.LimitAm1 = 0M;
            Trn1.AggregateAmount = 200M;
            Trn1.CreatedDate = DateTimeOffset.Now.Date.ToString("yyyy-MM-dd");
            
            card1.AvailBalance = card1.AvailBalance - Trn1.LimitAm0 - Trn1.LimitAm1;

            if (IsGreater(Trn1.LimitAm0, Trn1.LimitAm0, card1.AvailBalance))
            {
                dbContext.Add(Trn1);
                dbContext.SaveChanges();
            }
           

            var Trn2 = new Transaction();
            Trn2.TrnType = TransactionType.CardPresent;
            Trn2.LimitAm0 = 200M;
            Trn2.LimitAm1 = 700M;
            Trn2.AggregateAmount = Trn2.LimitAm0+ Trn2.LimitAm1;
            Trn2.CreatedDate = DateTimeOffset.Now.Date.ToString("yyyy-MM-dd");
            
            card1.AvailBalance = card1.AvailBalance - Trn2.LimitAm0 - Trn2.LimitAm1;
            dbContext.SaveChanges();

            if (IsGreater(Trn2.LimitAm0, Trn2.LimitAm0, card1.AvailBalance))
            {
                dbContext.Add(Trn2);
                dbContext.SaveChanges();
            }
              

        }
    }

    public static bool IsGreater(decimal i0, decimal i1, decimal AvailBalance)
    {

        return i0 + i1 <= 2000 && i0 <= 500 && i1 <= 1500 && (i0 + i1) <= AvailBalance;
    }
}


