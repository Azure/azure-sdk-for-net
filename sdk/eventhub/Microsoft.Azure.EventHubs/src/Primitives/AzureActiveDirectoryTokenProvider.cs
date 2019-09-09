// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Represents the Azure Active Directory token provider for the Event Hubs.
    /// </summary>
    public class AzureActiveDirectoryTokenProvider : TokenProvider
    {
        readonly string clientId;
        readonly object authCallbackState;
        readonly string authority;
        event AuthenticationCallback AuthCallback;

        internal AzureActiveDirectoryTokenProvider(AuthenticationCallback authenticationCallback, string authority, object state)
        {
            this.clientId = Guid.NewGuid().ToString();
            this.authority = authority;
            this.AuthCallback = authenticationCallback;
            this.authCallbackState = state;
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override async Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            var token = await this.AuthCallback(ClientConstants.EventHubsAudience, this.authority, this.authCallbackState).ConfigureAwait(false);

            return new JsonSecurityToken(token, appliesTo);
        }

        /// <summary>
        /// The authentication delegate to provide access token.
        /// </summary>
        /// <param name="audience">The service resource URI for token acquisition.</param>
        /// <param name="authority">Address of the authority to issue token.</param>
        /// <param name="state">State to be delivered to callback.</param>
        /// <returns></returns>
        public delegate Task<string> AuthenticationCallback(string audience, string authority, object state);
    }
}