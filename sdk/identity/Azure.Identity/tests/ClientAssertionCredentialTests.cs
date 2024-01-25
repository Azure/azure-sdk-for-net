// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientAssertionCredentialTests : CredentialTestBase<ClientAssertionCredentialOptions>
    {
        public ClientAssertionCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var clientAssertionOptions = new ClientAssertionCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }, MsalClient = mockConfidentialMsalClient, Pipeline = CredentialPipeline.GetInstance(null) };

            return InstrumentClient(new ClientAssertionCredential(expectedTenantId, ClientId, () => "assertion", clientAssertionOptions));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new ClientAssertionCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                MsalClient = config.MockConfidentialMsalClient,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            var pipeline = CredentialPipeline.GetInstance(options);
            options.Pipeline = pipeline;
            return InstrumentClient(new ClientAssertionCredential(config.TenantId, ClientId, () => "assertion", options));
        }
    }
}
