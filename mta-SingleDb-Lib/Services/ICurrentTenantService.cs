namespace mta_SingleDb_Lib.Services
{
    public interface ICurrentTenantService
    {
        Guid? TenantId { get; set; }
        Task<bool> SetTenant(string tenant);
    }
}