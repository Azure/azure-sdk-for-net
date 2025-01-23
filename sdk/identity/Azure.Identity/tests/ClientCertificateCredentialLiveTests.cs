// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientCertificateCredentialLiveTests : IdentityRecordedTestBase
    {
        public ClientCertificateCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearDiscoveryCache()
        {
            StaticCachesUtilities.ClearStaticMetadataProviderCache();
        }

        [TestCase(true)]
        [TestCase(false)]
        [PlaybackOnly("Live tests involving secrets will be temporarily disabled.")]
        public async Task FromCertificatePath(bool usePem)
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;
            var certPath = usePem ? TestEnvironment.ServicePrincipalCertificatePemPath : TestEnvironment.ServicePrincipalCertificatePfxPath;

            var options = InstrumentClientOptions(new TokenCredentialOptions());

            var credential = InstrumentClient(new ClientCertificateCredential(tenantId, clientId, certPath, options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // ensure we can initially acquire a  token
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);

            // ensure subsequent calls before the token expires are served from the token cache
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);

            // ensure new credentials don't share tokens from the cache
            var credential2 = new ClientCertificateCredential(tenantId, clientId, certPath, options);

            AccessToken token2 = await credential2.GetTokenAsync(tokenRequestContext);

            // this assert is conditional because the access token is scrubbed in the recording so they will never be different
            if (Mode != RecordedTestMode.Playback && Mode != RecordedTestMode.None)
            {
                Assert.AreNotEqual(token.Token, token2.Token);
            }
        }

        [Test]
        [PlaybackOnly("Live tests involving secrets will be temporarily disabled.")]
        public async Task FromX509Certificate2()
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadPkcs12FromFile(TestEnvironment.ServicePrincipalCertificatePfxPath, null);
#else
            var cert = new X509Certificate2(TestEnvironment.ServicePrincipalCertificatePfxPath);
#endif

            var options = InstrumentClientOptions(new TokenCredentialOptions());

            var credential = InstrumentClient(new ClientCertificateCredential(tenantId, clientId, cert, options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // ensure we can initially acquire a  token
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);

            // ensure subsequent calls before the token expires are served from the token cache
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);

            // ensure new credentials don't share tokens from the cache
            var credential2 = new ClientCertificateCredential(tenantId, clientId, cert, options);

            AccessToken token2 = await credential2.GetTokenAsync(tokenRequestContext);

            // this assert is conditional because the access token is scrubbed in the recording so they will never be different
            if (Mode != RecordedTestMode.Playback && Mode != RecordedTestMode.None)
            {
                Assert.AreNotEqual(token.Token, token2.Token);
            }
        }

        [Test]
        [Ignore("To be run manually. Unit test coverage exists.")]
        public async Task IncludeX5CClaimHeader()
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;
            var certPath = TestEnvironment.ServicePrincipalSniCertificatePath;

            var options = InstrumentClientOptions(new ClientCertificateCredentialOptions { SendCertificateChain = true });

            var credential = InstrumentClient(new ClientCertificateCredential(tenantId, clientId, certPath, options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // ensure we can initially acquire a  token
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);
        }

        [Test]
        public void IncorrectCertificate()
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;
            var certPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");

            var options = InstrumentClientOptions(new TokenCredentialOptions());

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadPkcs12FromFile(certPath, null);
#else
            var cert = new X509Certificate2(certPath);
#endif
            var credential = InstrumentClient(new ClientCertificateCredential(tenantId, clientId, cert, options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(new Uri(TestEnvironment.AuthorityHostUrl)) });

            // ensure the incorrect client claim is rejected, handled and wrapped in AuthenticationFailedException
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(tokenRequestContext));
        }
    }
}
