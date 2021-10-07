// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Test.Shared;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueConfigurationTests
    {
        private readonly AzuriteFixture azuriteFixture;

        public QueueConfigurationTests()
        {
            azuriteFixture = AzuriteNUnitFixture.Instance;
        }

        [Test]
        public async Task QueueClient_CanConnect_ConnectionString()
        {
            var account = azuriteFixture.GetAzureAccount();
            var prog = new BindToCloudQueueProgram();
            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"CustomConnection", account.ConnectionString },
                        {"queueName", "testqueue" }
                    });
                })
                .ConfigureDefaultTestHost(prog, builder =>
                {
                    SetupAzurite(builder);
                    builder.AddAzureStorageQueues();
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudQueueProgram>();
            await jobHost.CallAsync(nameof(BindToCloudQueueProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("testqueue", result.Name);
            Assert.True(await result.ExistsAsync());
        }

        [Test]
        public async Task QueueClient_CanConnect_ServiceUri()
        {
            var account = azuriteFixture.GetAzureAccount();
            var prog = new BindToCloudQueueProgram();
            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"CustomConnection:serviceUri", account.QueueEndpoint },
                        {"queueName", "testqueue" }
                    });
                })
                .ConfigureDefaultTestHost(prog, builder =>
                {
                    SetupAzurite(builder);
                    builder.AddAzureStorageQueues();
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudQueueProgram>();
            await jobHost.CallAsync(nameof(BindToCloudQueueProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("testqueue", result.Name);
            Assert.True(await result.ExistsAsync());
        }

        [Test]
        public async Task QueueClient_CanConnect_QueueServiceUri()
        {
            var account = azuriteFixture.GetAzureAccount();
            var prog = new BindToCloudQueueProgram();
            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"CustomConnection:queueServiceUri", account.QueueEndpoint },
                        {"queueName", "testqueue" }
                    });
                })
                .ConfigureDefaultTestHost(prog, builder =>
                {
                    SetupAzurite(builder);
                    builder.AddAzureStorageQueues();
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudQueueProgram>();
            await jobHost.CallAsync(nameof(BindToCloudQueueProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("testqueue", result.Name);
            Assert.True(await result.ExistsAsync());
        }

        private void SetupAzurite(IWebJobsBuilder builder)
        {
            builder.Services.AddAzureClients(builder =>
            {
                builder.UseCredential(azuriteFixture.GetCredential());
                builder.ConfigureDefaults(options => options.Transport = azuriteFixture.GetTransport());
            });
        }

        private class BindToCloudQueueProgram
        {
            public QueueClient Result { get; set; }

            public void Run(
                [Queue("%queueName%", Connection = "CustomConnection")] QueueClient queue)
            {
                Result = queue;
            }
        }
    }
}
