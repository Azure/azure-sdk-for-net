// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the Azure Active Directory token provider for the Service Bus.
    /// </summary>
    public class AzureActiveDirectoryTokenProvider : TokenProvider
    {
        private readonly string _authority;
        private readonly object _authCallbackState;
        private event AuthenticationCallback AuthCallback;

        /// <summary>
        ///
        /// </summary>
        /// <param name="audience"></param>
        /// <param name="authority"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public delegate Task<string> AuthenticationCallback(string audience, string authority, object state);

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureActiveDirectoryTokenProvider"/> class.
        /// </summary>
        /// <param name="authenticationCallback"></param>
        /// <param name="authority"></param>
        /// <param name="state"></param>
        public AzureActiveDirectoryTokenProvider(AuthenticationCallback authenticationCallback, string authority, object state)
        {
            this.AuthCallback = authenticationCallback ?? throw Fx.Exception.ArgumentNull(nameof(authenticationCallback));
            this._authority = authority ?? throw Fx.Exception.ArgumentNull(nameof(authority));
            this._authCallbackState = state;
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override async Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            var tokenString = await this.AuthCallback(Constants.AadServiceBusAudience, this._authority, this._authCallbackState).ConfigureAwait(false);
            return new JsonSecurityToken(tokenString, appliesTo);
        }
    }
}
