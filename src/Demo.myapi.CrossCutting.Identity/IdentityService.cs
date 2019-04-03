using Microsoft.AspNetCore.Http;
using Demo.myapi.BusinessLogic.Interfaces;

namespace Demo.myapi.CrossCutting.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            //return this._httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == "nameidentifier").Value;
            return "admin";
        }
    }
}
