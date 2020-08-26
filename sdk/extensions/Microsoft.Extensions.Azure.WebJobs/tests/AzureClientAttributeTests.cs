// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Extensions.WebJobs;
using Azure.Security.KeyVault.Keys;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Azure.WebJobs.Tests
{
    public class AzureClientAttributeTests : RecordedTestBase<WebJobsTestEnvironment>
    {
        public AzureClientAttributeTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task A()
        {
            var host = new HostBuilder()
                .ConfigureServices(services => services.AddAzureClients(builder => builder.ConfigureDefaults(options => Recording.InstrumentClientOptions(options))))
                .ConfigureAppConfiguration(config =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "Connection:vaultUri", TestEnvironment.KeyVaultUrl }
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
            public void Run([AzureClient("Connection")] KeyClient serviceClient)
            {
            }
        }
    }
}
