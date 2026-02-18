// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.ConfigurableCredentials;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Azure.Identity.Broker.Tests.ConfigurableCredentials
{
    /// <summary>
    /// Tests for broker-mode InteractiveBrowserCredential accessed through ConfigurableCredential.
    /// Inherits from InteractiveBrowserCredentialBrokerTests to get broker-specific test cases.
    /// Overrides factory methods to create credentials via IConfiguration.
    /// </summary>
    internal class InteractiveBrowserCredentialBrokerTests : Tests.InteractiveBrowserCredentialBrokerTests
    {
        private readonly ConfigurableCredentialTestHelper<InteractiveBrowserCredential> _helper;

        public InteractiveBrowserCredentialBrokerTests()
        {
            _helper = new ConfigurableCredentialTestHelper<InteractiveBrowserCredential>(
                "InteractiveBrowser");
        }

        protected override TokenCredential CreateCredentialWithBeforeBuildClient(Action<PublicClientApplicationBuilder> beforeBuildClient)
            => CreateFromConfig(beforeBuildClient);

        protected override TokenCredential CreateCredentialWithBrokerMode(Action<PublicClientApplicationBuilder> beforeBuildClient)
            => CreateFromConfig(beforeBuildClient, useDefaultBrokerAccount: true, isChainedCredential: true);

        private TokenCredential CreateFromConfig(
            Action<PublicClientApplicationBuilder> beforeBuildClient,
            bool useDefaultBrokerAccount = false,
            bool isChainedCredential = false)
        {
            IConfiguration config = _helper.GetConfiguration();
            config["MyClient:Credential:InteractiveBrowserCredentialClientId"] = Guid.NewGuid().ToString();
            if (useDefaultBrokerAccount)
            {
                config["MyClient:Credential:UseDefaultBrokerAccount"] = "True";
            }

            ConfigurableCredential ccCredential;
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                ccCredential = _helper.GetCredentialFromConfig(config);
            }

            var ibc = _helper.GetUnderlyingCredential(ccCredential);
            if (isChainedCredential)
            {
                ibc.IsChainedCredential = true;
            }
            typeof(MsalPublicClient)
                .GetField("_beforeBuildClient", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(ibc.Client, beforeBuildClient);

            return _helper.InstrumentCredential(ccCredential);
        }
    }
}
