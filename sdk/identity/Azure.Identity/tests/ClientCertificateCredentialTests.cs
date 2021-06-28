﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientCertificateCredentialTests : ClientTestBase
    {
        private const string Scope = "https://vault.azure.net/.default";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private string expectedToken;
        private DateTimeOffset expiresOn;
        private MockMsalConfidentialClient mockMsalClient;
        private string expectedTenantId;
        private TokenCredentialOptions options;

        public ClientCertificateCredentialTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public void VerifyCtorParametersValidation()
        {
            var tenantId = Guid.NewGuid().ToString();

            var clientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath);

            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(null, clientId, mockCert));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(null, clientId, certificatePath));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, null, mockCert));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, null, certificatePath));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, clientId, (X509Certificate2)null));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, clientId, (string)null));
        }

        [Test]
        public void VerifyBadCertificateFileBehavior()
        {
            var tenantId = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();

            TokenRequestContext tokenContext = new TokenRequestContext(MockScopes.Default);

            ClientCertificateCredential missingFileCredential = new ClientCertificateCredential(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "notfound.pem"));
            ClientCertificateCredential invalidPemCredential = new ClientCertificateCredential(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-invalid-data.pem"));
            ClientCertificateCredential unknownFormatCredential = new ClientCertificateCredential(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.unknown"));
            ClientCertificateCredential encryptedCredential = new ClientCertificateCredential(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-password-protected.pfx"));
            ClientCertificateCredential unsupportedCertCredential = new ClientCertificateCredential(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ec-cert.pem"));

            Assert.Throws<CredentialUnavailableException>(() => missingFileCredential.GetToken(tokenContext));
            Assert.Throws<CredentialUnavailableException>(() => invalidPemCredential.GetToken(tokenContext));
            Assert.Throws<CredentialUnavailableException>(() => unknownFormatCredential.GetToken(tokenContext));
            Assert.Throws<CredentialUnavailableException>(() => encryptedCredential.GetToken(tokenContext));
            Assert.Throws<CredentialUnavailableException>(() => unsupportedCertCredential.GetToken(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await missingFileCredential.GetTokenAsync(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await invalidPemCredential.GetTokenAsync(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await unknownFormatCredential.GetTokenAsync(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await encryptedCredential.GetTokenAsync(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await unsupportedCertCredential.GetTokenAsync(tokenContext));
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task VerifyClientCertificateRequestFailedAsync(bool usePemFile)
        {
            var response = new MockResponse(400);

            response.SetContent($"{{ \"error_code\": \"InvalidSecret\", \"message\": \"The specified client_secret is incorrect\" }}");

            var mockTransport = new MockTransport(response);

            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var certificatePathPem = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
            var mockCert = new X509Certificate2(certificatePath);

            ClientCertificateCredential credential = InstrumentClient(
                usePemFile
                    ? new ClientCertificateCredential(expectedTenantId, expectedClientId, certificatePathPem, options)
                    : new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, options)
            );

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            await Task.CompletedTask;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void VerifyClientCertificateCredentialException(bool usePemFile)
        {
            string expectedInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalConfidentialClient(new MockClientException(expectedInnerExMessage));

            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var certificatePathPem = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
            var mockCert = new X509Certificate2(certificatePath);

            ClientCertificateCredential credential = InstrumentClient(
                usePemFile
                    ? new ClientCertificateCredential(expectedTenantId, expectedClientId, certificatePathPem, default, default, mockMsalClient)
                    : new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, default, default, mockMsalClient)
            );

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expectedInnerExMessage, ex.InnerException.Message);
        }

        [Test]
        public async Task UsesTenantIdHint(
            [Values(true, false)] bool usePemFile,
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            options.AllowMultiTenantAuthentication = allowMultiTenantAuthentication;
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options.AllowMultiTenantAuthentication);
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var certificatePathPem = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
            var mockCert = new X509Certificate2(certificatePath);

            ClientCertificateCredential credential = InstrumentClient(
                usePemFile
                    ? new ClientCertificateCredential(TenantId, ClientId, certificatePathPem, options, default, mockMsalClient)
                    : new ClientCertificateCredential(TenantId, ClientId, mockCert, options, default, mockMsalClient)
            );

            var token = await credential.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
        }

        public void TestSetup()
        {
            options = new TokenCredentialOptions();
            expectedTenantId = null;
            expectedToken = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            var result = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");

            Func<string[], string, AuthenticationResult> clientFactory = (_, _tenantId) =>
            {
                return result;
            };
            mockMsalClient = new MockMsalConfidentialClient(clientFactory);
        }

        private static IEnumerable<TestCaseData> RegionalAuthorityTestData()
        {
            yield return new TestCaseData(null);
            yield return new TestCaseData(RegionalAuthority.AutoDiscoverRegion);
            yield return new TestCaseData(RegionalAuthority.USWest);
        }

        [Test]
        [TestCaseSource("RegionalAuthorityTestData")]
        public void VerifyMsalClientRegionalAuthority(RegionalAuthority? regionalAuthority)
        {
            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");

            var cred =  new ClientCertificateCredential(expectedTenantId, expectedClientId, certificatePath, new ClientCertificateCredentialOptions { RegionalAuthority = regionalAuthority });

            Assert.AreEqual(regionalAuthority, cred.Client.RegionalAuthority);
        }
    }
}
