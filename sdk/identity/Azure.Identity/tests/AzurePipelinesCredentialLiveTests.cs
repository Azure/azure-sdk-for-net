// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
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

            if (string.IsNullOrEmpty(systemAccessToken) || string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(serviceConnectionId))
            {
                var envVars = Environment.GetEnvironmentVariables();
                StringBuilder sb = new StringBuilder();
                foreach (var key in envVars.Keys)
                {
                    sb.AppendLine($"{key}: {envVars[key]}");
                }
                Console.WriteLine(sb);
                Assert.Fail($"{sb} SYSTEM_ACCESSTOKEN: {systemAccessToken}, AZURE_SERVICE_CONNECTION_TENANT_ID: {tenantId}, AZURE_SERVICE_CONNECTION_CLIENT_ID: {clientId}, AZURE_SERVICE_CONNECTION_ID: {serviceConnectionId}");
                Assert.Ignore("AzurePipelinesCredentialLiveTests disabled because required environment variables are not set");
            }

            var cred = new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId, systemAccessToken);

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new[] { "https://management.azure.com//.default" }), CancellationToken.None);

            Assert.IsNotNull(token.Token);
        }

        [Test]
        [LiveOnly]
        public void AzurePipelineCredentialLiveTest_GetToken_InvalidSystemAccessToken()
        {
            string systemAccessToken = "invalidSystemAccessToken";
            var tenantId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_TENANT_ID");
            var clientId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_CLIENT_ID");
            var serviceConnectionId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_ID");

            if (string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(serviceConnectionId))
            {
                var envVars = Environment.GetEnvironmentVariables();
                StringBuilder sb = new StringBuilder();
                foreach (var key in envVars.Keys)
                {
                    sb.AppendLine($"{key}: {envVars[key]}");
                }
                Console.WriteLine(sb);
                Assert.Fail($"{sb} SYSTEM_ACCESSTOKEN: {systemAccessToken}, AZURE_SERVICE_CONNECTION_TENANT_ID: {tenantId}, AZURE_SERVICE_CONNECTION_CLIENT_ID: {clientId}, AZURE_SERVICE_CONNECTION_ID: {serviceConnectionId}");
                Assert.Ignore("AzurePipelinesCredentialLiveTests disabled because required environment variables are not set");
            }

            var cred = new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId, systemAccessToken);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { "https://management.azure.com//.default" }), CancellationToken.None));
            Assert.That(ex.Message, Does.Contain("not authorized"));
        }
    }
}
