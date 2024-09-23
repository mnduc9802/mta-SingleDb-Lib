using System.Collections.Generic;
using System.Threading.Tasks;
using mta_SingleDb_Lib.Entities;
using mta_SingleDb_Lib.Services.TenantMemberService.DTOs;

namespace Services.TenantMemberService
{
    public interface ITenantMemberService
    {
        Task<IEnumerable<TenantMember>> GetAllMembers(Guid tenantId);
        Task<TenantMember> CreateMember(CreateTenantMemberRequest request);
        Task<bool> DeleteMember(Guid id);
    }
}