// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using Azure.Identity;
using Microsoft.Identity.Client;
using NUnit.Framework;
namespace Azure.Core.Tests.Identity
{
    public class ClientAssertionCredentialTests : CredentialTestBase<ClientAssertionCredentialOptions>
    {
        public ClientAssertionCredentialTests(bool isAsync) : base(isAsync)
        { }

        protected virtual TokenCredential CreateCredential(string tenantId, string clientId, string assertionValue, ClientAssertionCredentialOptions options)
        {
            var credential = IsAsync
                ? new ClientAssertionCredential(tenantId, clientId, (_) => Task.FromResult(assertionValue), options)
                : new ClientAssertionCredential(tenantId, clientId, () => assertionValue, options);
            return InstrumentClient(credential);
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var clientAssertionOptions = new ClientAssertionCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }, MsalClient = mockConfidentialMsalClient, Pipeline = CredentialPipeline.GetInstance(null) };

            return CreateCredential(expectedTenantId, ClientId, "assertion", clientAssertionOptions);
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new ClientAssertionCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                MsalClient = config.MockConfidentialMsalClient,
                AuthorityHost = config.AuthorityHost,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            if (config.TokenCachePersistenceOptions != null)
            {
                options.TokenCachePersistenceOptions = config.TokenCachePersistenceOptions;
            }
            var pipeline = CredentialPipeline.GetInstance(options);
            options.Pipeline = pipeline;
            return CreateCredential(config.TenantId, ClientId, "assertion", options);
        }

        [Test]
        public async Task ValidatesClientAssertionIsCorrect()
        {
            var expectedToken = Guid.NewGuid().ToString();
            var expectedClientAssertion = Guid.NewGuid().ToString();
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => expectedToken,
                RequestValidator = req =>
                {
                    if (req.Content != null)
                    {
                        var stream = new MemoryStream();
                        req.Content.WriteTo(stream, default);
                        var content = new BinaryData(stream.ToArray()).ToString();
                        Assert.That(content, Does.Contain($"client_assertion={expectedClientAssertion}"));
                    }
                }
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var _transport = new MockTransport(factory);
            var _pipeline = new HttpPipeline(_transport, new[] { new BearerTokenAuthenticationPolicy(new MockCredential(), "scope") });

            options = new ClientAssertionCredentialOptions
            {
                AuthorityHost = new Uri("https://localhost"),
                Transport = _transport
            };
            var pipeline = CredentialPipeline.GetInstance(options);
            ((ClientAssertionCredentialOptions)options).Pipeline = pipeline;

            var client = CreateCredential(TenantId, ClientId, expectedClientAssertion, options as ClientAssertionCredentialOptions);

            var token = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            Assert.AreEqual(expectedToken, token.Token, "Should be the expected token value");
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task SelectsClientBasedOnProofOfPossession(bool isProofOfPossessionEnabled)
        {
            var bearerClient = new MockMsalConfidentialClient(AuthenticationResultFactory.Create("bearer-token"));
            var popClient = new MockMsalConfidentialClient(AuthenticationResultFactory.Create("pop-token"));
            var credential = CreatePopCredential(bearerClient, popClient);

            AccessToken token = await GetTokenAsync(credential, isProofOfPossessionEnabled);

            Assert.AreEqual(isProofOfPossessionEnabled ? "pop-token" : "bearer-token", token.Token);
        }

        [Test]
        public async Task FallsBackToBearerWhenBindingCertificateUnavailable()
        {
            int bearerCalls = 0;
            var bearerClient = new MockMsalConfidentialClient().WithClientFactory((_, _, _, _) =>
            {
                bearerCalls++;
                return AuthenticationResultFactory.Create("bearer-token");
            });
            var popClient = new MockMsalConfidentialClient(new MsalClientException(MsalError.MtlsCertificateNotProvided, "No binding certificate."));
            var credential = CreatePopCredential(bearerClient, popClient);

            // The host cannot bind a certificate (managed identity returned a bearer assertion), so the mTLS
            // proof-of-possession redemption fails with MtlsCertificateNotProvided and the credential falls back
            // to a bearer token instead of failing - matching the direct managed identity flow.
            AccessToken token = await GetTokenAsync(credential, isProofOfPossessionEnabled: true);

            Assert.AreEqual("bearer-token", token.Token);
            Assert.AreEqual(1, bearerCalls, "Bearer client should be invoked once as the fallback.");
        }

        [Test]
        public void DoesNotFallBackForOtherPopFailures()
        {
            int bearerCalls = 0;
            var bearerClient = new MockMsalConfidentialClient().WithClientFactory((_, _, _, _) =>
            {
                bearerCalls++;
                return AuthenticationResultFactory.Create("bearer-token");
            });
            var popClient = new MockMsalConfidentialClient(new MsalClientException("pop_failure", "PoP acquisition failed."));
            var credential = CreatePopCredential(bearerClient, popClient);

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await GetTokenAsync(credential, isProofOfPossessionEnabled: true));
            Assert.AreEqual(0, bearerCalls);
        }

        [Test]
        public async Task FallsBackToBearerWhenAssertionHasNoBindingCertificate()
        {
            // Exercises the real PoP MsalConfidentialClient (rather than an injected exception): the assertion
            // source returns a token with no binding certificate, so MSAL rejects the mTLS proof-of-possession
            // request with MtlsCertificateNotProvided. The credential then falls back to a bearer token request,
            // matching the graceful degradation of the direct managed identity flow on a non-capable host.
            int bearerCalls = 0;
            var bearerClient = new MockMsalConfidentialClient().WithClientFactory((_, _, _, _) =>
            {
                bearerCalls++;
                return AuthenticationResultFactory.Create("bearer-token");
            });
            var assertionSource = new MockTokenCredential
            {
                // Returns a token but no binding certificate (BindingCertificate defaults to null).
                TokenFactory = (context, cancellationToken) => new AccessToken("assertion-token", DateTimeOffset.UtcNow.AddHours(1)),
            };
            var options = new ClientAssertionCredentialOptions
            {
                MsalClient = bearerClient,        // mock bearer client used for the fallback
                EnableMtlsProofOfPossession = true,
                DisableInstanceDiscovery = true,  // avoid network for authority instance discovery
                Pipeline = CredentialPipeline.GetInstance(null),
            };
            // PopMsalClient is intentionally not set, so a real mTLS PoP MsalConfidentialClient is created.
            var credential = new ClientAssertionCredential(TenantId, ClientId, assertionSource, "api://AzureADTokenExchange/.default", options);

            AccessToken token = await GetTokenAsync(credential, isProofOfPossessionEnabled: true);

            Assert.AreEqual("bearer-token", token.Token);
            Assert.AreEqual(1, bearerCalls, "Bearer client should be invoked once as the fallback when the assertion lacks a binding certificate.");
        }

        [Test]
        public async Task NonCapableHostFallsBackToBearerAndReusesCachedTokenAcrossCalls()
        {
            // Real Client and PopClient (neither injected) so the bearer client's MSAL token cache is exercised
            // across repeated calls - the interaction a mocked bearer client cannot reproduce. On a non-capable
            // host every proof-of-possession attempt fails with MtlsCertificateNotProvided and falls back to a
            // bearer token; the credential stays stateless (it re-attempts PoP each call and never latches).
            const string assertionScope = "api://AzureADTokenExchange/.default";
            int popAssertionCalls = 0;     // assertion source invoked by the PoP client (proof-of-possession context)
            int bearerAssertionCalls = 0;  // assertion source invoked by the bearer client (bearer context)
            int tokenRequests = 0;         // bearer redemptions that reached the token endpoint

            var assertionSource = new MockTokenCredential
            {
                TokenFactory = (context, cancellationToken) =>
                {
                    if (context.IsProofOfPossessionEnabled)
                    {
                        popAssertionCalls++;
                    }
                    else
                    {
                        bearerAssertionCalls++;
                    }
                    // Non-capable host: the managed identity returns a bearer assertion with no binding certificate.
                    return new AccessToken("assertion-token", DateTimeOffset.UtcNow.AddHours(1));
                },
            };
            var options = new ClientAssertionCredentialOptions
            {
                EnableMtlsProofOfPossession = true,
                DisableInstanceDiscovery = true,
                Transport = new MockTransport(MockTokenTransportFactory(new TransportConfig
                {
                    TokenFactory = request =>
                    {
                        tokenRequests++;
                        return "bearer-token";
                    },
                })),
            };
            // Neither MsalClient nor PopMsalClient is set, so both are real MsalConfidentialClient instances.
            var credential = new ClientAssertionCredential(TenantId, ClientId, assertionSource, assertionScope, options);

            AccessToken first = await GetTokenAsync(credential, isProofOfPossessionEnabled: true);
            AccessToken second = await GetTokenAsync(credential, isProofOfPossessionEnabled: true);

            Assert.AreEqual("bearer-token", first.Token);
            Assert.AreEqual("bearer-token", second.Token);
            // PoP is re-attempted on every call - the credential is stateless and never latches to bearer.
            Assert.AreEqual(2, popAssertionCalls, "PoP must be retried on each call; the credential must not latch to bearer.");
            // The bearer fallback redeems once; the second call is served from the bearer client's cache.
            Assert.AreEqual(1, tokenRequests, "The second call should be served from the bearer client's cache.");
            Assert.AreEqual(1, bearerAssertionCalls, "The bearer assertion should be built once; the second call hits the cache.");
        }

        [Test]
        public async Task DoesNotServeCachedBearerTokenWhenPopFailsTransiently()
        {
            // Real bearer Client (only the PoP client is mocked) so a genuine cached bearer token exists after the
            // first call's fallback. A transient managed-identity error on the next PoP attempt must surface rather
            // than silently serving that cached bearer token: PoP is still achievable on a capable host, so a
            // transient failure must not downgrade a request that asked for proof-of-possession.
            const string assertionScope = "api://AzureADTokenExchange/.default";
            int tokenRequests = 0;
            int popCalls = 0;
            var popClient = new MockMsalConfidentialClient().WithClientFactory((_, _, _, _) =>
            {
                popCalls++;
                if (popCalls == 1)
                {
                    // First call: non-capable host (no binding certificate) -> falls back and warms the bearer cache.
                    throw new MsalClientException(MsalError.MtlsCertificateNotProvided, "No binding certificate.");
                }
                // Second call: a transient managed-identity error (for example IMDS throttling).
                throw new MsalServiceException("throttled", "Managed identity endpoint returned 429.");
            });
            var assertionSource = new MockTokenCredential
            {
                TokenFactory = (context, cancellationToken) => new AccessToken("assertion-token", DateTimeOffset.UtcNow.AddHours(1)),
            };
            var options = new ClientAssertionCredentialOptions
            {
                PopMsalClient = popClient,        // mock PoP client that flips behavior across calls
                EnableMtlsProofOfPossession = true,
                DisableInstanceDiscovery = true,
                Transport = new MockTransport(MockTokenTransportFactory(new TransportConfig
                {
                    TokenFactory = request =>
                    {
                        tokenRequests++;
                        return "bearer-token";
                    },
                })),
                // MsalClient is intentionally not set, so the bearer Client is a real MsalConfidentialClient with a cache.
            };
            var credential = new ClientAssertionCredential(TenantId, ClientId, assertionSource, assertionScope, options);

            AccessToken first = await GetTokenAsync(credential, isProofOfPossessionEnabled: true);
            Assert.AreEqual("bearer-token", first.Token);
            Assert.AreEqual(1, tokenRequests, "The first call should fall back and cache a bearer token.");

            // The transient PoP failure surfaces; the credential does not silently serve the cached bearer token.
            Assert.ThrowsAsync<AuthenticationFailedException>(
                async () => await GetTokenAsync(credential, isProofOfPossessionEnabled: true));
            Assert.AreEqual(1, tokenRequests, "A transient PoP-path failure must not serve the cached bearer token.");
        }

        [Test]
        public async Task UsesBearerWhenMtlsProofOfPossessionDisabled()
        {
            const string assertionScope = "api://AzureADTokenExchange/.default";
            int assertionCalls = 0;
            var assertionSource = new MockTokenCredential
            {
                TokenFactory = (context, cancellationToken) =>
                {
                    assertionCalls++;
                    Assert.IsFalse(context.IsProofOfPossessionEnabled);
                    CollectionAssert.AreEqual(new[] { assertionScope }, context.Scopes);
                    return new AccessToken("assertion-token", DateTimeOffset.UtcNow.AddHours(1));
                },
            };
            var options = new ClientAssertionCredentialOptions
            {
                EnableMtlsProofOfPossession = false,
                DisableInstanceDiscovery = true,
                Transport = new MockTransport(MockTokenTransportFactory(new TransportConfig
                {
                    TokenFactory = request =>
                    {
                        using var stream = new MemoryStream();
                        request.Content.WriteTo(stream, default);
                        Assert.That(new BinaryData(stream.ToArray()).ToString(), Does.Contain("client_assertion=assertion-token"));
                        return "bearer-token";
                    },
                })),
            };
            var credential = new ClientAssertionCredential(TenantId, ClientId, assertionSource, assertionScope, options);

            AccessToken token = await GetTokenAsync(credential, isProofOfPossessionEnabled: true);

            Assert.IsNull(credential.PopClient);
            Assert.AreEqual(1, assertionCalls);
            Assert.AreEqual("bearer-token", token.Token);
            Assert.AreEqual("Bearer", token.TokenType);
            Assert.IsNull(token.BindingCertificate);
        }

        [Test]
        public async Task PopAssertionPropagatesContextCancellationAndCertificate()
        {
#pragma warning disable SYSLIB0026 // Empty certificate is sufficient to verify reference propagation.
            using var certificate = new X509Certificate2();
#pragma warning restore SYSLIB0026
            TokenRequestContext capturedContext = default;
            CancellationToken capturedCancellationToken = default;
            var assertionCredential = new MockTokenCredential
            {
                TokenFactory = (context, cancellationToken) =>
                {
                    capturedContext = context;
                    capturedCancellationToken = cancellationToken;
                    return new AccessToken("assertion", DateTimeOffset.UtcNow.AddMinutes(10), null, "PoP", certificate);
                }
            };
            var correlationId = Guid.NewGuid();
            var assertionOptions = new AssertionRequestOptions
            {
                Claims = "claims",
                ClientCapabilities = new[] { "CP1" },
                CorrelationId = correlationId,
            };
            using var cancellationSource = new CancellationTokenSource();

            ClientSignedAssertion assertion = await ClientAssertionCredential.GetPopAssertionAsync(
                assertionCredential,
                "api://AzureADTokenExchange/.default",
                assertionOptions,
                cancellationSource.Token);

            Assert.AreEqual("assertion", assertion.Assertion);
            Assert.AreSame(certificate, assertion.TokenBindingCertificate);
            Assert.True(capturedContext.IsProofOfPossessionEnabled);
            Assert.True(capturedContext.IsCaeEnabled);
            Assert.AreEqual("claims", capturedContext.Claims);
            Assert.AreEqual(correlationId.ToString(), capturedContext.ParentRequestId);
            Assert.AreEqual(cancellationSource.Token, capturedCancellationToken);
        }

        private ClientAssertionCredential CreatePopCredential(MsalConfidentialClient bearerClient, MsalConfidentialClient popClient)
        {
            var credentialOptions = new ClientAssertionCredentialOptions
            {
                MsalClient = bearerClient,
                PopMsalClient = popClient,
                EnableMtlsProofOfPossession = true,
                Pipeline = CredentialPipeline.GetInstance(null),
            };
            return new ClientAssertionCredential(TenantId, ClientId, new MockTokenCredential(), "assertion-scope", credentialOptions);
        }

        private async Task<AccessToken> GetTokenAsync(ClientAssertionCredential credential, bool isProofOfPossessionEnabled)
        {
            var requestContext = new TokenRequestContext(MockScopes.Default, isProofOfPossessionEnabled: isProofOfPossessionEnabled);
            return IsAsync
                ? await credential.GetTokenAsync(requestContext)
                : credential.GetToken(requestContext);
        }
    }
}
