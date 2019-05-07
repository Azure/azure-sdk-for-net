// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BearerTokenAuthenticationPolicyTests: SyncAsyncPolicyTestBase
    {
        public BearerTokenAuthenticationPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task UsesTokenProvidedByCredentials()
        {
            var credentialsMock = new Mock<TokenCredential>();
            credentialsMock.Setup(
                    credential => credential.GetTokenAsync(
                        It.Is<string[]>(strings => strings.SequenceEqual(new[] { "scope1", "scope2" })),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync("token");

            var policy = new BearerTokenAuthenticationPolicy(credentialsMock.Object, new [] { "scope1", "scope2" });
            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy);

            Assert.True(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer token", authValue);
        }

        [Test]
        public async Task RequestsTokenEveryRequest()
        {
            string currentToken = null;
            var credentialsMock = new Mock<TokenCredential>();
            credentialsMock.Setup(
                    credential => credential.GetTokenAsync(
                        It.Is<string[]>(strings => strings.SequenceEqual(new[] { "scope1", "scope2" })),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => currentToken);

            var policy = new BearerTokenAuthenticationPolicy(credentialsMock.Object, new [] { "scope1", "scope2" });
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            currentToken = "token1";
            await SendGetRequest(transport, policy);

            currentToken = "token2";
            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual("Bearer token1", auth1Value);
            Assert.AreEqual("Bearer token2", auth2Value);
        }

        [Test]
        public async Task CachesHeaderValue()
        {
            var credentialsMock = new Mock<TokenCredential>();
            credentialsMock.Setup(
                    credential => credential.GetTokenAsync(
                        It.Is<string[]>(strings => strings.SequenceEqual(new[] { "scope"})),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync("token");

            var policy = new BearerTokenAuthenticationPolicy(credentialsMock.Object, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreSame(auth1Value, auth1Value);
            Assert.AreEqual("Bearer token", auth2Value);
        }
    }
}
