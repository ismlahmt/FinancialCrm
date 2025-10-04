using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCrm
{
    public class DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
