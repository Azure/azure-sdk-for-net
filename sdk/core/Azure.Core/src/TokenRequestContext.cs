// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.Core
{
    /// <summary>
    /// Contains the details of an authentication token request.
    /// </summary>
    public readonly struct TokenRequestContext
    {
        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        public TokenRequestContext(string[] scopes, string? parentRequestId)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = default;
            TenantId = default;
        }

        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claims">Additional claims to be included in the token.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TokenRequestContext(string[] scopes, string? parentRequestId, string? claims)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = default;
        }

        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claims">Additional claims to be included in the token.</param>
        /// <param name="tenantId"> The tenantId to be included in the token request. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TokenRequestContext(string[] scopes, string? parentRequestId, string? claims, string? tenantId)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = tenantId;
        }

        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claims">Additional claims to be included in the token.</param>
        /// <param name="tenantId"> The tenantId to be included in the token request.</param>
        /// <param name="isCaeEnabled">Indicates whether to enable Continuous Access Evaluation (CAE) for the requested token.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TokenRequestContext(string[] scopes, string? parentRequestId, string? claims, string? tenantId, bool isCaeEnabled)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = tenantId;
            IsCaeEnabled = isCaeEnabled;
        }

        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claims">Additional claims to be included in the token.</param>
        /// <param name="tenantId">The tenant ID to be included in the token request.</param>
        /// <param name="isCaeEnabled">Indicates whether to enable Continuous Access Evaluation (CAE) for the requested token.</param>
        /// <param name="isProofOfPossessionEnabled">Indicates whether to enable Proof of Possession (PoP) for the requested token.</param>
        /// <param name="proofOfPossessionNonce">The nonce value required for PoP token requests.</param>
        /// <param name="requestUri">The resource request URI to be authorized with a PoP token.</param>
        /// <param name="requestMethod">The HTTP request method name of the resource request (e.g. GET, POST, etc.).</param>
        public TokenRequestContext(string[] scopes, string? parentRequestId = default, string? claims = default, string? tenantId = default, bool isCaeEnabled = false, bool isProofOfPossessionEnabled = false, string? proofOfPossessionNonce = default, Uri? requestUri = default, string? requestMethod = default)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = tenantId;
            IsCaeEnabled = isCaeEnabled;
            ProofOfPossessionNonce = proofOfPossessionNonce;
            IsProofOfPossessionEnabled = isProofOfPossessionEnabled;
            ResourceRequestUri = requestUri;
            ResourceRequestMethod = requestMethod;
        }

        /// <summary>
        /// The scopes required for the token.
        /// </summary>
        public string[] Scopes { get; }

        /// <summary>
        /// The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.
        /// </summary>
        public string? ParentRequestId { get; }

        /// <summary>
        /// Additional claims to be included in the token. See <see href="https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter">https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter</see> for more information on format and content.
        /// </summary>
        public string? Claims { get; }

        /// <summary>
        /// The tenantId to be included in the token request.
        /// </summary>
        public string? TenantId { get; }

        /// <summary>
        /// Indicates whether to enable Continuous Access Evaluation (CAE) for the requested token.
        /// </summary>
        /// <remarks>
        /// If a resource API implements CAE and your application declares it can handle CAE, your app receives CAE tokens for that resource.
        /// For this reason, if you declare your app CAE ready, your application must handle the CAE claim challenge for all resource APIs that accept Microsoft Identity access tokens.
        /// If you don't handle CAE responses in these API calls, your app could end up in a loop retrying an API call with a token that is still in the returned lifespan of the token but has been revoked due to CAE.
        /// </remarks>
        public bool IsCaeEnabled { get; }

        /// <summary>
        /// Indicates whether to enable Proof of Possession (PoP) for the requested token.
        /// </summary>
        public bool IsProofOfPossessionEnabled { get; }

        /// <summary>
        /// The nonce value required for PoP token requests. This is typically retrieved from the WWW-Authenticate header of a 401 challenge response.
        /// This is used in combination with <see cref="ResourceRequestUri"/> and <see cref="ResourceRequestMethod"/> to generate the PoP token.
        /// </summary>
        public string? ProofOfPossessionNonce { get; }

        /// <summary>
        /// The HTTP method of the request. This is used in combination with <see cref="ResourceRequestUri"/> and <see cref="ProofOfPossessionNonce"/> to generate the PoP token.
        /// </summary>
        public string? ResourceRequestMethod { get; }

        /// <summary>
        /// The URI of the request. This is used in combination with <see cref="ResourceRequestMethod"/> and <see cref="ProofOfPossessionNonce"/> to generate the PoP token.
        /// </summary>
        public Uri? ResourceRequestUri { get; }

        /// <summary>
        /// Creates a new instance of <see cref="TokenRequestContext"/> from the specified <see cref="GetTokenOptions"/>.
        /// </summary>
        internal static TokenRequestContext FromGetTokenOptions(GetTokenOptions getTokenOptions)
        {
            var scopes = getTokenOptions.Properties.TryGetValue(GetTokenOptions.ScopesPropertyName, out var scopesValue) && scopesValue is ReadOnlyMemory<string> memoryScopes
                ? memoryScopes.ToArray()
                : scopesValue is string[] scopeArray ?
                    scopeArray :
                    throw new InvalidOperationException($"The '{GetTokenOptions.ScopesPropertyName}' property must be set in the {nameof(GetTokenOptions)}.");
            string? parentRequestId = getTokenOptions.Properties.TryGetValue("parentRequestId", out var parentRequestIdValue) && parentRequestIdValue is string ? (string)parentRequestIdValue : default;
            string? claims = getTokenOptions.Properties.TryGetValue("claims", out var claimsValue) && claimsValue is string ? (string)claimsValue : default;
            string? tenantId = getTokenOptions.Properties.TryGetValue("tenantId", out var tenantIdValue) && tenantIdValue is string ? (string)tenantIdValue : default;
            bool isCaeEnabled = getTokenOptions.Properties.TryGetValue("isCaeEnabled", out var isCaeEnabledValue) && isCaeEnabledValue is bool ? (bool)isCaeEnabledValue : default;
            bool isProofOfPossessionEnabled = getTokenOptions.Properties.TryGetValue("isProofOfPossessionEnabled", out var isProofOfPossessionEnabledValue) && isProofOfPossessionEnabledValue is bool ? (bool)isProofOfPossessionEnabledValue : false;
            string? proofOfPossessionNonce = getTokenOptions.Properties.TryGetValue("proofOfPossessionNonce", out var proofOfPossessionNonceValue) && proofOfPossessionNonceValue is string ? (string)proofOfPossessionNonceValue : default;
            Uri? requestUri = getTokenOptions.Properties.TryGetValue("requestUri", out var requestUriValue) && requestUriValue is Uri ? (Uri)requestUriValue : default;
            string? requestMethod = getTokenOptions.Properties.TryGetValue("requestMethod", out var requestMethodValue) && requestMethodValue is string ? (string)requestMethodValue : default;

            return new TokenRequestContext(scopes, parentRequestId, claims, tenantId, isCaeEnabled, isProofOfPossessionEnabled, proofOfPossessionNonce, requestUri, requestMethod);
        }
    }
}
