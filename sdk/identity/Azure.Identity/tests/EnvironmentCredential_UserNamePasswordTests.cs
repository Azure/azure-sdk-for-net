// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [NonParallelizable]
    public class EnvironmentCredential_UserNamePasswordTests : CredentialTestBase<EnvironmentCredentialOptions>
    {
        public EnvironmentCredential_UserNamePasswordTests(bool isAsync) : base(isAsync)
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
                    {"AZURE_USERNAME", "mockusername" },
                    { "AZURE_PASSWORD", "mockpassword" },
                    { "AZURE_CLIENT_CERTIFICATE_PATH", null }
                }))
            {
                var options = new EnvironmentCredentialOptions
                {
                    DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                    IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                    MsalConfidentialClient = config.MockConfidentialMsalClient,
                    MsalPublicClient = config.MockPublicMsalClient
                };
                if (config.Transport != null)
                {
                    options.Transport = config.Transport;
                }

                return InstrumentClient(new EnvironmentCredential(options));
            }
        }
    }
}
