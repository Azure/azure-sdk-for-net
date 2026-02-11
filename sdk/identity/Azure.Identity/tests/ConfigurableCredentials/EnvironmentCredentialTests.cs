// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity.Tests.ConfigurableCredentials.Environment
{
    internal class EnvironmentCredentialTests : Tests.EnvironmentCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<EnvironmentCredential> _helper;

        public EnvironmentCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<EnvironmentCredential>(
                "Environment",
                null,
                null,
                InstrumentClient);
        }

        private ConfigurableCredential CreateConfiguredCredential(EnvironmentCredentialOptions options = null)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (options != null)
            {
                config["MyClient:Credential:DisableInstanceDiscovery"] = options.DisableInstanceDiscovery.ToString();
            }
            return _helper.GetCredentialFromConfig(config);
        }

        protected override TokenCredential CreateBareCredential()
            => CreateConfiguredCredential();

        protected override TokenCredential CreateBareCredentialWithOptions(EnvironmentCredentialOptions options)
            => CreateConfiguredCredential(options);

        protected override TokenCredential CreateInstrumentedCredential()
            => _helper.InstrumentCredential(CreateConfiguredCredential());

        protected override TokenCredential CreateInstrumentedBareCredential()
            => _helper.InstrumentCredential(CreateConfiguredCredential());

        protected override EnvironmentCredential GetEnvironmentCredential(TokenCredential credential)
            => _helper.GetUnderlyingCredential((ConfigurableCredential)credential);
    }
}
