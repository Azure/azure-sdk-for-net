// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

using Azure.Identity;
namespace Azure.Core.Tests.Identity.ConfigurableCredentials.AzureCli
{
    internal class AzureCliCredentialTests : Azure.Core.Tests.Identity.AzureCliCredentialTests
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

        private TokenCredential CreateConfiguredCredential(IProcessService processService = null, string tenantId = null, string subscription = null, bool addTenantIdHint = false, TimeSpan? timeout = null, bool isChained = false)
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
            if (subscription != null)
            {
                config[$"{prefix}:Subscription"] = subscription;
            }
            if (timeout != null)
            {
                config[$"{prefix}:ProcessTimeout"] = timeout.Value.ToString();
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
            => CreateConfiguredCredential(processService, timeout: timeout, isChained: isChained);

        protected override TokenCredential CreateCredentialWithChainedOption(IProcessService processService, bool isChained)
            => CreateConfiguredCredential(processService, isChained: isChained);

        protected override TokenCredential CreateBareCredential()
            => CreateConfiguredCredential();

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
