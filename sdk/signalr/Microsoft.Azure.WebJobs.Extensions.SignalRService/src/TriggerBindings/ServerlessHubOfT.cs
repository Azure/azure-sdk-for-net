// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "https://github.com/Azure/azure-sdk-for-net/issues/17164")]
    public abstract class ServerlessHub<T> where T : class
    {
        private static readonly Lazy<JwtSecurityTokenHandler> JwtSecurityTokenHandler = new(() => new JwtSecurityTokenHandler());

        protected ServiceHubContext<T> HubContext { get; }

        internal ServerlessHub(ServiceHubContext<T> serviceHubContext = null)
        {
            if (serviceHubContext is null)
            {
                serviceHubContext = (StaticServiceHubContextStore.Get() as IInternalServiceHubContextStore).GetAsync<T>(GetType().Name).EnsureCompleted();
            }
            HubContext = serviceHubContext;
        }

        /// <summary>
        /// Gets client endpoint access information object for SignalR hub connections to connect to Azure SignalR Service
        /// </summary>
        protected async ValueTask<SignalRConnectionInfo> NegotiateAsync(NegotiationOptions options)
        {
            var negotiateResponse = await HubContext.NegotiateAsync(options).ConfigureAwait(false);
            return new SignalRConnectionInfo
            {
                Url = negotiateResponse.Url,
                AccessToken = negotiateResponse.AccessToken
            };
        }

        /// <summary>
        /// Get claim list from a JWT.
        /// </summary>
        protected static IList<Claim> GetClaims(string jwt)
        {
            if (jwt.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                jwt = jwt.Substring("Bearer ".Length).Trim();
            }
            return JwtSecurityTokenHandler.Value.ReadJwtToken(jwt).Claims.ToList();
        }
    }
}
