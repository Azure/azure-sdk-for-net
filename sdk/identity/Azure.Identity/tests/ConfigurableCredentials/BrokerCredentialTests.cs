// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity.Tests.ConfigurableCredentials.Broker
{
    /// <summary>
    /// Tests for BrokerCredential accessed through ConfigurableCredential.
    /// Inherits from Tests.BrokerCredentialTests to get all Broker-specific test cases.
    /// Overrides factory methods to create credentials via IConfiguration.
    /// </summary>
    internal class BrokerCredentialTests : Tests.BrokerCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<BrokerCredential> _helper;

        public BrokerCredentialTests()
        {
            _helper = new ConfigurableCredentialTestHelper<BrokerCredential>("Broker");
        }

        private TokenCredential CreateConfiguredCredential(string tenantId = null, bool addTenantIdHint = false)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            if (addTenantIdHint)
            {
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";
            }

            ConfigurableCredential credential;
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return _helper.InstrumentCredential(credential);
        }

        protected override TokenCredential CreateCredential(string tenantId = null, bool addTenantIdHint = false)
            => CreateConfiguredCredential(tenantId, addTenantIdHint);

        protected override TokenCredential CreateBareCredential()
            => CreateConfiguredCredential();

        // ConfigurableCredential wraps in DefaultAzureCredential (always chained),
        // so the expected exception is always CredentialUnavailableException.
        protected override Type GetExpectedExceptionType(bool isChained)
            => typeof(CredentialUnavailableException);

        protected override void CreateCredentialForTenantValidation(string tenantId)
            => _helper.CreateCredentialForTenantValidation(tenantId);
    }
}
