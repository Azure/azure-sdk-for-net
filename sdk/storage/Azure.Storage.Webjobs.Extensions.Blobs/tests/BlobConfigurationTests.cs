// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class BlobConfigurationTests : IClassFixture<AzuriteFixture>
    {
        private readonly AzuriteFixture azuriteFixture;

        public BlobConfigurationTests(AzuriteFixture azuriteFixture)
        {
            this.azuriteFixture = azuriteFixture;
        }

        [Fact]
        public async Task BlobClient_CanConnect_ConnectionString()
        {
            var account = azuriteFixture.GetAzureAccount();
            var prog = new BindToCloudBlockBlobProgram();
            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"CustomConnection", account.ConnectionString }
                    });
                })
                .ConfigureDefaultTestHost(prog, builder =>
                {
                    builder.AddAzureStorageBlobs().AddAzureStorageQueues();
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudBlockBlobProgram>();
            await jobHost.CallAsync(nameof(BindToCloudBlockBlobProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("blob", result.Name);
            Assert.Equal("container", result.BlobContainerName);
            Assert.NotNull(result.BlobContainerName);
            Assert.False(await result.ExistsAsync());
        }

        [Fact]
        public async Task BlobClient_CanConnect_EndPoint()
        {
            var account = azuriteFixture.GetAzureAccount();
            var prog = new BindToCloudBlockBlobProgram();
            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"CustomConnection_endpoint", account.ConnectionString }
                    });
                })
                .ConfigureDefaultTestHost(prog, builder =>
                {
                    builder.AddAzureStorageBlobs().AddAzureStorageQueues();
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudBlockBlobProgram>();
            await jobHost.CallAsync(nameof(BindToCloudBlockBlobProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("blob", result.Name);
            Assert.Equal("container", result.BlobContainerName);
            Assert.NotNull(result.BlobContainerName);
            Assert.False(await result.ExistsAsync());
        }

        private class BindToCloudBlockBlobProgram
        {
            public BlockBlobClient Result { get; set; }

            public void Run(
                [Blob("container/blob", Connection = "CustomConnection")] BlockBlobClient blob)
            {
                this.Result = blob;
            }
        }
    }
}