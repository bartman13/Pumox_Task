using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PumoxBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace PumoxBackend.Helpers
{
    public class AuthenticationHandler
    {
        public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
        {
            private readonly IUserService _userService;

            public BasicAuthenticationHandler(
                IOptionsMonitor<AuthenticationSchemeOptions> options,
                ILoggerFactory logger,
                UrlEncoder encoder,
                ISystemClock clock,
                IUserService userService)
                : base(options, logger, encoder, clock)
            {
                _userService = userService;
            }
            protected override Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                bool authResult;
                try
                {
                    var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                    var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                    var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                    var username = credentials[0];
                    var password = credentials[1];
                    authResult =  _userService.Authenticate(username, password);
                }
                catch
                {
                    return  Task.Run(() => AuthenticateResult.Fail("Error Occured.Authorization failed."));
                }

                if (! authResult)
                    return Task.Run(() => AuthenticateResult.Fail("Invalid Credentials"));
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "user"),
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return  Task.Run(() => AuthenticateResult.Success(ticket));
            }
        }
    }
}