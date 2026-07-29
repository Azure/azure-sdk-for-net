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
        public async Task FallsBackToBearerWhenBindingCertificateIsUnavailable()
        {
            var bearerClient = new MockMsalConfidentialClient(AuthenticationResultFactory.Create("bearer-token"));
            var popClient = new MockMsalConfidentialClient(new MsalClientException(MsalError.MtlsCertificateNotProvided, "No binding certificate."));
            var credential = CreatePopCredential(bearerClient, popClient);

            AccessToken token = await GetTokenAsync(credential, isProofOfPossessionEnabled: true);

            Assert.AreEqual("bearer-token", token.Token);
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
