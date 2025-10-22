// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using BenchmarkDotNet.Configs;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class WorkloadIdentityCredentialTests : CredentialTestBase<WorkloadIdentityCredentialOptions>
    {
        public WorkloadIdentityCredentialTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public void VerifyInvalidConfigurationThrowsCredentialUnavailable([Values] bool specifyTenantId, [Values] bool specifyClientId, [Values] bool specifyTokenFilePath)
        {
            if (specifyTenantId && specifyClientId && specifyTokenFilePath)
            {
                Assert.Pass();
            }

            WorkloadIdentityCredentialOptions options = new WorkloadIdentityCredentialOptions
            {
                TenantId = specifyTenantId ? Guid.NewGuid().ToString() : null,
                ClientId = specifyClientId ? Guid.NewGuid().ToString() : null,
                TokenFilePath = specifyTokenFilePath ? Guid.NewGuid().ToString() : null
            };

            WorkloadIdentityCredential credential = InstrumentClient(new WorkloadIdentityCredential(options));

            var tokenRequestContext = new TokenRequestContext(MockScopes.Default);

            Assert.ThrowsAsync<CredentialUnavailableException>(() => credential.GetTokenAsync(tokenRequestContext).AsTask());
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
#if NET9_0_OR_GREATER
            var mockCert = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var mockCert = new X509Certificate2(certificatePath);
#endif

            var workloadOptions = options.Clone<WorkloadIdentityCredentialOptions>();

            workloadOptions.TenantId = TenantId;
            workloadOptions.ClientId = ClientId;
            workloadOptions.TokenFilePath = _tempFiles.GetTempFilePath();
            workloadOptions.MsalClient = mockConfidentialMsalClient;
            workloadOptions.Pipeline = CredentialPipeline.GetInstance(null);

            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(workloadOptions.AuthorityHost, workloadOptions.ClientId, workloadOptions.TenantId, mockCert);

            File.WriteAllText(workloadOptions.TokenFilePath, assertion);

            return InstrumentClient(new WorkloadIdentityCredential(workloadOptions));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
#if NET9_0_OR_GREATER
            var mockCert = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var mockCert = new X509Certificate2(certificatePath);
#endif

            var workloadOptions = config.Clone<WorkloadIdentityCredentialOptions>();

            workloadOptions.TenantId = config.TenantId;
            workloadOptions.ClientId = ClientId;
            workloadOptions.TokenFilePath = _tempFiles.GetTempFilePath();
            workloadOptions.MsalClient = config.MockConfidentialMsalClient;
            workloadOptions.AuthorityHost = config.AuthorityHost;

            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(workloadOptions.AuthorityHost, workloadOptions.ClientId, workloadOptions.TenantId, mockCert);

            File.WriteAllText(workloadOptions.TokenFilePath, assertion);

            return InstrumentClient(new WorkloadIdentityCredential(workloadOptions));
        }

        [Test]
        public void KubernetesProxy_DisabledByDefault()
        {
            var tokenFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(tokenFilePath, "test-token");

            var options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TenantId,
                ClientId = ClientId,
                TokenFilePath = tokenFilePath,
                MsalClient = mockConfidentialMsalClient,
                Pipeline = CredentialPipeline.GetInstance(null)
            };

            // Should not throw even with invalid proxy config
            using (new TestEnvVar("AZURE_KUBERNETES_TOKEN_PROXY", "http://invalid&proxy#url"))
            using (new TestEnvVar("AZURE_KUBERNETES_CA_DATA", "invalid-cert-data"))
            {
                var credential = new WorkloadIdentityCredential(options);
                Assert.IsNotNull(credential);
            }
        }

        [Test]
        public void KubernetesProxy_OptInWithoutEnvVars_NoError()
        {
            var tokenFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(tokenFilePath, "test-token");

            var options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TenantId,
                ClientId = ClientId,
                TokenFilePath = tokenFilePath,
                AzureKubernetesTokenProxy = true,
                MsalClient = mockConfidentialMsalClient,
                Pipeline = CredentialPipeline.GetInstance(null)
            };

            // Should not throw when proxy is enabled but env vars are not set
            var credential = new WorkloadIdentityCredential(options);
            Assert.IsNotNull(credential);
        }

        [Test]
        public void KubernetesProxy_InvalidProxyUrl_ThrowsInvalidOperation()
        {
            var tokenFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(tokenFilePath, "test-token");

            var options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TenantId,
                ClientId = ClientId,
                TokenFilePath = tokenFilePath,
                AzureKubernetesTokenProxy = true,
                MsalClient = mockConfidentialMsalClient,
                Pipeline = CredentialPipeline.GetInstance(null)
            };

            // Invalid URL schemes
            using (new TestEnvVar("AZURE_KUBERNETES_TOKEN_PROXY", "http://not-https"))
            {
                var ex = Assert.Throws<InvalidOperationException>(() => new WorkloadIdentityCredential(options));
                Assert.That(ex.Message, Does.Contain("HTTPS"));
            }

            // URL with query string
            using (new TestEnvVar("AZURE_KUBERNETES_TOKEN_PROXY", "https://proxy.local?query=value"))
            {
                var ex = Assert.Throws<InvalidOperationException>(() => new WorkloadIdentityCredential(options));
                Assert.That(ex.Message, Does.Contain("query"));
            }

            // URL with fragment
            using (new TestEnvVar("AZURE_KUBERNETES_TOKEN_PROXY", "https://proxy.local#fragment"))
            {
                var ex = Assert.Throws<InvalidOperationException>(() => new WorkloadIdentityCredential(options));
                Assert.That(ex.Message, Does.Contain("fragment"));
            }
        }

        [Test]
        public void KubernetesProxy_BothCaFileAndCaData_ThrowsInvalidOperation()
        {
            var tokenFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(tokenFilePath, "test-token");

            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, "-----BEGIN CERTIFICATE-----\ntest\n-----END CERTIFICATE-----");

            var options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TenantId,
                ClientId = ClientId,
                TokenFilePath = tokenFilePath,
                AzureKubernetesTokenProxy = true,
                MsalClient = mockConfidentialMsalClient,
                Pipeline = CredentialPipeline.GetInstance(null)
            };

            using (new TestEnvVar("AZURE_KUBERNETES_TOKEN_PROXY", "https://proxy.local"))
            using (new TestEnvVar("AZURE_KUBERNETES_CA_FILE", caFilePath))
            using (new TestEnvVar("AZURE_KUBERNETES_CA_DATA", "LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0t"))
            {
                var ex = Assert.Throws<InvalidOperationException>(() => new WorkloadIdentityCredential(options));
                Assert.That(ex.Message, Does.Contain("ambiguous"));
            }
        }

        [Test]
        public void KubernetesProxy_CaFileDoesNotExist_ThrowsInvalidOperation()
        {
            var tokenFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(tokenFilePath, "test-token");

            var options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TenantId,
                ClientId = ClientId,
                TokenFilePath = tokenFilePath,
                AzureKubernetesTokenProxy = true,
                MsalClient = mockConfidentialMsalClient,
                Pipeline = CredentialPipeline.GetInstance(null)
            };

            using (new TestEnvVar("AZURE_KUBERNETES_TOKEN_PROXY", "https://proxy.local"))
            using (new TestEnvVar("AZURE_KUBERNETES_CA_FILE", "/path/does/not/exist.pem"))
            {
                var ex = Assert.Throws<InvalidOperationException>(() => new WorkloadIdentityCredential(options));
                Assert.That(ex.Message, Does.Contain("does not exist"));
            }
        }

        [TearDown]
        public void CleanupTestAssertionFiles()
        {
            _tempFiles.CleanupTempFiles();
        }

        private TestTempFileHandler _tempFiles = new TestTempFileHandler();
    }
}
