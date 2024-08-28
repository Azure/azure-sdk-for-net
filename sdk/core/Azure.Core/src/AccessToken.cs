// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;

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
        }

        /// <summary>
        /// Creates a new instance of <see cref="AccessToken"/> using the provided <paramref name="accessToken"/> and <paramref name="expiresOn"/>.
        /// </summary>
        /// <param name="accessToken">The bearer access token value.</param>
        /// <param name="expiresOn">The bearer access token expiry date.</param>
        /// <param name="refreshOn">Specifies the time when the cached token should be proactively refreshed.</param>
        public AccessToken(string accessToken, DateTimeOffset expiresOn, DateTimeOffset? refreshOn)
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
        /// Gets the time when the token should be refreshed.
        /// </summary>
        public DateTimeOffset? RefreshOn { get; }

        /// <summary>
        /// Converts this <see cref="AccessToken"/> to a <see cref="Credential"/>.
        /// </summary>
        public Credential ToCredential()
        {
            return new Credential(Token, "Bearer", ExpiresOn);
        }

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
