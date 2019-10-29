// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BearerTokenAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        public BearerTokenAuthenticationPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task UsesTokenProvidedByCredentials()
        {
            var credentialsMock = new Mock<TokenCredential>();

            if (IsAsync)
            {
                credentialsMock.Setup(
                        credential => credential.GetTokenAsync(
                            It.Is<TokenRequestContext>(request => request.Scopes.SequenceEqual(new[] { "scope1", "scope2" })),
                            It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AccessToken("token", DateTimeOffset.MaxValue));
            }
            else
            {
                credentialsMock.Setup(
                        credential => credential.GetToken(
                            It.Is<TokenRequestContext>(request => request.Scopes.SequenceEqual(new[] { "scope1", "scope2" })),
                            It.IsAny<CancellationToken>()))
                    .Returns(new AccessToken("token", DateTimeOffset.MaxValue));
            }

            var policy = new BearerTokenAuthenticationPolicy(credentialsMock.Object, new[] { "scope1", "scope2" });
            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy);

            Assert.True(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer token", authValue);
        }

        [Test]
        public async Task RequestsTokenEveryRequest()
        {
            AccessToken currentToken = new AccessToken(null, default);
            var credentialsMock = new Mock<TokenCredential>();

            if (IsAsync)
            {
                credentialsMock.Setup(
                        credential => credential.GetTokenAsync(
                            It.Is<TokenRequestContext>(request => request.Scopes.SequenceEqual(new[] { "scope1", "scope2" })),
                            It.IsAny<CancellationToken>()))
                    .ReturnsAsync(() => currentToken);
            }
            else
            {
                credentialsMock.Setup(
                        credential => credential.GetToken(
                            It.Is<TokenRequestContext>(request => request.Scopes.SequenceEqual(new[] { "scope1", "scope2" })),
                            It.IsAny<CancellationToken>()))
                    .Returns(() => currentToken);
            }

            var policy = new BearerTokenAuthenticationPolicy(credentialsMock.Object, new[] { "scope1", "scope2" });
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            currentToken = new AccessToken("token1", DateTimeOffset.UtcNow);
            await SendGetRequest(transport, policy);

            currentToken = new AccessToken("token2", DateTimeOffset.UtcNow);
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
            if (IsAsync)
            {
                credentialsMock.Setup(
                        credential => credential.GetTokenAsync(
                            It.Is<TokenRequestContext>(request => request.Scopes.SequenceEqual(new[] { "scope" })),
                            It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AccessToken("token", DateTimeOffset.MaxValue));
            }
            else
            {
                credentialsMock.Setup(
                        credential => credential.GetToken(
                            It.Is<TokenRequestContext>(request => request.Scopes.SequenceEqual(new[] { "scope" })),
                            It.IsAny<CancellationToken>()))
                    .Returns(new AccessToken("token", DateTimeOffset.MaxValue));
            }

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
