using Core.Entities.Concrete;
using Core.Utilities.Security.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security;

public interface IUserService
{
    /// <summary>
    ///     Get Account Id
    /// </summary>
    Guid UserId { get; }


    /// <summary>
    ///     User is Authenticated
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    ///     Get User FullName
    /// </summary>
    string FullName { get; }

    UserInfo UserInfo { get; }

    /// <summary>
    ///     Get User Rules
    /// </summary>
    /// <returns></returns>
    List<OperationClaim> Rules();
}
