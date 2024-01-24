// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;

namespace Azure.Core
{
    /// <summary>
    /// Contains the details of an authentication token request.
    /// </summary>
    public readonly struct PopTokenRequestContext
    {
        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claims">Additional claims to be included in the token.</param>
        /// <param name="tenantId">The tenant ID to be included in the token request.</param>
        /// <param name="isCaeEnabled">Indicates whether to enable Continuous Access Evaluation (CAE) for the requested token.</param>
        /// <param name="proofOfPossessionNonce">The nonce value required for PoP token requests.</param>
        /// <param name="request">The request to be authorized with a PoP token.</param>
        public PopTokenRequestContext(string[] scopes, string? parentRequestId = default, string? claims = default, string? tenantId = default, bool isCaeEnabled = false, string? proofOfPossessionNonce = default, Request? request = default)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = tenantId;
            IsCaeEnabled = isCaeEnabled;
            ProofOfPossessionNonce = proofOfPossessionNonce;
            _request = request;
        }

        /// <summary>
        /// Creates a new TokenRequestContext from this instance.
        /// </summary>
        /// <returns></returns>
        public TokenRequestContext ToTokenRequestContext()
        {
            return new TokenRequestContext(Scopes, ParentRequestId, Claims, TenantId, IsCaeEnabled);
        }

        /// <summary>
        /// Creates a new PopTokenRequestContext from a TokenRequestContext.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static PopTokenRequestContext FromTokenRequestContext(TokenRequestContext context, Request? request = default)
        {
            return new PopTokenRequestContext(context.Scopes, context.ParentRequestId, context.Claims, context.TenantId, context.IsCaeEnabled, default, request);
        }

        /// <summary>
        /// Creates a new TokenRequestContext from this instance.
        /// </summary>
        /// <param name="context"></param>
        public static implicit operator TokenRequestContext(PopTokenRequestContext context) => context.ToTokenRequestContext();

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
        /// The tenant ID to be included in the token request.
        /// </summary>
        public string? TenantId { get; }

        /// <summary>
        /// Indicates whether to enable Continuous Access Evaluation (CAE) for the requested token.
        /// </summary>
        /// <remarks>
        /// If a resource API implements CAE and your application declares it can handle CAE, your app receives CAE tokens for that resource.
        /// For this reason, if you declare your app CAE-ready, your app must handle the CAE claim challenge for all resource APIs that accept Microsoft Identity access tokens.
        /// If you don't handle CAE responses in these API calls, your app could end up in a loop retrying an API call with a token that is still in the returned lifespan of the token but has been revoked due to CAE.
        /// </remarks>
        public bool IsCaeEnabled { get; }

        /// <summary>
        /// The nonce value required for PoP token requests. This is typically retrieved from teh WWW-Authenticate header of a 401 challenge response.
        /// This is used in combination with <see cref="Uri"/> and <see cref="HttpMethod"/> to generate the PoP token.
        /// </summary>
        public string? ProofOfPossessionNonce { get; }

        private readonly Request? _request;

        /// <summary>
        /// The HTTP method of the request. This is used in combination with <see cref="Uri"/> and <see cref="ProofOfPossessionNonce"/> to generate the PoP token.
        /// </summary>
        public HttpMethod? HttpMethod => new(_request!.Method.ToString());

        /// <summary>
        /// The URI of the request. This is used in combination with <see cref="HttpMethod"/> and <see cref="ProofOfPossessionNonce"/> to generate the PoP token.
        /// </summary>
        public Uri? Uri => _request?.Uri.ToUri();
    }
}
