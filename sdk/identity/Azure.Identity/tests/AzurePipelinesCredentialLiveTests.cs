// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzurePipelinesCredentialLiveTests : IdentityRecordedTestBase
    {
        public AzurePipelinesCredentialLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        [LiveOnly]
        public async Task AzurePipelineCredentialLiveTest_GetToken()
        {
            var systemAccessToken = Environment.GetEnvironmentVariable("SYSTEM_ACCESSTOKEN");

            Assert.IsNotNull(systemAccessToken);

            var cred = new AzurePipelinesCredential(systemAccessToken);

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new[] { "https://management.azure.com//.default" }), CancellationToken.None);

            Assert.IsNotNull(token.Token);
        }
    }
}
