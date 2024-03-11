// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Storage.Tests.Shared;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        private const string DynamicConcurrencyQueueName = TestArtifactsPrefix + "queue%rnd%";
        private const string DynamicConcurrencyBlobContainerName = TestArtifactsPrefix + "blob%rnd%";
        private const string TestQueueName = TestArtifactsPrefix + "queue%rnd%";
        private const string QueueName = "testqueue";
        private const string TestQueueNameEtag = TestArtifactsPrefix + "etag2equeue%rnd%";
        private const string DoneQueueName = TestArtifactsPrefix + "donequeue%rnd%";

        private const string BadMessageQueue = TestArtifactsPrefix + "-badmessage-%rnd%";

        private static int _badMessageCalls;

        private static EventWaitHandle _startWaitHandle;
        private static EventWaitHandle _functionChainWaitHandle;
        private static EventWaitHandle _waitHandle;
        private QueueServiceClient _queueServiceClient;
        private QueueServiceClient _queueServiceClientWithoutEncoding;
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
            _queueServiceClientWithoutEncoding = _fixture.QueueServiceClientWithoutEncoding;
            _blobServiceClient = _fixture.BlobServiceClient;
            _waitHandle = new ManualResetEvent(initialState: false);
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

        public static void BadMessage_String(
            [QueueTrigger(BadMessageQueue)] string message,
#pragma warning disable CS0618 // Type or member is obsolete
            TraceWriter log)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            _badMessageCalls++;
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

        [Test]
        [Category("DynamicConcurrency")]
        public async Task AzureStorageEndToEnd_DynamicConcurrency()
        {
            await EndToEndTest(uploadBlobBeforeHostStart: true, b =>
            {
                b.Services.AddOptions<ConcurrencyOptions>().Configure(options =>
                {
                    options.DynamicConcurrencyEnabled = true;
                });
            });
        }

        [Test]
        [Category("DynamicConcurrency")]
        [RetryOnException(5, typeof(OperationCanceledException))]
        public async Task DynamicConcurrency_Queues()
        {
            // Reinitialize the name resolver to avoid conflicts
            _resolver = new RandomNameResolver();
            DynamicConcurrencyTestJob.InvocationCount = 0;

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<DynamicConcurrencyTestJob>(b =>
                {
                    b.AddAzureStorageQueues();

                    b.Services.AddOptions<ConcurrencyOptions>().Configure(options =>
                    {
                        options.DynamicConcurrencyEnabled = true;
                    });
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INameResolver>(_resolver);
                })
                .ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();

            MethodInfo methodInfo = typeof(DynamicConcurrencyTestJob).GetMethod("ProcessMessage", BindingFlags.Public | BindingFlags.Static);
            string functionId = $"{methodInfo.DeclaringType.FullName}.{methodInfo.Name}";
            var concurrencyManager = host.Services.GetServices<ConcurrencyManager>().SingleOrDefault();
            var concurrencyStatus = concurrencyManager.GetStatus(functionId);
            Assert.AreEqual(1, concurrencyStatus.CurrentConcurrency);

            // write a bunch of queue messages
            int numMessages = 300;
            string queueName = _resolver.ResolveInString(DynamicConcurrencyQueueName);
            await WriteQueueMessages(queueName, numMessages);

            // start the host
            await host.StartAsync();

            // wait for all messages to be processed
            await TestHelpers.Await(() =>
            {
                return DynamicConcurrencyTestJob.InvocationCount >= numMessages;
            });

            await host.StopAsync();

            // ensure we've dynamically increased concurrency
            concurrencyStatus = concurrencyManager.GetStatus(functionId);
            Assert.GreaterOrEqual(concurrencyStatus.CurrentConcurrency, 5);

            // check a few of the concurrency logs
            var concurrencyLogs = host.GetTestLoggerProvider().GetAllLogMessages().Where(p => p.Category == LogCategories.Concurrency).Select(p => p.FormattedMessage).ToList();
            int concurrencyIncreaseLogCount = concurrencyLogs.Count(p => p.Contains("ProcessMessage Increasing concurrency"));
            Assert.GreaterOrEqual(concurrencyIncreaseLogCount, 3);
        }

        [Test]
        [Category("DynamicConcurrency")]
        public async Task DynamicConcurrency_Blobs()
        {
            // Reinitialize the name resolver to avoid conflicts
            _resolver = new RandomNameResolver();
            DynamicConcurrencyTestJob.InvocationCount = 0;

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<DynamicConcurrencyTestJob>(b =>
                {
                    b.AddAzureStorageBlobs();

                    b.Services.AddOptions<ConcurrencyOptions>().Configure(options =>
                    {
                        options.DynamicConcurrencyEnabled = true;
                    });

                    b.Services.AddOptions<QueuesOptions>().Configure(options =>
                    {
                        options.MaxPollingInterval = TimeSpan.FromSeconds(1);
                    });
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INameResolver>(_resolver);
                })
                .ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();

            string sharedListenerId = "SharedBlobQueueListener";
            var concurrencyManager = host.Services.GetServices<ConcurrencyManager>().SingleOrDefault();
            var concurrencyStatus = concurrencyManager.GetStatus(sharedListenerId);
            Assert.AreEqual(1, concurrencyStatus.CurrentConcurrency);

            // write some blobs
            int numBlobs = 50;
            string blobContainerName = _resolver.ResolveInString(DynamicConcurrencyBlobContainerName);
            await WriteBlobs(blobContainerName, numBlobs);

            // start the host
            await host.StartAsync();

            // wait for all messages to be processed
            await TestHelpers.Await(() =>
            {
                return DynamicConcurrencyTestJob.InvocationCount >= numBlobs;
            });

            await host.StopAsync();

            // ensure we've dynamically increased concurrency
            concurrencyStatus = concurrencyManager.GetStatus("SharedBlobQueueListener");
            Assert.GreaterOrEqual(concurrencyStatus.CurrentConcurrency, 2);

            // check a few of the concurrency logs
            var concurrencyLogs = host.GetTestLoggerProvider().GetAllLogMessages().Where(p => p.Category == LogCategories.Concurrency).Select(p => p.FormattedMessage).ToList();
            int concurrencyIncreaseLogCount = concurrencyLogs.Count(p => p.Contains($"{sharedListenerId} Increasing concurrency"));
            Assert.GreaterOrEqual(concurrencyIncreaseLogCount, 1);
        }

        private async Task EndToEndTest(bool uploadBlobBeforeHostStart, Action<IWebJobsBuilder> additionalSetup = null)
        {
            // Reinitialize the name resolver to avoid conflicts
            _resolver = new RandomNameResolver();

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<AzureStorageEndToEndTests>(b =>
                {
                    b.AddAzureStorageBlobs().AddAzureStorageQueues();

                    additionalSetup?.Invoke(b);
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

            var waitTime = TimeSpan.FromSeconds(30);
            bool signaled = _functionChainWaitHandle.WaitOne(waitTime);

            // Stop the host and wait for it to finish
            await host.StopAsync();

            Assert.True(signaled, $"[{DateTime.UtcNow.ToString("HH:mm:ss.fff")}] Function chain did not complete in {waitTime}. Logs:{Environment.NewLine}{host.GetTestLoggerProvider().GetLogString()}");
        }

        [Test]
        public async Task BadQueueMessageE2ETests()
        {
            // This test ensures that the host does not crash on a bad message (it previously did)
            // Insert a bad message into a queue that should:
            // - trigger BadMessage_String, which should fail
            // - BadMessage_String should be transfered to poison queue.
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

            var queue = _queueServiceClientWithoutEncoding.GetQueueClient(_resolver.ResolveInString(BadMessageQueue));
            await queue.CreateIfNotExistsAsync();
            await queue.ClearMessagesAsync();

            var poisonQueue = _queueServiceClientWithoutEncoding.GetQueueClient(_resolver.ResolveInString(BadMessageQueue) + "-poison");
            await poisonQueue.DeleteIfExistsAsync();

            await queue.SendMessageAsync(messageContent);

            QueueMessage poisonMessage = null;
            await TestHelpers.Await(async () =>
            {
                bool done = false;
                if (await poisonQueue.ExistsAsync())
                {
                    poisonMessage = await poisonQueue.ReceiveMessageAsync();
                    done = poisonMessage != null;
                }
                var logs = loggerProvider.GetAllLogMessages();
                return done;
            });

            await host.StopAsync();

            // find the raw string to compare it to the original
            Assert.NotNull(poisonMessage);
            Assert.AreEqual(messageContent, poisonMessage.MessageText);

            // Make sure the functions were called correctly
            Assert.AreEqual(0, _badMessageCalls);

            // Validate Logger
            var loggerErrors = loggerProvider.GetAllLogMessages().Where(l => l.Level == Microsoft.Extensions.Logging.LogLevel.Error);
            Assert.True(loggerErrors.All(t => t.Exception.InnerException.InnerException is FormatException));
        }

        [Test]
        public async Task TestSingle_Dispose()
        {
            await WriteQueueMessages(QueueName, 5);

            IHost host = BuildHost<TestSingleDispose>();

            var waitTime = TimeSpan.FromSeconds(30);
            bool result = _waitHandle.WaitOne(waitTime);
            Assert.True(result);
            host.Dispose();
        }

        [Test]
        public async Task TestSingle_StopWithoutDrain()
        {
            await WriteQueueMessages(QueueName, 1);
            IHost host = BuildHost<TestSingleDispose>();

            var waitTime = TimeSpan.FromSeconds(30);
            bool result = _waitHandle.WaitOne(waitTime);
            Assert.True(result);
            await host.StopAsync();
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

        private async Task WriteQueueMessages(string queueName, int numMessages)
        {
            QueueClient queue = _queueServiceClient.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();

            int numThreads = 10;
            if (numMessages <= numThreads)
            {
                numThreads = 1;
            }
            int messagesPerThread = numMessages / numThreads;
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < numThreads; i++)
            {
                tasks.Add(AddMessagesAsync(messagesPerThread, queue));
            }

            int remainder = numMessages / numThreads;
            tasks.Add(AddMessagesAsync(remainder, queue));

            await Task.WhenAll(tasks);
        }

        private async Task WriteBlobs(string containerName, int numBlobs)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            int numThreads = 10;
            if (numBlobs <= numThreads)
            {
                numThreads = 1;
            }
            int blobsPerThread = numBlobs / numThreads;
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < numThreads; i++)
            {
                tasks.Add(AddBlobsAsync(blobsPerThread, container));
            }

            int remainder = numBlobs % numThreads;
            tasks.Add(AddBlobsAsync(remainder, container));

            await Task.WhenAll(tasks);
        }

        private static async Task AddBlobsAsync(int numBlobs, BlobContainerClient blobContainerClient)
        {
            for (int i = 0; i < numBlobs; i++)
            {
                var testBlob = blobContainerClient.GetBlockBlobClient($"test{Guid.NewGuid()}");
                await testBlob.UploadTextAsync(JsonConvert.SerializeObject($"TestData{i}"));
            }
        }

        private static async Task AddMessagesAsync(int numMessages, QueueClient queue)
        {
            for (int i = 0; i < numMessages; i++)
            {
                await queue.SendMessageAsync(Guid.NewGuid().ToString());
            }
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
                this.QueueServiceClientWithoutEncoding = new QueueServiceClient(testEnvironment.PrimaryStorageAccountConnectionString);
                this.BlobServiceClient = new BlobServiceClient(testEnvironment.PrimaryStorageAccountConnectionString);
            }

            public QueueServiceClient QueueServiceClient
            {
                get;
                private set;
            }

            public QueueServiceClient QueueServiceClientWithoutEncoding
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

        public class DynamicConcurrencyTestJob
        {
            public static int InvocationCount;

            public static async Task ProcessMessage([QueueTrigger(DynamicConcurrencyQueueName)] string input)
            {
                await Task.Delay(250);

                Interlocked.Increment(ref InvocationCount);
            }

            public static async Task ProcessBlob([BlobTrigger(DynamicConcurrencyBlobContainerName)] string input)
            {
                await Task.Delay(250);

                Interlocked.Increment(ref InvocationCount);
            }
        }

        public class TestSingleDispose
        {
            public static async Task RunAsync(
                [QueueTrigger(QueueName)]
                QueueMessage message,
                CancellationToken cancellationToken)
            {
                _waitHandle.Set();
                // wait a small amount of time for the host to call dispose
                await Task.Delay(2000, CancellationToken.None);
                Assert.IsTrue(cancellationToken.IsCancellationRequested);
            }
        }

        protected IHost BuildHost<TJobClass>(
            Action<IHostBuilder> configurationDelegate = null,
            bool startHost = true)
        {
            // Reinitialize the name resolver to avoid conflicts
            _resolver = new RandomNameResolver();

            var hostBuilder = new HostBuilder()
                .ConfigureDefaultTestHost<TJobClass>(b =>
                {
                    b.AddAzureStorageQueues();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INameResolver>(_resolver);
                })
                .ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Debug);
                });
            // do this after the defaults so test-specific values will override the defaults
            configurationDelegate?.Invoke(hostBuilder);
            IHost host = hostBuilder.Build();
            if (startHost)
            {
                host.StartAsync().GetAwaiter().GetResult();
            }

            return host;
        }
    }
}
