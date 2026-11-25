// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace SignalRServiceExtension.Tests.Samples
{
    public static class AuthenticationRefresh
    {
        #region Snippet:AuthenticationRefreshConfigure
        public static void ConfigureAuthentication(
            IServiceCollection services,
            Action<TokenValidationParameters> configureTokenValidation)
        {
            services.AddDefaultAuth(configureTokenValidation, (token, _, connection) =>
            {
                var userId = token.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrWhiteSpace(userId))
                {
                    throw new SecurityTokenValidationException("The validated token does not identify a user.");
                }

                connection.UserId = userId;
                connection.Claims = token.Principal.FindAll(ClaimTypes.Role).ToList();
                return connection;
            });
        }
        #endregion

        #region Snippet:AuthenticationRefresh
        [FunctionName("Negotiate")]
        public static IActionResult Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "chat/negotiate")] HttpRequest req,
            [SignalRConnectionInfo(
                HubName = "chat",
                EnableAuthenticationRefresh = true,
                CloseOnAuthenticationExpiration = true,
                TokenLifetimeSeconds = 3600)] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo is null ? new UnauthorizedResult() : new OkObjectResult(connectionInfo);
        }

        [FunctionName("Refresh")]
        public static IActionResult Refresh(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "chat/refresh")] HttpRequest req,
            [SignalRRefresh(
                HubName = "chat",
                TokenLifetimeSeconds = 3600)] SignalRRefreshResult result)
        {
            return result.Status switch
            {
                SignalRRefreshStatus.Succeeded => new OkObjectResult(result.ConnectionInfo),
                SignalRRefreshStatus.MissingConnectionToken => new BadRequestResult(),
                SignalRRefreshStatus.Unauthorized => new UnauthorizedResult(),
                SignalRRefreshStatus.Forbidden => new StatusCodeResult(StatusCodes.Status403Forbidden),
                SignalRRefreshStatus.ConnectionNotFound => new NotFoundResult(),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError),
            };
        }
        #endregion
    }
}
