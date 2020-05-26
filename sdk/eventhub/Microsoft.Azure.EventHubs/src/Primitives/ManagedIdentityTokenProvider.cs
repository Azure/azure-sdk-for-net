// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Threading.Tasks;
    using Azure.Services.AppAuthentication;

    /// <summary>
    /// Represents the Azure Active Directory token provider for Azure Managed Identity integration.
    /// </summary>
    public class ManagedIdentityTokenProvider : TokenProvider
    {
        readonly AzureServiceTokenProvider azureServiceTokenProvider;

        /// <summary>
        /// Initializes new instance of <see cref="ManagedIdentityTokenProvider"/> class with default <see cref="AzureServiceTokenProvider"/> configuration.
        /// </summary>
        public ManagedIdentityTokenProvider() : this(new AzureServiceTokenProvider()){}

        /// <summary>
        /// Initializes new instance of <see cref="ManagedIdentityTokenProvider"/> class with <see cref="AzureServiceTokenProvider"/>.
        /// </summary>
        /// <param name="azureServiceTokenProvider">The <see cref="AzureServiceTokenProvider"/> to be used to fetch access tokens.</param>
        public ManagedIdentityTokenProvider(AzureServiceTokenProvider azureServiceTokenProvider)
        {
            this.azureServiceTokenProvider = azureServiceTokenProvider;
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override async Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync(ClientConstants.EventHubsAudience).ConfigureAwait(false);
            return new JsonSecurityToken(accessToken, appliesTo);
        }
    }
}
