// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class OnBehalfOfCredentialTests : CredentialTestBase
    {
        public OnBehalfOfCredentialTests(bool isAsync) : base(isAsync) { }

#pragma warning disable SYSLIB0026 // X509Certificate2 is immutable
        private static readonly X509Certificate2 _mockCertificate = new();
#pragma warning restore // X509Certificate2 is immutable

        [Test]
        public void CtorValidation()
        {
            OnBehalfOfCredential cred;
            string userAssertion = Guid.NewGuid().ToString();
            string clientSecret = Guid.NewGuid().ToString();

            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(null, ClientId, clientSecret, userAssertion, null));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, null, clientSecret, userAssertion, null));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, ClientId, default(string), userAssertion));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, ClientId, clientSecret, null, null));
            cred = new OnBehalfOfCredential(TenantId, ClientId, clientSecret, userAssertion, null);
            // Assert
            Assert.AreEqual(clientSecret, cred._client._clientSecret);

            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(null, ClientId, _mockCertificate, userAssertion));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, null, _mockCertificate, userAssertion));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, ClientId, default(string), userAssertion));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, null));
            cred = new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, userAssertion);
            // Assert
            Assert.NotNull(cred._client._certificateProvider);

            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(null, ClientId, _mockCertificate, userAssertion, new OnBehalfOfCredentialOptions()));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, null, _mockCertificate, userAssertion, new OnBehalfOfCredentialOptions()));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, ClientId, default(X509Certificate2), userAssertion, new OnBehalfOfCredentialOptions()));
            Assert.Throws<ArgumentNullException>(() => new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, null, new OnBehalfOfCredentialOptions()));
            cred = new OnBehalfOfCredential(TenantId, ClientId, _mockCertificate, userAssertion, new OnBehalfOfCredentialOptions());
            // Assert
            Assert.NotNull(cred._client._certificateProvider);
        }

        [Test]
        public async Task UsesTenantIdHint(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            TestSetup();
            options = new OnBehalfOfCredentialOptions();
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(explicitTenantId, context);
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
    }
}
