// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// Contains the details of an authentication token request.
    /// </summary>
    public static class TokenRequestContextFactory
    {
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
    }
}
