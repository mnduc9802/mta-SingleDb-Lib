using Microsoft.EntityFrameworkCore;
using mta_SingleDb_Lib.Entities;
using mta_SingleDb_Lib.Services;

namespace mta_SingleDb_Lib.Models
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentTenantService _currentTenantService;

        public Guid CurrentTenantId { get; set; } // Thay đổi kiểu dữ liệu thành Guid

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentTenantService currentTenantService)
            : base(options)
        {
            _currentTenantService = currentTenantService;
            CurrentTenantId = _currentTenantService.TenantId ?? Guid.Empty; // Gán giá trị Guid
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantMember> TenantMembers { get; set; } // Thêm DbSet cho TenantMember

        // On App Startup
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TenantMember>().HasQueryFilter(a => a.TenantId == CurrentTenantId); // Cập nhật bộ lọc cho TenantMember
        }

        // Save Changes
        public override int SaveChanges()
        {
            if (CurrentTenantId == Guid.Empty)
            {
                throw new InvalidOperationException("Current tenant ID is not set.");
            }

            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = CurrentTenantId; // Gán CurrentTenantId cho TenantId
                        break;
                }
            }

            var result = base.SaveChanges();
            return result;
        }
    }
}