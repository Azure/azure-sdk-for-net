// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private readonly TokenRequestContext _tokenContext;

        /// <summary>
        /// Gets the set of additionally allowed tenants.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; }

        /// <summary>
        /// Creates an instance of the ManagedFederatedIdentityCredential with a synchronous callback that provides a signed client assertion to authenticate against Microsoft Entra ID.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal.</param>
        /// <param name="managedIdentityId">The managed identity which has been configured as a Federated Identity Credential (FIC).  May be a client id, resource id, or object id.</param>
        /// <param name="azureCloud">
        ///     The name of the cloud where the managed identity is configured.  Valid values are:
        ///       <list type="bullet">
        ///         <item>
        ///           <term>public</term>
        ///           <description>Entra ID Global cloud</description>
        ///         </item>
        ///         <item>
        ///           <term>usgov</term>
        ///           <description>Entra ID US Government</description>
        ///         </item>
        ///         <item>
        ///           <term>china</term>
        ///           <description>Entra ID China operated by 21Vianet</description>
        ///         </item>
        ///       </list>
        /// </param>
        /// <param name="additionallyAllowedTenants">The set of </param>
        public ManagedFederatedIdentityCredential(string tenantId, string clientId, string managedIdentityId, string azureCloud, IEnumerable<string> additionallyAllowedTenants = default)
            : this(tenantId, clientId, (object)managedIdentityId, azureCloud, additionallyAllowedTenants)
        {
        }

        /// <summary>
        /// Creates an instance of the ManagedFederatedIdentityCredential with a synchronous callback that provides a signed client assertion to authenticate against Microsoft Entra ID.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal.</param>
        /// <param name="managedIdentityId">The managed identity which has been configured as a Federated Identity Credential (FIC).  May be a client id, resource id, or object id.</param>
        /// <param name="azureCloud">
        ///     The name of the cloud where the managed identity is configured.  Valid values are:
        ///       <list type="bullet">
        ///         <item>
        ///           <term>public</term>
        ///           <description>Entra ID Global cloud</description>
        ///         </item>
        ///         <item>
        ///           <term>usgov</term>
        ///           <description>Entra ID US Government</description>
        ///         </item>
        ///         <item>
        ///           <term>china</term>
        ///           <description>Entra ID China operated by 21Vianet</description>
        ///         </item>
        ///       </list>
        /// </param>
        /// <param name="additionallyAllowedTenants">The set of </param>
        public ManagedFederatedIdentityCredential(string tenantId, string clientId, ResourceIdentifier managedIdentityId, string azureCloud, IEnumerable<string> additionallyAllowedTenants = default)
            : this(tenantId, clientId, (object)managedIdentityId, azureCloud, additionallyAllowedTenants)
        {
        }

        /// <summary>
        /// Creates an instance of the ManagedFederatedIdentityCredential with a synchronous callback that provides a signed client assertion to authenticate against Microsoft Entra ID.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal.</param>
        /// <param name="managedIdentityId">The managed identity which has been configured as a Federated Identity Credential (FIC).  May be a client id, resource id, or object id.</param>
        /// <param name="azureCloud">
        ///     The name of the cloud where the managed identity is configured.  Valid values are:
        ///       <list type="bullet">
        ///         <item>
        ///           <term>public</term>
        ///           <description>Entra ID Global cloud</description>
        ///         </item>
        ///         <item>
        ///           <term>usgov</term>
        ///           <description>Entra ID US Government</description>
        ///         </item>
        ///         <item>
        ///           <term>china</term>
        ///           <description>Entra ID China operated by 21Vianet</description>
        ///         </item>
        ///       </list>
        /// </param>
        /// <param name="additionallyAllowedTenants">The set of </param>
        public ManagedFederatedIdentityCredential(string tenantId, string clientId, ManagedIdentityId managedIdentityId, string azureCloud, IEnumerable<string> additionallyAllowedTenants = default)
            : this(tenantId, clientId, (object)managedIdentityId, azureCloud, additionallyAllowedTenants)
        {
        }

        internal ManagedFederatedIdentityCredential(string tenantId, string clientId, object managedIdentityId, string azureCloud, IEnumerable<string> additionallyAllowedTenants = default)
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

            _managedIdentityCredential = managedIdentityId switch
            {
                ManagedIdentityId objectId => new ManagedIdentityCredential(objectId),
                ResourceIdentifier resourceId => new ManagedIdentityCredential(resourceId),
                string managedClientId => new ManagedIdentityCredential(managedClientId),
                _ => throw new ArgumentException($"Invalid managed identity ID type: {managedIdentityId.GetType()}", nameof(managedIdentityId))
            };

            _tokenContext = new TokenRequestContext([TranslateCloudToTokenScope(azureCloud)]);
            _clientAssertionCredential = new ClientAssertionCredential(
                tenantId,
                clientId,
                async _ =>
                    (await _managedIdentityCredential
                        .GetTokenAsync(_tokenContext)
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

        /// <inheritdoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => _clientAssertionCredential.GetToken(requestContext, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) => _clientAssertionCredential.GetTokenAsync(requestContext, cancellationToken);

        private static string TranslateCloudToTokenScope(string azureCloud) =>
            azureCloud switch
            {
                AzureCloud.Public => "api://AzureADTokenExchange/.default",
                AzureCloud.USGov => "api://AzureADTokenExchangeUSGov/.default",
                AzureCloud.China => "api://AzureADTokenExchangeChina/.default",
                _ => throw new ArgumentException($"Unknown Azure cloud: {azureCloud}", nameof(azureCloud)),
            };
        }
}
