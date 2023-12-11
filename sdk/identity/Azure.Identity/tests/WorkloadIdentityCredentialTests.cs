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
            var mockCert = new X509Certificate2(certificatePath);

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
            var mockCert = new X509Certificate2(certificatePath);

            var workloadOptions = config.Clone<WorkloadIdentityCredentialOptions>();

            workloadOptions.TenantId = config.TenantId;
            workloadOptions.ClientId = ClientId;
            workloadOptions.TokenFilePath = _tempFiles.GetTempFilePath();
            workloadOptions.MsalClient = config.MockConfidentialMsalClient;

            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(workloadOptions.AuthorityHost, workloadOptions.ClientId, workloadOptions.TenantId, mockCert);

            File.WriteAllText(workloadOptions.TokenFilePath, assertion);

            return InstrumentClient(new WorkloadIdentityCredential(workloadOptions));
        }

        [TearDown]
        public void CleanupTestAssertionFiles()
        {
            _tempFiles.CleanupTempFiles();
        }

        private TestTempFileHandler _tempFiles = new TestTempFileHandler();
    }
}
