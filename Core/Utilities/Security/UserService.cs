using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Options;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Security
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggedInUsers _loggedInUsers;

        public UserService(IHttpContextAccessor httpContextAccessor, LoggedInUsers loggedInUsers)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggedInUsers = loggedInUsers;
        }

        private UserInfo GetUser()
        {
            var userInfo = _httpContextAccessor?.HttpContext?.User;
            var userId = userInfo.GetUserId();

            return _loggedInUsers.UserInfo.FirstOrDefault(x => x.UserId == userId);
        }

        public UserInfo UserInfo => GetUser();

        public bool IsAuthenticated => (GetUser()?.UserId ?? Guid.Empty) != Guid.Empty;

        public Guid UserId => GetUser()?.UserId ?? Guid.Empty;

        public string FullName => GetUser()?.FullName ?? "";


        public List<OperationClaim> Rules()
        {
            return GetUser()?.Roles ?? new List<OperationClaim>();
        }
    }

}
