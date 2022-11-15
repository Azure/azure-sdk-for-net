// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientAssertionCredentialTests : CredentialTestBase
    {
        public ClientAssertionCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var clientAssertionOptions = new ClientAssertionCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }, MsalClient = mockConfidentialMsalClient, Pipeline = CredentialPipeline.GetInstance(null) };

            return InstrumentClient(new ClientAssertionCredential(expectedTenantId, ClientId, () => "assertion", clientAssertionOptions));
        }

        public override async Task VerifyAllowedTenantEnforcement(AllowedTenantsTestParameters parameters)
        {
            Console.WriteLine(parameters.ToDebugString());

            // no need to test with null TenantId since we can't construct this credential without it
            if (parameters.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var msalClientMock = new MockMsalConfidentialClient(AuthenticationResultFactory.Create());

            var options = new ClientAssertionCredentialOptions() { MsalClient = msalClientMock, Pipeline = CredentialPipeline.GetInstance(null) };

            foreach (var addlTenant in parameters.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(addlTenant);
            }

            var cred = InstrumentClient(new ClientAssertionCredential(parameters.TenantId, ClientId, () => "assertion", options));

            await AssertAllowedTenantIdsEnforcedAsync(parameters, cred);
        }
    }
}
