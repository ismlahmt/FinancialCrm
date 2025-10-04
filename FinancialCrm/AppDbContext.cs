using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCrm
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base() { }
        public DbSet<User> Users { get; set; }

    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
