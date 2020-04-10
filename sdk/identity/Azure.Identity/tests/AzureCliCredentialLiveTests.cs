// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzureCliCredentialLiveTests : ClientTestBase
    {
        public AzureCliCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AuthWithCliAsync()
        {
            var credential = new AzureCliCredential();

            SecretClient client = new SecretClient(new Uri("https://clicredtestvault.vault.azure.net/"), credential);

            await client.SetSecretAsync("myclicredsecret", "cliauthworked");

            KeyVaultSecret secret = await client.GetSecretAsync("myclicredsecret");

            Assert.AreEqual("cliauthworked", secret.Value);
        }
    }
}
