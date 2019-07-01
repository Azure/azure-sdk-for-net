// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using client secret
    /// details configured in the following environment variables:
    /// - AZURE_TENANT_ID: The Azure Active Directory tenant(directory) ID.
    /// - AZURE_CLIENT_ID: The client(application) ID of an App Registration in the tenant.
    /// - AZURE_CLIENT_SECRET: A client secret that was generated for the App Registration.
    /// This credential ultimately uses a <see cref="ClientSecretCredential"/> to
    /// perform the authentication using these details. Please consult the
    /// documentation of that class for more details.
    /// </summary>
    public class EnvironmentCredential : TokenCredential
    {
        private TokenCredential _credential = null;

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.  
        /// If the expected environment variables are not found at this time, the GetToken method will return the default <see cref="AccessToken"/> when invoked.
        /// </summary>
        public EnvironmentCredential()
            : this(null)
        {
        }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.  
        /// If the expected environment variables are not found at this time, the GetToken method will return the default <see cref="AccessToken"/> when invoked.
        /// </summary>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public EnvironmentCredential(IdentityClientOptions options)
        {
            string tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            string clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

            if (tenantId != null && clientId != null && clientSecret != null)
            {
                _credential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);
            }
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables 
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET to authenticate.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specified, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return (_credential != null) ? _credential.GetToken(scopes, cancellationToken) : default;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables 
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET to authenticate.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specifeid, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/>.</returns>
        public async override Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return (_credential != null) ? await _credential.GetTokenAsync(scopes, cancellationToken) : default;
        }
    }
}
