// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class OnBehalfOfCredentialTests : CredentialTestBase<OnBehalfOfCredentialOptions>
    {
        public OnBehalfOfCredentialTests(bool isAsync) : base(isAsync) { }

#pragma warning disable SYSLIB0026 // X509Certificate2 is immutable
        private static readonly X509Certificate2 _mockCertificate = new();
#pragma warning restore // X509Certificate2 is immutable

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var oboOptions = new OnBehalfOfCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }
            };
            return InstrumentClient(
                new OnBehalfOfCredential(
                    TenantId,
                    ClientId,
                    "secret",
                    expectedUserAssertion,
                    oboOptions,
                    null,
                    mockConfidentialMsalClient));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new OnBehalfOfCredentialOptions
            {
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            var pipeline = CredentialPipeline.GetInstance(options);
            return InstrumentClient(
                new OnBehalfOfCredential(
                    config.TenantId,
                    ClientId,
                    "secret",
                    expectedUserAssertion,
                    options,
                    pipeline,
                    config.MockConfidentialMsalClient));
        }

        [Test]
        public void CtorValidation()
        {
            OnBehalfOfCredential cred;
            string userAssertion = Guid.NewGuid().ToString();
            string clientSecret = Guid.NewGuid().ToString();

            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(null, ClientId, clientSecret, userAssertion, null));
            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(TenantId, null, clientSecret, userAssertion, null));
            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(TenantId, ClientId, default(string), userAssertion));
            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(TenantId, ClientId, clientSecret, null, null));
            cred = new OnBehalfOfCredential(TenantId, ClientId, clientSecret, userAssertion, null);
            // Assert
            Assert.AreEqual(clientSecret, cred.Client._clientSecret);

            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(null, ClientId, _mockCertificate, userAssertion));
            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(TenantId, null, _mockCertificate, userAssertion));
            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(TenantId, ClientId, default(string), userAssertion));
            Assert.Throws<ArgumentNullException>(() =>
                new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, null));
            cred = new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, userAssertion);
            // Assert
            Assert.NotNull(cred.Client._certificateProvider);

            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(null, ClientId, _mockCertificate, userAssertion, new OnBehalfOfCredentialOptions()));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, null, _mockCertificate, userAssertion, new OnBehalfOfCredentialOptions()));
            Assert.Throws<ArgumentNullException>(
                () => new OnBehalfOfCredential(TenantId, ClientId, default(X509Certificate2), userAssertion, new OnBehalfOfCredentialOptions()));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, null, new OnBehalfOfCredentialOptions()));
            cred = new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, userAssertion, new OnBehalfOfCredentialOptions());
            // Assert
            Assert.NotNull(cred.Client._certificateProvider);
        }

        [Test]
        public async Task UsesTenantIdHint(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            TestSetup();
            options = new OnBehalfOfCredentialOptions() { AdditionallyAllowedTenants = { TenantIdHint } };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(explicitTenantId, context, TenantIdResolverBase.AllTenants);
            OnBehalfOfCredential client = InstrumentClient(
                new OnBehalfOfCredential(
                    TenantId,
                    ClientId,
                    "secret",
                    expectedUserAssertion,
                    options as OnBehalfOfCredentialOptions,
                    null,
                    mockConfidentialMsalClient));

            var token = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
        }

        [Test]
        public async Task SendCertificateChain([Values(true, false)] bool sendCertChain)
        {
            TestSetup();
            var _transport = CredentialTestHelpers.Createx5cValidatingTransport(sendCertChain, expectedToken);
            var _pipeline = new HttpPipeline(_transport, new[] { new BearerTokenAuthenticationPolicy(new MockCredential(), "scope") });
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath);

            options = new OnBehalfOfCredentialOptions
            {
                AuthorityHost = new Uri("https://localhost")
            };
            ((OnBehalfOfCredentialOptions)options).SendCertificateChain = sendCertChain;
            OnBehalfOfCredential client = InstrumentClient(
                new OnBehalfOfCredential(
                    TenantId,
                    ClientId,
                    mockCert,
                    expectedUserAssertion,
                    options as OnBehalfOfCredentialOptions,
                    new CredentialPipeline(_pipeline, new ClientDiagnostics(options)),
                    null));

            var token = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
        }
    }
}
