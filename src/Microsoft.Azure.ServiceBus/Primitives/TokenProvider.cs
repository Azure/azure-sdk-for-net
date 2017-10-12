// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This abstract base class can be extended to implement additional token providers.
    /// </summary>
    internal abstract class TokenProvider
    {
        internal static readonly TimeSpan DefaultTokenTimeout = TimeSpan.FromMinutes(60);
        internal static readonly Func<string, byte[]> MessagingTokenProviderKeyEncoder = Encoding.UTF8.GetBytes;
        const TokenScope DefaultTokenScope = TokenScope.Entity;

        /// <summary></summary>
        protected TokenProvider()
            : this(TokenProvider.DefaultTokenScope)
        {
        }

        /// <summary></summary>
        /// <param name="tokenScope"></param>
        protected TokenProvider(TokenScope tokenScope)
        {
            this.TokenScope = tokenScope;
            this.ThisLock = new object();
        }

        /// <summary>
        /// Gets the scope or permissions associated with the token.
        /// </summary>
        public TokenScope TokenScope { get; }

        /// <summary></summary>
        protected object ThisLock { get; }

        /// <summary>
        /// Construct a TokenProvider based on a sharedAccessSignature.
        /// </summary>
        /// <param name="sharedAccessSignature">The shared access signature</param>
        /// <returns>A TokenProvider initialized with the shared access signature</returns>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string sharedAccessSignature)
        {
            return new SharedAccessSignatureTokenProvider(sharedAccessSignature);
        }

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <returns>A TokenProvider initialized with the provided RuleId and Password</returns>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, DefaultTokenTimeout);
        }

        ////internal static TokenProvider CreateIoTTokenProvider(string keyName, string sharedAccessKey)
        ////{
        ////    return new IoTTokenProvider(keyName, sharedAccessKey, DefaultTokenTimeout);
        ////}

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenTimeToLive">The token time to live</param>
        /// <returns>A TokenProvider initialized with the provided RuleId and Password</returns>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenTimeToLive);
        }

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenScope">The tokenScope of tokens to request.</param>
        /// <returns>A TokenProvider initialized with the provided RuleId and Password</returns>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TokenScope tokenScope)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, DefaultTokenTimeout, tokenScope);
        }

        /// <summary>
        /// Construct a TokenProvider based on the provided Key Name and Shared Access Key.
        /// </summary>
        /// <param name="keyName">The key name of the corresponding SharedAccessKeyAuthorizationRule.</param>
        /// <param name="sharedAccessKey">The key associated with the SharedAccessKeyAuthorizationRule</param>
        /// <param name="tokenTimeToLive">The token time to live</param>
        /// <param name="tokenScope">The tokenScope of tokens to request.</param>
        /// <returns>A TokenProvider initialized with the provided RuleId and Password</returns>
        public static TokenProvider CreateSharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive, TokenScope tokenScope)
        {
            return new SharedAccessSignatureTokenProvider(keyName, sharedAccessKey, tokenTimeToLive, tokenScope);
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="action">The request action</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns></returns>
        public Task<SecurityToken> GetTokenAsync(string appliesTo, string action, TimeSpan timeout)
        {
            TimeoutHelper.ThrowIfNegativeArgument(timeout);
            appliesTo = this.NormalizeAppliesTo(appliesTo);
            return this.OnGetTokenAsync(appliesTo, action, timeout);
        }

        /// <summary></summary>
        /// <param name="appliesTo"></param>
        /// <param name="action"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected abstract Task<SecurityToken> OnGetTokenAsync(string appliesTo, string action, TimeSpan timeout);

        /// <summary></summary>
        /// <param name="appliesTo"></param>
        /// <returns></returns>
        protected virtual string NormalizeAppliesTo(string appliesTo)
        {
            return ServiceBusUriHelper.NormalizeUri(appliesTo, "http", true, stripPath: this.TokenScope == TokenScope.Namespace, ensureTrailingSlash: true);
        }
    }
}