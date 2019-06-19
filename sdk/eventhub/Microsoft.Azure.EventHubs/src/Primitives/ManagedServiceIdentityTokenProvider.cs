// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Threading.Tasks;
    using Azure.Services.AppAuthentication;

    /// <summary>
    /// Represents the Azure Active Directory token provider for Azure Managed Service Identity integration.
    /// </summary>
    public class ManagedServiceIdentityTokenProvider : TokenProvider
    {
        static readonly AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override async Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync(ClientConstants.AadEventHubsAudience);
            return new JsonSecurityToken(accessToken, appliesTo);
        }
    }
}
