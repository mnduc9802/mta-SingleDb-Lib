using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mta_SingleDb_Lib.Entities;
using mta_SingleDb_Lib.Models;
using mta_SingleDb_Lib.Services;
using mta_SingleDb_Lib.Services.TenantMemberService.DTOs;

namespace Services.TenantMemberService
{
    public class TenantMemberService : ITenantMemberService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentTenantService _currentTenantService;

        public TenantMemberService(ApplicationDbContext context, ICurrentTenantService currentTenantService)
        {
            _context = context;
            _currentTenantService = currentTenantService;
        }

        public async Task<IEnumerable<TenantMember>> GetAllMembers(Guid tenantId)
        {
            return await _context.TenantMembers
                                 .Where(m => m.TenantId == tenantId)
                                 .ToListAsync();
        }

        public async Task<TenantMember> CreateMember(CreateTenantMemberRequest request)
        {
            if (string.IsNullOrEmpty(_currentTenantService.TenantId.ToString()))
            {
                throw new InvalidOperationException("Current tenant ID is not set.");
            }

            var tenantMember = new TenantMember
            {
                UserId = request.UserId,
                UserName = request.UserName,
                UserFullName = request.UserFullName,
                TenantId = _currentTenantService.TenantId.Value,
                BackupDataTenantId = request.BackupDataTenantId
            };

            await _context.TenantMembers.AddAsync(tenantMember);
            await _context.SaveChangesAsync();

            return tenantMember;
        }

        public async Task<bool> DeleteMember(Guid id)
        {
            var tenantMember = await _context.TenantMembers
                                              .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == _currentTenantService.TenantId);

            if (tenantMember != null)
            {
                _context.TenantMembers.Remove(tenantMember);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}