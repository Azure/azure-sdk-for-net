// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [NonParallelizable]
    public class EnvironmentCredential_ClientSecretTests : CredentialTestBase<EnvironmentCredentialOptions>
    {
        public EnvironmentCredential_ClientSecretTests(bool isAsync) : base(isAsync)
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

            var options = new EnvironmentCredentialOptions
            {
                Transport = config.Transport,
                DisableInstanceDiscovery = config.DisableMetadataDiscovery ?? false
            };
            var pipeline = CredentialPipeline.GetInstance(options);
            using (new TestEnvVar(
                new()
                {
                    { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", string.Join(";", config.AdditionallyAllowedTenants ?? Enumerable.Empty<string>()) },
                    { "AZURE_CLIENT_ID", ClientId },
                    { "AZURE_CLIENT_SECRET", "mockclientsecret"},
                    { "AZURE_TENANT_ID", config.TenantId },
                    { "AZURE_USERNAME", null },
                    { "AZURE_PASSWORD", null },
                    { "AZURE_CLIENT_CERTIFICATE_PATH", null }
                }))
            {
                return InstrumentClient(new EnvironmentCredential(pipeline, options));
            }
        }

        public override Task VerifyAllowedTenantEnforcementAllCreds(AllowedTenantsTestParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
