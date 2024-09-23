using Microsoft.EntityFrameworkCore;
using mta_SingleDb_Lib.Entities;

namespace mta_SingleDb_Lib.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}