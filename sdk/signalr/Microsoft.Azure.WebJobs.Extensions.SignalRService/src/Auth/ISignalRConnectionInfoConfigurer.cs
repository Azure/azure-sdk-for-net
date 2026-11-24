// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    ///  A configuration abstraction for configuring SignalR connection information
    /// </summary>
    public interface ISignalRConnectionInfoConfigurer
    {
        /// <summary>
        /// Configuring SignalR access token from a given Azure function access token result, http request, SignalR connection detail, and return a new SignalR connection detail for generating access token to access SignalR service.
        /// </summary>
        /// <remarks>
        /// The callback can throw <see cref="SecurityTokenValidationException"/> to reject the authenticated identity.
        /// </remarks>
        Func<SecurityTokenResult, HttpRequest, SignalRConnectionDetail, SignalRConnectionDetail> Configure { get; set; }
    }

    internal static class SignalRConnectionInfoConfigurerExtensions
    {
        internal static SignalRConnectionDetail ConfigureAuthenticatedConnection(
            this ISignalRConnectionInfoConfigurer configurer,
            SecurityTokenResult token,
            HttpRequest request,
            SignalRConnectionDetail connection)
        {
            var configure = configurer?.Configure;
            try
            {
                return configure?.Invoke(token, request, connection) ?? connection;
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }
        }
    }
}