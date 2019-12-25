// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class CliCredentialTest : ClientTestBase
    {
        public CliCredentialTest(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetTokenMockAsync()
        {
            var expectedToken = "mock-cli-access-token";

            string mockResult = $"{{ \"accessToken\": \"{expectedToken}\", \"expiresOn\": \"1900-01-01 00:00:00.1\" }}";

            var mockCliCredentialClient = new MockCliCredentialClient((mockResult, 0));

            CliCredential credential = InstrumentClient(new CliCredential(CredentialPipeline.GetInstance(null), mockCliCredentialClient));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
        }

        [Test]
        public async Task CliCredentialWinAzureCLINotInstalledException()
        {
            string expectedInnerExMessage = "Azure CLI not installed";

            var mockAadClient = new MockCliCredentialClient(("'az' is not recognized", 1));

            CliCredential credential = InstrumentClient(new CliCredential(CredentialPipeline.GetInstance(null), mockAadClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(expectedInnerExMessage, ex.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task CliCredentialLinuxAzureCLINotInstalledException()
        {
            string expectedInnerExMessage = "Azure CLI not installed";

            var mockAadClient = new MockCliCredentialClient(("az: command not found", 1));

            CliCredential credential = InstrumentClient(new CliCredential(CredentialPipeline.GetInstance(null), mockAadClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(expectedInnerExMessage, ex.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task CliCredentialOtherAzureCLINotInstalledException()
        {
            string expectedInnerExMessage = "Azure CLI not installed";

            var mockAadClient = new MockCliCredentialClient(("az: not found", 1));

            CliCredential credential = InstrumentClient(new CliCredential(CredentialPipeline.GetInstance(null), mockAadClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(expectedInnerExMessage, ex.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task CliCredentialAuthenticationFailedException()
        {
            string mockResult = $"mock-result";

            var mockAadClient = new MockCliCredentialClient((mockResult, 1));

            CliCredential credential = InstrumentClient(new CliCredential(CredentialPipeline.GetInstance(null), mockAadClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            await Task.CompletedTask;
        }
    }
}
