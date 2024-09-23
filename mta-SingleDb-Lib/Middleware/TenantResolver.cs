using Microsoft.AspNetCore.Http;
using mta_SingleDb_Lib.Services;

namespace mta_SingleDb_Lib.Middleware
{
    public class TenantResolver
    {
        private readonly RequestDelegate _next;

        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
        {
            // Kiểm tra xem tiêu đề "X-Tenant" có tồn tại không
            if (context.Request.Headers.TryGetValue("X-Tenant", out var tenantFromHeader))
            {
                // Gọi service để thiết lập tenant hiện tại
                await currentTenantService.SetTenant(tenantFromHeader);
            }

            // Tiếp tục xử lý request
            await _next(context);
        }
    }
}