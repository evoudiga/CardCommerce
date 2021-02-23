using Microsoft.EntityFrameworkCore;
using CardCommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCommerce.Core.Data
{
    public class CardDBContext : DbContext
    {
        const string connectionString = "Server=localhost;Database=CardDb;User Id=sa;Password=admin!@#123"; //connection string για συνδεση στη ΒΔ

    //    public CrmDbContext() //ορισμός Constructor
    //    {

    //    }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //connectivity with sql server via connctionString
        {
            base.OnConfiguring(optionsBuilder);            // τι θα χρησιμοποιήσει
            optionsBuilder.UseSqlServer(connectionString); //πώς θα συνδεθεί
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // ορισμός πινάκων
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>()   //χρήση της κλάσης Customer 
               .ToTable("Card");           //ως πίνακα στο μοντέλο μου

            modelBuilder.Entity<Transaction>()   //χρήση της κλάσης Order 
                .ToTable("Transaction");
        }        

    }   
}
