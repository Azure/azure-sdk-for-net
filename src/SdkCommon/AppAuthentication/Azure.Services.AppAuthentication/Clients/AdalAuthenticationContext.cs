// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Uses ADAL to get tokens. Used for Integrated Windows Authentication and Client Credentials flow (client secret and certificates). 
    /// </summary>
    internal class AdalAuthenticationContext : IAuthenticationContext
    {
        /// <summary>
        /// Used to get token for Integrated Windows Authentication scenario. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientId"></param>
        /// <param name="userCredential"></param>
        /// <returns></returns>
        public async Task<string> AcquireTokenAsync(string authority, string resource, string clientId, UserCredential userCredential)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(authority);
            var result = await authenticationContext.AcquireTokenAsync(resource, clientId, userCredential).ConfigureAwait(false);
            return result.AccessToken;
        }

        /// <summary>
        /// Used to get token for Integrated Windows Authentication scenario, where the token may already be in ADAL cache. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<string> AcquireTokenSilentAsync(string authority, string resource, string clientId)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(authority);
            var result = await authenticationContext.AcquireTokenSilentAsync(resource, clientId).ConfigureAwait(false);
            return result.AccessToken;
        }

        /// <summary>
        /// Used to get token for client credentials flow using a client secret. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientCredential"></param>
        /// <returns></returns>
        public async Task<string> AcquireTokenAsync(string authority, string resource, ClientCredential clientCredential)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(authority);
            var authResult = await authenticationContext.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
            return authResult.AccessToken;
        }

        /// <summary>
        /// Used to get token for client credentials flow using a client certificate. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientCertificate"></param>
        /// <returns></returns>
        public async Task<string> AcquireTokenAsync(string authority, string resource, IClientAssertionCertificate clientCertificate)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(authority);
            var result = await authenticationContext.AcquireTokenAsync(resource, clientCertificate).ConfigureAwait(false);
            return result.AccessToken;
        }
    }
}
