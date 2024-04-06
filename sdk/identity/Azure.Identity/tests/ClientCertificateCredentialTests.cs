// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientCertificateCredentialTests : CredentialTestBase<ClientCertificateCredentialOptions>
    {
        public ClientCertificateCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath);

            return InstrumentClient(
                new ClientCertificateCredential(TenantId, ClientId, mockCert, options, default, mockConfidentialMsalClient)
            );
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new ClientCertificateCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            var pipeline = CredentialPipeline.GetInstance(options);
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var mockCert = new X509Certificate2(certificatePath);

            return InstrumentClient(
                new ClientCertificateCredential(config.TenantId, ClientId, mockCert, options, pipeline, config.MockConfidentialMsalClient)
            );
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

            TokenRequestContext tokenContext = new(MockScopes.Default);

            ClientCertificateCredential missingFileCredential = new(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "notfound.pem"));
            ClientCertificateCredential invalidPemCredential = new(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-invalid-data.pem"));
            ClientCertificateCredential unknownFormatCredential = new(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.unknown"));
            ClientCertificateCredential encryptedCredential = new(
                tenantId,
                clientId,
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-password-protected.pfx"));
            ClientCertificateCredential unsupportedCertCredential = new(
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

        public async Task ExceptionContainsTroubleshootingLink()
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

            ClientCertificateCredential credential = InstrumentClient(new ClientCertificateCredential(expectedTenantId, expectedClientId, mockCert, options));

            var exception = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.That(exception.Message, Does.Contain(ClientCertificateCredential.Troubleshooting));
            await Task.CompletedTask;
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
                    ? new ClientCertificateCredential(expectedTenantId, expectedClientId, certificatePathPem, default, default, default, mockMsalClient)
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
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            var options = new ClientCertificateCredentialOptions { AdditionallyAllowedTenants = { TenantIdHint } };
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var certificatePathPem = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
            var mockCert = new X509Certificate2(certificatePath);

            ClientCertificateCredential credential = InstrumentClient(
                usePemFile
                    ? new ClientCertificateCredential(TenantId, ClientId, certificatePathPem, default, options, default, mockConfidentialMsalClient)
                    : new ClientCertificateCredential(TenantId, ClientId, mockCert, options, default, mockConfidentialMsalClient)
            );

            var token = await credential.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
        }

        [Test]
        public async Task SendCertificateChain([Values(true, false)] bool usePemFile, [Values(true)] bool sendCertChain)
        {
            TestSetup();
            var _transport = CredentialTestHelpers.Createx5cValidatingTransport(sendCertChain, expectedToken);
            var _pipeline = new HttpPipeline(_transport, new[] { new BearerTokenAuthenticationPolicy(new MockCredential(), "scope") });
            var context = new TokenRequestContext(new[] { Scope }, tenantId: TenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var certificatePathPem = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
            var mockCert = new X509Certificate2(certificatePath);
            options = new ClientCertificateCredentialOptions
            {
                AuthorityHost = new Uri("https://localhost")
            };
            ((ClientCertificateCredentialOptions)options).SendCertificateChain = sendCertChain;

            ClientCertificateCredential credential = InstrumentClient(
                usePemFile
                    ? new ClientCertificateCredential(TenantId, ClientId, certificatePathPem, default, options,
                        new CredentialPipeline(_pipeline, new ClientDiagnostics(options)), null)
                    : new ClientCertificateCredential(TenantId, ClientId, mockCert, options,
                        new CredentialPipeline(_pipeline, new ClientDiagnostics(options)), null)
            );

            var token = await credential.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
        }

        [Test]
        public void VerifyMsalClientRegionalAuthority()
        {
            string[] authorities = { null, ConfidentialClientApplication.AttemptRegionDiscovery, "westus" };

            foreach (string regionalAuthority in authorities)
            {
                using (new TestEnvVar("AZURE_REGIONAL_AUTHORITY_NAME", regionalAuthority))
                {
                    var expectedTenantId = Guid.NewGuid().ToString();
                    var expectedClientId = Guid.NewGuid().ToString();
                    var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");

                    var cred = new ClientCertificateCredential(expectedTenantId, expectedClientId, certificatePath);
                    Assert.AreEqual(regionalAuthority, cred.Client.RegionalAuthority);
                }
            }
        }
    }
}
