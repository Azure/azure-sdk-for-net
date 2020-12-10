// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Clients.Tests
{
    public class AzureClientAttributeTests
    {
        [TestCase("Connection")]
        [TestCase("AzureWebJobsConnection")]
        [TestCase("ConnectionStrings:Connection")]
        public async Task CreatesClientUsingSectionWithUri(string keyName)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { $"{keyName}:endpoint", "http://localhost" }
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
            public void Run([AzureClient("Connection")] TestClient testClient)
            {
                Assert.NotNull(testClient.Options);
                Assert.AreEqual(testClient.Uri.AbsoluteUri, "http://localhost/");
            }
        }

        [TestCase("Connection")]
        [TestCase("AzureWebJobsConnection")]
        [TestCase("ConnectionStrings:Connection")]
        public async Task CreatesClientUsingConnectionString(string keyName)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { $"{keyName}", "Key=Value;Key2=Value2" }
                    });
                })
                .ConfigureDefaultTestHost<FunctionWithAzureClientUsingConnectionString>(builder =>
                {
                    builder.AddAzureClients();
                }).Build();

            var jobHost = host.GetJobHost<FunctionWithAzureClientUsingConnectionString>();
            await jobHost.CallAsync(nameof(FunctionWithAzureClientUsingConnectionString.Run));
        }

        [TestCase("Connection")]
        [TestCase("AzureWebJobsConnection")]
        [TestCase("ConnectionStrings:Connection")]
        public async Task CreatesClientUsingExplicitConnectionString(string keyName)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { $"{keyName}:ConnectionString", "Key=Value;Key2=Value2" }
                    });
                })
                .ConfigureDefaultTestHost<FunctionWithAzureClientUsingConnectionString>(builder =>
                {
                    builder.AddAzureClients();
                }).Build();

            var jobHost = host.GetJobHost<FunctionWithAzureClientUsingConnectionString>();
            await jobHost.CallAsync(nameof(FunctionWithAzureClientUsingConnectionString.Run));
        }

        public class FunctionWithAzureClientUsingConnectionString
        {
            public void Run([AzureClient("Connection")] TestClient testClient)
            {
                Assert.NotNull(testClient.Options);
                Assert.AreEqual(testClient.ConnectionString, "Key=Value;Key2=Value2");
            }
        }

        [Test]
        public async Task CreatesClientUsingExplicitConnectionString()
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "ConnectionSettingName", "MyConnection"},
                        { "MyConnection:ConnectionString", "Key=Value;Key2=Value2" }
                    });
                })
                .ConfigureDefaultTestHost<FunctionWithAzureClientUsingFormattedString>(builder =>
                {
                    builder.AddAzureClients();
                }).Build();

            var jobHost = host.GetJobHost<FunctionWithAzureClientUsingFormattedString>();
            await jobHost.CallAsync(nameof(FunctionWithAzureClientUsingFormattedString.Run));
        }

        public class FunctionWithAzureClientUsingFormattedString
        {
            public void Run([AzureClient("%ConnectionSettingName%")] TestClient testClient)
            {
                Assert.NotNull(testClient.Options);
                Assert.AreEqual(testClient.ConnectionString, "Key=Value;Key2=Value2");
            }
        }
    }
}