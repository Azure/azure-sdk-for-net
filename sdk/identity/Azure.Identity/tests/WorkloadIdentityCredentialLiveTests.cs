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
        public async Task AuthnenticateWithWorkflowIdentity()
        {
            WorkloadIdentityCredentialOptions options = new WorkloadIdentityCredentialOptions
            {
                TenantId = TestEnvironment.ServicePrincipalTenantId,
                ClientId = TestEnvironment.ServicePrincipalClientId,
                TokenFilePath = _tempFiles.GetTempFilePath()
            };

            var certificatePath = TestEnvironment.ServicePrincipalCertificatePfxPath;
            var cert = new X509Certificate2(certificatePath);

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

        [TearDown]
        public void CleanupTestAssertionFiles()
        {
            _tempFiles.CleanupTempFiles();
        }

        private TestTempFileHandler _tempFiles = new TestTempFileHandler();
    }
}
