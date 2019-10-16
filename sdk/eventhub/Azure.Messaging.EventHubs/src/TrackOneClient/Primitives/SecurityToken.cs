// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>
    /// Provides information about a security token such as audience, expiry time, and the string token value.
    /// </summary>
    internal class SecurityToken
    {
        /// <summary>
        /// Token literal
        /// </summary>
        private readonly string _token;

        /// <summary>
        /// Token type
        /// </summary>
        private readonly string _tokenType;

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

            _token = tokenString;
            ExpiresAtUtc = expiresAtUtc;
            Audience = audience;
            _tokenType = tokenType;
        }

        /// <summary>
        /// Gets the audience of this token.
        /// </summary>
        public string Audience { get; }

        /// <summary>
        /// Gets the expiration time of this token.
        /// </summary>
        public DateTime ExpiresAtUtc { get; }

        /// <summary>
        /// Gets the actual token.
        /// </summary>
        public virtual string TokenValue => _token;

        /// <summary>
        /// Gets the token type.
        /// </summary>
        public virtual string TokenType => _tokenType;
    }
}
