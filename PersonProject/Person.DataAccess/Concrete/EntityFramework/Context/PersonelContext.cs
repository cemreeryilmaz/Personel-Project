using Microsoft.EntityFrameworkCore;
using Person.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.DataAccess.Concrete.EntityFramework.Context
{
    public class PersonelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CEMRE\SQLEXPRESS;initial catalog=Personel;integrated security=true;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        public DbSet<Personel> Personels { get; set; }
    }
}
