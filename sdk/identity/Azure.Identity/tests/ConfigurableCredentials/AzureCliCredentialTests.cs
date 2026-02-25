// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.AzureCli
{
    internal class AzureCliCredentialTests : Tests.AzureCliCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<AzureCliCredential> _helper;

        public AzureCliCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<AzureCliCredential>(
                "AzureCli",
                CredentialTestHelpers.CreateTokenForAzureCli().Json,
                null,
                InstrumentClient);
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
            => _helper.GetTokenCredential(options, TenantId);

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
            => _helper.GetTokenCredential(config);

        private TokenCredential CreateConfiguredCredential(IProcessService processService = null, string tenantId = null, string subscription = null, bool addTenantIdHint = false, TimeSpan? timeout = null)
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
            if (subscription != null)
            {
                config["MyClient:Credential:Subscription"] = subscription;
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

        protected override TokenCredential CreateCredential(IProcessService processService, string tenantId = null, string subscription = null, bool addTenantIdHint = false)
            => CreateConfiguredCredential(processService, tenantId, subscription, addTenantIdHint);

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

        // Tests that validate AzureCliCredentialOptions directly need configurable equivalents.

        [Test]
        public override void AzureCliCredentialOptionsValidatesSubscriptionOption()
        {
            IConfiguration config = _helper.GetConfiguration();
            config["MyClient:Credential:Subscription"] = "My Subscription Name with a quote \"";
            Assert.Throws<ArgumentException>(() => _helper.GetCredentialFromConfig(config));

            config["MyClient:Credential:Subscription"] = "My Subscription Name -_";
            _helper.GetCredentialFromConfig(config);

            config["MyClient:Credential:Subscription"] = Guid.NewGuid().ToString();
            _helper.GetCredentialFromConfig(config);
        }
    }
}
