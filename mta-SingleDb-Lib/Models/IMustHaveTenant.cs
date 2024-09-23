namespace mta_SingleDb_Lib.Models
{
    public interface IMustHaveTenant
    {
        Guid TenantId { get; set; }
    }
}