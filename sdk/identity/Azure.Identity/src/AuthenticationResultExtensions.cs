// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal static class AuthenticationResultExtensions
    {
        public static AccessToken ToAccessToken(this AuthenticationResult result)
        {
            return new AccessToken(result.AccessToken, result.ExpiresOn, result.AuthenticationResultMetadata?.RefreshOn, result.TokenType);
        }
    }
}
