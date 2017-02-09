// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using System.Security;
using System.Threading.Tasks;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Interface to the keystore for authentication
    /// </summary>
    internal sealed class KeyStoreApplicationCredentialProvider : IApplicationAuthenticationProvider
    {
        private string _tenantId;

        /// <summary>
        /// Create a credential provider
        /// </summary>
        /// <param name="tenant"></param>
        public KeyStoreApplicationCredentialProvider(string tenant)
        {
            this._tenantId = tenant;
        }
        
        /// <summary>
        /// Authenticate using the secret for the specified client from the key store
        /// </summary>
        /// <param name="clientId">The active directory client id for the application.</param>
        /// <param name="audience">The intended audience for authentication</param>
        /// <param name="context">The AD AuthenticationContext to use</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, AuthenticationContext context)
        {
            var task = new Task<SecureString>(() =>
            {
                return ServicePrincipalKeyStore.GetKey(clientId, _tenantId);
            });
            task.Start();
            var key = await task.ConfigureAwait(false);

            return await context.AcquireTokenAsync(audience, new ClientCredential(clientId, key));
        }
    }
}
