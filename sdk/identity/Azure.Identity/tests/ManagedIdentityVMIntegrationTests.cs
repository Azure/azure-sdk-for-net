// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityVMIntegrationTests : IdentityRecordedTestBase
    {
        public ManagedIdentityVMIntegrationTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        [LiveOnly]
        [Category("IdentityVM")]
        // This test leverages the test app found in Azure.Identity\integration\WebApp
        // It validates that ManagedIdentityCredential can acquire a token in an actual Azure Web App environment
        public async Task GetManagedIdentityToken()
        {
            var cred = new ManagedIdentityCredential(TestEnvironment.VMUserAssignedManagedIdentityClientId);
            var token = await cred.GetTokenAsync(new(CredentialTestHelpers.DefaultScope));
            Assert.NotNull(token.Token);
        }
    }
}
