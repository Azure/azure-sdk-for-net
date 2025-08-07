// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientAssertionCredentialLiveTests : IdentityRecordedTestBase
    {
        public ClientAssertionCredentialLiveTests(bool isAsync) : base(isAsync)
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
        public async Task AuthnenticateWithAssertionCallback(bool useAsyncCallback)
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadPkcs12FromFile(TestEnvironment.ServicePrincipalCertificatePfxPath, null);
#else
            var cert = new X509Certificate2(TestEnvironment.ServicePrincipalCertificatePfxPath);
#endif

            var options = InstrumentClientOptions(new ClientAssertionCredentialOptions());

            ClientAssertionCredential credential;

            if (useAsyncCallback)
            {
                Func<CancellationToken, Task<string>> assertionCallback = (ct) => Task.FromResult(CredentialTestHelpers.CreateClientAssertionJWT(options.AuthorityHost, clientId, tenantId, cert));

                credential = InstrumentClient(new ClientAssertionCredential(tenantId, clientId, assertionCallback, options));
            }
            else
            {
                Func<string> assertionCallback = () => CredentialTestHelpers.CreateClientAssertionJWT(options.AuthorityHost, clientId, tenantId, cert);

                credential = InstrumentClient(new ClientAssertionCredential(tenantId, clientId, assertionCallback, options));
            }

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
    }
}
