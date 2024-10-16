// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Identity
{
    [TestFixture]
    public class EntraTokenCredentialTest
    {
        private const string SampleToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjMyNTAzNjgwMDAwfQ.9i7FNNHHJT8cOzo-yrAUJyBSfJ-tPPk2emcHavOEpWc";
        private const string SampleTokenExpiry = "2034-10-04T10:21:29.4729393+00:00";
        private const string ExpiredToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjEwMH0.1h_scYkNp-G98-O4cW6KvfJZwiz54uJMyeDACE4nypg";
        protected const string TokenResponseTemplate = "{{\"identity\":{{\"id\":\"8:acs:52a5e676-39a3-4f45-a8ed-5a162dbbd7eb_cdc5aeea-15c5-4db6-b079-fcadd2505dc2_cab309e5-a2e7-4ac8-b04e-5fadc3aa90fa\"}},\n" +
                        "\"accessToken\":{{\"token\":\"{0}\",\n" +
                        "\"expiresOn\":\"{1}\"}}}}";
        protected string TokenResponse = string.Format(TokenResponseTemplate, SampleToken, SampleTokenExpiry);

        private Mock<TokenCredential> _mockTokenCredential = null!;
        private string[] _scopes = new string[] { "https://communication.azure.com/clients/VoIP" };
        private string _resourceEndpoint = "https://myResource.communication.azure.com";

        [SetUp]
        public void Setup()
        {
            _mockTokenCredential = new Mock<TokenCredential>();
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            _mockTokenCredential
              .Setup(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new AccessToken(SampleToken, expiryTime));
        }

        [Test]
        public void EntraTokenCredential_Init_ThrowsErrorWithNulls()
        {
            Assert.Throws<ArgumentNullException>(() => new EntraCommunicationTokenCredentialOptions(
                null,
                _mockTokenCredential.Object,
                _scopes));

            Assert.Throws<ArgumentException>(() => new EntraCommunicationTokenCredentialOptions(
                "",
                _mockTokenCredential.Object,
                _scopes));

            Assert.Throws<ArgumentNullException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                null,
                _scopes));

            Assert.Throws<ArgumentException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                new string[] { }));

            Assert.Throws<ArgumentNullException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                null));
        }

        [Test]
        public void EntraTokenCredential_InitWhtScopes_InitWithDefaultScope()
        {
            var credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object);
            var scopes = new[] { "https://communication.azure.com/clients/.default" };
            Assert.AreEqual(credential.Scopes, scopes);
        }

        [Test]
        public void EntraTokenCredential_Init_FetchesTokenImmediately()
        {
            // Arrange
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var options = CreateEntraTokenCredentialOptions();
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse) });
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);
            // Assert
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task EntraTokenCredential_GetToken_ReturnsToken()
        {
            // Arrange
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var options = CreateEntraTokenCredentialOptions();
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse) });
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act
            var token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);

            // Assert
            Assert.AreEqual(SampleToken, token.Token);
            Assert.AreEqual(token.ExpiresOn, expiryTime);
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task EntraTokenCredential_GetToken_InternalEntraTokenChangeInvalidatesCachedToken()
        {
            // Arrange
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var newToken = "newToken";
            var refreshOn = DateTimeOffset.Now;
            _mockTokenCredential
                .SetupSequence(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessToken("Entra token for call from constructor", refreshOn))
                .ReturnsAsync(new AccessToken("Entra token for the first getToken call token", expiryTime));

            var options = CreateEntraTokenCredentialOptions();
            var latestTokenResponse = string.Format(TokenResponseTemplate, newToken, SampleTokenExpiry);
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse), CreateMockResponse(200, latestTokenResponse) });
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);
            // Act
            var token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);

            // Assert for cached tokens are updated
            Assert.AreEqual(newToken, token.Token);
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
        }

        [Test]
        public async Task EntraTokenCredential_GetToken_MultipleCallsReturnsCachedToken()
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions();
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse) });
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act
            var token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);
            for (var i = 0; i < 10; i++)
            {
                token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);
            }
            // Assert
            Assert.AreEqual(SampleToken, token.Token);
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public void EntraTokenCredential_GetToken_ThrowsFailedResponse()
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions();
            var errorMessage = "{\"error\":{\"code\":\"BadRequest\",\"message\":\"Invalid request.\"}}";
            var mockResponses = new[]
            {
                CreateMockResponse(400, errorMessage),
                CreateMockResponse(400, errorMessage),
            };
            var mockTransport = CreateMockTransport(mockResponses);
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act & Assert
            Assert.ThrowsAsync<RequestFailedException>(async () => await entraTokenCredential.GetTokenAsync(CancellationToken.None));
        }

        [Test]
        public void EntraTokenCredential_GetToken_ThrowsInvalidJson()
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions();
            var errorMessage = "{\"error\":{\"code\":\"BadRequest\",\"message\":\"Invalid request.\"}}";
            var mockResponses = new[]
            {
                CreateMockResponse(200, errorMessage),
                CreateMockResponse(200, errorMessage),
            };
            var mockTransport = CreateMockTransport(mockResponses);

            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act & Assert
            Assert.ThrowsAsync<RequestFailedException>(async () => await entraTokenCredential.GetTokenAsync(CancellationToken.None));
        }

        [Test]
        public void EntraTokenCredential_GetToken_RetriesThreeTimesOnTransientError()
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions();
            var lastRetryErrorMessage = "Last Retry Error Message";
            var mockResponses = new MockResponse[]
            {
                CreateMockResponse(500, "First Retry Error Message"),
                CreateMockResponse(500, "Second Retry Error Message"),
                CreateMockResponse(500, "Third Retry Error Message"),
                CreateMockResponse(500, "Last retry for the pre-warm fetch"),
                CreateMockResponse(500, "First Retry Error Message"),
                CreateMockResponse(500, "Second Retry Error Message"),
                CreateMockResponse(500, "Third Retry Error Message"),
                CreateMockResponse(500, lastRetryErrorMessage),
                CreateMockResponse(500, "Shouldn't reach here"),
            };

            var mockTransport = CreateMockTransport(mockResponses);
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act & Assert
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await entraTokenCredential.GetTokenAsync(CancellationToken.None));
            Assert.AreEqual(lastRetryErrorMessage, lastRetryErrorMessage);
        }

        private EntraCommunicationTokenCredentialOptions CreateEntraTokenCredentialOptions()
        {
            return new EntraCommunicationTokenCredentialOptions(_resourceEndpoint, _mockTokenCredential.Object, _scopes);
        }

        private MockResponse CreateMockResponse(int statusCode, string body)
        {
            return new MockResponse(statusCode).WithContent(body);
        }

        private HttpPipelineTransport CreateMockTransport(MockResponse[] mockResponses)
        {
            return new MockTransport(mockResponses);
        }
    }
}
