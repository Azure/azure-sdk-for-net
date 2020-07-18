// Copyright (c) Microsoft Corporation. All rights reserved.
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
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientCertificateCredentialTests : ClientTestBase
    {
        public ClientCertificateCredentialTests(bool isAsync) : base(isAsync)
        {
        }

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

            ClientCertificateCredential missingFileCredential = new ClientCertificateCredential(tenantId, clientId, Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "notfound.pem"));
            ClientCertificateCredential invalidPemCredential = new ClientCertificateCredential(tenantId, clientId, Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-invalid-data.pem"));
            ClientCertificateCredential unknownFormatCredential = new ClientCertificateCredential(tenantId, clientId, Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.unknown"));
            ClientCertificateCredential encryptedCredential = new ClientCertificateCredential(tenantId, clientId, Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-password-protected.pfx"));

            Assert.Throws<CredentialUnavailableException>(() => missingFileCredential.GetToken(tokenContext));
            Assert.Throws<CredentialUnavailableException>(() => invalidPemCredential.GetToken(tokenContext));
            Assert.Throws<CredentialUnavailableException>(() => unknownFormatCredential.GetToken(tokenContext));
            Assert.Throws<CredentialUnavailableException>(() => encryptedCredential.GetToken(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await missingFileCredential.GetTokenAsync(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await invalidPemCredential.GetTokenAsync(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await unknownFormatCredential.GetTokenAsync(tokenContext));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await encryptedCredential.GetTokenAsync(tokenContext));
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
                usePemFile ? new ClientCertificateCredential(expectedTenantId, expectedClientId, certificatePathPem, options) : new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, options)
            );

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            await Task.CompletedTask;
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task VerifyClientCertificateCredentialExceptionAsync(bool usePemFile)
        {
            string expectedInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalConfidentialClient(new MockClientException(expectedInnerExMessage));


            var expectedTenantId = Guid.NewGuid().ToString();

            var expectedClientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var certificatePathPem = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
            var mockCert = new X509Certificate2(certificatePath);

            ClientCertificateCredential credential = InstrumentClient(
                usePemFile ? new ClientCertificateCredential(expectedTenantId, expectedClientId, certificatePathPem, CredentialPipeline.GetInstance(null), mockMsalClient) : new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, CredentialPipeline.GetInstance(null), mockMsalClient)
            );

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expectedInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }
    }
}
