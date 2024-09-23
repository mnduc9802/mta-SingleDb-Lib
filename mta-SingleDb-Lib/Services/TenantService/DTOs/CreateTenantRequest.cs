using System;
using System.ComponentModel.DataAnnotations;

namespace mta_SingleDb_Lib.Services.TenantService.DTOs
{
    public class CreateTenantRequest
    {
        [Required]
        public string Name { get; set; }

        // Thêm thông tin chủ sở hữu nếu cần
        [Required]
        public Guid OwnerId { get; set; } // ID của người sở hữu tenant

        public string OwnerName { get; set; } // Tên của người sở hữu

        public string Description { get; set; } // Mô tả tenant

        public bool IsWorkSpacePersonal { get; set; } // Có phải là không gian làm việc cá nhân không?
    }
}