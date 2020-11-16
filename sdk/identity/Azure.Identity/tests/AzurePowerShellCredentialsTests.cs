// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzurePowerShellCredentialsTests : ClientTestBase
    {
        public AzurePowerShellCredentialsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AuthenticateWithAzurePowerShellCredential()
        {
            AzurePowerShellCredential apc = new AzurePowerShellCredential();
            var result =
                await apc.GetTokenAsync(new TokenRequestContext(new[] {"https://backup.blob.core.windows.net"}));

            Assert.IsNotNull(result);
        }
    }
}
