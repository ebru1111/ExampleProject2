using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _OrnekProje.Models
{
    public class Context: DbContext
    {
        public Context()
        {
            
            Database.Connection.ConnectionString = "server = .; database = OrnekProjeDb; Integrated Security=True";

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }

    }
}