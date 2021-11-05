// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Azure.WebJobs.Tests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.WebJobs.Extensions.Clients.Tests
{
    public class AzureClientAttributeFunctionalTests : RecordedTestBase<WebJobsTestEnvironment>
    {
        public AzureClientAttributeFunctionalTests(bool isAsync) : base(isAsync)
        {
            Matcher = new RecordMatcher()
            {
                IgnoredQueryParameters =
                {
                    // Ignore KeyVault client API Version when matching
                    "api-version"
                }
            };
        }

        [RecordedTest]
        public async Task CanInjectKeyVaultClient()
        {
            // We don't controll the client creation
            ValidateClientInstrumentation = false;
            var host = new HostBuilder()
                .ConfigureServices(services => services.AddAzureClients(builder => builder
                    .ConfigureDefaults(options => InstrumentClientOptions<ClientOptions>(options))
                    .UseCredential(TestEnvironment.Credential)))
                .ConfigureAppConfiguration(config =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "AzureWebJobsConnection:vaultUri", TestEnvironment.KeyVaultUrl }
                    });
                })
                .ConfigureDefaultTestHost<FunctionWithAzureClient>(builder =>
                {
                    builder.AddAzureClients();
                }).Build();

            var jobHost = host.GetJobHost<FunctionWithAzureClient>();
            await jobHost.CallAsync(nameof(FunctionWithAzureClient.Run));
        }

        public class FunctionWithAzureClient
        {
            public async Task Run([AzureClient("Connection")] SecretClient keyClient)
            {
                await keyClient.SetSecretAsync("TestSecret", "Secret value");
            }
        }
    }
}
