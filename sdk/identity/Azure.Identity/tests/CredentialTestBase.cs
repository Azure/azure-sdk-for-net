// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public abstract class CredentialTestBase<TCredOptions> : ClientTestBase where TCredOptions : TokenCredentialOptions
    {
        protected const string Scope = "https://vault.azure.net/.default";
        protected const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        protected const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        protected const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        protected const string ObjectId = "22730c7e-c3c8-431b-94cf-5676152d9338";
        protected const string ExpectedUsername = "mockuser@mockdomain.com";
        protected const string UserrealmResponse = "{\"ver\": \"1.0\", \"account_type\": \"Managed\", \"domain_name\": \"constoso.com\", \"cloud_instance_name\": \"microsoftonline.com\", \"cloud_audience_urn\": \"urn:federation:MicrosoftOnline\"}";
        protected string expectedToken;
        protected string expectedUserAssertion;
        protected string expectedTenantId;
        protected string expectedReplyUri;
        protected string authCode;
        protected const string ReplyUrl = "https://myredirect/";
        protected string clientSecret = Guid.NewGuid().ToString();
        protected DateTimeOffset expiresOn;
        internal MockMsalConfidentialClient mockConfidentialMsalClient;
        internal MockMsalPublicClient mockPublicMsalClient;
        protected TokenCredentialOptions options;
        protected AuthenticationResult result;
        protected string expectedCode;
        protected DeviceCodeResult deviceCodeResult;

        protected const string DiscoveryResponseBody =
            "{\"tenant_discovery_endpoint\": \"https://login.microsoftonline.com/c54fac88-3dd3-461f-a7c4-8a368e0340b3/v2.0/.well-known/openid-configuration\",\"api-version\": \"1.1\",\"metadata\":[{\"preferred_network\": \"login.microsoftonline.com\",\"preferred_cache\": \"login.windows.net\",\"aliases\":[\"login.microsoftonline.com\",\"login.windows.net\",\"login.microsoft.com\",\"sts.windows.net\"]},{\"preferred_network\": \"login.partner.microsoftonline.cn\",\"preferred_cache\": \"login.partner.microsoftonline.cn\",\"aliases\":[\"login.partner.microsoftonline.cn\",\"login.chinacloudapi.cn\"]},{\"preferred_network\": \"login.microsoftonline.de\",\"preferred_cache\": \"login.microsoftonline.de\",\"aliases\":[\"login.microsoftonline.de\"]},{\"preferred_network\": \"login.microsoftonline.us\",\"preferred_cache\": \"login.microsoftonline.us\",\"aliases\":[\"login.microsoftonline.us\",\"login.usgovcloudapi.net\"]},{\"preferred_network\": \"login-us.microsoftonline.com\",\"preferred_cache\": \"login-us.microsoftonline.com\",\"aliases\":[\"login-us.microsoftonline.com\"]}]}";

        public CredentialTestBase(bool isAsync) : base(isAsync)
        {
        }

        public abstract TokenCredential GetTokenCredential(TokenCredentialOptions options);
        public abstract TokenCredential GetTokenCredential(CommonCredentialTestConfig config);

        [Test]
        public async Task IsAccountIdentifierLoggingEnabled([Values(true, false)] bool isOptionSet)
        {
            var options = new TokenCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = isOptionSet } };
            TestSetup(options);
            expectedTenantId = TenantId;
            using var _listener = new TestEventListener();
            _listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Verbose);
            var credential = GetTokenCredential(options);
            var context = new TokenRequestContext(new[] { Scope }, tenantId: TenantId);
            await credential.GetTokenAsync(context, default);

            var loggedEvents = _listener.EventsById(AzureIdentityEventSource.AuthenticatedAccountDetailsEvent);
            if (isOptionSet)
            {
                CollectionAssert.IsNotEmpty(loggedEvents);
            }
            else
            {
                CollectionAssert.IsEmpty(loggedEvents);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task DisableInstanceMetadataDicovery([Values(true, false)] bool disable)
        {
            // Skip test if the credential does not support disabling instance discovery
            if (!typeof(ISupportsDisableInstanceDiscovery).IsAssignableFrom(typeof(TCredOptions)))
            {
                Assert.Ignore($"{typeof(TCredOptions).Name} does not implement {nameof(ISupportsDisableInstanceDiscovery)}");
            }

            // Clear instance discovery cache
            StaticCachesUtilities.ClearStaticMetadataProviderCache();

            // Configure the transport
            var token = Guid.NewGuid().ToString();
            var idToken = CreateMsalIdToken(Guid.NewGuid().ToString(), "userName", TenantId);
            bool calledDiscoveryEndpoint = false;
            var mockTransport = new MockTransport(req =>
            {
                calledDiscoveryEndpoint |= req.Uri.Path.Contains("discovery/instance");

                MockResponse response = new(200);
                if (req.Uri.Path.EndsWith("/devicecode"))
                {
                    response = CreateMockMsalDeviceCodeResponse();
                }
                else if (req.Uri.Path.Contains("/userrealm/"))
                {
                    response.SetContent(UserrealmResponse);
                }
                else
                {
                    if (typeof(TCredOptions) == typeof(DeviceCodeCredentialOptions) ||
                        typeof(TCredOptions) == typeof(UsernamePasswordCredentialOptions) ||
                        typeof(TCredOptions) == typeof(SharedTokenCacheCredentialOptions) ||
                        typeof(TCredOptions) == typeof(InteractiveBrowserCredentialOptions) ||
                        typeof(TCredOptions) == typeof(AuthorizationCodeCredentialOptions))
                    {
                        response = CreateMockMsalTokenResponse(200, token, TenantId, ExpectedUsername, ObjectId);
                    }
                    else
                    {
                        response.SetContent($"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"{token}\" }}");
                    }
                }

                return response;
            });

            var config = new CommonCredentialTestConfig()
            {
                DisableMetadataDiscovery = disable,
                Transport = mockTransport
            };
            var credential = GetTokenCredential(config);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreNotEqual(disable, calledDiscoveryEndpoint);
            Assert.AreEqual(token, actualToken.Token);
        }

        public class AllowedTenantsTestParameters
        {
            public string TenantId { get; set; }
            public List<string> AdditionallyAllowedTenants { get; set; }
            public TokenRequestContext TokenRequestContext { get; set; }
            public string ToDebugString()
            {
                return $"TenantId:{TenantId ?? "null"}, AddlTenants:[{string.Join(",", AdditionallyAllowedTenants)}], RequestedTenantId:{TokenRequestContext.TenantId ?? "null"}";
            }
        }

        public static IEnumerable<AllowedTenantsTestParameters> GetAllowedTenantsTestCases()
        {
            string tenant = Guid.NewGuid().ToString();
            string addlTenantA = Guid.NewGuid().ToString();
            string addlTenantB = Guid.NewGuid().ToString();

            List<string> tenantValues = new List<string>() { tenant, null };

            List<List<string>> additionalAllowedTenantsValues = new List<List<string>>()
            {
                new List<string>(),
                new List<string> { addlTenantA, addlTenantB },
                new List<string> { "*" },
                new List<string> { addlTenantA, "*", addlTenantB }
            };

            List<TokenRequestContext> tokenRequestContextValues = new List<TokenRequestContext>()
            {
                new TokenRequestContext(MockScopes.Default),
                new TokenRequestContext(MockScopes.Default, tenantId: tenant),
                new TokenRequestContext(MockScopes.Default, tenantId: addlTenantA),
                new TokenRequestContext(MockScopes.Default, tenantId: addlTenantB),
                new TokenRequestContext(MockScopes.Default, tenantId: Guid.NewGuid().ToString()),
            };

            foreach (var mainTenant in tenantValues)
            {
                foreach (var additoinallyAllowedTenants in additionalAllowedTenantsValues)
                {
                    foreach (var tokenRequestContext in tokenRequestContextValues)
                    {
                        yield return new AllowedTenantsTestParameters { TenantId = mainTenant, AdditionallyAllowedTenants = additoinallyAllowedTenants, TokenRequestContext = tokenRequestContext };
                    }
                }
            }
        }

        [TestCaseSource(nameof(GetAllowedTenantsTestCases))]
        public abstract Task VerifyAllowedTenantEnforcement(AllowedTenantsTestParameters parameters);

        public static async Task AssertAllowedTenantIdsEnforcedAsync(AllowedTenantsTestParameters parameters, TokenCredential credential)
        {
            bool expAllowed = parameters.TenantId == null
                || parameters.TokenRequestContext.TenantId == null
                || parameters.TenantId == parameters.TokenRequestContext.TenantId
                || parameters.AdditionallyAllowedTenants.Contains(parameters.TokenRequestContext.TenantId)
                || parameters.AdditionallyAllowedTenants.Contains("*");

            if (expAllowed)
            {
                var accessToken = await credential.GetTokenAsync(parameters.TokenRequestContext, default);

                Assert.IsNotNull(accessToken.Token);
            }
            else
            {
                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => { await credential.GetTokenAsync(parameters.TokenRequestContext, default); });

                StringAssert.Contains($"The current credential is not configured to acquire tokens for tenant {parameters.TokenRequestContext.TenantId}", ex.Message);
            }
        }

        public void TestSetup(TokenCredentialOptions options = null)
        {
            expectedTenantId = null;
            expectedReplyUri = null;
            authCode = Guid.NewGuid().ToString();
            options = options ?? new TokenCredentialOptions();
            expectedToken = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.UtcNow.AddHours(1));
            expectedUserAssertion = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            result = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");

            mockConfidentialMsalClient = new MockMsalConfidentialClient(null, null, null, null, null, options)
                .WithSilentFactory(
                    (_, _tenantId, _replyUri, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithAuthCodeFactory(
                    (_, _tenantId, _replyUri, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return result;
                    })
                .WithOnBehalfOfFactory(
                    (_, _, userAssertion, _, _) =>
                    {
                        Assert.AreEqual(expectedUserAssertion, userAssertion.Assertion);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithClientFactory(
                    (_, _tenantId) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        return result;
                    });

            expectedCode = Guid.NewGuid().ToString();
            mockPublicMsalClient = new MockMsalPublicClient(null, null, null, null, options);
            deviceCodeResult = MockMsalPublicClient.GetDeviceCodeResult(deviceCode: expectedCode);
            mockPublicMsalClient.DeviceCodeResult = deviceCodeResult;
            var publicResult = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");
            mockPublicMsalClient.SilentAuthFactory = (_, tId) =>
            {
                Assert.AreEqual(expectedTenantId, tId);
                return publicResult;
            };
            mockPublicMsalClient.DeviceCodeAuthFactory = (_, _) =>
            {
                // Assert.AreEqual(tenantId, tId);
                return publicResult;
            };
            mockPublicMsalClient.InteractiveAuthFactory = (_, _, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.SilentAuthFactory = (_, tenant) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.ExtendedSilentAuthFactory = (_, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.UserPassAuthFactory = (_, tenant) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.RefreshTokenFactory = (_, _, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
        }

        protected async Task<string> ReadMockRequestContent(MockRequest request)
        {
            if (request.Content == null)
            {
                return null;
            }

            using var memoryStream = new MemoryStream();
            request.Content.WriteTo(memoryStream, CancellationToken.None);
            memoryStream.Position = 0;
            using (var streamReader = new StreamReader(memoryStream))
            {
                return await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        protected byte[] GetMockCacheBytes(string objectId, string userName, string clientId, string tenantId, string token, string refreshToken)
        {
            var cacheString = @$"{{
  ""AccessToken"": {{
      ""{objectId}.{tenantId}-login.microsoftonline.com-accesstoken-{clientId}-organizations-{MockScopes.Default}"": {{
          ""credential_type"": ""AccessToken"",
          ""secret"": ""{token}"",
          ""home_account_id"": ""{objectId}.{tenantId}"",
          ""environment"": ""login.microsoftonline.com"",
          ""client_id"": ""{clientId}"",
          ""target"": ""{MockScopes.Default}"",
          ""realm"": ""organizations"",
          ""token_type"": ""Bearer"",
          ""cached_at"": ""1671572411"",
          ""expires_on"": ""1671576858"",
          ""extended_expires_on"": ""1671576858""
      }}
  }},
  ""Account"": {{
      ""{objectId}.{tenantId}-login.microsoftonline.com-organizations"": {{
          ""home_account_id"": ""{objectId}.{tenantId}"",
          ""environment"": ""login.microsoftonline.com"",
          ""realm"": ""organizations"",
          ""local_account_id"": ""{objectId}"",
          ""username"": ""{userName}"",
          ""authority_type"": ""MSSTS""
      }}
  }},
  ""IdToken"": {{
      ""{objectId}.{tenantId}-login.microsoftonline.com-idtoken-{clientId}-organizations-"": {{
          ""credential_type"": ""IdToken"",
          ""secret"": ""{token}"",
          ""home_account_id"": ""{objectId}.{tenantId}"",
          ""environment"": ""login.microsoftonline.com"",
          ""realm"": ""organizations"",
          ""client_id"": ""{clientId}""
      }},
  }},
  ""RefreshToken"": {{
      ""{objectId}.{tenantId}-login.microsoftonline.com-refreshtoken-{clientId}--{MockScopes.Default}"": {{
          ""credential_type"": ""RefreshToken"",
          ""secret"": ""{refreshToken}"",
          ""home_account_id"": ""{objectId}.{tenantId}"",
          ""environment"": ""login.microsoftonline.com"",
          ""client_id"": ""{clientId}"",
          ""target"": ""{MockScopes.Default}"",
          ""last_modification_time"": ""1674853645"",
          ""family_id"": ""1""
      }}
  }},
  ""AppMetadata"": {{
      ""appmetadata-login.microsoftonline.com-{clientId}"": {{
          ""client_id"": ""{clientId}"",
          ""environment"": ""login.microsoftonline.com"",
          ""family_id"": ""1""
      }}
  }}
}}";
            return Encoding.UTF8.GetBytes(cacheString);
        }

        protected MockResponse CreateMockMsalTokenResponse(int responseCode, string token, string tenantId, string userName, string objectId = null)
        {
            var response = new MockResponse(responseCode);
            var idToken = CreateMsalIdToken(Guid.NewGuid().ToString(), userName, tenantId);
            response.SetContent(
                $"{{\"token_type\": \"Bearer\",\"access_token\": \"{token}\",\"refresh_token\": \"{token}\",\"scope\": null,\"client_info\": null,\"id_token\": null,\"expires_in\": 10000,\"ext_expires_in\": 100000,\"refresh_in\": 1000, \"correlation_id\": \"{Guid.NewGuid().ToString()}\", \"client_info\": \"{CreateMsalClientInfo(objectId, tenantId)}\",\"id_token\": \"{idToken}\"}}");
            return response;
        }

        protected MockResponse CreateMockMsalDeviceCodeResponse(string deviceCode = null, string userCode = null)
        {
            var response = new MockResponse(200);
            response.SetContent(
                    $"{{\"device_code\": \"{deviceCode ?? Guid.NewGuid().ToString()}\",\"user_code\": \"{userCode ?? Guid.NewGuid().ToString()}\",\"verification_url\": \"https://microsoft.com/devicelogin\",\"expires_in\": 900,\"interval\": 5,\"message\": \"my message\"}}");
            return response;
        }

        public static string CreateMsalClientInfo(string objectId = null, string tenantId = null)
        {
            var uid = objectId ?? "myuid";
            var tid = tenantId ?? "myutid";
            return MsalEncode($"{{\"uid\":\"{uid}\",\"utid\":\"{tid}\"}}");
        }

        public static string CreateMsalIdToken(string uniqueId, string displayableId, string tenantId)
        {
            string id = "{\"aud\": \"e854a4a7-6c34-449c-b237-fc7a28093d84\"," +
                        "\"iss\": \"https://login.microsoftonline.com/6c3d51dd-f0e5-4959-b4ea-a80c4e36fe5e/v2.0/\"," +
                        "\"iat\": 1455833828," +
                        "\"nbf\": 1455833828," +
                        "\"exp\": 1455837728," +
                        "\"ipaddr\": \"131.107.159.117\"," +
                        "\"name\": \"Marrrrrio Bossy\"," +
                        "\"oid\": \"" + uniqueId + "\"," +
                        "\"preferred_username\": \"" + displayableId + "\"," +
                        "\"sub\": \"K4_SGGxKqW1SxUAmhg6C1F6VPiFzcx-Qd80ehIEdFus\"," +
                        "\"tid\": \"" + tenantId + "\"," +
                        "\"ver\": \"2.0\"}";
            return string.Format(CultureInfo.InvariantCulture, "someheader.{0}.somesignature", MsalEncode(id));
        }

        private const char base64PadCharacter = '=';
#if NET45
        private const string doubleBase64PadCharacter = "==";
#endif
        private const char base64Character62 = '+';
        private const char base64Character63 = '/';
        private const char base64UrlCharacter62 = '-';
        private const char base64UrlCharacter63 = '_';

        /// <summary>
        /// Encoding table
        /// </summary>
        internal static readonly char[] s_base64Table =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
            'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', base64UrlCharacter62, base64UrlCharacter63
        };

        /// <summary>
        /// The following functions perform base64url encoding which differs from regular base64 encoding as follows
        /// * padding is skipped so the pad character '=' doesn't have to be percent encoded
        /// * the 62nd and 63rd regular base64 encoding characters ('+' and '/') are replace with ('-' and '_')
        /// The changes make the encoding alphabet file and URL safe.
        /// </summary>
        /// <param name="arg">string to encode.</param>
        /// <returns>Base64Url encoding of the UTF8 bytes.</returns>
        public static string MsalEncode(string arg)
        {
            if (arg == null)
                return null;

            return MsalEncode(Encoding.UTF8.GetBytes(arg));
        }

        // From https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/blob/master/src/client/Microsoft.Identity.Client/Utils/Base64UrlHelpers.cs

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64-url digits. Parameters specify
        /// the subset as an offset in the input array, and the number of elements in the array to convert.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <param name="length">An offset in inArray.</param>
        /// <param name="offset">The number of elements of inArray to convert.</param>
        /// <returns>The string representation in base 64 url encoding of length elements of inArray, starting at position offset.</returns>
        /// <exception cref="ArgumentNullException">'inArray' is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">offset or length is negative OR offset plus length is greater than the length of inArray.</exception>
        private static string MsalEncode(byte[] inArray, int offset, int length)
        {
            _ = inArray ?? throw new ArgumentNullException(nameof(inArray));

            if (length == 0)
                return string.Empty;

            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            if (offset < 0 || inArray.Length < offset)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (inArray.Length < offset + length)
                throw new ArgumentOutOfRangeException(nameof(length));

            int lengthmod3 = length % 3;
            int limit = offset + (length - lengthmod3);
            char[] output = new char[(length + 2) / 3 * 4];
            char[] table = s_base64Table;
            int i, j = 0;

            // takes 3 bytes from inArray and insert 4 bytes into output
            for (i = offset; i < limit; i += 3)
            {
                byte d0 = inArray[i];
                byte d1 = inArray[i + 1];
                byte d2 = inArray[i + 2];

                output[j + 0] = table[d0 >> 2];
                output[j + 1] = table[((d0 & 0x03) << 4) | (d1 >> 4)];
                output[j + 2] = table[((d1 & 0x0f) << 2) | (d2 >> 6)];
                output[j + 3] = table[d2 & 0x3f];
                j += 4;
            }

            //Where we left off before
            i = limit;

            switch (lengthmod3)
            {
                case 2:
                    {
                        byte d0 = inArray[i];
                        byte d1 = inArray[i + 1];

                        output[j + 0] = table[d0 >> 2];
                        output[j + 1] = table[((d0 & 0x03) << 4) | (d1 >> 4)];
                        output[j + 2] = table[(d1 & 0x0f) << 2];
                        j += 3;
                    }
                    break;

                case 1:
                    {
                        byte d0 = inArray[i];

                        output[j + 0] = table[d0 >> 2];
                        output[j + 1] = table[(d0 & 0x03) << 4];
                        j += 2;
                    }
                    break;

                    //default or case 0: no further operations are needed.
            }

            return new string(output, 0, j);
        }

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64-url digits. Parameters specify
        /// the subset as an offset in the input array, and the number of elements in the array to convert.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation in base 64 url encoding of length elements of inArray, starting at position offset.</returns>
        /// <exception cref="ArgumentNullException">'inArray' is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">offset or length is negative OR offset plus length is greater than the length of inArray.</exception>
        public static string MsalEncode(byte[] inArray)
        {
            if (inArray == null)
                return null;

            return MsalEncode(inArray, 0, inArray.Length);
        }

        protected bool RequestBodyHasUserAssertionWithHeader(Request req, string headerName)
        {
            req.Content.TryComputeLength(out var len);
            byte[] content = new byte[len];
            var stream = new MemoryStream((int)len);
            req.Content.WriteTo(stream, default);
            var body = Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
            var parts = body.Split('&');
            foreach (var part in parts)
            {
                if (part.StartsWith("client_assertion="))
                {
                    var assertion = part.AsSpan();
                    int start = assertion.IndexOf('=') + 1;
                    assertion = assertion.Slice(start);
                    int end = assertion.IndexOf('.');
                    var jwt = assertion.Slice(0, end);
                    string convertedToken = jwt.ToString().Replace('_', '/').Replace('-', '+');
                    switch (jwt.Length % 4)
                    {
                        case 2:
                            convertedToken += "==";
                            break;
                        case 3:
                            convertedToken += "=";
                            break;
                    }

                    Utf8JsonReader reader = new Utf8JsonReader(Convert.FromBase64String(convertedToken));
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.PropertyName)
                        {
                            var header = reader.GetString();
                            if (header == headerName)
                            {
                                return true;
                            }

                            reader.Read();
                        }
                    }
                }
            }

            return false;
        }

        protected MockTransport Createx5cValidatingTransport(bool sendCertChain) => new MockTransport((req) =>
        {
            // respond to tenant discovery
            if (req.Uri.Path.StartsWith("/common/discovery"))
            {
                return new MockResponse(200).SetContent(DiscoveryResponseBody);
            }

            // respond to token request
            if (req.Uri.Path.EndsWith("/token"))
            {
                Assert.That(sendCertChain, Is.EqualTo(RequestBodyHasUserAssertionWithHeader(req, "x5c")));
                return new MockResponse(200).WithContent(
                        $"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"{expectedToken}\" }}");
            }
            return new MockResponse(200);
        });

        public class CommonCredentialTestConfig
        {
            public bool? DisableMetadataDiscovery { get; set; }
            public HttpPipelineTransport Transport { get; set; }
        }
    }
}
