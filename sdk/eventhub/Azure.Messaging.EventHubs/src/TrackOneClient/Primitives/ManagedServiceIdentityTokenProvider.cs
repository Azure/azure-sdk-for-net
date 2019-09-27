// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;

namespace TrackOne
{
    /// <summary>
    /// Represents the Azure Active Directory token provider for Azure Managed Service Identity integration.
    /// </summary>
    internal class ManagedServiceIdentityTokenProvider : TokenProvider
    {
        private static readonly AzureServiceTokenProvider s_azureServiceTokenProvider = new AzureServiceTokenProvider();

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override async Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            string accessToken = await s_azureServiceTokenProvider.GetAccessTokenAsync(ClientConstants.AadEventHubsAudience);
            return new JsonSecurityToken(accessToken, appliesTo);
        }
    }
}
