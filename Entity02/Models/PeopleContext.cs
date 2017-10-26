using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entity02.Models
{
    public class PeopleContext: DbContext
    {
        static PeopleContext()
        {
            Database.SetInitializer<PeopleContext>(new PeopleContextInitializer());
        }
        public DbSet<Worker> Workers { set; get; }
        public DbSet<Company> Companyes { set; get; }

        public DbSet<Hobby> Hobbyes { set; get; }
    }
}