// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests
{
    /// <summary>
    /// Various E2E tests that use only the public surface and the real Azure storage
    /// </summary>
    public class AzureStorageEndToEndTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private const string TestArtifactsPrefix = "e2etest";
        private const string ContainerName = TestArtifactsPrefix + "container%rnd%";
        private const string BlobName = "testblob";

        private const string TableName = TestArtifactsPrefix + "table%rnd%";

        private const string HostStartQueueName = TestArtifactsPrefix + "startqueue%rnd%";
        private const string TestQueueName = TestArtifactsPrefix + "queue%rnd%";
        private const string TestQueueNameEtag = TestArtifactsPrefix + "etag2equeue%rnd%";
        private const string DoneQueueName = TestArtifactsPrefix + "donequeue%rnd%";

        private const string BadMessageQueue1 = TestArtifactsPrefix + "-badmessage1-%rnd%";
        private const string BadMessageQueue2 = TestArtifactsPrefix + "-badmessage2-%rnd%";

        private static int _badMessage1Calls;
        private static int _badMessage2Calls;

        private static EventWaitHandle _startWaitHandle;
        private static EventWaitHandle _functionChainWaitHandle;
        private QueueServiceClient _queueServiceClient;
        private BlobServiceClient _blobServiceClient;
        private RandomNameResolver _resolver;

        private static string _lastMessageId;
        private static string _lastMessagePopReceipt;

        private static AzureStorageEndToEndTests.TestFixture _fixture;

        [OneTimeSetUp]
        public void SetUp()
        {
            _fixture = new AzureStorageEndToEndTests.TestFixture(TestEnvironment);
            _queueServiceClient = _fixture.QueueServiceClient;
            _blobServiceClient = _fixture.BlobServiceClient;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _fixture.Dispose();
        }

        /// <summary>
        /// Used to syncronize the application start and blob creation
        /// </summary>
        public static void NotifyStart(
            [QueueTrigger(HostStartQueueName)] string input)
        {
            _startWaitHandle.Set();
        }

        /// <summary>
        /// Covers:
        /// - blob binding to custom object
        /// - blob trigger
        /// - queue writing
        /// - blob name pattern binding
        /// </summary>
        public static void BlobToQueue(
            [BlobTrigger(ContainerName + @"/{name}")] string input,
            string name,
            [Queue(TestQueueNameEtag)] out CustomObject output)
        {
            // TODO: Use CustomObject as param when POCO blob supported:
            //       https://github.com/Azure/azure-webjobs-sdk/issues/995
            var inputObject = JsonConvert.DeserializeObject<CustomObject>(input);

            CustomObject result = new CustomObject()
            {
                Text = inputObject.Text + " " + name,
                Number = inputObject.Number + 1
            };

            output = result;
        }

        /// <summary>
        /// Covers:
        /// - queue binding to custom object
        /// - queue trigger
        /// - table writing
        /// </summary>
        public static void QueueToICollectorAndQueue(
            [QueueTrigger(TestQueueNameEtag)] CustomObject e2equeue,
            [Queue(TestQueueName)] out CustomObject output)
        {
            output = e2equeue;
        }

        /// <summary>
        /// Covers:
        /// - queue binding to custom object
        /// - queue trigger
        /// - table writing
        /// </summary>
        public static void QueueToTable(
            [QueueTrigger(TestQueueName)] CustomObject e2equeue,
            [Queue(DoneQueueName)] out string e2edone)
        {
            // Write a queue message to signal the scenario completion
            e2edone = "done";
        }

        /// <summary>
        /// Notifies the completion of the scenario
        /// </summary>
        public static void NotifyCompletion(
            [QueueTrigger(DoneQueueName)] string e2edone)
        {
            _functionChainWaitHandle.Set();
        }

        /// <summary>
        /// We'll insert a bad message. It should get here okay. It will
        /// then pass it on to the next trigger.
        /// </summary>
        public static void BadMessage_CloudQueueMessage(
            [QueueTrigger(BadMessageQueue1)] QueueMessage badMessageIn,
            [Queue(BadMessageQueue2)] out string badMessageOut,
#pragma warning disable CS0618 // Type or member is obsolete
            TraceWriter log)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            _badMessage1Calls++;
            badMessageOut = badMessageIn.MessageText;
        }

        public static void BadMessage_String(
            [QueueTrigger(BadMessageQueue2)] string message,
#pragma warning disable CS0618 // Type or member is obsolete
            TraceWriter log)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            _badMessage2Calls++;
        }

        // Uncomment the Fact attribute to run
        // [Fact(Timeout = 20 * 60 * 1000)]
        public async Task AzureStorageEndToEndSlow()
        {
            await EndToEndTest(uploadBlobBeforeHostStart: false);
        }

        [Test]
        public async Task AzureStorageEndToEndFast()
        {
            await EndToEndTest(uploadBlobBeforeHostStart: true);
        }

        private async Task EndToEndTest(bool uploadBlobBeforeHostStart)
        {
            // Reinitialize the name resolver to avoid conflicts
            _resolver = new RandomNameResolver();

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<AzureStorageEndToEndTests>(b =>
                {
                    b.AddAzureStorageBlobs().AddAzureStorageQueues();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INameResolver>(_resolver);
                })
                .Build();

            if (uploadBlobBeforeHostStart)
            {
                // The function will be triggered fast because the blob is already there
                await UploadTestObject();
            }

            // The jobs host is started
            JobHost jobHost = host.GetJobHost();

            _functionChainWaitHandle = new ManualResetEvent(initialState: false);

            await host.StartAsync();

            if (!uploadBlobBeforeHostStart)
            {
                await WaitForTestFunctionsToStart();
                await UploadTestObject();
            }

            var waitTime = TimeSpan.FromSeconds(15);
            bool signaled = _functionChainWaitHandle.WaitOne(waitTime);

            // Stop the host and wait for it to finish
            await host.StopAsync();

            Assert.True(signaled, $"[{DateTime.UtcNow.ToString("HH:mm:ss.fff")}] Function chain did not complete in {waitTime}. Logs:{Environment.NewLine}{host.GetTestLoggerProvider().GetLogString()}");
        }

        [Test]
        [Ignore("TODO (kasobol-msft) revisit this test when base64/BinaryData is supported in SDK")]
        public async Task BadQueueMessageE2ETests()
        {
            // This test ensures that the host does not crash on a bad message (it previously did)
            // Insert a bad message into a queue that should:
            // - trigger BadMessage_CloudQueueMessage, which will put it into a second queue that will
            // - trigger BadMessage_String, which should fail
            // - BadMessage_String should fail repeatedly until it is moved to the poison queue
            // The test will watch that poison queue to know when to complete

            // Reinitialize the name resolver to avoid conflicts
            _resolver = new RandomNameResolver();
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<AzureStorageEndToEndTests>(b =>
                {
                    b.AddAzureStorageBlobs().AddAzureStorageQueues();
                })
                .ConfigureServices(services =>
                {
                    // use a custom processor so we can grab the Id and PopReceipt
                    services.AddSingleton<IQueueProcessorFactory>(new TestQueueProcessorFactory());
                    services.AddSingleton<INameResolver>(_resolver);
                })
                .Build();

            TestLoggerProvider loggerProvider = host.GetTestLoggerProvider();

            // The jobs host is started
            host.Start();

            // Construct a bad message:
            // - use a GUID as the content, which is not a valid base64 string
            // - pass 'true', to indicate that it is a base64 string
            string messageContent = Guid.NewGuid().ToString();
            // var message = new CloudQueueMessage(messageContent, true); // TODO (kasobol-msft) check this base64 thing

            var queue = _queueServiceClient.GetQueueClient(_resolver.ResolveInString(BadMessageQueue1));
            await queue.CreateIfNotExistsAsync();
            await queue.ClearMessagesAsync();

            // the poison queue will end up off of the second queue
            var poisonQueue = _queueServiceClient.GetQueueClient(_resolver.ResolveInString(BadMessageQueue2) + "-poison");
            await poisonQueue.DeleteIfExistsAsync();

            await queue.SendMessageAsync(messageContent);

            QueueMessage poisonMessage = null;
            await TestHelpers.Await(async () =>
            {
                bool done = false;
                if (await poisonQueue.ExistsAsync())
                {
                    poisonMessage = (await poisonQueue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                    done = poisonMessage != null;

                    if (done)
                    {
                        // Sleep briefly, then make sure the other message has been deleted.
                        // If so, trying to delete it again will throw an error.
                        Thread.Sleep(1000);

                        // The message is in the second queue
                        var queue2 = _queueServiceClient.GetQueueClient(_resolver.ResolveInString(BadMessageQueue2));

                        RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                            () => queue2.DeleteMessageAsync(_lastMessageId, _lastMessagePopReceipt));
                        Assert.AreEqual("MessageNotFound", ex.ErrorCode);
                    }
                }
                var logs = loggerProvider.GetAllLogMessages();
                return done;
            });

            await host.StopAsync();

            // find the raw string to compare it to the original
            Assert.NotNull(poisonMessage);
            Assert.AreEqual(messageContent, poisonMessage.MessageText);

            // Make sure the functions were called correctly
            Assert.AreEqual(1, _badMessage1Calls);
            Assert.AreEqual(0, _badMessage2Calls);

            // Validate Logger
            var loggerErrors = loggerProvider.GetAllLogMessages().Where(l => l.Level == Microsoft.Extensions.Logging.LogLevel.Error);
            Assert.True(loggerErrors.All(t => t.Exception.InnerException.InnerException is FormatException));
        }

        private async Task UploadTestObject()
        {
            string testContainerName = _resolver.ResolveInString(ContainerName);

            var container = _blobServiceClient.GetBlobContainerClient(testContainerName);
            await container.CreateIfNotExistsAsync();

            // The test blob
            var testBlob = container.GetBlockBlobClient(BlobName);
            CustomObject testObject = new CustomObject()
            {
                Text = "Test",
                Number = 42
            };

            await testBlob.UploadTextAsync(JsonConvert.SerializeObject(testObject));
        }

        private async Task WaitForTestFunctionsToStart()
        {
            _startWaitHandle = new ManualResetEvent(initialState: false);

            string startQueueName = _resolver.ResolveInString(HostStartQueueName);

            QueueClient queue = _queueServiceClient.GetQueueClient(startQueueName);
            await queue.CreateIfNotExistsAsync();
            await queue.SendMessageAsync(string.Empty);

            _startWaitHandle.WaitOne(30000);
        }

        private class TestQueueProcessorFactory : IQueueProcessorFactory
        {
            public QueueProcessor Create(QueueProcessorOptions context)
            {
                return new TestQueueProcessor(context);
            }
        }

        private class TestQueueProcessor : QueueProcessor
        {
            public TestQueueProcessor(QueueProcessorOptions context)
                : base(context)
            {
            }

            protected override Task<bool> BeginProcessingMessageAsync(QueueMessage message, CancellationToken cancellationToken)
            {
                _lastMessageId = message.MessageId;
                _lastMessagePopReceipt = message.PopReceipt;

                return base.BeginProcessingMessageAsync(message, cancellationToken);
            }
        }

        public class TestFixture : IDisposable
        {
            public TestFixture(WebJobsTestEnvironment testEnvironment)
            {
                IHost host = new HostBuilder()
                    .ConfigureDefaultTestHost<TestFixture>(b =>
                    {
                        b.AddAzureStorageBlobs().AddAzureStorageQueues();
                    })
                    .Build();

                var queueOptions = new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64 };
                this.QueueServiceClient = new QueueServiceClient(testEnvironment.PrimaryStorageAccountConnectionString, queueOptions);
                this.BlobServiceClient = new BlobServiceClient(testEnvironment.PrimaryStorageAccountConnectionString);
            }

            public QueueServiceClient QueueServiceClient
            {
                get;
                private set;
            }

            public BlobServiceClient BlobServiceClient
            {
                get;
                private set;
            }

            public void Dispose()
            {
                foreach (var testContainer in BlobServiceClient.GetBlobContainers(prefix: TestArtifactsPrefix))
                {
                    this.BlobServiceClient.GetBlobContainerClient(testContainer.Name).Delete();
                }

                foreach (var testQueue in this.QueueServiceClient.GetQueues(prefix: TestArtifactsPrefix))
                {
                    this.QueueServiceClient.GetQueueClient(testQueue.Name).Delete();
                }
            }
        }
    }
}
