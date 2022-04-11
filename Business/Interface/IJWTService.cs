using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;

namespace reposbackend.Business.Interface
{
    public interface IJWTService
    {
        JsonWebToken CreateJsonWebToken(IEnumerable<Claim> claims);
    }
}