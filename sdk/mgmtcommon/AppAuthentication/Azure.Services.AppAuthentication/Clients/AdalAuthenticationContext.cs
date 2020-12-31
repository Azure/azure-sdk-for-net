// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Uses ADAL to get tokens. Used for Integrated Windows Authentication and Client Credentials flow (client secret and certificates). 
    /// </summary>
    internal class AdalAuthenticationContext : IAuthenticationContext
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Create a context without an HTTP factory
        /// </summary>
        public AdalAuthenticationContext()
        {
        }

        /// <summary>
        /// Create a context with an HTTP factory
        /// </summary>
        /// <param name="httpClientFactory">Null is allowed</param>
        public AdalAuthenticationContext(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Used to get authentication result for Integrated Windows Authentication scenario. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientId"></param>
        /// <param name="userCredential"></param>
        /// <returns></returns>
        public async Task<AppAuthenticationResult> AcquireTokenAsync(string authority, string resource, string clientId, UserCredential userCredential)
        {
            var authenticationContext = GetAuthenticationContext(authority);
            var authResult = await authenticationContext.AcquireTokenAsync(resource, clientId, userCredential).ConfigureAwait(false);
            return AppAuthenticationResult.Create(authResult);
        }

        /// <summary>
        /// Used to get authentication result for Integrated Windows Authentication scenario, where the token may already be in ADAL cache. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<AppAuthenticationResult> AcquireTokenSilentAsync(string authority, string resource, string clientId)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(authority);
            var authResult = await authenticationContext.AcquireTokenSilentAsync(resource, clientId).ConfigureAwait(false);
            return AppAuthenticationResult.Create(authResult);
        }

        /// <summary>
        /// Used to get authentication result for client credentials flow using a client secret. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientCredential"></param>
        /// <returns></returns>
        public async Task<AppAuthenticationResult> AcquireTokenAsync(string authority, string resource, ClientCredential clientCredential)
        {
            var authenticationContext = GetAuthenticationContext(authority);
            var authResult = await authenticationContext.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
            return AppAuthenticationResult.Create(authResult);
        }

        /// <summary>
        /// Used to get authentication for client credentials flow using a client certificate. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientCertificate"></param>
        /// <returns></returns>
        public async Task<AppAuthenticationResult> AcquireTokenAsync(string authority, string resource, IClientAssertionCertificate clientCertificate)
        {
            var authenticationContext = GetAuthenticationContext(authority);
            var authResult = await authenticationContext.AcquireTokenAsync(resource, clientCertificate, true).ConfigureAwait(false);
            return AppAuthenticationResult.Create(authResult);
        }

        /// <summary>
        /// Creates the ADAL authentication context
        /// </summary>
        /// <param name="authority"></param>
        /// <returns></returns>
        private AuthenticationContext GetAuthenticationContext(string authority)
        {
            return _httpClientFactory == null
                ? new AuthenticationContext(authority)
                : new AuthenticationContext(authority, true, TokenCache.DefaultShared, _httpClientFactory);
        }
    }
}
