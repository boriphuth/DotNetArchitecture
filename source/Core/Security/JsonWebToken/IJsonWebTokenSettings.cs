using Microsoft.IdentityModel.Tokens;
using System;

namespace Solution.Core.Security
{
    public interface IJsonWebTokenSettings
    {
        string Audience { get; }

        DateTime Expires { get; }

        string Issuer { get; }

        string Key { get; }

        SecurityKey SecurityKey { get; }

        SigningCredentials SigningCredentials { get; }
    }
}
