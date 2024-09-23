using System;
using System.ComponentModel.DataAnnotations;

namespace mta_SingleDb_Lib.Services.TenantMemberService.DTOs
{
    public class CreateTenantMemberRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserFullName { get; set; }

        [Required]
        public Guid TenantId { get; set; }

        public bool BackupDataTenantId { get; set; } // Nếu cần thiết, bạn có thể thêm thuộc tính này
    }
}