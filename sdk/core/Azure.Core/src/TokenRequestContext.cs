// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// Contains the details of an authentication token request.
    /// </summary>
    public readonly struct TokenRequestContext : IReadOnlyDictionary<string, object>
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
        public TokenRequestContext(string[] scopes, string? parentRequestId = default, string? claims = default, string? tenantId = default, bool isCaeEnabled = false)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = tenantId;
            IsCaeEnabled = isCaeEnabled;
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
        /// Creates a <see cref="TokenRequestContext"/> from a dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static TokenRequestContext FromDictionary(IReadOnlyDictionary<string, object> dictionary)
        {
            if (dictionary is TokenRequestContext tokenRequestContext)
            {
                return tokenRequestContext;
            }

            string[] scopes;
            if (dictionary.TryGetValue("scopes", out var scopesValue) && scopesValue is string[] scopesArray)
            {
                scopes = scopesArray;
            }
            else
            {
                throw new System.ArgumentException("Missing required scopes in the dictionary.");
            }
            string? parentRequestId = dictionary.TryGetValue("parentRequestId", out var parentRequestIdValue) ? (string)parentRequestIdValue : default;
            string? claims = dictionary.TryGetValue("claims", out var claimsValue) ? (string)claimsValue : default;
            string? tenantId = dictionary.TryGetValue("tenantId", out var tenantIdValue) ? (string)tenantIdValue : default;
            bool isCaeEnabled = dictionary.TryGetValue("isCaeEnabled", out var isCaeEnabledValue) ? (bool)isCaeEnabledValue : default;

            return new TokenRequestContext(scopes, parentRequestId, claims, tenantId, isCaeEnabled);
        }

        object IReadOnlyDictionary<string, object>.this[string key] => throw new System.NotImplementedException();

        IEnumerable<string> IReadOnlyDictionary<string, object>.Keys => throw new System.NotImplementedException();

        IEnumerable<object> IReadOnlyDictionary<string, object>.Values => throw new System.NotImplementedException();

        int IReadOnlyCollection<KeyValuePair<string, object>>.Count => throw new System.NotImplementedException();

        bool IReadOnlyDictionary<string, object>.ContainsKey(string key)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        bool IReadOnlyDictionary<string, object>.TryGetValue(string key, out object value)
        {
            throw new System.NotImplementedException();
        }
    }
}
