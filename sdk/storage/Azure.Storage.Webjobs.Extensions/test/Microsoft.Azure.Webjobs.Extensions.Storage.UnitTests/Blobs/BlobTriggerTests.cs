// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Blob;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class BlobTriggerTests
    {
        private const string ContainerName = "container";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;

        [Fact]
        public async Task BlobTrigger_IfBoundToCloudBlob_Binds()
        {
            // Arrange
            var account = CreateFakeStorageAccount();
            var container = CreateContainer(account, ContainerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(BlobName);

            await blob.UploadTextAsync("ignore");

            // Act
            ICloudBlob result = await RunTriggerAsync<ICloudBlob>(account, typeof(BindToCloudBlobProgram),
                (s) => BindToCloudBlobProgram.TaskSource = s);

            // Assert
            Assert.Equal(blob.Uri, result.Uri);
        }

        private class BindToCloudBlobProgram
        {
            public static TaskCompletionSource<ICloudBlob> TaskSource { get; set; }

            public static void Run([BlobTrigger(BlobPath)] ICloudBlob blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Fact]
        public async Task BlobTrigger_Binding_Metadata()
        {
            var app = new BindToCloudBlob2Program();
            var activator = new FakeActivator(app);
            var account = CreateFakeStorageAccount();
            var provider = new FakeStorageAccountProvider(account);
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToCloudBlob2Program>(b =>
                {
                    b.AddAzureStorage();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IJobActivator>(activator);
                    services.AddSingleton<StorageAccountProvider>(provider);
                })
                .Build();

            // Set the binding data, and verify it's accessible in the function. 
            var container = CreateContainer(account, ContainerName);
            var blob = container.GetBlockBlobReference(BlobName);
            blob.Metadata["m1"] = "v1";

            await host.GetJobHost().CallAsync(typeof(BindToCloudBlob2Program).GetMethod(nameof(BindToCloudBlob2Program.Run)), new { blob });

            Assert.True(app.Success);
        }

        private class BindToCloudBlob2Program
        {
            public bool Success;
            public void Run(
                [BlobTrigger(BlobPath)] ICloudBlob blob,
                [Blob("container/{metadata.m1}")] ICloudBlob blob1
                )
            {
                Assert.Equal("v1", blob1.Name);
                this.Success = true;
            }
        }

        private static CloudBlobContainer CreateContainer(StorageAccount account, string containerName)
        {
            var client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(containerName);
            container.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            return container;
        }

        private static StorageAccount CreateFakeStorageAccount()
        {
            var account = new FakeStorageAccount();

            // make sure our system containers are present
            var container = CreateContainer(account, "azure-webjobs-hosts");

            return account;
        }

        private static async Task<TResult> RunTriggerAsync<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(account, programType, setTaskSource);
        }

        private static async Task<TResult> RunTriggerAsync<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource, IEnumerable<string> ignoreFailureFunctions)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(account, programType, setTaskSource, ignoreFailureFunctions);
        }
    }
}
