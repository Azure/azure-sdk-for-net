// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientCertificateCredentialTests : ClientTestBase
    {
        public ClientCertificateCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void VerifyCtorParametersValidation()
        {
            var tenantId = Guid.NewGuid().ToString();

            var clientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath, "password");

            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(null, clientId, mockCert));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, null, mockCert));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, clientId, null));
        }

        [Test]
        public async Task VerifyClientCertificateRequestAsync()
        {
            var response = new MockResponse(200);

            var expectedToken = "mock-msi-access-token";

            response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_in\": 3600 }}");

            var mockTransport = new MockTransport(response);

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath, "password");

            ClientCertificateCredential credential = InstrumentClient(new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, options));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);

            MockRequest request = mockTransport.SingleRequest;

            Assert.IsTrue(request.Content.TryComputeLength(out long contentLen));

            var content = new byte[contentLen];

            await request.Content.WriteToAsync(new MemoryStream(content), default);

            Assert.IsTrue(TryParseFormEncodedBody(content, out Dictionary<string, string> parsedBody));

            Assert.IsTrue(parsedBody.TryGetValue("response_type", out string responseType) && responseType == "token");

            Assert.IsTrue(parsedBody.TryGetValue("grant_type", out string grantType) && grantType == "client_credentials");

            Assert.IsTrue(parsedBody.TryGetValue("client_assertion_type", out string assertionType) && assertionType == "urn:ietf:params:oauth:client-assertion-type:jwt-bearer");

            Assert.IsTrue(parsedBody.TryGetValue("client_id", out string actualClientId) && actualClientId == expectedClientId);

            Assert.IsTrue(parsedBody.TryGetValue("scope", out string actualScope) && actualScope == MockScopes.Default.ToString());

            Assert.IsTrue(parsedBody.TryGetValue("client_assertion", out string clientAssertion));

            // var header
            VerifyClientAssertion(clientAssertion, expectedTenantId, expectedClientId, mockCert);
        }

        [Test]
        public async Task VerifyClientCertificateRequestFailedAsync()
        {
            var response = new MockResponse(400);

            response.SetContent($"{{ \"error_code\": \"InvalidSecret\", \"message\": \"The specified client_secret is incorrect\" }}");

            var mockTransport = new MockTransport(response);

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath, "password");

            ClientCertificateCredential credential = InstrumentClient(new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, options));

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            await Task.CompletedTask;
        }

        [Test]
        public async Task VerifyClientCertificateCredentialExceptionAsync()
        {
            string expectedInnerExMessage = Guid.NewGuid().ToString();

            var mockAadClient = new MockAadIdentityClient(() => { throw new MockClientException(expectedInnerExMessage); });

            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath, "password");

            ClientCertificateCredential credential = InstrumentClient(new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, CredentialPipeline.GetInstance(null), mockAadClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expectedInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        public void VerifyClientAssertion(string clientAssertion, string expectedTenantId, string expectedClientId, X509Certificate2 clientCertificate)
        {
            var splitAssertion = clientAssertion.Split('.');

            Assert.IsTrue(splitAssertion.Length == 3);

            var compactHeader = splitAssertion[0];
            var compactPayload = splitAssertion[1];
            var encodedSignature = splitAssertion[2];

            // verify the JWT header
            using (JsonDocument json = JsonDocument.Parse(Base64Url.Decode(compactHeader)))
            {
                Assert.IsTrue(json.RootElement.TryGetProperty("typ", out JsonElement typProp) && typProp.GetString() == "JWT");
                Assert.IsTrue(json.RootElement.TryGetProperty("alg", out JsonElement algProp) && algProp.GetString() == "RS256");
                Assert.IsTrue(json.RootElement.TryGetProperty("x5t", out JsonElement x5tProp) && x5tProp.GetString() == Base64Url.HexToBase64Url(clientCertificate.Thumbprint));
            }

            // verify the JWT payload
            using (JsonDocument json = JsonDocument.Parse(Base64Url.Decode(compactPayload)))
            {
                Assert.IsTrue(json.RootElement.TryGetProperty("aud", out JsonElement audProp) && audProp.GetString() == $"https://login.microsoftonline.com/{expectedTenantId}/oauth2/v2.0/token");
                Assert.IsTrue(json.RootElement.TryGetProperty("iss", out JsonElement issProp) && issProp.GetString() == expectedClientId);
                Assert.IsTrue(json.RootElement.TryGetProperty("sub", out JsonElement subProp) && subProp.GetString() == expectedClientId);
                Assert.IsTrue(json.RootElement.TryGetProperty("nbf", out JsonElement nbfProp) && nbfProp.GetInt64() <= DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                Assert.IsTrue(json.RootElement.TryGetProperty("exp", out JsonElement expProp) && expProp.GetInt64() > DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                ;
            }

            // verify the JWT signature
            Assert.IsTrue(clientCertificate.GetRSAPublicKey().VerifyData(Encoding.ASCII.GetBytes(compactHeader + "." + compactPayload), Base64Url.Decode(encodedSignature), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        }

        public bool TryParseFormEncodedBody(byte[] content, out Dictionary<string, string> parsed)
        {
            parsed = new Dictionary<string, string>();

            var contentStr = Encoding.UTF8.GetString(content);

            foreach (string parameter in contentStr.Split('&'))
            {
                if (string.IsNullOrEmpty(parameter))
                {
                    return false;
                }

                var splitParam = parameter.Split('=');

                if (splitParam.Length != 2)
                {
                    return false;
                }

                parsed[splitParam[0]] = Uri.UnescapeDataString(splitParam[1]);
            }

            return true;
        }

    }
}
