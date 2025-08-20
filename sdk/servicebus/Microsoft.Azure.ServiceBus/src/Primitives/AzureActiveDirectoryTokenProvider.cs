// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the Azure Active Directory token provider for the Service Bus.
    /// </summary>
    public class AzureActiveDirectoryTokenProvider : TokenProvider
    {
        readonly string authority;
        readonly object authCallbackState;
        event AuthenticationCallback AuthCallback;

        public delegate Task<string> AuthenticationCallback(string audience, string authority, object state);

        public AzureActiveDirectoryTokenProvider(AuthenticationCallback authenticationCallback, string authority, object state)
        {
            this.AuthCallback = authenticationCallback ?? throw Fx.Exception.ArgumentNull(nameof(authenticationCallback));
            this.authority = authority ?? throw Fx.Exception.ArgumentNull(nameof(authority));
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
            var tokenString = await this.AuthCallback(Constants.AadServiceBusAudience, this.authority, this.authCallbackState).ConfigureAwait(false);
            return new JsonSecurityToken(tokenString, appliesTo);
        }
    }
}