// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class WorkloadIdentityCredentialLiveTests : IdentityRecordedTestBase
    {
        public WorkloadIdentityCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearDiscoveryCache()
        {
            StaticCachesUtilities.ClearStaticMetadataProviderCache();
        }

        [Test]
        [PlaybackOnly("Live tests involving secrets will be temporarily disabled.")]
        public async Task AuthnenticateWithWorkflowIdentity()
        {
            WorkloadIdentityCredentialOptions options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TestEnvironment.ServicePrincipalTenantId,
                ClientId = TestEnvironment.ServicePrincipalClientId,
                TokenFilePath = _tempFiles.GetTempFilePath()
            };

            var certificatePath = TestEnvironment.ServicePrincipalCertificatePfxPath;

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var cert = new X509Certificate2(certificatePath);
#endif

            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(options.AuthorityHost, options.ClientId, options.TenantId, cert);

            File.WriteAllText(options.TokenFilePath, assertion);

            options = InstrumentClientOptions(options);

            WorkloadIdentityCredential credential = InstrumentClient(new WorkloadIdentityCredential(options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // ensure we can initially acquire a  token
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);

            // ensure subsequent calls before the token expires are served from the token cache
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);
        }

        [Test]
        [PlaybackOnly("Requires AKS environment with Kubernetes token proxy configured.")]
        public async Task AuthenticateWithWorkloadIdentity_KubernetesProxyWithCaFile()
        {
            // This test requires the following environment variables to be set:
            // - AZURE_KUBERNETES_TOKEN_PROXY: URL of the Kubernetes token proxy
            // - AZURE_KUBERNETES_CA_FILE: Path to CA certificate file
            // These are automatically set by AKS when the workload identity webhook is enabled

            var proxyUrl = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_TOKEN_PROXY");
            var caFile = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_CA_FILE");

            if (string.IsNullOrEmpty(proxyUrl) || string.IsNullOrEmpty(caFile))
            {
                Assert.Ignore("Kubernetes proxy environment variables not set. This test requires an AKS environment.");
            }

            WorkloadIdentityCredentialOptions options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TestEnvironment.ServicePrincipalTenantId,
                ClientId = TestEnvironment.ServicePrincipalClientId,
                TokenFilePath = _tempFiles.GetTempFilePath(),
                IsAzureKubernetesTokenProxyEnabled = true // Enable proxy support
            };

            var certificatePath = TestEnvironment.ServicePrincipalCertificatePfxPath;

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var cert = new X509Certificate2(certificatePath);
#endif

            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(options.AuthorityHost, options.ClientId, options.TenantId, cert);

            File.WriteAllText(options.TokenFilePath, assertion);

            options = InstrumentClientOptions(options);

            WorkloadIdentityCredential credential = InstrumentClient(new WorkloadIdentityCredential(options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // Acquire token through the Kubernetes proxy
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);

            // Verify cached token works
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);
        }

        [Test]
        [PlaybackOnly("Requires AKS environment with Kubernetes token proxy configured.")]
        public async Task AuthenticateWithWorkloadIdentity_KubernetesProxyWithCaData()
        {
            // This test requires the following environment variables to be set:
            // - AZURE_KUBERNETES_TOKEN_PROXY: URL of the Kubernetes token proxy
            // - AZURE_KUBERNETES_CA_DATA: Base64-encoded CA certificate data
            // These are automatically set by AKS when the workload identity webhook is enabled

            var proxyUrl = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_TOKEN_PROXY");
            var caData = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_CA_DATA");

            if (string.IsNullOrEmpty(proxyUrl) || string.IsNullOrEmpty(caData))
            {
                Assert.Ignore("Kubernetes proxy environment variables not set. This test requires an AKS environment.");
            }

            WorkloadIdentityCredentialOptions options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TestEnvironment.ServicePrincipalTenantId,
                ClientId = TestEnvironment.ServicePrincipalClientId,
                TokenFilePath = _tempFiles.GetTempFilePath(),
                IsAzureKubernetesTokenProxyEnabled = true // Enable proxy support
            };

            var certificatePath = TestEnvironment.ServicePrincipalCertificatePfxPath;

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var cert = new X509Certificate2(certificatePath);
#endif

            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(options.AuthorityHost, options.ClientId, options.TenantId, cert);

            File.WriteAllText(options.TokenFilePath, assertion);

            options = InstrumentClientOptions(options);

            WorkloadIdentityCredential credential = InstrumentClient(new WorkloadIdentityCredential(options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // Acquire token through the Kubernetes proxy
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);

            // Verify cached token works
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);
        }

        [Test]
        [PlaybackOnly("Requires AKS environment with Kubernetes token proxy configured.")]
        public async Task AuthenticateWithWorkloadIdentity_KubernetesProxyWithSniName()
        {
            // This test requires the following environment variables to be set:
            // - AZURE_KUBERNETES_TOKEN_PROXY: URL of the Kubernetes token proxy
            // - AZURE_KUBERNETES_CA_FILE: Path to CA certificate file
            // - AZURE_KUBERNETES_SNI_NAME: SNI name for TLS connection
            // These are automatically set by AKS when the workload identity webhook is enabled

            var proxyUrl = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_TOKEN_PROXY");
            var caFile = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_CA_FILE");
            var sniName = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_SNI_NAME");

            if (string.IsNullOrEmpty(proxyUrl) || string.IsNullOrEmpty(caFile) || string.IsNullOrEmpty(sniName))
            {
                Assert.Ignore("Kubernetes proxy environment variables not set. This test requires an AKS environment with SNI configured.");
            }

            WorkloadIdentityCredentialOptions options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TestEnvironment.ServicePrincipalTenantId,
                ClientId = TestEnvironment.ServicePrincipalClientId,
                TokenFilePath = _tempFiles.GetTempFilePath(),
                IsAzureKubernetesTokenProxyEnabled = true // Enable proxy support
            };

            var certificatePath = TestEnvironment.ServicePrincipalCertificatePfxPath;

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var cert = new X509Certificate2(certificatePath);
#endif

            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(options.AuthorityHost, options.ClientId, options.TenantId, cert);

            File.WriteAllText(options.TokenFilePath, assertion);

            options = InstrumentClientOptions(options);

            WorkloadIdentityCredential credential = InstrumentClient(new WorkloadIdentityCredential(options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // Acquire token through the Kubernetes proxy with SNI
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);

            // Verify cached token works
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);
        }

        [TearDown]
        public void CleanupTestAssertionFiles()
        {
            _tempFiles.CleanupTempFiles();
        }

        private TestTempFileHandler _tempFiles = new TestTempFileHandler();
    }
}
