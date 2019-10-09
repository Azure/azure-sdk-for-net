// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Reflection;
using Azure.Core;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialTests : ClientTestBase
    {
        public ManagedIdentityCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ResetManagedIdenityClient()
        {
            typeof(ManagedIdentityClient).GetField("s_msiType", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, 0);
            typeof(ManagedIdentityClient).GetField("s_endpoint", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, null);
        }

        [Test]
        [Ignore("This test can only be run from an environment where managed identity is enabled")]
        public async Task GetSystemTokenLiveAsync()
        {
            var credential = new ManagedIdentityCredential();

            AccessToken token = await credential.GetTokenAsync(new TokenRequest(new string[] { "https://management.azure.com//.default" }));

            Assert.IsNotNull(token.Token);
        }
    }
}
