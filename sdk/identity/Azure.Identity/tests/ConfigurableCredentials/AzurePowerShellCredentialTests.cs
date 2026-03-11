// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.AzurePowerShell
{
    internal class AzurePowerShellCredentialTests : Tests.AzurePowerShellCredentialsTests
    {
        private readonly ConfigurableCredentialTestHelper<AzurePowerShellCredential> _helper;

        public AzurePowerShellCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<AzurePowerShellCredential>(
                "AzurePowerShell",
                CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30)).Json,
                null,
                InstrumentClient);
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
            => _helper.GetTokenCredential(options, TenantId);

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
            => _helper.GetTokenCredential(config);

        private TokenCredential CreateConfiguredCredential(IProcessService processService = null, string tenantId = null, bool addTenantIdHint = false, TimeSpan? timeout = null, bool isChained = false)
        {
            IConfiguration config = isChained ? _helper.GetChainedConfiguration() : _helper.GetConfiguration();
            // For chained mode, credential-specific properties go under the source's section.
            string prefix = isChained ? "MyClient:Credential:Sources:0" : "MyClient:Credential";
            if (tenantId != null)
            {
                config[$"{prefix}:TenantId"] = tenantId;
            }
            if (addTenantIdHint)
            {
                config[$"{prefix}:AdditionallyAllowedTenants:0"] = TenantIdHint;
            }
            if (timeout != null)
            {
                config[$"{prefix}:CredentialProcessTimeout"] = timeout.Value.ToString();
            }

            ConfigurableCredential credential;
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return _helper.InstrumentCredential(credential, processService);
        }

        protected override TokenCredential CreateCredential(IProcessService processService, string tenantId = null, bool addTenantIdHint = false)
            => CreateConfiguredCredential(processService, tenantId, addTenantIdHint);

        protected override TokenCredential CreateCredentialWithTimeout(IProcessService processService, TimeSpan timeout, bool isChained = false)
            => CreateConfiguredCredential(processService, timeout: timeout, isChained: isChained);

        protected override TokenCredential CreateCredentialWithChainedOption(IProcessService processService, bool isChained)
            => CreateConfiguredCredential(processService, isChained: isChained);

        protected override TokenCredential CreateBareCredential()
            => CreateConfiguredCredential();

        protected override void CreateCredentialForTenantValidation(string tenantId)
            => _helper.CreateCredentialForTenantValidation(tenantId);
    }
}
