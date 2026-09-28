// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    [NonParallelizable]
    public class ChallengeBasedAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        internal ChallengeBasedAuthenticationPolicy _policy;
        private const string MtlsPoPTokenType = "mtls_pop";
        private const string KeyVaultChallenge = "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://vault.azure.net\"";
        public ChallengeBasedAuthenticationPolicyTests(bool isAsync) : base(isAsync)
        {
            _policy = new ChallengeBasedAuthenticationPolicy(new MockCredentialThrowsWithNoScopes(), false);
        }

        [SetUp]
        public void SetUp()
        {
            // Clear the cache to ensure the test starts with an empty cache.
            ChallengeBasedAuthenticationPolicy.ClearCache();
            _policy = new ChallengeBasedAuthenticationPolicy(new MockCredentialThrowsWithNoScopes(), false);
        }

        [Test]
        public async Task ScopesAreInitializedFromCache()
        {
            var keyvaultChallengeResponse = new MockResponse(401);
            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", KeyVaultChallenge));
            MockTransport transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));

            Response response = await SendGetRequest(transport, _policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));

            // Construct a new policy so that we can get the Scopes from cache.
            _policy = new ChallengeBasedAuthenticationPolicy(new MockCredentialThrowsWithNoScopes(), false);

            transport = CreateMockTransport(new MockResponse(200));
            response = await SendGetRequest(transport, _policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));
        }

        [Test]
        public async Task AddsTokenBoundAuthHeaderForMtlsPoPToken()
        {
            MockCredentialThrowsWithNoScopes credential = new(MtlsPoPTokenType);
            ChallengeBasedAuthenticationPolicy policy = new(credential, false);
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(200));

            Response response = await SendGetRequest(transport, policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests[1].Headers.TryGetValue("x-ms-tokenboundauth", out string headerValue), Is.True);
            Assert.That(headerValue, Is.EqualTo("true"));
            Assert.That(credential.LastRequestContext.IsProofOfPossessionEnabled, Is.True);
            Assert.That(credential.LastRequestContext.ResourceRequestMethod, Is.EqualTo(RequestMethod.Get.ToString()));
            Assert.That(credential.LastRequestContext.ResourceRequestUri, Is.EqualTo(new Uri("https://myvault.vault.azure.net/")));
        }

#if NET8_0_OR_GREATER
        [Test]
        public async Task AppliesBindingCertificateForMtlsPoPToken()
        {
            using RSA key = RSA.Create(2048);
            CertificateRequest request = new("CN=KeyVaultPoPTest", key, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            using X509Certificate2 certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow.AddMinutes(1));
            MockCredentialThrowsWithNoScopes credential = new(MtlsPoPTokenType, certificate);
            ChallengeBasedAuthenticationPolicy policy = new(credential, false);
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(200));

            Response response = await SendGetRequest(transport, policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.TransportUpdates, Has.Count.EqualTo(1));
            Assert.That(transport.TransportUpdates[0].ClientCertificates, Has.Count.EqualTo(1));
            Assert.That(transport.TransportUpdates[0].ClientCertificates[0], Is.SameAs(certificate));
            Assert.That(transport.Requests[1].Headers.TryGetValue("x-ms-tokenboundauth", out string headerValue), Is.True);
            Assert.That(headerValue, Is.EqualTo("true"));
        }
#endif

        [Test]
        public async Task DoesNotAddTokenBoundAuthHeaderForBearerToken()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(200));

            Response response = await SendGetRequest(transport, _policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests[1].Headers.Contains("x-ms-tokenboundauth"), Is.False);
        }

        [Test]
        public async Task RemovesTokenBoundAuthHeaderWhenCaeReauthorizationReturnsBearer()
        {
            string caeChallenge = string.Concat(
                "Be", "arer ",
                "authorization_uri=\"https://login.microsoftonline.com/common/oauth2/authorize\", ",
                "error=\"insufficient_claims\", ",
                "claims=\"eyJhY2Nlc3NfdG9rZW4iOnsiYWNycyI6eyJlc3NlbnRpYWwiOnRydWUsInZhbHVlIjoiY3AxIn19fQ==\"");

            Queue<MockResponse> responses = new(
            [
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(401).WithHeader("WWW-Authenticate", caeChallenge),
                new MockResponse(200),
            ]);
            List<bool> tokenBoundHeaders = [];
            MockTransport transport = new(request =>
            {
                tokenBoundHeaders.Add(request.Headers.Contains("x-ms-tokenboundauth"));
                return responses.Dequeue();
            });
            SequentialTokenCredential credential = new(MtlsPoPTokenType, "Bearer");
            ChallengeBasedAuthenticationPolicy policy = new(credential, false);

            Response response = await SendGetRequest(transport, policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
            Assert.That(tokenBoundHeaders, Is.EqualTo(new[] { false, true, false }));
        }

        [Test]
        public async Task RetriesTokenBindingValidationFailure()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                CreateTokenBindingValidationFailure(nonSeekable: true),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
            Assert.That(transport.Requests[2].Headers.TryGetValue("x-ms-tokenboundauth", out string headerValue), Is.True);
            Assert.That(headerValue, Is.EqualTo("true"));
        }

        [Test]
        public async Task RetriesTokenBindingValidationFailureFromSeekableStream()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                CreateTokenBindingValidationFailure(bufferedStream: true),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        }

        [Test]
        public async Task RetriesNonBufferedTokenBindingValidationFailure()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                CreateTokenBindingValidationFailure(nonSeekable: true),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport, bufferResponse: false);

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        }

        [Test]
        public async Task PreservesCustomNonErrorClassifierForTokenBindingValidationFailure()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                CreateTokenBindingValidationFailure(),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport, new UnauthorizedIsNotErrorClassifier());

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task TokenBindingValidationChallengeHonorsConfiguredRetryLimit()
        {
            MockTransport warmupTransport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(200));
            _ = await SendGetRequest(warmupTransport, _policy, uri: new Uri("https://myvault.vault.azure.net"));

            MockTransport transport = CreateMockTransport(
                CreateTokenBindingValidationFailure()
                    .WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport, maxRetries: 0);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task StopsRetryingTokenBindingValidationFailureAtConfiguredLimit()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                CreateTokenBindingValidationFailure(),
                CreateTokenBindingValidationFailure());

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        }

        [Test]
        public async Task DoesNotRetryOtherUnauthorizedResponses()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(401).WithJson("""
                {
                    "error": {
                        "code": "Unauthorized",
                        "message": "Access denied."
                    }
                }
                """));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task DoesNotRetryWhenMarkerIsOutsideErrorMessage()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(401).WithJson("""
                {
                    "error": {
                        "code": "Unauthorized",
                        "message": "Access denied.",
                        "details": "[MtlsCnfClaimRequestDataValidationFailed]"
                    }
                }
                """),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        }

        [TestCase("[]")]
        [TestCase("\"Access denied.\"")]
        [TestCase("null")]
        [TestCase("42")]
        [TestCase("true")]
        public async Task DoesNotRetryNonObjectJsonResponse(string content)
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(401)
                {
                    ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(content)),
                },
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task DoesNotRetryMalformedUnauthorizedResponse()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(401)
                {
                    ContentStream = new MemoryStream(Encoding.UTF8.GetBytes("{")),
                },
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task DoesNotRetryTokenBindingValidationFailureWithoutBoundHeader()
        {
            MockTransport transport = CreateMockTransport(
                CreateTokenBindingValidationFailure(),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task PreservesSeekableResponsePosition()
        {
            byte[] content = Encoding.UTF8.GetBytes("""
            {
                "error": {
                    "code": "Unauthorized",
                    "message": "Access denied."
                }
            }
            """);
            BufferedStream contentStream = new(new MemoryStream(content));
            contentStream.Position = 5;
            MockTransport transport = CreateMockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", KeyVaultChallenge),
                new MockResponse(401)
                {
                    ContentStream = contentStream,
                });

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(401));
            Assert.That(response.ContentStream, Is.SameAs(contentStream));
            Assert.That(response.ContentStream.Position, Is.EqualTo(5));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task PreservesStandardRetryClassification()
        {
            MockTransport transport = CreateMockTransport(
                new MockResponse(500),
                new MockResponse(200));

            Response response = await SendGetRequestWithRetry(transport);

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        }

        [TestCaseSource(nameof(VerifyChallengeResourceData))]
        public async Task VerifyChallengeResource(Uri uri, bool disableVerification)
        {
            var keyvaultChallengeResponse = new MockResponse(401);
            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", KeyVaultChallenge));
            MockTransport transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));

            ChallengeBasedAuthenticationPolicy policy = new(new MockCredentialThrowsWithNoScopes(), disableVerification);

            if (!disableVerification)
            {
                InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: uri));
                Assert.That(ex.Message, Is.EqualTo("The challenge resource 'vault.azure.net' does not match the requested domain. Set DisableChallengeResourceVerification to true in your client options to disable. See https://aka.ms/azsdk/blog/vault-uri for more information."));
            }
            else
            {
                Response response = await SendGetRequest(transport, policy, uri: uri);
                Assert.That(response.Status, Is.EqualTo(200));
            }
        }

        private static IEnumerable<object[]> VerifyChallengeResourceData => new[]
        {
            "https://example.com",
            "https://examplevault.azure.net",
            "https://example.vault.azure.com",
        }.Zip(new[] { false, true }, (uri, disableVerification) => new object[] { new Uri(uri), disableVerification });

        [Test]
        public void VerifyChallengeResourceInvalidUri()
        {
            var keyvaultChallengeResponse = new MockResponse(401);
            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"invalid-uri\""));
            MockTransport transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));

            ChallengeBasedAuthenticationPolicy policy = new(new MockCredentialThrowsWithNoScopes(), false);
            Uri uri = new("https://example.com");

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: uri));
            Assert.That(ex.Message, Is.EqualTo("The challenge contains invalid scope 'invalid-uri/.default'."));
        }

        private async Task<Response> SendGetRequestWithRetry(
            MockTransport transport,
            ResponseClassifier responseClassifier = null,
            bool bufferResponse = true,
            int maxRetries = 1)
        {
            // ResponseBodyPolicy leaves seekable test streams unchanged, while production HTTP response
            // streams are buffered into MemoryStream before the retry classifier runs.
            transport.ExpectSyncPipeline = null;
            TestClientOptions options = new()
            {
                Transport = transport,
            };
            options.Retry.MaxRetries = maxRetries;
            options.Retry.Delay = TimeSpan.Zero;
            ChallengeBasedAuthenticationPolicy policy = new(new MockCredentialThrowsWithNoScopes(MtlsPoPTokenType), false);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, policy);

            return await SendRequestAsync(
                pipeline,
                message =>
                {
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(new Uri("https://myvault.vault.azure.net"));
                    if (responseClassifier != null)
                    {
                        message.ResponseClassifier = responseClassifier;
                    }
                },
                bufferResponse);
        }

        private static MockResponse CreateTokenBindingValidationFailure(bool nonSeekable = false, bool bufferedStream = false)
        {
            byte[] content = Encoding.UTF8.GetBytes("""
            {
                "error": {
                    "code": "Unauthorized",
                    "message": "[MtlsCnfClaimRequestDataValidationFailed] Could not validate token."
                }
            }
            """);

            Stream contentStream = nonSeekable
                ? new NonSeekableMemoryStream(content)
                : bufferedStream
                    ? new BufferedStream(new MemoryStream(content))
                    : new MemoryStream(content);

            return new MockResponse(401)
            {
                ContentStream = contentStream,
            };
        }

        private class TestClientOptions : ClientOptions
        {
        }

        private class UnauthorizedIsNotErrorClassifier : ResponseClassifier
        {
            public override bool IsErrorResponse(HttpMessage message)
                => message.Response.Status != (int)HttpStatusCode.Unauthorized && base.IsErrorResponse(message);
        }

        public class MockCredentialThrowsWithNoScopes : TokenCredential
        {
            private readonly string _tokenType;
            private readonly X509Certificate2 _bindingCertificate;

            public MockCredentialThrowsWithNoScopes(string tokenType = "Bearer", X509Certificate2 bindingCertificate = null)
            {
                _tokenType = tokenType;
                _bindingCertificate = bindingCertificate;
            }

            public TokenRequestContext LastRequestContext { get; private set; }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                if (requestContext.Scopes.Length != 1)
                {
                    Assert.Fail("TokenRequestContext contained no scopes.");
                }

                LastRequestContext = requestContext;
                return _bindingCertificate is null
                    ? new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue, refreshOn: null, tokenType: _tokenType)
                    : new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue, refreshOn: null, tokenType: _tokenType, bindingCertificate: _bindingCertificate);
            }
        }

        private class SequentialTokenCredential : TokenCredential
        {
            private readonly Queue<string> _tokenTypes;

            public SequentialTokenCredential(params string[] tokenTypes)
            {
                _tokenTypes = new Queue<string>(tokenTypes);
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                Assert.That(_tokenTypes, Is.Not.Empty);
                return new AccessToken("TEST TOKEN", DateTimeOffset.MaxValue, refreshOn: null, tokenType: _tokenTypes.Dequeue());
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }
    }
}
