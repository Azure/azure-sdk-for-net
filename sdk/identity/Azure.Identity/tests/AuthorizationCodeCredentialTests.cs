// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AuthorizationCodeCredentialTests : ClientTestBase
    {
        public AuthorizationCodeCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AuthenticateWithAuthCodeMockAsync()
        {
            var expectedToken = Guid.NewGuid().ToString();
            var authCode = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var tenantId = Guid.NewGuid().ToString();
            var clientSecret = Guid.NewGuid().ToString();

            MockResponse response = CreateAuthorizationResponse(expectedToken);

            var mockTransport = new MockTransport(request => ProcessMockRequest(request, tenantId, expectedToken));

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            AuthorizationCodeCredential cred = InstrumentClient(new AuthorizationCodeCredential(tenantId, clientId, clientSecret, authCode, options));

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }));

            Assert.AreEqual(token.Token, expectedToken);

            AccessToken token2 = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://managemnt.azure.com/.default" }));

            Assert.AreEqual(token.Token, expectedToken);
        }

        private MockResponse ProcessMockRequest(MockRequest mockRequest, string tenantId, string token)
        {
            string requestUrl = mockRequest.Uri.ToUri().AbsoluteUri;

            if (requestUrl.StartsWith("https://login.microsoftonline.com/common/discovery/instance"))
            {
                return DiscoveryInstanceResponse;
            }

            if (requestUrl.StartsWith($"https://login.microsoftonline.com/{tenantId}/v2.0/.well-known/openid-configuration"))
            {
                return CreateOpenIdConfigurationResponse(tenantId);
            }

            if (requestUrl.StartsWith($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token"))
            {
                return CreateAuthorizationResponse(token);
            }

            throw new InvalidOperationException();
        }

        private MockResponse CreateAuthorizationResponse(string accessToken)
        {
            MockResponse response = new MockResponse(200).WithContent(@$"{{
    ""token_type"": ""Bearer"",
    ""scope"": ""https://vault.azure.net/user_impersonation https://vault.azure.net/.default"",
    ""expires_in"": 3600,
    ""ext_expires_in"": 3600,
    ""access_token"": ""{accessToken}"",
    ""refresh_token"": ""eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9-eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ-SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"",
    ""foci"": ""1"",
    ""id_token"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6InU0T2ZORlBId0VCb3NIanRyYXVPYlY4NExuWSJ9.eyJhdWQiOiJFMDFCNUY2NC03OEY1LTRGODgtQjI4Mi03QUUzOUI4QUM0QkQiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vRDEwOUI0NkUtM0E5Ri00NDQwLTg2MjItMjVEQjQxOTg1MDUxL3YyLjAiLCJpYXQiOjE1NjM5OTA0MDEsIm5iZiI6MTU2Mzk5MDQwMSwiZXhwIjoxNTYzOTk0MzAxLCJhaW8iOiJRMVV3TlV4YVNFeG9aak5uUWpSd00zcFRNamRrV2pSTFNVcEdMMVV3TWt0a2FrZDFTRkJVVlZwMmVFODRNMFZ0VXk4Mlp6TjJLM1JrVVVzeVQyVXhNamxJWTNKQ1p6MGlMQ0p1WVcxbElqb2lVMk52ZEhRZ1UyTiIsIm5hbWUiOiJTb21lIFVzZXIiLCJvaWQiOiIyQ0M5QzNBOC0yNTA5LTQyMEYtQjAwQi02RTczQkM1MURDQjUiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJzb21ldXNlckBtaWNyb3NvZnQuY29tIiwic3ViIjoiQ0p6ZFdJaU9pSkdXakY0UVVOS1JFRnBRWFp6IiwidGlkIjoiMjRGRTMxMUYtN0E3MS00RjgzLTkxNkEtOTQ3OEQ0NUMwNDI3IiwidXRpIjoidFFqSTRNaTAzUVVVek9VSTRRVU0wUWtRaUxDSnBjM01pT2lKb2RIUiIsInZlciI6IjIuMCJ9.eVyG1AL8jwnTo3m9mGsV4EDHa_8PN6rRPEN9E3cQzxNoPU9HZTFt1SgOnLB7n1a4J_E3iVoZ3VB5I-NdDBESRdlg1k4XlrWqtisxl3I7pvWVFZKEhwHYYQ_nZITNeCb48LfZNz-Mr4EZeX6oyUymha5tOomikBLLxP78LOTlbGQiFn9AjtV0LtMeoiDf-K9t-kgU-XwsVjCyFKFBQhcyv7zaBEpeA-Kzh3-HG7wZ-geteM5y-JF97nD_rJ8ow1FmvtDYy6MVcwuNTv2YYT8dn8s-SGB4vpNNignlL0QgYh2P2cIrPdhZVc2iQqYTn_FK_UFPqyb_MZSjl1QkXVhgJA"",
    ""client_info"": ""eyJ1aWQiOiIyQ0M5QzNBOC0yNTA5LTQyMEYtQjAwQi02RTczQkM1MURDQjUiLCJ1dGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3In0""
}}");

            return response;
        }

        private static MockResponse DiscoveryInstanceResponse
        {
            get
            {
                return new MockResponse(200).WithContent(@"
{
    ""tenant_discovery_endpoint"": ""https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration"",
    ""api-version"": ""1.1"",
    ""metadata"": [
        {
            ""preferred_network"": ""login.microsoftonline.com"",
            ""preferred_cache"": ""login.windows.net"",
            ""aliases"": [
                ""login.microsoftonline.com"",
                ""login.windows.net"",
                ""login.microsoft.com"",
                ""sts.windows.net""
            ]
},
        {
            ""preferred_network"": ""login.partner.microsoftonline.cn"",
            ""preferred_cache"": ""login.partner.microsoftonline.cn"",
            ""aliases"": [
                ""login.partner.microsoftonline.cn"",
                ""login.chinacloudapi.cn""
            ]
        },
        {
            ""preferred_network"": ""login.microsoftonline.de"",
            ""preferred_cache"": ""login.microsoftonline.de"",
            ""aliases"": [
                ""login.microsoftonline.de""
            ]
        },
        {
            ""preferred_network"": ""login.microsoftonline.us"",
            ""preferred_cache"": ""login.microsoftonline.us"",
            ""aliases"": [
                ""login.microsoftonline.us"",
                ""login.usgovcloudapi.net""
            ]
        },
        {
            ""preferred_network"": ""login-us.microsoftonline.com"",
            ""preferred_cache"": ""login-us.microsoftonline.com"",
            ""aliases"": [
                ""login-us.microsoftonline.com""
            ]
        }
    ]
}");
            }
        }

        private MockResponse CreateOpenIdConfigurationResponse(string tenantId)
        {
                return new MockResponse(200).WithContent(@$"{{
    ""authorization_endpoint"": ""https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/authorize"",
    ""token_endpoint"": ""https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token"",
    ""token_endpoint_auth_methods_supported"": [
        ""client_secret_post"",
        ""private_key_jwt"",
        ""client_secret_basic""
    ],
    ""jwks_uri"": ""https://login.microsoftonline.com/{tenantId}/discovery/v2.0/keys"",
    ""response_modes_supported"": [
        ""query"",
        ""fragment"",
        ""form_post""
    ],
    ""subject_types_supported"": [
        ""pairwise""
    ],
    ""id_token_signing_alg_values_supported"": [
        ""RS256""
    ],
    ""http_logout_supported"": true,
    ""frontchannel_logout_supported"": true,
    ""end_session_endpoint"": ""https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/logout"",
    ""response_types_supported"": [
        ""code"",
        ""id_token"",
        ""code id_token"",
        ""id_token token""
    ],
    ""scopes_supported"": [
        ""openid"",
        ""profile"",
        ""email"",
        ""offline_access""
    ],
    ""issuer"": ""https://login.microsoftonline.com/{tenantId}/v2.0"",
    ""claims_supported"": [
        ""sub"",
        ""iss"",
        ""cloud_instance_name"",
        ""cloud_instance_host_name"",
        ""cloud_graph_host_name"",
        ""msgraph_host"",
        ""aud"",
        ""exp"",
        ""iat"",
        ""auth_time"",
        ""acr"",
        ""nonce"",
        ""preferred_username"",
        ""name"",
        ""tid"",
        ""ver"",
        ""at_hash"",
        ""c_hash"",
        ""email""
    ],
    ""request_uri_parameter_supported"": false,
    ""userinfo_endpoint"": ""https://graph.microsoft.com/oidc/userinfo"",
    ""tenant_region_scope"": null,
    ""cloud_instance_name"": ""microsoftonline.com"",
    ""cloud_graph_host_name"": ""graph.windows.net"",
    ""msgraph_host"": ""graph.microsoft.com"",
    ""rbac_url"": ""https://pas.windows.net""
}}");
        }
    }
}
