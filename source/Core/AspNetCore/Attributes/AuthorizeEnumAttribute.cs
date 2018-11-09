using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace Solution.Core.AspNetCore
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class AuthorizeEnumAttribute : AuthorizeAttribute
    {
        public AuthorizeEnumAttribute(params object[] roles)
        {
            Roles = string.Join(",", roles.Select(role => Enum.GetName(role.GetType(), role)));
        }
    }
}
