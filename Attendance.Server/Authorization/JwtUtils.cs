using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Attendance.Server.Models;
using Attendance.Shared.Interfaces;
using Attendance.Shared.Models;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Attendance.Server.Authorization;

public class JwtUtils : IJwtUtils
{
    private readonly AppSettings _appSettings;
    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var tokenHanlder = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHanlder.CreateToken(tokenDescriptor);
        return tokenHanlder.WriteToken(token);
    }

    public int? ValidateToken(string token)
    {
        if (token is null) return null;
        var tokenHanlder = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);

        try
        {
            tokenHanlder.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x =>
                x.Type == "id").Value);

            return userId;
        }
        catch
        {
            return null;
        }
    }
}