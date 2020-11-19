// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzurePowerShellCredentialsTests : ClientTestBase
    {
        public AzurePowerShellCredentialsTests(bool isAsync) : base(isAsync)
        {
        }

        //[Test]
        //public async Task AuthenticateWithAzurePowerShellCredential()
        //{
        //    AzurePowerShellCredential apc = new AzurePowerShellCredential();
        //    var result =
        //        await apc.GetTokenAsync(new TokenRequestContext(new[] {"https://backup.blob.core.windows.net"}));

        //    Assert.IsNotNull(result);
        //}

        [Test]
        public async Task AuthenticateWithAzurePowerShellCredential()
        {
            var (expectedToken, expectedExpiresOn) = CredentialTestHelpers.CreateTokenForAzurePowerShell(new TimeSpan(30));

            var testProcess = new TestProcess { Output = expectedToken };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential
                (new AzurePowerShellCredentialOptions() ,CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);
        }

        [Test]
        public void AuthenticateWithCliCredential_AzurePowerShellNotInstalled([Values("'pwsh' is not recognized", "pwsh: command not found", "pwsh: not found", "'powershell' is not recognized", "pwspowershellh: command not found", "powershell: not found")] string errorMessage)
        {
            string expectedMessage = "PowerShell is not installed.";
            var testProcess = new TestProcess { Error = errorMessage };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }
}
