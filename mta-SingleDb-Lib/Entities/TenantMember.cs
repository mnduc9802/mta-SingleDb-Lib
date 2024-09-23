using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mta_SingleDb_Lib.Entities
{
    public class TenantMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "uuid")]
        public Guid UserId { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string UserFullName { get; set; }

        [Required]
        [Column(TypeName = "uuid")]
        public Guid TenantId { get; set; }

        [Column(TypeName = "boolean")]
        public bool BackupDataTenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        public Tenant Tenant { get; set; }
    }
}