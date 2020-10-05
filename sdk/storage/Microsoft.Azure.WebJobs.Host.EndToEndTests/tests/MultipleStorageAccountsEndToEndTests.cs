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
using Newtonsoft.Json.Linq;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class MultipleStorageAccountsEndToEndTests
    {
        private const string TestArtifactPrefix = "e2etestmultiaccount";
        private const string Input = TestArtifactPrefix + "-input-%rnd%";
        private const string Output = TestArtifactPrefix + "-output-%rnd%";
        private const string InputTableName = TestArtifactPrefix + "tableinput%rnd%";
        private const string OutputTableName = TestArtifactPrefix + "tableinput%rnd%";
        private const string TestData = "TestData";
        private const string Secondary = "SecondaryStorage";
        private static TestFixture _fixture;


        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _fixture = new TestFixture();
            await _fixture.InitializeAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _fixture.DisposeAsync();
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task BlobToBlob_DifferentAccounts_PrimaryToSecondary_Succeeds()
        {
            BlockBlobClient resultBlob = null;

            await TestHelpers.Await(async () =>
            {
                var pageable = _fixture.OutputContainer2.GetBlobsAsync(prefix: "blob1");
                var enumerator = pageable.GetAsyncEnumerator();
                var result = await enumerator.MoveNextAsync() && enumerator.Current.Properties.ContentLength > 0;
                if (result)
                {
                    resultBlob = _fixture.OutputContainer2.GetBlockBlobClient(enumerator.Current.Name);
                }
                return result;
            });

            string data = await resultBlob.DownloadTextAsync();
            Assert.AreEqual("blob1", resultBlob.Name);
            Assert.AreEqual(TestData, data);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task BlobToBlob_DifferentAccounts_SecondaryToPrimary_Succeeds()
        {
            BlockBlobClient resultBlob = null;

            await TestHelpers.Await(async () =>
            {
                var pageable = _fixture.OutputContainer1.GetBlobsAsync();
                var enumerator = pageable.GetAsyncEnumerator();
                var result = await enumerator.MoveNextAsync() && enumerator.Current.Properties.ContentLength > 0;
                if (result)
                {
                    resultBlob = _fixture.OutputContainer1.GetBlockBlobClient(enumerator.Current.Name);
                }
                return result;
            });

            string data = await resultBlob.DownloadTextAsync();
            Assert.AreEqual("blob2", resultBlob.Name);
            Assert.AreEqual(TestData, data);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task QueueToQueue_DifferentAccounts_PrimaryToSecondary_Succeeds()
        {
            QueueMessage resultMessage = null;

            await TestHelpers.Await(async () =>
            {
                resultMessage = (await _fixture.OutputQueue2.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                return resultMessage != null;
            });

            Assert.AreEqual(TestData, resultMessage.MessageText);
        }

        [WebJobsLiveOnly]
        [TestCase("QueueToBlob_DifferentAccounts_PrimaryToSecondary_NameResolver")]
        [TestCase("QueueToBlob_DifferentAccounts_PrimaryToSecondary_FullSettingName")]
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

            var blobReference = _fixture.OutputContainer2.GetBlobClient(name);
            await TestHelpers.Await(async () => (await blobReference.ExistsAsync()).Value);

            string data;
            using (var memoryStream = new MemoryStream())
            {
                await blobReference.DownloadToAsync(memoryStream);
                memoryStream.Position = 0;
                using (var reader = new StreamReader(memoryStream))
                {
                    data = reader.ReadToEnd();
                }
            }
            Assert.AreEqual(TestData, data);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task QueueToQueue_DifferentAccounts_SecondaryToPrimary_Succeeds()
        {
            QueueMessage resultMessage = null;

            await TestHelpers.Await(async () =>
            {
                resultMessage = (await _fixture.OutputQueue1.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                return resultMessage != null;
            });

            Assert.AreEqual(TestData, resultMessage.MessageText);
        }

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

        public class TestFixture
        {
            public async Task InitializeAsync()
            {
                // TODO (kasobol-msft) find better way
                string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    RandomNameResolver nameResolver = new TestNameResolver();

                    Host = new HostBuilder()
                        .ConfigureDefaultTestHost<MultipleStorageAccountsEndToEndTests>(b =>
                        {
                            b.AddAzureStorageBlobs().AddAzureStorageQueues();
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

                    var blobClient1 = Account1.CreateBlobServiceClient();
                    string inputName = nameResolver.ResolveInString(Input);
                    var inputContainer1 = blobClient1.GetBlobContainerClient(inputName);
                    await inputContainer1.CreateIfNotExistsAsync();
                    string outputName = nameResolver.ResolveWholeString(Output);
                    OutputContainer1 = blobClient1.GetBlobContainerClient(outputName);
                    await OutputContainer1.CreateIfNotExistsAsync();

                    var blobClient2 = Account2.CreateBlobServiceClient();
                    var inputContainer2 = blobClient2.GetBlobContainerClient(inputName);
                    await inputContainer2.CreateIfNotExistsAsync();
                    OutputContainer2 = blobClient2.GetBlobContainerClient(outputName);
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
                    BlockBlobClient blob = inputContainer1.GetBlockBlobClient("blob1");
                    await blob.UploadTextAsync(TestData);
                    blob = inputContainer2.GetBlockBlobClient("blob2");
                    await blob.UploadTextAsync(TestData);

                    // upload some test queue messages to the input queues of both storage accounts
                    await inputQueue1.SendMessageAsync(TestData);
                    await inputQueue2.SendMessageAsync(TestData);

                    Host.Start();
                }
            }

            public JobHost JobHost => Host.GetJobHost();

            public IHost Host
            {
                get;
                private set;
            }

            public StorageAccount Account1 { get; private set; }
            public StorageAccount Account2 { get; private set; }

            public BlobContainerClient OutputContainer1 { get; private set; }

            public BlobContainerClient OutputContainer2 { get; private set; }

            public QueueClient OutputQueue1 { get; private set; }

            public QueueClient OutputQueue2 { get; private set; }

            public async Task DisposeAsync()
            {
                if (Host != null)
                {
                    await Host.StopAsync();

                    await CleanContainersAsync();
                }
            }

            private async Task CleanContainersAsync()
            {
                await Clean(Account1);
                await Clean(Account2);
            }
        }

        private static async Task Clean(StorageAccount account)
        {
            var blobClient = account.CreateBlobServiceClient();
            await foreach (var testContainer in blobClient.GetBlobContainersAsync(prefix: TestArtifactPrefix))
            {
                await blobClient.GetBlobContainerClient(testContainer.Name).DeleteAsync();
            }

            var queueClient = account.CreateQueueServiceClient();
            await foreach (var queue in queueClient.GetQueuesAsync(prefix: TestArtifactPrefix))
            {
                await queueClient.GetQueueClient(queue.Name).DeleteAsync();
            }
        }

        public class Message
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
