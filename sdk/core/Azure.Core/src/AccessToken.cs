// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Represents an Azure service bearer access token with expiry information.
    /// </summary>
    public struct AccessToken
    {
        /// <summary>
        /// Creates a new instance of <see cref="AccessToken"/> using the provided <paramref name="accessToken"/> and <paramref name="expiresOn"/>.
        /// </summary>
        /// <param name="accessToken">The bearer access token value.</param>
        /// <param name="expiresOn">The bearer access token expiry date.</param>
        public AccessToken(string accessToken, DateTimeOffset expiresOn)
        {
            Token = accessToken;
            ExpiresOn = expiresOn;
            RefreshOn = null;
        }

        /// <summary>
        /// Creates a new instance of <see cref="AccessToken"/> using the provided <paramref name="accessToken"/> and <paramref name="expiresOn"/>.
        /// </summary>
        /// <param name="accessToken">The bearer access token value.</param>
        /// <param name="expiresOn">The bearer access token expiry date.</param>
        /// <param name="refreshOn">A hint indicating when the <see cref="AccessToken"/> should be refreshed.</param>
        public AccessToken(string accessToken, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
        {
            Token = accessToken;
            ExpiresOn = expiresOn;
            RefreshOn = refreshOn;
        }

        /// <summary>
        /// Get the access token value.
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Gets the time when the provided token expires.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; }

        /// <summary>
        /// Indicates when the <see cref="AccessToken"/> should be refreshed, when set.
        /// This value should also be used as an indication of when the <see cref="AccessToken"/> can be cached.
        /// For example, if the value is less than or equal to DateTimeOffset.Now,
        /// <see cref="TokenCredential.GetToken(TokenRequestContext, System.Threading.CancellationToken)"/> or
        /// <see cref="TokenCredential.GetTokenAsync(TokenRequestContext, System.Threading.CancellationToken)"/>
        /// should always be called rather than caching the token in your own code.
        /// </summary>
        public DateTimeOffset? RefreshOn { get; set; }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is AccessToken accessToken)
            {
                return accessToken.ExpiresOn == ExpiresOn && accessToken.Token == Token;
            }

            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(Token, ExpiresOn);
        }
    }
}
