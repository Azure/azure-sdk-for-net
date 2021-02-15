// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    public class BlobConfigurationTests
    {
        private readonly AzuriteFixture azuriteFixture;

        public BlobConfigurationTests()
        {
            azuriteFixture = AzuriteNUnitFixture.Instance;
        }

        [Test]
        public async Task BlobClient_CanConnect_ConnectionString()
        {
            var account = azuriteFixture.GetAzureAccount();
            var prog = new BindToCloudBlockBlobProgram();
            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"CustomConnection", account.ConnectionString },
                        {"blobPath", "cscontainer/csblob" }
                    });
                })
                .ConfigureDefaultTestHost(prog, builder =>
                {
                    SetupAzurite(builder);
                    builder.AddAzureStorageBlobs();
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudBlockBlobProgram>();
            await jobHost.CallAsync(nameof(BindToCloudBlockBlobProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("csblob", result.Name);
            Assert.AreEqual("cscontainer", result.BlobContainerName);
            Assert.NotNull(result.BlobContainerName);
            Assert.False(await result.ExistsAsync());
        }

        [Test]
        public async Task BlobClient_CanConnect_EndPoint()
        {
            var account = azuriteFixture.GetAzureAccount();
            var prog = new BindToCloudBlockBlobProgram();
            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"CustomConnection:endpoint", account.Endpoint },
                        {"blobPath", "endpointcontainer/endpointblob" }
                    });
                })
                .ConfigureDefaultTestHost(prog, builder =>
                {
                    SetupAzurite(builder);
                    builder.AddAzureStorageBlobs();
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudBlockBlobProgram>();
            await jobHost.CallAsync(nameof(BindToCloudBlockBlobProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("endpointblob", result.Name);
            Assert.AreEqual("endpointcontainer", result.BlobContainerName);
            Assert.NotNull(result.BlobContainerName);
            Assert.False(await result.ExistsAsync());
        }

        private void SetupAzurite(IWebJobsBuilder builder)
        {
            builder.Services.AddAzureClients(builder =>
            {
                builder.UseCredential(azuriteFixture.GetCredential());
                builder.ConfigureDefaults(options => options.Transport = azuriteFixture.GetTransport());
            });
        }

        private class BindToCloudBlockBlobProgram
        {
            public BlockBlobClient Result { get; set; }

            public void Run(
                [Blob("%blobPath%", Connection = "CustomConnection")] BlockBlobClient blob)
            {
                Result = blob;
            }
        }
    }
}
