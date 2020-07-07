// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.Storage.Blob;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests.Blobs.Listeners
{
    public class ScanContainersStrategyTests
    {
        [Fact]
        public async Task TestBlobListener()
        {
            const string containerName = "container";
            var account = CreateFakeStorageAccount();
            var container = account.CreateCloudBlobClient().GetContainerReference(containerName);
            IBlobListenerStrategy product = new ScanContainersStrategy();
            LambdaBlobTriggerExecutor executor = new LambdaBlobTriggerExecutor();
            product.Register(container, executor);
            product.Start();

            executor.ExecuteLambda = (_) =>
            {
                throw new InvalidOperationException("shouldn't be any blobs in the container");
            };
            product.Execute();

            const string expectedBlobName = "foo1.csv";
            var blob = container.GetBlockBlobReference(expectedBlobName);
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

        private static StorageAccount CreateFakeStorageAccount()
        {
            return new FakeStorageAccount();
        }

        private class LambdaBlobTriggerExecutor : ITriggerExecutor<BlobTriggerExecutorContext>
        {
            public Func<ICloudBlob, bool> ExecuteLambda { get; set; }

            public Task<FunctionResult> ExecuteAsync(BlobTriggerExecutorContext value, CancellationToken cancellationToken)
            {
                bool succeeded = ExecuteLambda.Invoke(value.Blob);
                FunctionResult result = new FunctionResult(succeeded);
                return Task.FromResult(result);
            }
        }
    }
}
