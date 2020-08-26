// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json.Linq;
using Xunit;
using CloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class MultipleStorageAccountsEndToEndTests : IClassFixture<MultipleStorageAccountsEndToEndTests.TestFixture>
    {
        private const string TestArtifactPrefix = "e2etestmultiaccount";
        private const string Input = TestArtifactPrefix + "-input-%rnd%";
        private const string Output = TestArtifactPrefix + "-output-%rnd%";
        private const string InputTableName = TestArtifactPrefix + "tableinput%rnd%";
        private const string OutputTableName = TestArtifactPrefix + "tableinput%rnd%";
        private const string TestData = "TestData";
        private const string Secondary = "SecondaryStorage";
        private static CloudStorageAccount primaryAccountResult;
        private static CloudStorageAccount secondaryAccountResult;
        private readonly TestFixture _fixture;

        public MultipleStorageAccountsEndToEndTests(TestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task BlobToBlob_DifferentAccounts_PrimaryToSecondary_Succeeds()
        {
            CloudBlockBlob resultBlob = null;

            await TestHelpers.Await(async () =>
            {
                resultBlob = (CloudBlockBlob)(await _fixture.OutputContainer2.ListBlobsSegmentedAsync("blob1", null)).Results.SingleOrDefault();
                return resultBlob != null;
            });

            string data = await resultBlob.DownloadTextAsync();
            Assert.Equal("blob1", resultBlob.Name);
            Assert.Equal(TestData, data);
        }

        [Fact]
        public async Task BlobToBlob_DifferentAccounts_SecondaryToPrimary_Succeeds()
        {
            CloudBlockBlob resultBlob = null;

            await TestHelpers.Await(async () =>
            {
                resultBlob = (CloudBlockBlob)(await _fixture.OutputContainer1.ListBlobsSegmentedAsync(null)).Results.SingleOrDefault();
                return resultBlob != null;
            });

            string data = await resultBlob.DownloadTextAsync();
            Assert.Equal("blob2", resultBlob.Name);
            Assert.Equal(TestData, data);
        }

        [Fact]
        public async Task QueueToQueue_DifferentAccounts_PrimaryToSecondary_Succeeds()
        {
            QueueMessage resultMessage = null;

            await TestHelpers.Await(async () =>
            {
                resultMessage = (await _fixture.OutputQueue2.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                return resultMessage != null;
            });

            Assert.Equal(TestData, resultMessage.MessageText);
        }

        [Theory]
        [InlineData("QueueToBlob_DifferentAccounts_PrimaryToSecondary_NameResolver")]
        [InlineData("QueueToBlob_DifferentAccounts_PrimaryToSecondary_FullSettingName")]
        public async Task QueueToBlob_DifferentAccounts_PrimaryToSecondary_NameResolver_Succeeds(string methodName)
        {
            var method = typeof(MultipleStorageAccountsEndToEndTests).GetMethod(methodName);
            string name = Guid.NewGuid().ToString();
            JObject jObject = new JObject
            {
                { "Name", name },
                { "Value", TestData }
            };
            await _fixture.JobHost.CallAsync(method, new { input = jObject.ToString() });

            var blobReference = await _fixture.OutputContainer2.GetBlobReferenceFromServerAsync(name);
            await TestHelpers.Await(() => blobReference.ExistsAsync());

            string data;
            using (var memoryStream = new MemoryStream())
            {
                await blobReference.DownloadToStreamAsync(memoryStream);
                memoryStream.Position = 0;
                using (var reader = new StreamReader(memoryStream))
                {
                    data = reader.ReadToEnd();
                }
            }
            Assert.Equal(TestData, data);
        }

        [Fact]
        public async Task QueueToQueue_DifferentAccounts_SecondaryToPrimary_Succeeds()
        {
            QueueMessage resultMessage = null;

            await TestHelpers.Await(async () =>
            {
                resultMessage = (await _fixture.OutputQueue1.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                return resultMessage != null;
            });

            Assert.Equal(TestData, resultMessage.MessageText);
        }

        [Fact]
        public async Task CloudStorageAccount_PrimaryAndSecondary_Succeeds()
        {
            await _fixture.JobHost.CallAsync(typeof(MultipleStorageAccountsEndToEndTests).GetMethod(nameof(MultipleStorageAccountsEndToEndTests.BindToCloudStorageAccount)));

            Assert.Equal(_fixture.Account1.SdkObject.Credentials.AccountName, primaryAccountResult.Credentials.AccountName);
            Assert.Equal(_fixture.Account2.SdkObject.Credentials.AccountName, secondaryAccountResult.Credentials.AccountName);
        }

#pragma warning disable xUnit1013 // Public method should be marked as test
        public static void BlobToBlob_DifferentAccounts_PrimaryToSecondary(
            [BlobTrigger(Input + "/{name}")] string input,
            [Blob(Output + "/{name}", Connection = Secondary)] out string output)
        {
            output = input;
        }

        public static void BlobToBlob_DifferentAccounts_SecondaryToPrimary(
            [BlobTrigger(Input + "/{name}", Connection = Secondary)] string input,
            [Blob(Output + "/{name}")] out string output)
        {
            output = input;
        }


        public static void QueueToQueue_DifferentAccounts_PrimaryToSecondary(
            [QueueTrigger(Input)] string input,
            [Queue(Output, Connection = Secondary)] out string output)
        {
            output = input;
        }

        [NoAutomaticTrigger]
        public static void QueueToBlob_DifferentAccounts_PrimaryToSecondary_NameResolver(
            [QueueTrigger("test")] Message input,
            [Blob(Output + "/{Name}", Connection = "%test_account%")] out string output)
        {
            output = input.Value;
        }

        [NoAutomaticTrigger]
        public static void QueueToBlob_DifferentAccounts_PrimaryToSecondary_FullSettingName(
            [QueueTrigger("test")] Message input,
            [Blob(Output + "/{Name}", Connection = "AzureWebJobsSecondaryStorage")] out string output)
        {
            output = input.Value;
        }

        public static void QueueToQueue_DifferentAccounts_SecondaryToPrimary(
            [QueueTrigger(Input, Connection = Secondary)] string input,
            [Queue(Output)] out string output)
        {
            output = input;
        }

        [NoAutomaticTrigger]
        public static void BindToCloudStorageAccount(
            CloudStorageAccount primary,
            [StorageAccount(Secondary)] CloudStorageAccount secondary)
        {
            primaryAccountResult = primary;
            secondaryAccountResult = secondary;
        }

#pragma warning restore xUnit1013 // Public method should be marked as test

        private class TestNameResolver : RandomNameResolver
        {
            public override string Resolve(string name)
            {
                if (name == "test_account")
                {
                    return "SecondaryStorage";
                }
                return base.Resolve(name);
            }
        }

        public class TestFixture : IAsyncLifetime
        {
            public async Task InitializeAsync()
            {
                RandomNameResolver nameResolver = new TestNameResolver();

                Host = new HostBuilder()
                    .ConfigureDefaultTestHost<MultipleStorageAccountsEndToEndTests>(b =>
                    {
                        b.AddAzureStorage();
                    })
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton<INameResolver>(nameResolver);
                    })
                    .Build();

                Account1 = Host.GetStorageAccount();
                var config = Host.Services.GetService<IConfiguration>();
                string secondaryConnectionString = config[$"AzureWebJobs{Secondary}"];
                Account2 = StorageAccount.NewFromConnectionString(secondaryConnectionString);

                await CleanContainersAsync();

                CloudBlobClient blobClient1 = Account1.CreateCloudBlobClient();
                string inputName = nameResolver.ResolveInString(Input);
                CloudBlobContainer inputContainer1 = blobClient1.GetContainerReference(inputName);
                await inputContainer1.CreateIfNotExistsAsync();
                string outputName = nameResolver.ResolveWholeString(Output);
                OutputContainer1 = blobClient1.GetContainerReference(outputName);
                await OutputContainer1.CreateIfNotExistsAsync();

                CloudBlobClient blobClient2 = Account2.CreateCloudBlobClient();
                CloudBlobContainer inputContainer2 = blobClient2.GetContainerReference(inputName);
                await inputContainer2.CreateIfNotExistsAsync();
                OutputContainer2 = blobClient2.GetContainerReference(outputName);
                await OutputContainer2.CreateIfNotExistsAsync();

                var queueClient1 = Account1.CreateQueueServiceClient();
                var inputQueue1 = queueClient1.GetQueueClient(inputName);
                await inputQueue1.CreateIfNotExistsAsync();
                OutputQueue1 = queueClient1.GetQueueClient(outputName);
                await OutputQueue1.CreateIfNotExistsAsync();

                var queueClient2 = Account2.CreateQueueServiceClient();
                var inputQueue2 = queueClient2.GetQueueClient(inputName);
                await inputQueue2.CreateIfNotExistsAsync();
                OutputQueue2 = queueClient2.GetQueueClient(outputName);
                await OutputQueue2.CreateIfNotExistsAsync();

                string outputTableName = nameResolver.ResolveWholeString(OutputTableName);

                // upload some test blobs to the input containers of both storage accounts
                CloudBlockBlob blob = inputContainer1.GetBlockBlobReference("blob1");
                await blob.UploadTextAsync(TestData);
                blob = inputContainer2.GetBlockBlobReference("blob2");
                await blob.UploadTextAsync(TestData);

                // upload some test queue messages to the input queues of both storage accounts
                await inputQueue1.SendMessageAsync(TestData);
                await inputQueue2.SendMessageAsync(TestData);

                Host.Start();
            }

            public JobHost JobHost => Host.GetJobHost();

            public IHost Host
            {
                get;
                private set;
            }

            public StorageAccount Account1 { get; private set; }
            public StorageAccount Account2 { get; private set; }

            public CloudBlobContainer OutputContainer1 { get; private set; }

            public CloudBlobContainer OutputContainer2 { get; private set; }

            public QueueClient OutputQueue1 { get; private set; }

            public QueueClient OutputQueue2 { get; private set; }

            public async Task DisposeAsync()
            {
                await Host.StopAsync();

                await CleanContainersAsync();
            }

            private async Task CleanContainersAsync()
            {
                await Clean(Account1);
                await Clean(Account2);
            }
        }

        private static async Task Clean(StorageAccount account)
        {
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            foreach (var testContainer in (await blobClient.ListContainersSegmentedAsync(TestArtifactPrefix, null)).Results)
            {
                await testContainer.DeleteAsync();
            }

            var queueClient = account.CreateQueueServiceClient();
            await foreach (var queue in queueClient.GetQueuesAsync(prefix: TestArtifactPrefix))
            {
                await queueClient.GetQueueClient(queue.Name).DeleteAsync();
            }
        }

        public class TestTableEntity
        {
            public string Text { get; set; }
        }

        public class Message
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
