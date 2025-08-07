// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialFederatedTokenLiveTests : IdentityRecordedTestBase
    {
        public ManagedIdentityCredentialFederatedTokenLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearDiscoveryCache()
        {
            StaticCachesUtilities.ClearStaticMetadataProviderCache();
        }

        [NonParallelizable]
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/43401")]
        public async Task VerifyViaMockK8TokenExchangeEnvironment()
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;
            var authorityHostUrl = TestEnvironment.AuthorityHostUrl;

            var assertionAudienceBuilder = new RequestUriBuilder();
            assertionAudienceBuilder.Reset(new Uri(authorityHostUrl));
            assertionAudienceBuilder.AppendPath(tenantId);
            assertionAudienceBuilder.AppendPath("/oauth2/v2.0/token", escape: false);
            var assertionAudience = assertionAudienceBuilder.ToString();

#if NET9_0_OR_GREATER
            var assertionCert = X509CertificateLoader.LoadCertificateFromFile(TestEnvironment.ServicePrincipalCertificatePfxPath);
#else
            var assertionCert = new X509Certificate2(TestEnvironment.ServicePrincipalCertificatePfxPath);
#endif

            string tokenFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());

            File.WriteAllText(tokenFilePath, CreateClientAssertionJWT(clientId, assertionAudience, assertionCert));

            try
            {
                using (var environment = new TestEnvVar(new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", null },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null },
                    { "AZURE_CLIENT_ID", clientId },
                    { "AZURE_TENANT_ID", tenantId },
                    { "AZURE_AUTHORITY_HOST", authorityHostUrl },
                    { "AZURE_FEDERATED_TOKEN_FILE", tokenFilePath }
                }))
                {
                    var options = InstrumentClientOptions(new TokenCredentialOptions());
                    var credential = InstrumentClient(new ManagedIdentityCredential(options: options));

                    var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

                    var accessToken = await credential.GetTokenAsync(tokenRequestContext);

                    Assert.IsNotNull(accessToken.Token);
                }
            }
            finally
            {
                File.Delete(tokenFilePath);
            }
        }

        public static string CreateClientAssertionJWT(string clientId, string audience, X509Certificate2 clientCertificate)
        {
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

        private static string HexToBase64Url(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return Base64Url.Encode(bytes);
        }
    }
}
