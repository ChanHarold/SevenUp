using SevenUp.DataAccess.Entities;
using System.Data;
using System.Data.Entity;

namespace SevenUp.DataAccess
{
    public class SevenUpDb : DbContext
    {
        public SevenUpDb()
            : base("name=SevenUpDb")
        {
        }
        public DbSet<AuthCode> AuthCodes { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}