// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientAssertionCredentialTests : CredentialTestBase<ClientAssertionCredentialOptions>
    {
        public ClientAssertionCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var clientAssertionOptions = new ClientAssertionCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }, MsalClient = mockConfidentialMsalClient, Pipeline = CredentialPipeline.GetInstance(null) };

            return InstrumentClient(new ClientAssertionCredential(expectedTenantId, ClientId, () => "assertion", clientAssertionOptions));
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
            return IsAsync ?
                InstrumentClient(new ClientAssertionCredential(config.TenantId, ClientId, (_) => Task.FromResult("assertion"), options)) :
                InstrumentClient(new ClientAssertionCredential(config.TenantId, ClientId, () => "assertion", options));
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

            ClientAssertionCredential client = IsAsync ?
            InstrumentClient(new ClientAssertionCredential(TenantId, ClientId, (_) => Task.FromResult(expectedClientAssertion), options as ClientAssertionCredentialOptions)) :
            InstrumentClient(new ClientAssertionCredential(TenantId, ClientId, () => expectedClientAssertion, options as ClientAssertionCredentialOptions));

            var token = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            Assert.AreEqual(expectedToken, token.Token, "Should be the expected token value");
        }
    }
}
