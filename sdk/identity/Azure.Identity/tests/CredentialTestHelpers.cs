// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    internal static class CredentialTestHelpers
    {
        public static string[] DefaultScope = new string[] { "https://management.azure.com//.default" };
        private const string DiscoveryResponseBody =
            "{\"tenant_discovery_endpoint\": \"https://login.microsoftonline.com/c54fac88-3dd3-461f-a7c4-8a368e0340b3/v2.0/.well-known/openid-configuration\",\"api-version\": \"1.1\",\"metadata\":[{\"preferred_network\": \"login.microsoftonline.com\",\"preferred_cache\": \"login.windows.net\",\"aliases\":[\"login.microsoftonline.com\",\"login.windows.net\",\"login.microsoft.com\",\"sts.windows.net\"]},{\"preferred_network\": \"login.partner.microsoftonline.cn\",\"preferred_cache\": \"login.partner.microsoftonline.cn\",\"aliases\":[\"login.partner.microsoftonline.cn\",\"login.chinacloudapi.cn\"]},{\"preferred_network\": \"login.microsoftonline.de\",\"preferred_cache\": \"login.microsoftonline.de\",\"aliases\":[\"login.microsoftonline.de\"]},{\"preferred_network\": \"login.microsoftonline.us\",\"preferred_cache\": \"login.microsoftonline.us\",\"aliases\":[\"login.microsoftonline.us\",\"login.usgovcloudapi.net\"]},{\"preferred_network\": \"login-us.microsoftonline.com\",\"preferred_cache\": \"login-us.microsoftonline.com\",\"aliases\":[\"login-us.microsoftonline.com\"]}]}";
        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForAzureCli() => CreateTokenForAzureCli(TimeSpan.FromSeconds(30));

        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForAzureCli(TimeSpan expiresOffset)
        {
            const string expiresOnStringFormat = "yyyy-MM-dd HH:mm:ss.ffffff";

            var expiresOnString = DateTimeOffset.Now.Add(expiresOffset).ToString(expiresOnStringFormat);
            var expiresOn = DateTimeOffset.ParseExact(expiresOnString, expiresOnStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal);
            var token = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), expiresOn.UtcDateTime);
            var json = $"{{ \"accessToken\": \"{token}\", \"expiresOn\": \"{expiresOnString}\" }}";
            return (token, expiresOn, json);
        }

        public static (string Token, string Json) CreateTokenForAzureCliExpiresOn(DateTimeOffset expiresOn, bool includeExpiresOn)
        {
            const string expiresOnStringFormat = "yyyy-MM-dd HH:mm:ss.ffffff";

            var expiresOnString = expiresOn.ToLocalTime().ToString(expiresOnStringFormat);
            var token = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), expiresOn.UtcDateTime);
            var json = includeExpiresOn ?
                $$"""{ "accessToken": "{{token}}", "expiresOn": "{{expiresOnString}}", "expires_on": {{expiresOn.ToUnixTimeSeconds()}} }""" :
                $$"""{ "accessToken": "{{token}}", "expiresOn": "{{expiresOnString}}" }""";
            return (token, json);
        }

        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForAzureDeveloperCli() => CreateTokenForAzureDeveloperCli(TimeSpan.FromSeconds(30));

        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForAzureDeveloperCli(TimeSpan expiresOffset)
        {
            const string expiresOnStringFormat = "yyyy-MM-ddTHH:mm:ssZ";

            var expiresOnString = DateTimeOffset.Now.Add(expiresOffset).ToString(expiresOnStringFormat);
            var expiresOn = DateTimeOffset.ParseExact(expiresOnString, expiresOnStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal);
            var token = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), expiresOn.UtcDateTime);
            var json = $"{{ \"token\": \"{token}\", \"expiresOn\": \"{expiresOnString}\" }}";
            return (token, expiresOn, json);
        }

        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForAzureDeveloperCliExpiresIn(int seconds = 30)
        {
            var expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(seconds);
            var token = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), expiresOn.UtcDateTime);
            var json = $"{{ \"token\": \"{token}\", \"expiresIn\": {seconds} }}";
            return (token, expiresOn, json);
        }

        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForAzurePowerShell(TimeSpan expiresOffset)
        {
            var expiresOn = DateTimeOffset.FromUnixTimeSeconds(DateTimeOffset.UtcNow.Add(expiresOffset).ToUnixTimeSeconds());
            var token = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), expiresOn.UtcDateTime);
            var xml = @$"<Object Type=""System.Management.Automation.PSCustomObject""><Property Name=""Token"" Type=""System.String"">{token}</Property><Property Name=""ExpiresOn"" Type=""System.Int64"">{expiresOn.ToUnixTimeSeconds()}</Property></Object>";
            return (token, expiresOn, xml);
        }

        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForVisualStudio() => CreateTokenForVisualStudio(TimeSpan.FromSeconds(30));

        public static (string Token, DateTimeOffset ExpiresOn, string Json) CreateTokenForVisualStudio(TimeSpan expiresOffset)
        {
            var expiresOnString = DateTimeOffset.UtcNow.Add(expiresOffset).ToString("s");
            var expiresOn = DateTimeOffset.Parse(expiresOnString);
            var token = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), expiresOn.UtcDateTime);
            var json = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"{expiresOnString}\" }}";
            return (token, expiresOn, json);
        }

        public static TestFileSystemService CreateFileSystemForVisualStudio(params int[] preferences)
        {
            var sb = new StringBuilder();
            var paths = new List<string>();

            for (var i = 0; i < preferences.Length || i == 0; i++)
            {
                var preference = preferences.Length > 0 ? preferences[i] : 0;
                if (i > 0)
                {
                    sb.Append(", ");
                }

                paths.Add($"c:\\VS{preference}\\service.exe");
                sb.Append($"{{\"Path\": \"c:\\\\VS{preference}\\\\service.exe\", \"Arguments\": [\"{preference}\"], \"Preference\": {preference}}}");
            }

            var json = $"{{ \"TokenProviders\": [{sb}] }}";
            return new TestFileSystemService { FileExistsHandler = p => paths.Contains(p), ReadAllHandler = p => json };
        }

        public static TestFileSystemService CreateFileSystemForVisualStudioCode(IdentityTestEnvironment testEnvironment, string cloudName = default)
        {
            var sb = new StringBuilder("{");

            if (testEnvironment.IdentityTenantId != default)
            {
                sb.AppendFormat("\"azure.tenant\": \"{0}\"", testEnvironment.IdentityTenantId);
            }

            if (testEnvironment.IdentityTenantId != default && cloudName != default)
            {
                sb.Append(',');
            }

            if (cloudName != default)
            {
                sb.AppendFormat("\"azure.cloud\": \"{0}\"", cloudName);
            }

            sb.Append('}');

            return new TestFileSystemService { FileExistsHandler = p => Path.HasExtension("json"), ReadAllHandler = s => sb.ToString() };
        }

        public static async ValueTask<AuthenticationRecord> GetAuthenticationRecordAsync(IdentityTestEnvironment testEnvironment, RecordedTestMode mode)
        {
            var clientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
            if (mode == RecordedTestMode.Playback)
            {
                var mockUsername = "mockuser@mockdomain.com";
                var mockEnvironment = AzureAuthorityHosts.AzurePublicCloud.ToString();
                var mockHomeId = $"{Guid.NewGuid()}.{Guid.NewGuid()}";
                var mockTenantId = Guid.NewGuid().ToString();

                return new AuthenticationRecord(mockUsername, mockEnvironment, mockHomeId, mockTenantId, clientId);
            }

            var username = testEnvironment.Username;
            var password = testEnvironment.Password;
            var tenantId = testEnvironment.IdentityTenantId;

            var result = await PublicClientApplicationBuilder.Create(clientId)
                .WithTenantId(tenantId)
                .Build()
                .AcquireTokenByUsernamePassword(new[] { testEnvironment.KeyvaultScope }, username, password)
                .ExecuteAsync();

            return new AuthenticationRecord(result, clientId);
        }

        public static async Task<string> GetRefreshTokenAsync(IdentityTestEnvironment testEnvironment, RecordedTestMode mode)
        {
            if (mode == RecordedTestMode.Playback)
            {
                return Guid.NewGuid().ToString();
            }

            var clientId = "aebc6443-996d-45c2-90f0-388ff96faa56";
            var username = testEnvironment.Username;
            var password = testEnvironment.Password;
            var authorityUri = new Uri(new Uri(testEnvironment.AuthorityHostUrl), testEnvironment.IdentityTenantId).ToString();

            var client = PublicClientApplicationBuilder.Create(clientId)
                .WithAuthority(authorityUri)
                .Build();

            var retriever = new RefreshTokenRetriever(client.UserTokenCache);
            await client.AcquireTokenByUsernamePassword(new[] { testEnvironment.KeyvaultScope }, username, password).ExecuteAsync();

            StaticCachesUtilities.ClearStaticMetadataProviderCache();
            return retriever.RefreshToken;
        }

        public static async Task<IDisposable> CreateRefreshTokenFixtureAsync(IdentityTestEnvironment testEnvironment, RecordedTestMode mode, string serviceName, string cloudName)
        {
            var refreshToken = await GetRefreshTokenAsync(testEnvironment, mode);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return WindowsRefreshTokenFixture.Create(serviceName, cloudName, refreshToken);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OsxRefreshTokenFixture.Create(serviceName, cloudName, refreshToken);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return LinuxRefreshTokenFixture.Create(serviceName, cloudName, refreshToken);
            }

            throw new PlatformNotSupportedException();
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

        public static bool RequestBodyHasUserAssertionWithHeader(Request req, string headerName)
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

        public static MockTransport Createx5cValidatingTransport(bool sendCertChain, string token) => new MockTransport((req) =>
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
                        $"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"{token}\" }}");
            }
            return new MockResponse(200);
        });

        public static byte[] GetMockCacheBytes(string objectId, string userName, string clientId, string tenantId, string token, string refreshToken)
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

        public static MockResponse CreateMockMsalTokenResponse(int responseCode, string token, string tenantId, string userName, string objectId = null)
        {
            var response = new MockResponse(responseCode);
            var idToken = CreateMsalIdToken(Guid.NewGuid().ToString(), userName, tenantId);
            response.SetContent(
                $"{{\"token_type\": \"Bearer\",\"access_token\": \"{token}\",\"refresh_token\": \"{token}\",\"scope\": null,\"client_info\": null,\"id_token\": null,\"expires_in\": 10000,\"ext_expires_in\": 100000,\"refresh_in\": 1000, \"correlation_id\": \"{Guid.NewGuid().ToString()}\", \"client_info\": \"{CreateMsalClientInfo(objectId, tenantId)}\",\"id_token\": \"{idToken}\"}}");
            return response;
        }

        public static MockResponse CreateMockMsalDeviceCodeResponse(string deviceCode = null, string userCode = null)
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

        public static bool ExtractMsalDisableInstanceDiscoveryProperty(TokenCredential cred)
        {
            var targetCred = cred is EnvironmentCredential environmentCredential ? environmentCredential.Credential : cred;
            var msalClient = targetCred.GetType().GetProperty("Client", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(targetCred);
            bool DisableInstanceDiscovery = (bool)msalClient.GetType().GetProperty("DisableInstanceDiscovery", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(msalClient);
            return DisableInstanceDiscovery;
        }

        public static string[] ExtractAdditionalTenantProperty(TokenCredential cred)
        {
            var targetCred = cred is EnvironmentCredential environmentCredential ? environmentCredential.Credential : cred;
            var additionallyAllowedTenantIds = (string[])targetCred.GetType().GetProperty("AdditionallyAllowedTenantIds", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(targetCred);
            return additionallyAllowedTenantIds;
        }

        public static bool TryGetConfiguredTenantIdForMsalCredential(TokenCredential cred, out string tenantID)
        {
            var targetCred = cred is EnvironmentCredential environmentCredential ? environmentCredential.Credential : cred;
            object clientObject = targetCred.GetType().GetProperty("Client", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(targetCred);
            tenantID = clientObject switch
            {
                MsalPublicClient msalPub => msalPub?.TenantId,
                MsalConfidentialClient msalConf => msalConf?.TenantId,
                _ => null
            };
            if (tenantID == null)
            {
                tenantID = targetCred.GetType().GetProperty("TenantId", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(targetCred) as string;
            }
            return tenantID != null;
        }

        public static bool IsMsalCredential(TokenCredential cred)
        {
            var clientType = GetMsalClientType(cred);
            return GetMsalClientType(cred) == typeof(MsalPublicClient) || clientType == typeof(MsalConfidentialClient);
        }

        public static bool IsCredentialTypePubClient(TokenCredential cred)
        {
            var clientType = GetMsalClientType(cred);
            return clientType == typeof(MsalPublicClient);
        }

        private static Type GetMsalClientType(TokenCredential cred)
        {
            var targetCred = cred is EnvironmentCredential environmentCredential ? environmentCredential.Credential : cred;
            return targetCred.GetType().GetProperty("Client", BindingFlags.Instance | BindingFlags.NonPublic)?.PropertyType;
        }

        public static string CreateClientAssertionJWT(Uri authorityHost, string clientId, string tenantId, X509Certificate2 clientCertificate)
        {
            var audienceBuilder = new RequestUriBuilder();

            audienceBuilder.Reset(authorityHost);

            audienceBuilder.AppendPath(tenantId + "/v2.0", false);

            var audience = audienceBuilder.ToString();

            var headerBuff = new ArrayBufferWriter<byte>();

            using (var headerJson = new Utf8JsonWriter(headerBuff))
            {
                headerJson.WriteStartObject();

                headerJson.WriteString("typ", "JWT");
                headerJson.WriteString("alg", "RS256");
                headerJson.WriteString("x5t", HexToBase64Url(clientCertificate.Thumbprint));

                headerJson.WriteEndObject();

                headerJson.Flush();
            }

            var payloadBuff = new ArrayBufferWriter<byte>();

            using (var payloadJson = new Utf8JsonWriter(payloadBuff))
            {
                payloadJson.WriteStartObject();

                payloadJson.WriteString("jti", Guid.NewGuid());
                payloadJson.WriteString("aud", audience);
                payloadJson.WriteString("iss", clientId);
                payloadJson.WriteString("sub", clientId);
                payloadJson.WriteNumber("nbf", DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                payloadJson.WriteNumber("exp", (DateTimeOffset.UtcNow + TimeSpan.FromMinutes(30)).ToUnixTimeSeconds());

                payloadJson.WriteEndObject();

                payloadJson.Flush();
            }

            string header = Base64Url.Encode(headerBuff.WrittenMemory.ToArray());

            string payload = Base64Url.Encode(payloadBuff.WrittenMemory.ToArray());

            string flattenedJws = header + "." + payload;

            byte[] signature = clientCertificate.GetRSAPrivateKey().SignData(Encoding.ASCII.GetBytes(flattenedJws), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            return flattenedJws + "." + Base64Url.Encode(signature);
        }

        public static string HexToBase64Url(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return Base64Url.Encode(bytes);
        }

        private sealed class RefreshTokenRetriever
        {
            public string RefreshToken { get; private set; }

            public RefreshTokenRetriever(ITokenCache tokenCache)
            {
                tokenCache.SetAfterAccess(AfterAccessHandler);
            }

            private void AfterAccessHandler(TokenCacheNotificationArgs args)
            {
                var data = args.TokenCache.SerializeMsalV3();
                var serializedData = new UTF8Encoding().GetString(data);
                var root = JsonDocument.Parse(serializedData).RootElement;
                var refreshTokenObject = root.GetProperty("RefreshToken");
                foreach (JsonProperty property in refreshTokenObject.EnumerateObject())
                {
                    if (property.Name.StartsWith(args.Account.HomeAccountId.Identifier))
                    {
                        RefreshToken = property.Value.GetProperty("secret").GetString();
                        return;
                    }
                }
            }
        }

        private sealed class WindowsRefreshTokenFixture : IDisposable
        {
            private readonly string _target;

            public static IDisposable Create(string serviceName, string cloudName, string refreshToken)
            {
                var target = $"VS Code Azure/{cloudName}";
                var credentialBlobPtr = Marshal.StringToHGlobalAnsi(refreshToken);

                var credentialData = new WindowsNativeMethods.CredentialData
                {
                    AttributeCount = 0,
                    Attributes = IntPtr.Zero,
                    Comment = null,
                    CredentialBlob = credentialBlobPtr,
                    CredentialBlobSize = (uint)refreshToken.Length,
                    Flags = 0,
                    Persist = WindowsNativeMethods.CRED_PERSIST.CRED_PERSIST_LOCAL_MACHINE,
                    TargetAlias = null,
                    TargetName = $"{serviceName}/{cloudName}",
                    Type = WindowsNativeMethods.CRED_TYPE.GENERIC,
                    UserName = "Azure"
                };

                var credentialDataPtr = Marshal.AllocHGlobal(Marshal.SizeOf(credentialData));

                try
                {
                    Marshal.StructureToPtr(credentialData, credentialDataPtr, false);
                    WindowsNativeMethods.CredWrite(credentialDataPtr);
                    return new WindowsRefreshTokenFixture(target);
                }
                finally
                {
                    Marshal.FreeHGlobal(credentialDataPtr);
                    Marshal.FreeHGlobal(credentialBlobPtr);
                }
            }

            private WindowsRefreshTokenFixture(string target)
            {
                _target = target;
            }

            public void Dispose() => WindowsNativeMethods.CredDelete(_target, WindowsNativeMethods.CRED_TYPE.GENERIC);
        }

        private sealed class OsxRefreshTokenFixture : IDisposable
        {
            private readonly string _serviceName;
            private readonly string _cloudName;

            public static IDisposable Create(string serviceName, string cloudName, string refreshToken)
            {
                IntPtr itemRef = IntPtr.Zero;

                try
                {
                    MacosNativeMethods.SecKeychainAddGenericPassword(IntPtr.Zero, serviceName, cloudName, refreshToken, out itemRef);
                }
                finally
                {
                    MacosNativeMethods.CFRelease(itemRef);
                }

                return new OsxRefreshTokenFixture(serviceName, cloudName);
            }

            private OsxRefreshTokenFixture(string serviceName, string cloudName)
            {
                _serviceName = serviceName;
                _cloudName = cloudName;
            }

            public void Dispose()
            {
                IntPtr credentialsPtr = IntPtr.Zero;
                IntPtr itemRef = IntPtr.Zero;

                try
                {
                    MacosNativeMethods.SecKeychainFindGenericPassword(IntPtr.Zero, _serviceName, _cloudName, out _, out credentialsPtr, out itemRef);
                    MacosNativeMethods.SecKeychainItemDelete(itemRef);
                }
                finally
                {
                    try
                    {
                        MacosNativeMethods.SecKeychainItemFreeContent(IntPtr.Zero, credentialsPtr);
                    }
                    finally
                    {
                        MacosNativeMethods.CFRelease(itemRef);
                    }
                }
            }
        }

        private sealed class LinuxRefreshTokenFixture : IDisposable
        {
            private readonly string _serviceName;
            private readonly string _cloudName;

            public static IDisposable Create(string serviceName, string cloudName, string refreshToken)
            {
                IntPtr schemaPtr = GetLibsecretSchema();

                try
                {
                    LinuxNativeMethods.secret_password_store_sync(schemaPtr, LinuxNativeMethods.SECRET_COLLECTION_SESSION, $"{serviceName}/{cloudName}", refreshToken, IntPtr.Zero, "service", serviceName, "account", cloudName);
                }
                finally
                {
                    LinuxNativeMethods.secret_schema_unref(schemaPtr);
                }

                return new LinuxRefreshTokenFixture(serviceName, cloudName);
            }

            public LinuxRefreshTokenFixture(string serviceName, string cloudName)
            {
                _serviceName = serviceName;
                _cloudName = cloudName;
            }

            public void Dispose()
            {
                IntPtr schemaPtr = GetLibsecretSchema();

                try
                {
                    LinuxNativeMethods.secret_password_clear_sync(schemaPtr, IntPtr.Zero, "service", _serviceName, "account", _cloudName);
                }
                finally
                {
                    LinuxNativeMethods.secret_schema_unref(schemaPtr);
                }
            }

            private static IntPtr GetLibsecretSchema()
                => LinuxNativeMethods.secret_schema_new("org.freedesktop.Secret.Generic",
                    LinuxNativeMethods.SecretSchemaFlags.SECRET_SCHEMA_DONT_MATCH_NAME,
                    "service",
                    LinuxNativeMethods.SecretSchemaAttributeType.SECRET_SCHEMA_ATTRIBUTE_STRING,
                    "account",
                    LinuxNativeMethods.SecretSchemaAttributeType.SECRET_SCHEMA_ATTRIBUTE_STRING);
        }
    }
}
