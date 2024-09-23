using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mta_SingleDb_Lib.Entities
{
    public class Tenant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Sử dụng UUID tự động
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }  // UUID cho PostgreSQL

        [Required]
        [Column(TypeName = "text")]
        public string Name { get; set; }  // Tên của tenant (kiểu text)

        [Required]
        [Column(TypeName = "uuid")]
        public Guid Owner { get; set; }  // UUID của chủ sở hữu tenant

        [Required]
        [Column(TypeName = "text")]
        public string OwnerName { get; set; }  // Tên chủ sở hữu tenant

        [Column(TypeName = "text")]
        public string Description { get; set; }  // Mô tả tenant

        [Column(TypeName = "timestamp")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;  // Ngày tạo tenant

        [Column(TypeName = "boolean")]
        public bool IsWorkSpacePersonal { get; set; }  // Tenant có phải là không gian làm việc cá nhân không?
    }
}