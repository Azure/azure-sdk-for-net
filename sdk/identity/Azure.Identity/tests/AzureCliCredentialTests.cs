// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzureCliCredentialTests : ClientTestBase
    {
        public AzureCliCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetTokenMockAsync()
        {
            var expectedToken = "mock-cli-access-token";

            string mockResult = $"{{ \"accessToken\": \"{expectedToken}\", \"expiresOn\": \"1900-01-01 00:00:00.123456\" }}";

            var mockCliCredentialClient = new MockAzureCliCredentialClient((mockResult, 0));

            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), mockCliCredentialClient));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
        }

        [Test]
        public void CliCredentialAzureCLINotInstalledException()
        {
            string expectedMessage = $"Azure CLI not installed";

            var mockCliCreClientList = new List<MockAzureCliCredentialClient>();

            // Mock client for Windows Azure CLI not installed error message
            mockCliCreClientList.Add(new MockAzureCliCredentialClient(("'az' is not recognized", 1)));

            // Mock client for Linux Azure CLI not installed error message
            mockCliCreClientList.Add(new MockAzureCliCredentialClient(("az: command not found", 1)));

            // Mock client for MacOS Azure CLI not installed error message
            mockCliCreClientList.Add(new MockAzureCliCredentialClient(("az: not found", 1)));

            foreach (var mockCliCredentialClient in mockCliCreClientList)
            {
                AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), mockCliCredentialClient));

                var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [Test]
        public void CliCredentialAzNotLogInException()
        {
            string expectedExMessage = $"Please run 'az login' to set up account";

            var mockCliCredentialClient = new MockAzureCliCredentialClient(("Please run 'az login'", 1));

            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), mockCliCredentialClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(expectedExMessage, ex.Message);
        }

        [Test]
        public void CliCredentialAuthenticationFailedException()
        {
            string mockResult = $"mock-result";

            var mockCliCredentialClient = new MockAzureCliCredentialClient((mockResult, 1));

            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), mockCliCredentialClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }
    }
}
