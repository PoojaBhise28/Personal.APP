using Microsoft.EntityFrameworkCore;
using PersonalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Data
{
    public class MyAppDbContext : DbContext
    {
       
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> PersonalDetails { get; set; }
    }
}
