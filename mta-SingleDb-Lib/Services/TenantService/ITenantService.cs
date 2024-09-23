using mta_SingleDb_Lib.Entities;
using mta_SingleDb_Lib.Services.TenantService.DTOs;

namespace mta_SingleDb_Lib.Services.TenantService
{
    public interface ITenantService
    {
        Task<Tenant> CreateTenant(CreateTenantRequest request);
    }
}