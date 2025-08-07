// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [NonParallelizable]
    public class EnvironmentCredential_ClientCertificateTests : CredentialTestBase<EnvironmentCredentialOptions>
    {
        public EnvironmentCredential_ClientCertificateTests(bool isAsync) : base(isAsync)
        {
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            Assert.Ignore("Not supported for this test.");
            return null;
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }
            using (new TestEnvVar(
                new()
                {
                    { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", string.Join(";", config.AdditionallyAllowedTenants ?? Enumerable.Empty<string>()) },
                    { "AZURE_CLIENT_ID", ClientId },
                    { "AZURE_CLIENT_SECRET", null},
                    { "AZURE_TENANT_ID", config.TenantId },
                    {"AZURE_USERNAME", null },
                    { "AZURE_PASSWORD", null },
                    { "AZURE_CLIENT_CERTIFICATE_PATH", Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem") },
                }))
            {
                var options = new EnvironmentCredentialOptions
                {
                    DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                    IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                    MsalConfidentialClient = config.MockConfidentialMsalClient,
                    MsalPublicClient = config.MockPublicMsalClient,
                    AuthorityHost = config.AuthorityHost,
                };
                if (config.Transport != null)
                {
                    options.Transport = config.Transport;
                }

                var pipeline = CredentialPipeline.GetInstance(options);

                return InstrumentClient(new EnvironmentCredential(pipeline, options));
            }
        }
    }
}
