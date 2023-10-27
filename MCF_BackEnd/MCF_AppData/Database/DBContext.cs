using MCF_AppData.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppData.Database
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) { }

        public DbSet<Login> Login { get; set; }
    }

    public class FirstDbContext : DbContext
    {
        public FirstDbContext(DbContextOptions<FirstDbContext> options) : base(options) { }

        public DbSet<Tr_Bpkb> Tr_Bpkb { get; set; }
        public DbSet<Location> Location { get; set; }
    }

    public class SecondDbContext : DbContext
    {
        public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options) { }

        public DbSet<Tr_Bpkb> Tr_Bpkb { get; set; }
        public DbSet<Location> Location { get; set; }
    }
}
