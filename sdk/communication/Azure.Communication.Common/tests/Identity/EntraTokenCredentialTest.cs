// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
        private const string communicationClientsEndpoint = "/access/entra/:exchangeAccessToken";
        private const string communicationClientsPrefix = "https://communication.azure.com/clients/";
        private const string communicationClientsScope = communicationClientsPrefix + "VoIP";
        private const string teamsExtensionEndpoint = "/access/teamsExtension/:exchangeAccessToken";
        private const string teamsExtensionScope = "https://auth.msft.communication.azure.com/TeamsExtension.ManageCalls";
        private string _resourceEndpoint = "https://myResource.communication.azure.com";

        private static readonly object[] validScopes =
        {
            new object[] { new string[] { communicationClientsScope }},
            new object[] { new string[] { teamsExtensionScope } }
        };
        private static readonly object[] invalidScopes =
        {
            new object[] { new string[] { communicationClientsScope, teamsExtensionScope } },
            new object[] { new string[] { teamsExtensionScope, communicationClientsScope } },
            new object[] { new string[] { "invalidScope" } },
            new object[] { new string[] { "" } },
        };

        [SetUp]
        public void Setup()
        {
            _mockTokenCredential = new Mock<TokenCredential>();
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            _mockTokenCredential
              .Setup(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new AccessToken(SampleToken, expiryTime));
        }

        [Test, TestCaseSource(nameof(validScopes))]
        public void EntraCommunicationTokenCredentialOptions_Init_ThrowsErrorWithNulls(string[] scopes)
        {
            Assert.Throws<ArgumentNullException>(() => new EntraCommunicationTokenCredentialOptions(
                null,
                _mockTokenCredential.Object)
            {
                Scopes = scopes
            });

            Assert.Throws<ArgumentException>(() => new EntraCommunicationTokenCredentialOptions(
                "",
                _mockTokenCredential.Object)
            {
                Scopes = scopes
            });

            Assert.Throws<ArgumentNullException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                null)
            {
                Scopes = scopes
            });
        }

        [Test]
        public void EntraCommunicationTokenCredentialOptions_NullOrEmptyScopes_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object)
            {
                Scopes = null
            });
            Assert.Throws<ArgumentException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object)
            {
                Scopes = Array.Empty<string>()
            });
        }

        [Test, TestCaseSource(nameof(invalidScopes))]
        public void EntraCommunicationTokenCredentialOptions_InvalidScopes_ThrowsForInvalidScopes(string[] scopes)
        {
            Assert.Throws<ArgumentException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object)
            {
                Scopes = scopes
            });
        }

        [Test]
        public void EntraCommunicationTokenCredentialOptions_InitWithoutScopes_InitsWithDefaultScope()
        {
            var credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object);
            var scopes = new[] { "https://communication.azure.com/clients/.default" };
            Assert.AreEqual(credential.Scopes, scopes);
        }

        [Test]
        public void EntraTokenCredential_Ctor_NullOptionsThrows()
        {
            // Arrange
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse) });
            // Assert
            Assert.Throws<ArgumentNullException>(() => new EntraTokenCredential(null, mockTransport));
        }

        [Test, TestCaseSource(nameof(validScopes))]
        public void EntraTokenCredential_Init_FetchesTokenImmediately(string[] scopes)
        {
            // Arrange
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var options = CreateEntraTokenCredentialOptions(scopes);
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse) });
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);
            // Assert
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test, TestCaseSource(nameof(validScopes))]
        public async Task EntraTokenCredential_GetToken_ReturnsToken(string[] scopes)
        {
            // Arrange
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var options = CreateEntraTokenCredentialOptions(scopes);
            var mockTransport = (MockTransport) CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse) });
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act
            var token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);

            // Assert
            Assert.AreEqual(SampleToken, token.Token);
            Assert.AreEqual(token.ExpiresOn, expiryTime);
            if (scopes.Contains(teamsExtensionScope))
            {
                Assert.AreEqual(teamsExtensionEndpoint, mockTransport.SingleRequest.Uri.Path);
            }
            else
            {
                Assert.AreEqual(communicationClientsEndpoint, mockTransport.SingleRequest.Uri.Path);
            }
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task EntraTokenCredential_InitWithoutScopes_ReturnsCommunicationClientsToken()
        {
            // Arrange
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var options = new EntraCommunicationTokenCredentialOptions(_resourceEndpoint, _mockTokenCredential.Object);
            var mockTransport = (MockTransport)CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse) });
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act
            var token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);

            // Assert
            Assert.AreEqual(SampleToken, token.Token);
            Assert.AreEqual(token.ExpiresOn, expiryTime);
            Assert.AreEqual(communicationClientsEndpoint, mockTransport.SingleRequest.Uri.Path);
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test, TestCaseSource(nameof(validScopes))]
        public async Task EntraTokenCredential_GetToken_InternalEntraTokenChangeInvalidatesCachedToken(string[] scopes)
        {
            // Arrange
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var refreshOn = DateTimeOffset.Now;
            _mockTokenCredential.Reset();
            _mockTokenCredential
                .SetupSequence(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessToken("Entra token for call from constructor", refreshOn))
                .ReturnsAsync(new AccessToken("Entra token for the first getToken call token", expiryTime));

            var newToken = "newToken";
            var latestTokenResponse = string.Format(TokenResponseTemplate, newToken, SampleTokenExpiry);
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse), CreateMockResponse(200, latestTokenResponse) });
            var options = CreateEntraTokenCredentialOptions(scopes);

            // Act
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);
            var token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);

            // Assert for cached tokens are updated
            Assert.AreEqual(newToken, token.Token);
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
        }

        [Test, TestCaseSource(nameof(validScopes))]
        public async Task EntraTokenCredential_GetToken_MultipleCallsReturnsCachedToken(string[] scopes)
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions(scopes);
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

        [Test, TestCaseSource(nameof(validScopes))]
        public void EntraTokenCredential_GetToken_ThrowsFailedResponse(string[] scopes)
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions(scopes);
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

        [Test, TestCaseSource(nameof(validScopes))]
        public void EntraTokenCredential_GetToken_ThrowsInvalidJson(string[] scopes)
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions(scopes);
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

        [Test, TestCaseSource(nameof(validScopes))]
        public void EntraTokenCredential_GetToken_RetriesThreeTimesOnTransientError(string[] scopes)
        {
            // Arrange
            var options = CreateEntraTokenCredentialOptions(scopes);
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
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await entraTokenCredential.GetTokenAsync(CancellationToken.None));
            StringAssert.Contains(lastRetryErrorMessage, ex?.Message);
        }

        [Test, TestCaseSource(nameof(invalidScopes))]
        public void EntraTokenCredential_GetToken_ThrowsForInvalidScopes(string[] scopes)
        {
            // Arrange
            var options = new EntraCommunicationTokenCredentialOptions(_resourceEndpoint, _mockTokenCredential.Object)
            {
                Scopes = Enumerable.Repeat(communicationClientsScope, scopes.Length).ToArray()
            };
            scopes.CopyTo(options.Scopes, 0);

            var mockResponses = new MockResponse[]
            {
                CreateMockResponse(200, TokenResponse)
            };

            var mockTransport = CreateMockTransport(mockResponses);
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await entraTokenCredential.GetTokenAsync(CancellationToken.None));
            StringAssert.Contains("Scopes validation failed. Ensure all scopes start with either", ex?.Message);
        }

        [Test]
        public async Task EntraTokenCredential_GetToken_NoIssueIfScopesChanged()
        {
            var scopes = new string[] { communicationClientsScope, communicationClientsPrefix + "Chat" };

            // Arrange
            _mockTokenCredential.Reset();
            var expiryTime = DateTimeOffset.Parse(SampleTokenExpiry, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var refreshOn = DateTimeOffset.Now;
            _mockTokenCredential
                .SetupSequence(tc => tc.GetTokenAsync(It.Is<TokenRequestContext>(c => c.Scopes.SequenceEqual(scopes)), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AccessToken("Entra token for call from constructor", refreshOn))
                .ReturnsAsync(new AccessToken("Entra token for the first getToken call token", expiryTime));

            var newToken = "newToken";
            var latestTokenResponse = string.Format(TokenResponseTemplate, newToken, SampleTokenExpiry);
            var mockTransport = CreateMockTransport(new[] { CreateMockResponse(200, TokenResponse), CreateMockResponse(200, latestTokenResponse) });

            var options = CreateEntraTokenCredentialOptions((string[])scopes.Clone());

            // Act
            var entraTokenCredential = new EntraTokenCredential(options, mockTransport);

            // Change scopes
            options.Scopes[1] = teamsExtensionScope;
            var token = await entraTokenCredential.GetTokenAsync(CancellationToken.None);

            // Assert for cached tokens are updated
            Assert.AreEqual(newToken, token.Token);
            _mockTokenCredential.Verify(tc => tc.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
        }

        private EntraCommunicationTokenCredentialOptions CreateEntraTokenCredentialOptions(string[] scopes)
        {
            return new EntraCommunicationTokenCredentialOptions(_resourceEndpoint, _mockTokenCredential.Object)
            {
                Scopes = scopes
            };
        }

        private MockResponse CreateMockResponse(int statusCode, string body)
        {
            return new MockResponse(statusCode).WithJson(body);
        }

        private HttpPipelineTransport CreateMockTransport(MockResponse[] mockResponses)
        {
            return new MockTransport(mockResponses);
        }
    }
}
