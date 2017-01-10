// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Rest.Azure.Authentication.Internal
{
    /// <summary>
    /// In memory store for application credentials.
    /// </summary>
    public class MemoryApplicationAuthenticationProvider : IApplicationAuthenticationProvider
    {
        private IDictionary<string, ClientCredential> _credentials;

        /// <summary>
        /// Intializes an in-memory store of application credentials
        /// </summary>
        public MemoryApplicationAuthenticationProvider()
        {
            this._credentials = new Dictionary<string, ClientCredential>();
        }

        /// <summary>
        /// Initializes an in-memory store of application credentials starting with the given credential
        /// </summary>
        /// <param name="credential"></param>
        public MemoryApplicationAuthenticationProvider(ClientCredential credential)
            : this()
        {
            AddCredential(credential);
        }

        /// <summary>
        /// Add the given credential to the in-memory store.
        /// </summary>
        /// <param name="credential">The credential to add.</param>
        public void AddCredential(ClientCredential credential)
        {
            if (!_credentials.ContainsKey(credential.ClientId))
            {
                _credentials[credential.ClientId] = credential;
            }
        }

        /// <summary>
        /// Authenticate using the credentials stored for the given client id
        /// </summary>
        /// <param name="clientId">The Application ID for this service principal</param>
        /// <param name="audience">The intended audicne for authentication</param>
        /// <param name="context">The AD AuthenticationContext to use</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, AuthenticationContext context)
        {
            if (_credentials.ContainsKey(clientId))
            {
                var creds = _credentials[clientId];
                return await context.AcquireTokenAsync(audience, creds);
            }

            throw new AuthenticationException("Matching credentials for client id '{0}' could not be found.");
        }
    }
}
