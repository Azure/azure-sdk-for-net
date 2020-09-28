// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Xunit;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Azure.WebJobs.Extensions.Storage.Common.Tests;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests.Blobs.Listeners
{
    public class ScanContainersStrategyTests : IClassFixture<AzuriteFixture>
    {
        private readonly AzuriteFixture azuriteFixture;

        public ScanContainersStrategyTests(AzuriteFixture azuriteFixture)
        {
            this.azuriteFixture = azuriteFixture;
        }

        [Fact]
        public async Task TestBlobListener()
        {
            const string containerName = "container";
            var account = CreateFakeStorageAccount();
            var blobServiceClient = account.CreateBlobServiceClient();
            var container = blobServiceClient.GetBlobContainerClient(containerName);
            IBlobListenerStrategy product = new ScanContainersStrategy();
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            product.Register(blobServiceClient, container, executor);
            product.Start();

            executor.ExecuteLambda = (_) =>
            {
                throw new InvalidOperationException("shouldn't be any blobs in the container");
            };
            product.Execute();

            const string expectedBlobName = "foo1.csv";
            var blob = container.GetBlockBlobClient(expectedBlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("ignore");

            int count = 0;
            executor.ExecuteLambda = (b) =>
            {
                count++;
                Assert.Equal(expectedBlobName, b.Name);
                return true;
            };
            product.Execute();
            Assert.Equal(1, count);

            // Now run again; shouldn't show up.
            executor.ExecuteLambda = (_) =>
            {
                throw new InvalidOperationException("shouldn't retrigger the same blob");
            };
            product.Execute();
        }

        private StorageAccount CreateFakeStorageAccount()
        {
            return StorageAccount.NewFromConnectionString(azuriteFixture.GetAccount().ConnectionString);
        }

        private class LambdaBlobTriggerExecutor : ITriggerExecutor<BlobTriggerExecutorContext>
        {
            public Func<BlobBaseClient, bool> ExecuteLambda { get; set; }

            public Task<FunctionResult> ExecuteAsync(BlobTriggerExecutorContext value, CancellationToken cancellationToken)
            {
                bool succeeded = ExecuteLambda.Invoke(value.Blob.BlobClient);
                FunctionResult result = new FunctionResult(succeeded);
                return Task.FromResult(result);
            }
        }
    }
}
