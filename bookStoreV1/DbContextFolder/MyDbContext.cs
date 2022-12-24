using bookStoreV1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookStoreV1.DbContextFolder
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options ) : base( options )
        {

        }


        public DbSet<Book> Books { get; set; }
    }
}
