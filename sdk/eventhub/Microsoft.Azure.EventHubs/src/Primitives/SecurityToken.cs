// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>
    /// Provides information about a security token such as audience, expiry time, and the string token value.
    /// </summary>
    public class SecurityToken
    {
        /// <summary>
        /// Token literal
        /// </summary>
        readonly string token;

        /// <summary>
        /// Expiry date-time
        /// </summary>
        readonly DateTime expiresAtUtc;
        
        /// <summary>
        /// Token audience
        /// </summary>
        readonly string audience;

        /// <summary>
        /// Token type
        /// </summary>
        readonly string tokenType;

        /// <summary>
        /// Creates a new instance of the <see cref="SecurityToken"/> class.
        /// </summary>
        /// <param name="tokenString">The token</param>
        /// <param name="expiresAtUtc">The expiration time</param>
        /// <param name="audience">The audience</param>
        /// <param name="tokenType">The type of the token</param>
        public SecurityToken(string tokenString, DateTime expiresAtUtc, string audience, string tokenType)
        {
            if (string.IsNullOrEmpty(tokenString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(tokenString));
            }

            if (string.IsNullOrEmpty(audience))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(audience));
            }

            this.token = tokenString;
            this.expiresAtUtc = expiresAtUtc;
            this.audience = audience;
            this.tokenType = tokenType;
        }

        /// <summary>
        /// Gets the audience of this token.
        /// </summary>
        public string Audience => this.audience;

        /// <summary>
        /// Gets the expiration time of this token.
        /// </summary>
        public DateTime ExpiresAtUtc => this.expiresAtUtc;

        /// <summary>
        /// Gets the actual token.
        /// </summary>
        public virtual string TokenValue => this.token;

        /// <summary>
        /// Gets the token type.
        /// </summary>
        public virtual string TokenType => this.tokenType;
    }
}
