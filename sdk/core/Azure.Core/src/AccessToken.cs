// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Security.Cryptography.X509Certificates;

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
            TokenType = "Bearer";
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
            TokenType = "Bearer";
        }

        /// <summary>
        /// Creates a new instance of <see cref="AccessToken"/> using the provided <paramref name="accessToken"/> and <paramref name="expiresOn"/>.
        /// </summary>
        /// <param name="accessToken">The access token value.</param>
        /// <param name="expiresOn">The access token expiry date.</param>
        /// <param name="refreshOn">Specifies the time when the cached token should be proactively refreshed.</param>
        /// <param name="tokenType">The access token type.</param>
        public AccessToken(string accessToken, DateTimeOffset expiresOn, DateTimeOffset? refreshOn, string tokenType)
        {
            Token = accessToken;
            ExpiresOn = expiresOn;
            RefreshOn = refreshOn;
            TokenType = tokenType;
        }

        /// <summary>
        /// Creates a new instance of <see cref="AccessToken"/> using the provided <paramref name="accessToken"/> and <paramref name="expiresOn"/>.
        /// </summary>
        /// <param name="accessToken">The access token value.</param>
        /// <param name="expiresOn">The access token expiry date.</param>
        /// <param name="refreshOn">Specifies the time when the cached token should be proactively refreshed.</param>
        /// <param name="tokenType">The access token type.</param>
        /// <param name="bindingCertificate">The binding certificate for the access token.</param>
        public AccessToken(string accessToken, DateTimeOffset expiresOn, DateTimeOffset? refreshOn, string tokenType, X509Certificate2 bindingCertificate)
        {
            Token = accessToken;
            ExpiresOn = expiresOn;
            RefreshOn = refreshOn;
            TokenType = tokenType;
            BindingCertificate = bindingCertificate;
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
        /// Identifies the type of access token.
        /// </summary>
        public string TokenType { get; }

        /// <summary>
        /// Gets or sets the binding certificate for the access token.
        /// This is used when authenticating via Proof of Possession (PoP).
        /// </summary>
        /// <seealso href="https://learn.microsoft.com/entra/msal/dotnet/advanced/proof-of-possession-tokens"/>
        public X509Certificate2? BindingCertificate { get; }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is AccessToken accessToken)
            {
                return accessToken.ExpiresOn == ExpiresOn && accessToken.Token == Token && accessToken.TokenType == TokenType;
            }

            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(Token, ExpiresOn, TokenType);
        }

        /// <summary>
        /// Converts this <see cref="AccessToken"/> to an <see cref="AuthenticationToken"/>.
        /// </summary>
        /// <returns></returns>
        internal AuthenticationToken ToAuthenticationToken()
        {
            return new AuthenticationToken(Token, TokenType, ExpiresOn, RefreshOn);
        }
    }
}
