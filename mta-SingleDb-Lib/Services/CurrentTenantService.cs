using Microsoft.EntityFrameworkCore;
using mta_SingleDb_Lib.Entities;
using mta_SingleDb_Lib.Models;

namespace mta_SingleDb_Lib.Services
{
    public class CurrentTenantService : ICurrentTenantService
    {
        private readonly TenantDbContext _context;

        public CurrentTenantService(TenantDbContext context)
        {
            _context = context;
        }

        public Guid? TenantId { get; set; } // Thay đổi kiểu dữ liệu thành Guid?

        public async Task<bool> SetTenant(string tenantName)
        {
            var tenantInfo = await _context.Tenants.FirstOrDefaultAsync(x => x.Name == tenantName);
            if (tenantInfo != null)
            {
                TenantId = tenantInfo.Id; // Gán giá trị Guid
                return true;
            }
            else
            {
                // Tạo mới tenant với GUID cho Id
                var newTenant = new Tenant
                {
                    Id = Guid.NewGuid(), // UUID mới
                    Name = tenantName,
                    Owner = Guid.NewGuid(), // UUID của chủ sở hữu
                    OwnerName = "Default Owner", // Tên chủ sở hữu thực tế
                    Description = "New tenant created", // Mô tả tùy chọn
                    CreatedDate = DateTime.UtcNow,
                    IsWorkSpacePersonal = false // Hoặc true, tùy thuộc vào logic của bạn
                };
                await AddTenantIfNotExists(newTenant);
                TenantId = newTenant.Id; // Gán giá trị Guid
                return true;
            }
        }

        private async Task AddTenantIfNotExists(Tenant newTenant)
        {
            _context.Tenants.Add(newTenant);
            await _context.SaveChangesAsync();
        }
    }
}