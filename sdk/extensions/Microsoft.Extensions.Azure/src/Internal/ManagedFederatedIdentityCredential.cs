// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;

namespace Microsoft.Extensions.Azure.Internal
{
    internal class ManagedFederatedIdentityCredential : TokenCredential
    {
        private readonly ManagedIdentityCredential _managedIdentityCredential;
        private readonly ClientAssertionCredential _clientAssertionCredential;

        /// <summary>
        ///   Gets the set of additionally allowed tenants.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; }
        /// <summary>
        /// Creates an instance of the ManagedFederatedIdentityCredential with a synchronous callback that provides a signed client assertion to authenticate against Microsoft Entra ID.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal.</param>
        /// <param name="managedIdentityClientId">The managed identity which has been configured as a Federated Identity Credential (FIC).</param>
        /// <param name="federatedAudience">
        ///     The audience for the federated credential, specific to the cloud.  Valid values are:
        ///       <list type="bullet">
        ///         <item>
        ///           <term>api://AzureADTokenExchange</term>
        ///           <description>Entra ID Global cloud</description>
        ///         </item>
        ///         <item>
        ///           <term>api://AzureADTokenExchangeUSGov</term>
        ///           <description>Entra ID US Government</description>
        ///         </item>
        ///         <item>
        ///           <term>api://AzureADTokenExchangeChina</term>
        ///           <description>Entra ID China operated by 21Vianet</description>
        ///         </item>
        ///       </list>
        /// </param>
        /// <param name="additionallyAllowedTenants">The set of </param>
        public ManagedFederatedIdentityCredential(string tenantId, string clientId, string managedIdentityClientId, string federatedAudience, IEnumerable<string> additionallyAllowedTenants = default)
        {
            ClientAssertionCredentialOptions clientAssertionOptions = null;

            if (additionallyAllowedTenants != null)
            {
                clientAssertionOptions = new();

                foreach (var tenant in additionallyAllowedTenants)
                {
                    clientAssertionOptions.AdditionallyAllowedTenants.Add(tenant);
                }

                AdditionallyAllowedTenants = clientAssertionOptions.AdditionallyAllowedTenants;
            }
            else
            {
                AdditionallyAllowedTenants = new List<string>();
            }

            _managedIdentityCredential = new ManagedIdentityCredential(managedIdentityClientId);
            _clientAssertionCredential = new ClientAssertionCredential(
                tenantId,
                clientId,
                async token =>
                    (await _managedIdentityCredential
                        .GetTokenAsync(new TokenRequestContext([$"{federatedAudience}/.default"]))
                        .ConfigureAwait(false))
                    .Token,
                clientAssertionOptions
            );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedFederatedIdentityCredential"/> class.
        /// </summary>
        protected ManagedFederatedIdentityCredential()
        {
        }

        /// <summary>
        /// Gets an <see cref="T:Azure.Core.AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="T:Azure.Core.TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to use.</param>
        /// <returns>
        /// A valid <see cref="T:Azure.Core.AccessToken" />.
        /// </returns>
        /// <remarks>
        /// Caching and management of the lifespan for the <see cref="T:Azure.Core.AccessToken" /> is considered the responsibility of the caller: each call should request a fresh token being requested.
        /// </remarks>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => _clientAssertionCredential.GetToken(requestContext, cancellationToken);

        /// <summary>
        /// Gets an <see cref="T:Azure.Core.AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="T:Azure.Core.TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to use.</param>
        /// <returns>
        /// A valid <see cref="T:Azure.Core.AccessToken" />.
        /// </returns>
        /// <remarks>
        /// Caching and management of the lifespan for the <see cref="T:Azure.Core.AccessToken" /> is considered the responsibility of the caller: each call should request a fresh token being requested.
        /// </remarks>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) => _clientAssertionCredential.GetTokenAsync(requestContext, cancellationToken);
    }
}
