using mta_SingleDb_Lib.Entities;
using mta_SingleDb_Lib.Services.TenantService.DTOs;
using mta_SingleDb_Lib.Models;

namespace mta_SingleDb_Lib.Services.TenantService
{
    public class TenantService : ITenantService
    {
        private readonly TenantDbContext _context;

        public TenantService(TenantDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant> CreateTenant(CreateTenantRequest request)
        {
            // Khởi tạo một Tenant mới
            var newTenant = new Tenant
            {
                Id = Guid.NewGuid(), // Tạo GUID mới cho tenant
                Name = request.Name,
                Owner = Guid.NewGuid(), // Hoặc sử dụng một giá trị thực tế cho Owner
                OwnerName = "Default Owner", // Thay thế bằng tên chủ sở hữu thực tế
                Description = "New tenant created", // Mô tả tùy chọn
                CreatedDate = DateTime.UtcNow, // Thời gian tạo
                IsWorkSpacePersonal = false // Hoặc true, tùy thuộc vào logic của bạn
            };

            // Thêm Tenant mới vào DbContext và lưu
            await _context.Tenants.AddAsync(newTenant);
            await _context.SaveChangesAsync();

            return newTenant;
        }
    }
}