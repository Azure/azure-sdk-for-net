// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TokenCredentialOptionsTests : ClientTestBase
    {
        public TokenCredentialOptionsTests(bool isAsync) : base(isAsync)
        {
        }

        [NonParallelizable]
        [Test]
        public void InvalidEnvAuthorityHost()
        {
            using (new TestEnvVar("AZURE_AUTHORITY_HOST", "mock-env-authority-host"))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();

                Assert.Throws<UriFormatException>(() => { Uri authHost = option.AuthorityHost; });
            }
        }

        [NonParallelizable]
        [Test]
        public void EnvAuthorityHost()
        {
            string envHostValue = AzureAuthorityHosts.AzureChina.ToString();

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", envHostValue))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();
                Uri authHost = option.AuthorityHost;

                Assert.AreEqual(authHost, new Uri(envHostValue));
            }
        }

        [NonParallelizable]
        [Test]
        public void CustomAuthorityHost()
        {
            string envHostValue = AzureAuthorityHosts.AzureGermany.ToString();

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", envHostValue))
            {
                Uri customUri = AzureAuthorityHosts.AzureChina;

                TokenCredentialOptions option = new TokenCredentialOptions() { AuthorityHost = customUri };
                Uri authHost = option.AuthorityHost;

                Assert.AreNotEqual(authHost, new Uri(envHostValue));
                Assert.AreEqual(authHost, customUri);
            }
        }

        [NonParallelizable]
        [Test]
        public void DefaultAuthorityHost()
        {
            using (new TestEnvVar("AZURE_AUTHORITY_HOST", null))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();

                Assert.AreEqual(option.AuthorityHost, AzureAuthorityHosts.AzurePublicCloud);
            }
        }

        [Test]
        public void SetAuthorityHostToNonHttpsEndpointThrows()
        {
            TokenCredentialOptions options = new TokenCredentialOptions();

            Assert.Throws<ArgumentException>(() => options.AuthorityHost = new Uri("http://unprotected.login.com"));
        }

        [NonParallelizable]
        [Test]
        public void EnviornmentSpecifiedNonHttpsAuthorityHostFails()
        {
            string tenantId = Guid.NewGuid().ToString();
            string clientId = Guid.NewGuid().ToString();
            string username = Guid.NewGuid().ToString();
            string password = Guid.NewGuid().ToString();
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", "http://unprotected.login.com"))
            {
                Assert.Throws<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificatePath, new ClientCertificateCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new ClientSecretCredential(tenantId, clientId, password, new TokenCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new DefaultAzureCredential(new DefaultAzureCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new DeviceCodeCredential(new DeviceCodeCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new SharedTokenCacheCredential(new SharedTokenCacheCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new UsernamePasswordCredential(tenantId, clientId, username, password, new TokenCredentialOptions()));
            }
        }
    }
}
