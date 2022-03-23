// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientAssertionCredentialLiveTests : IdentityRecordedTestBase
    {
        public ClientAssertionCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearDiscoveryCache()
        {
            StaticCachesUtilities.ClearStaticMetadataProviderCache();
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task AuthnenticateWithAssertionCallback(bool useAsyncCallback)
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;
            var cert = new X509Certificate2(TestEnvironment.ServicePrincipalCertificatePfxPath);

            var options = InstrumentClientOptions(new ClientAssertionCredentialOptions());

            ClientAssertionCredential credential;

            if (useAsyncCallback)
            {
                Func<CancellationToken, Task<string>> assertionCallback = (ct) => Task.FromResult(CreateClientAssertionJWT(options.AuthorityHost, clientId, tenantId, cert));

                credential = InstrumentClient(new ClientAssertionCredential(tenantId, clientId, assertionCallback, options));
            }
            else
            {
                Func<string> assertionCallback = () => CreateClientAssertionJWT(options.AuthorityHost, clientId, tenantId, cert);

                credential = InstrumentClient(new ClientAssertionCredential(tenantId, clientId, assertionCallback, options));
            }

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // ensure we can initially acquire a  token
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);

            // ensure subsequent calls before the token expires are served from the token cache
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);

            // ensure new credentials don't share tokens from the cache
            var credential2 = new ClientCertificateCredential(tenantId, clientId, cert, options);

            AccessToken token2 = await credential2.GetTokenAsync(tokenRequestContext);

            // this assert is conditional because the access token is scrubbed in the recording so they will never be different
            if (Mode != RecordedTestMode.Playback && Mode != RecordedTestMode.None)
            {
                Assert.AreNotEqual(token.Token, token2.Token);
            }
        }

        private static string CreateClientAssertionJWT(Uri authorityHost, string clientId, string tenantId, X509Certificate2 clientCertificate)
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
    }
}
