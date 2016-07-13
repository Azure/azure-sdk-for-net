// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public enum TokenAudience
    {
        Management,
        Graph
    }

    public class TokenInfo
    {
        public TokenInfo(string accessToken)
        {
            AccessToken = accessToken;
            AccessTokenType = "Bearer";
        }

        public TokenInfo(AuthenticationResult result)
        {
            AccessToken = result.AccessToken;
            AccessTokenType = result.AccessTokenType;
        }

        public string AccessToken { get; private set; }
        public string AccessTokenType { get; private set; }
    }
}
