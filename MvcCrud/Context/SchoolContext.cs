using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MvcCrud.Models;

namespace MvcCrud.Context
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students {get; set;}
    }
}
