// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using Moq;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientSecretCredentialTests : ClientTestBase
    {
        public ClientSecretCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void VerifyCtorParametersValidation()
        {
            var tenantId = Guid.NewGuid().ToString();

            var clientId = Guid.NewGuid().ToString();

            var secret = "secret";

            Assert.Throws<ArgumentNullException>(() => new ClientSecretCredential(null, clientId, secret));
            Assert.Throws<ArgumentNullException>(() => new ClientSecretCredential(tenantId, null, secret));
            Assert.Throws<ArgumentNullException>(() => new ClientSecretCredential(tenantId, clientId, null));
        }

        [Test]
        public async Task VerifyClientSecretCredentialRequestAsync()
        {
            var response = new MockResponse(200);

            var expectedToken = "mock-msi-access-token";

            response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_in\": 3600 }}");

            var mockTransport = new MockTransport(response);

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var expectedClientSecret = "secret";

            ClientSecretCredential client = InstrumentClient(new ClientSecretCredential(expectedTenantId, expectedClientId, expectedClientSecret, options));

            AccessToken actualToken = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);

            MockRequest request = mockTransport.SingleRequest;

            Assert.IsTrue(request.Content.TryComputeLength(out long contentLen));

            var content = new byte[contentLen];

            await request.Content.WriteToAsync(new MemoryStream(content), default);

            Assert.IsTrue(TryParseFormEncodedBody(content, out Dictionary<string, string> parsedBody));

            Assert.IsTrue(parsedBody.TryGetValue("response_type", out string responseType) && responseType == "token");

            Assert.IsTrue(parsedBody.TryGetValue("grant_type", out string grantType) && grantType == "client_credentials");

            Assert.IsTrue(parsedBody.TryGetValue("client_id", out string actualClientId) && actualClientId == expectedClientId);

            Assert.IsTrue(parsedBody.TryGetValue("client_secret", out string actualClientSecret) && actualClientSecret == "secret");

            Assert.IsTrue(parsedBody.TryGetValue("scope", out string actualScope) && actualScope == MockScopes.Default.ToString());
        }

        [Test]
        public async Task VerifyClientSecretRequestFailedAsync()
        {
            var response = new MockResponse(400);

            response.SetContent($"{{ \"error_code\": \"InvalidSecret\", \"message\": \"The specified client_secret is incorrect\" }}");

            var mockTransport = new MockTransport(response);

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var expectedClientSecret = "secret";

            ClientSecretCredential client = InstrumentClient(new ClientSecretCredential(expectedTenantId, expectedClientId, expectedClientSecret, options));

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            await Task.CompletedTask;
        }

        [Test]
        public async Task VerifyClientSecretCredentialExceptionAsync()
        {
            string expectedInnerExMessage = Guid.NewGuid().ToString();

            var mockAadClient = new MockAadIdentityClient(() => { throw new MockClientException(expectedInnerExMessage); });

            ClientSecretCredential credential = InstrumentClient(new ClientSecretCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), CredentialPipeline.GetInstance(null), mockAadClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expectedInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
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
