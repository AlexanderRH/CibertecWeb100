using Cibertec.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cibertec.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);

        TokenValidationParameters GetValidatorParameters();
    }
}
