using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using reposbackend.Infra;

namespace reposbackend.Business.Interface
{
    public interface IJWTService
    {
        JsonWebToken CreateJsonWebToken(List<Claim> claims);
    }
}