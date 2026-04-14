// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialLiveTests : ClientTestBase
    {
        public ManagedIdentityCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("This test can only be run from an environment where managed identity is enabled")]
        public async Task GetSystemTokenLiveAsync()
        {
            var credential = new ManagedIdentityCredential();

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://management.azure.com//.default" }));

            Assert.IsNotNull(token.Token);
        }

        [Test]
        [Ignore("This test can only be run from an environment where managed identity is enabled")]
        public async Task GetUserAssignedTokenLiveAsync()
        {
            var credential = new ManagedIdentityCredential(clientId: "afc83028-b0c7-463f-a9f3-25f08e69270d");

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://management.azure.com//.default" }));

            Assert.IsNotNull(token.Token);
        }
    }
}
