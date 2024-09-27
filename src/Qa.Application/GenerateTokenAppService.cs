using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Qa
{
    public class GenerateTokenAppService: ApplicationService
    {
        private readonly IOptionsMonitor<OpenIddictServerOptions> _oidcOptions;
        private readonly IdentityUserManager _userManager;

        public GenerateTokenAppService(IOptionsMonitor<OpenIddictServerOptions> oidcOptions, IdentityUserManager userManager)
        {
            _oidcOptions = oidcOptions;
            _userManager = userManager;
        }
        public async Task<string> TokenAsync()
        {

            var user = await _userManager.FindByNameAsync("admin");
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>()
        {
            new Claim("sub", user.Id.ToString()),
            new Claim("given_name", user.UserName),
            new Claim("email", user.Email),
            new Claim("tenantid", user.TenantId?.ToString() ?? ""),
            new Claim("scope", "address email phone roles profile offline_access Qa") //replace Qa with yours
        };

            claims.AddRange(roles.Select(role => new Claim("role", role)));
            var options = _oidcOptions.CurrentValue;
            var descriptor = new SecurityTokenDescriptor
            {
                Audience = "JWTSecureApiClient", 
                EncryptingCredentials = options.DisableAccessTokenEncryption
                    ? null
                    : options.EncryptionCredentials.First(),
                Expires = null,
                Subject = new ClaimsIdentity(claims, TokenValidationParameters.DefaultAuthenticationType),
                IssuedAt = DateTime.UtcNow,
                Issuer = "https://localhost:44356/", 
                SigningCredentials = options.SigningCredentials.First(),
                TokenType = OpenIddictConstants.JsonWebTokenTypes.Jwt,
            };

            var accessToken = options.JsonWebTokenHandler.CreateToken(descriptor);

            return accessToken;
        }

        [Authorize]
        public Task<string> TestTokenAsync()
        {
            return Task.FromResult(CurrentUser.UserName!);
        }
    }
}
