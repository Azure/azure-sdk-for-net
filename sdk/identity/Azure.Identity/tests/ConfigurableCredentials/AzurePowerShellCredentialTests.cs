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

        private TokenCredential CreateConfiguredCredential(IProcessService processService = null, string tenantId = null, bool addTenantIdHint = false, TimeSpan? timeout = null)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            if (addTenantIdHint)
            {
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = TenantIdHint;
            }
            if (timeout != null)
            {
                config["MyClient:Credential:CredentialProcessTimeout"] = timeout.Value.ToString();
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
            => CreateConfiguredCredential(processService, timeout: timeout);

        protected override TokenCredential CreateCredentialWithChainedOption(IProcessService processService, bool isChained)
            => CreateConfiguredCredential(processService);

        protected override TokenCredential CreateBareCredential()
            => CreateConfiguredCredential();

        // ConfigurableCredential with CredentialSource creates a single (non-chained) credential,
        // so chained credential scenarios are not applicable.
        protected override bool IsChainedCredentialSupported => false;

        protected override void CreateCredentialForTenantValidation(string tenantId)
            => _helper.CreateCredentialForTenantValidation(tenantId);
    }
}
