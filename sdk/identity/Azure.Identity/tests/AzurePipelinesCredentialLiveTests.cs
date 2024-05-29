// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            var tenantId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_TENANT_ID");
            var clientId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_CLIENT_ID");
            var serviceConnectionId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_ID");

            Assert.IsNotNull(systemAccessToken);

            var cred = new AzurePipelinesCredential(systemAccessToken, clientId, tenantId, serviceConnectionId);

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new[] { "https://management.azure.com//.default" }), CancellationToken.None);

            Assert.IsNotNull(token.Token);
        }
    }
}
