// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests
{
    public class MultipleStorageAccountsEndToEndTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private const string TestArtifactPrefix = "e2etestmultiaccount";
        private const string Input = TestArtifactPrefix + "-input-%rnd%";
        private const string Output = TestArtifactPrefix + "-output-%rnd%";
        private const string OutputTableName = TestArtifactPrefix + "tableinput%rnd%";
        private const string TestData = "TestData";
        private const string Secondary = "SecondaryStorage";
        private static TestFixture _fixture;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            Assert.IsNotEmpty(TestEnvironment.PrimaryStorageAccountConnectionString);
            Assert.IsNotEmpty(TestEnvironment.SecondaryStorageAccountConnectionString);
            _fixture = new TestFixture();
            await _fixture.InitializeAsync(TestEnvironment);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _fixture.DisposeAsync();
        }

        [Test]
        public async Task BlobToBlob_DifferentAccounts_PrimaryToSecondary_Succeeds()
        {
            BlockBlobClient resultBlob = null;

            await TestHelpers.Await(async () =>
            {
                var pageable = _fixture.OutputContainer2.GetBlobsAsync(
                    traits: BlobTraits.None,
                    states: BlobStates.None,
                    prefix: "blob1",
                    cancellationToken: CancellationToken.None);
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
            public async Task InitializeAsync(WebJobsTestEnvironment testEnvironment)
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

                BlobServiceClient1 = new BlobServiceClient(testEnvironment.PrimaryStorageAccountConnectionString);
                BlobServiceClient2 = new BlobServiceClient(testEnvironment.SecondaryStorageAccountConnectionString);
                var queueOptions = new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64 };
                QueueServiceClient1 = new QueueServiceClient(testEnvironment.PrimaryStorageAccountConnectionString, queueOptions);
                QueueServiceClient2 = new QueueServiceClient(testEnvironment.SecondaryStorageAccountConnectionString, queueOptions);

                await CleanContainersAsync();

                string inputName = nameResolver.ResolveInString(Input);
                var inputContainer1 = BlobServiceClient1.GetBlobContainerClient(inputName);
                await inputContainer1.CreateIfNotExistsAsync();
                string outputName = nameResolver.ResolveWholeString(Output);
                OutputContainer1 = BlobServiceClient1.GetBlobContainerClient(outputName);
                await OutputContainer1.CreateIfNotExistsAsync();

                var inputContainer2 = BlobServiceClient2.GetBlobContainerClient(inputName);
                await inputContainer2.CreateIfNotExistsAsync();
                OutputContainer2 = BlobServiceClient2.GetBlobContainerClient(outputName);
                await OutputContainer2.CreateIfNotExistsAsync();

                var inputQueue1 = QueueServiceClient1.GetQueueClient(inputName);
                await inputQueue1.CreateIfNotExistsAsync();
                OutputQueue1 = QueueServiceClient1.GetQueueClient(outputName);
                await OutputQueue1.CreateIfNotExistsAsync();

                var inputQueue2 = QueueServiceClient2.GetQueueClient(inputName);
                await inputQueue2.CreateIfNotExistsAsync();
                OutputQueue2 = QueueServiceClient2.GetQueueClient(outputName);
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

            public JobHost JobHost => Host.GetJobHost();

            public IHost Host
            {
                get;
                private set;
            }

            public BlobServiceClient BlobServiceClient1 { get; private set; }
            public BlobServiceClient BlobServiceClient2 { get; private set; }

            public QueueServiceClient QueueServiceClient1 { get; private set; }
            public QueueServiceClient QueueServiceClient2 { get; private set; }

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
                await Clean(BlobServiceClient1, QueueServiceClient1);
                await Clean(BlobServiceClient2, QueueServiceClient2);
            }
        }

        private static async Task Clean(BlobServiceClient blobClient, QueueServiceClient queueClient)
        {
            await foreach (var testContainer in blobClient.GetBlobContainersAsync(prefix: TestArtifactPrefix))
            {
                await blobClient.GetBlobContainerClient(testContainer.Name).DeleteAsync();
            }

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
