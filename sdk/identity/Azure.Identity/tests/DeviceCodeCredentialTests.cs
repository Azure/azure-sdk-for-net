// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class DeviceCodeCredentialTests : ClientTestBase
    {
        public DeviceCodeCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        private readonly HashSet<string> _requestedCodes = new HashSet<string>();

        private readonly object _requestedCodesLock = new object();

        private Task VerifyDeviceCode(DeviceCodeInfo code, string message)
        {
            Assert.AreEqual(message, code.Message);

            return Task.CompletedTask;
        }

        private Task VerifyDeviceCodeAndCancel(DeviceCodeInfo code, string message, CancellationTokenSource cancelSource)
        {
            Assert.AreEqual(message, code.Message);

            cancelSource.Cancel();

            return Task.CompletedTask;
        }

        private async Task VerifyDeviceCodeCallbackCancellationToken(DeviceCodeInfo code, CancellationToken cancellationToken)
        {
            await Task.Delay(2000, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();
        }

        private class MockException : Exception
        {
        }

        private async Task ThrowingDeviceCodeCallback(DeviceCodeInfo code, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            throw new MockException();
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockAsync()
        {
            var expectedCode = Guid.NewGuid().ToString();

            var expectedToken = Guid.NewGuid().ToString();

            var mockTransport = new MockTransport(request => ProcessMockRequest(request, expectedCode, expectedToken));

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var cred = InstrumentClient(new DeviceCodeCredential((code, cancelToken) => VerifyDeviceCode(code, expectedCode), ClientId, options: options));

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }));

            Assert.AreEqual(token.Token, expectedToken);
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockAsync2()
        {
            var expectedCode = Guid.NewGuid().ToString();

            var expectedToken = Guid.NewGuid().ToString();

            var mockTransport = new MockTransport(request => ProcessMockRequest(request, expectedCode, expectedToken));

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var cred = InstrumentClient(new DeviceCodeCredential((code, cancelToken) => VerifyDeviceCode(code, expectedCode), ClientId, options: options));

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }));

            Assert.AreEqual(token.Token, expectedToken);
        }

        [Test]
        [NonParallelizable]
        public async Task AuthenticateWithDeviceCodeNoCallback()
        {
            var capturedOut = new StringBuilder();

            var capturedOutWriter = new StringWriter(capturedOut);

            var stdOut = Console.Out;

            Console.SetOut(capturedOutWriter);

            try
            {
                var expectedCode = Guid.NewGuid().ToString();

                var expectedToken = Guid.NewGuid().ToString();

                var mockTransport = new MockTransport(request => ProcessMockRequest(request, expectedCode, expectedToken));

                var options = new DeviceCodeCredentialOptions() { Transport = mockTransport };

                var cred = InstrumentClient(new DeviceCodeCredential(options));

                AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }));

                Assert.AreEqual(token.Token, expectedToken);

                Assert.AreEqual(expectedCode + Environment.NewLine, capturedOut.ToString());
            }
            finally
            {
                Console.SetOut(stdOut);
            }
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockVerifyMsalCancellationAsync()
        {
            var expectedCode = Guid.NewGuid().ToString();

            var expectedToken = Guid.NewGuid().ToString();

            var cancelSource = new CancellationTokenSource();

            var mockTransport = new MockTransport(request => ProcessMockRequest(request, expectedCode, expectedToken));

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var cred = InstrumentClient(new DeviceCodeCredential((code, cancelToken) => VerifyDeviceCodeAndCancel(code, expectedCode, cancelSource), null, ClientId, options: options));

            var ex = Assert.CatchAsync<OperationCanceledException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token));

            await Task.CompletedTask;
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockVerifyCallbackCancellationAsync()
        {
            var expectedCode = Guid.NewGuid().ToString();

            var expectedToken = Guid.NewGuid().ToString();

            var mockTransport = new MockTransport(request => ProcessMockRequest(request, expectedCode, expectedToken));

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var cancelSource = new CancellationTokenSource(1000);

            var cred = InstrumentClient(new DeviceCodeCredential(VerifyDeviceCodeCallbackCancellationToken, ClientId, options: options));

            var getTokenTask = cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token);

            var ex = Assert.CatchAsync<OperationCanceledException>(async () => await getTokenTask);

            await Task.CompletedTask;
        }

        [Test]
        public void AuthenticateWithDeviceCodeCallbackThrowsAsync()
        {
            var expectedCode = Guid.NewGuid().ToString();

            var expectedToken = Guid.NewGuid().ToString();

            var cancelSource = new CancellationTokenSource();

            var mockTransport = new MockTransport(request => ProcessMockRequest(request, expectedCode, expectedToken));

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var cred = InstrumentClient(new DeviceCodeCredential(ThrowingDeviceCodeCallback, ClientId, options: options));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token));

            Assert.IsInstanceOf(typeof(MockException), ex.InnerException);
        }

        [Test]
        public void DisableAutomaticAuthenticationException()
        {
            var expectedCode = Guid.NewGuid().ToString();

            var cred = InstrumentClient(new DeviceCodeCredential(new DeviceCodeCredentialOptions { DisableAutomaticAuthentication = true, DeviceCodeCallback = (code, cancelToken) => VerifyDeviceCode(code, expectedCode) }));

            var expTokenRequestContext = new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }, Guid.NewGuid().ToString());

            var ex = Assert.ThrowsAsync<AuthenticationRequiredException>(async () => await cred.GetTokenAsync(expTokenRequestContext));

            Assert.AreEqual(expTokenRequestContext, ex.TokenRequestContext);
        }

        private MockResponse ProcessMockRequest(MockRequest mockRequest, string code, string token)
        {
            string requestUrl = mockRequest.Uri.ToUri().AbsoluteUri;

            if (requestUrl.StartsWith("https://login.microsoftonline.com/common/discovery/instance"))
            {
                return DiscoveryInstanceResponse;
            }

            if (requestUrl.StartsWith("https://login.microsoftonline.com/organizations/v2.0/.well-known/openid-configuration"))
            {
                return OpenIdConfigurationResponse;
            }

            if (requestUrl.StartsWith("https://login.microsoftonline.com/organizations/oauth2/v2.0/devicecode"))
            {
                return CreateDeviceCodeResponse(code);
            }

            if (requestUrl.StartsWith("https://login.microsoftonline.com/organizations/oauth2/v2.0/token"))
            {
                return CreateTokenResponse(code, token);
            }

            throw new InvalidOperationException();
        }

        private MockResponse CreateTokenResponse(string code, string token)
        {
            lock (_requestedCodesLock)
            {
                if (_requestedCodes.Add(code))
                {
                    return AuthorizationPendingResponse;
                }
                else
                {
                    return CreateAuthorizationResponse(token);
                }
            }
        }

        private MockResponse CreateDeviceCodeResponse(string code)
        {
            MockResponse response = new MockResponse(200).WithContent($@"{{
    ""user_code"": ""{code}"",
    ""device_code"": ""{code}_{code}"",
    ""verification_uri"": ""https://microsoft.com/devicelogin"",
    ""expires_in"": 900,
    ""interval"": 1,
    ""message"": ""{code}""
}}");

            return response;
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

        private static MockResponse OpenIdConfigurationResponse
        {
            get
            {
                return new MockResponse(200).WithContent(@"{
    ""authorization_endpoint"": ""https://login.microsoftonline.com/common/oauth2/v2.0/authorize"",
    ""token_endpoint"": ""https://login.microsoftonline.com/common/oauth2/v2.0/token"",
    ""token_endpoint_auth_methods_supported"": [
        ""client_secret_post"",
        ""private_key_jwt"",
        ""client_secret_basic""
    ],
    ""jwks_uri"": ""https://login.microsoftonline.com/common/discovery/v2.0/keys"",
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
    ""end_session_endpoint"": ""https://login.microsoftonline.com/common/oauth2/v2.0/logout"",
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
    ""issuer"": ""https://login.microsoftonline.com/{tenantid}/v2.0"",
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
}");
            }
        }

        private static MockResponse AuthorizationPendingResponse
        {
            get
            {
                return new MockResponse(404).WithContent(@"{
    ""error"": ""authorization_pending"",
    ""error_description"": ""AADSTS70016: Pending end-user authorization.\r\nTrace ID: c40ce91e-5009-4e64-9a10-7732b2500100\r\nCorrelation ID: 73a2edae-f747-44da-8ebf-7cba565fe49d\r\nTimestamp: 2019-07-24 17:49:13Z"",
    ""error_codes"": [
        70016
    ],
    ""timestamp"": ""2019-07-24 17:49:13Z"",
    ""trace_id"": ""c40ce91e-5009-4e64-9a10-7732b2500100"",
    ""correlation_id"": ""73a2edae-f747-44da-8ebf-7cba565fe49d""
}");
            }
        }
    }
}
