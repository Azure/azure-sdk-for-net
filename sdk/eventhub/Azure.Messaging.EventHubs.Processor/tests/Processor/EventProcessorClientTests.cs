// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessorClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventProcessorClientTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorsValidateTheConsumerGroup(string consumerGroup)
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), consumerGroup, "dummyConnection", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), consumerGroup, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate the consumer group.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), consumerGroup, "dummyNamespace", "dummyEventHub", new AzureNamedKeyCredential("key", "value"), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate the consumer group.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), consumerGroup, "dummyNamespace", "dummyEventHub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The SAS constructor should validate the consumer group.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorsValidateTheBlobContainerClient()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            Assert.That(() => new EventProcessorClient(null, "consumerGroup", fakeConnection, new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentNullException>(), "The connection string constructor should validate the blob container client.");
            Assert.That(() => new EventProcessorClient(null, "consumerGroup", "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentNullException>(), "The token credential constructor should validate the blob container client.");
            Assert.That(() => new EventProcessorClient(null, "consumerGroup", "dummyNamespace", "dummyEventHub", new AzureNamedKeyCredential("key", "value"), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentNullException>(), "The shared key credential constructor should validate the blob container client.");
            Assert.That(() => new EventProcessorClient(null, "consumerGroup", "dummyNamespace", "dummyEventHub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentNullException>(), "The SAS credential constructor should validate the blob container client.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorsValidateTheConnectionString(string connectionString)
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString, "dummy", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("[1.2.3.4]")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential should validate.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential should validate.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The SAS credential should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHub(string constructorArgument)
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential should validate.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential should validate.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException, "The token credential should validate.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(AzureNamedKeyCredential)), Throws.ArgumentNullException, "The shared key credential should validate.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(AzureSasCredential)), Throws.ArgumentNullException, "The SAS credential should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor(s).
        /// </summary>
        ///
        [Test]
        public void ConstructorsTranslateOptionsForTheBaseClass()
        {
            void assertOptionsMatch(EventProcessorOptions expected,
                                    EventProcessorOptions actual,
                                    string constructorDescription)
            {
                Assert.That(actual, Is.Not.Null, $"The processor options should have been created for the { constructorDescription } constructor.");
                Assert.That(actual.ConnectionOptions.TransportType, Is.EqualTo(expected.ConnectionOptions.TransportType), $"The connection options are incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.RetryOptions.MaximumRetries, Is.EqualTo(expected.RetryOptions.MaximumRetries), $"The retry options are incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.Identifier, Is.EqualTo(expected.Identifier), $"The identifier is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.MaximumWaitTime, Is.EqualTo(expected.MaximumWaitTime), $"The maximum wait time is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.TrackLastEnqueuedEventProperties, Is.EqualTo(expected.TrackLastEnqueuedEventProperties), $"The last event tracking flag is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.DefaultStartingPosition, Is.EqualTo(expected.DefaultStartingPosition), $"The default starting position is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.LoadBalancingUpdateInterval, Is.EqualTo(expected.LoadBalancingUpdateInterval), $"The load balancing interval is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.PartitionOwnershipExpirationInterval, Is.EqualTo(expected.PartitionOwnershipExpirationInterval), $"The ownership expiration interval incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.PrefetchCount, Is.EqualTo(expected.PrefetchCount), $"The prefetch count is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.PrefetchSizeInBytes, Is.EqualTo(expected.PrefetchSizeInBytes), $"The prefetch byte size is incorrect for the { constructorDescription } constructor.");
            }

            var clientOptions = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                RetryOptions = new EventHubsRetryOptions { MaximumRetries = 99 },
                Identifier = "OMG, HAI!",
                MaximumWaitTime = TimeSpan.FromDays(54),
                TrackLastEnqueuedEventProperties = true,
                PrefetchCount = 5,
                PrefetchSizeInBytes = 500,
                LoadBalancingUpdateInterval = TimeSpan.FromDays(65),
                PartitionOwnershipExpirationInterval = TimeSpan.FromMilliseconds(65)
            };

            var expectedOptions = InvokeCreateOptions(clientOptions);

            string description;
            EventProcessorClient processorClient;
            EventProcessorOptions actualOptions;

            // Connection String constructor

            description = "{{ connection string constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", clientOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);

            // Connection String and Event Hub Name constructor

            description = "{{ connection string with Event Hub name constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123", "theHub", clientOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);

            // Namespace constructor

            description = "{{ namespace constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "theHub", Mock.Of<TokenCredential>(), clientOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);

            // SAS constructor

            description = "{{ SAS constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "theHub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), clientOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);

            // Named Key constructor

            description = "{{ Named Key constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "theHub", new AzureNamedKeyCredential("fakeName", "fakeKey"), clientOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);

            // Internal testing constructor (Token)

            description = "{{ internal testing constructor (Token) }}";
            expectedOptions = new EventProcessorOptions();
            processorClient = new EventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "theHub", 100, Mock.Of<TokenCredential>(), expectedOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);

            // Internal testing constructor (Shared Key)

            description = "{{ internal testing constructor (Shared Key) }}";
            expectedOptions = new EventProcessorOptions();
            processorClient = new EventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "theHub", 100, new AzureNamedKeyCredential("key", "value"), expectedOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);

            // Internal testing constructor (SAS)

            description = "{{ internal testing constructor (SAS) }}";
            expectedOptions = new EventProcessorOptions();
            processorClient = new EventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "theHub", 100, new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), expectedOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);
        }

        [Test]
        public void ConstructorsSetClientDiagnostics()
        {
            // Connection String constructor

            EventProcessorClient processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", default(EventProcessorClientOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");

            // Connection String and Event Hub Name constructor

            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123", "theHub", default(EventProcessorClientOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");

            // Namespace constructor

            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "theHub", Mock.Of<TokenCredential>(), default(EventProcessorClientOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");

            // SAS constructor

            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "theHub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), default(EventProcessorClientOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");

            // Named Key constructor

            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "theHub", new AzureNamedKeyCredential("fakeName", "fakeKey"), default(EventProcessorClientOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");

            // Internal testing constructor (Token)

            processorClient = new EventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "theHub", 100, Mock.Of<TokenCredential>(), default(EventProcessorOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");
            // Internal testing constructor (Shared Key)

            processorClient = new EventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "theHub", 100, new AzureNamedKeyCredential("key", "value"), default(EventProcessorOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");

            // Internal testing constructor (SAS)

            processorClient = new EventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "theHub", 100, new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), default(EventProcessorOptions));
            Assert.IsNotNull(processorClient.ClientDiagnostics, "The diagnostics should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorParsesNamespaceFromUri()
        {
            var credential = Mock.Of<TokenCredential>();
            var host = "mynamespace.servicebus.windows.net";
            var namespaceUri = $"sb://{ host }";
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, namespaceUri, "dummy", credential);

            Assert.That(eventProcessor.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StartProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StartProcessingValidatesProcessEventsAsync(bool async)
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            if (async)
            {
                Assert.That(async () => await processorClient.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessEventAsync)));
            }
            else
            {
                Assert.That(() => processorClient.StartProcessing(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessEventAsync)));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StartProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StartProcessingValidatesProcessExceptionAsync(bool async)
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;

            if (async)
            {
                Assert.That(async () => await processorClient.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessErrorAsync)));
            }
            else
            {
                Assert.That(() => processorClient.StartProcessing(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessErrorAsync)));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StartProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingStartsWhenRequiredHandlerPropertiesAreSet(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            if (async)
            {
                Assert.That(async () => await processorClient.StartProcessingAsync(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
            }
            else
            {
                Assert.That(() => processorClient.StartProcessing(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
            }

            Assert.That(processorClient.IsRunning, Is.True, "The processor should have started.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processorClient.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StartProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StartProcessingRespectsTheCancellationToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            if (async)
            {
                Assert.That(async () => await processorClient.StartProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            }
            else
            {
                Assert.That(() => processorClient.StartProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StartProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingIsSafeToCallMultipleTimes(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            void assertStartProcessing()
            {
                if (async)
                {
                    Assert.That(async () => await processorClient.StartProcessingAsync(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
                }
                else
                {
                    Assert.That(() => processorClient.StartProcessing(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
                }

                Assert.That(processorClient.IsRunning, Is.True, "The processor should have started.");
                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            }

            assertStartProcessing();
            assertStartProcessing();

            await processorClient.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StartProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        public async Task ValidateStoragePermissionsAsyncValidatesBlobsCanBeWritten()
        {
            using var cancellationSource = new CancellationTokenSource();

            var capturedException = default(Exception);
            var expectedException = new AccessViolationException("Stop violating my access!");
            var mockContainerClient = new Mock<BlobContainerClient>();
            var mockBlobClient = new MockBlobClient("dummy") { UploadException = expectedException };

            mockContainerClient
                .Setup(client => client.GetBlobClient(It.IsAny<string>()))
                .Returns(mockBlobClient);

            var processorClient = new TestEventProcessorClient(mockContainerClient.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            try
            {
                await processorClient.ValidateStoragePermissionsAsync(mockContainerClient.Object, cancellationSource.Token);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been thrown.");
            Assert.That(capturedException, Is.InstanceOf<AggregateException>(), "A validation exception should be surfaced as an AggregateException.");
            Assert.That(((AggregateException)capturedException).InnerExceptions.Count, Is.EqualTo(1), "There should have been a single validation exception.");

            var innerException = ((AggregateException)capturedException).InnerExceptions.First();
            Assert.That(innerException, Is.SameAs(expectedException), "The source of the validation exception should have been exposed.");
            Assert.That(processorClient.IsRunning, Is.False, "The processor should not be running after a validation exception.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StartProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        public async Task ValidateStoragePermissionsAsyncLogsWhenCleanupFails()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new AccessViolationException("Stop violating my access!");
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var mockContainerClient = new Mock<BlobContainerClient>();
            var mockBlobClient = new MockBlobClient("dummy") { DeleteException = expectedException };

            mockContainerClient
                .Setup(client => client.GetBlobClient(It.IsAny<string>()))
                .Returns(mockBlobClient);

            var processorClient = new TestEventProcessorClient(mockContainerClient.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processorClient.ValidateStoragePermissionsAsync(mockContainerClient.Object, cancellationSource.Token), Throws.Nothing);

            mockLogger.Verify(log => log.ValidationCleanupError(
                processorClient.Identifier,
                processorClient.EventHubName,
                processorClient.ConsumerGroup, expectedException.Message),
            Times.Once);

            await processorClient.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StopProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingRespectsTheCancellationToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            await processorClient.StartProcessingAsync(cancellationSource.Token);
            Assert.That(processorClient.IsRunning, Is.True, "The processor should have started.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();

            if (async)
            {
                Assert.That(async () => await processorClient.StopProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            }
            else
            {
                Assert.That(() => processorClient.StopProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            }

            Assert.That(processorClient.IsRunning, Is.True, "The processor should have started.");

            using var stopCancellation = new CancellationTokenSource();
            stopCancellation.CancelAfter(TimeSpan.FromSeconds(5));

            await processorClient.StopProcessingAsync(stopCancellation.Token).IgnoreExceptions();
            stopCancellation.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StopProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingIsSafeToCallMultipleTimes(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            await processorClient.StartProcessingAsync(cancellationSource.Token);
            Assert.That(processorClient.IsRunning, Is.True, "The processor should have started.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            void assertStopProcessing()
            {
                if (async)
                {
                    Assert.That(async () => await processorClient.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
                }
                else
                {
                    Assert.That(() => processorClient.StopProcessing(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
                }

                Assert.That(processorClient.IsRunning, Is.False, "The processor should have stopped.");
                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            }

            assertStopProcessing();
            assertStopProcessing();

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of starting and stopping the <see cref="EventProcessorClient" />.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ProcessorCanStartAfterBeingStopped(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            void assertStartProcessing()
            {
                if (async)
                {
                    Assert.That(async () => await processorClient.StartProcessingAsync(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
                }
                else
                {
                    Assert.That(() => processorClient.StartProcessing(cancellationSource.Token), Throws.Nothing, "The processor should start without exceptions.");
                }

                Assert.That(processorClient.IsRunning, Is.True, "The processor should have started.");
                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            }

            // Verify the initial start.

            assertStartProcessing();

            // Stop processing.

            if (async)
            {
                Assert.That(async () => await processorClient.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The processor should stop without exceptions.");
            }
            else
            {
                Assert.That(() => processorClient.StopProcessing(cancellationSource.Token), Throws.Nothing, "The processor should stop without exceptions.");
            }

            Assert.That(processorClient.IsRunning, Is.False, "The processor should have stopped.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Verify starting after having been stopped.

            assertStartProcessing();

            await processorClient.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void ProcessorDoesNotAllowNullEventHandlers()
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            Assert.That(() => processorClient.PartitionInitializingAsync += null, Throws.InstanceOf<ArgumentNullException>(), "The initializing handler should not allow null.");
            Assert.That(() => processorClient.PartitionClosingAsync += null, Throws.InstanceOf<ArgumentNullException>(), "The closing handler should not allow null.");
            Assert.That(() => processorClient.ProcessEventAsync += null, Throws.InstanceOf<ArgumentNullException>(), "The processing handler should not allow null.");
            Assert.That(() => processorClient.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>(), "The error handler should not allow null.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void ProcessorAllowsOnlyOneHandlerRegistrationPerEvent()
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.PartitionInitializingAsync += eventArgs => Task.CompletedTask;
            processorClient.PartitionClosingAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processorClient.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>(), "The initializing handler should not allow multiple registrations.");
            Assert.That(() => processorClient.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>(), "The closing handler should not allow multiple registrations.");
            Assert.That(() => processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>(), "The processing handler should not allow multiple registrations.");
            Assert.That(() => processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>(), "The error handler should not allow multiple registrations.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void ProcessorDoesNotAllowRemovingEventHandlersWhenNoneWereSet()
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            Assert.That(() => processorClient.PartitionInitializingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The initializing handler should not allow removal.");
            Assert.That(() => processorClient.PartitionClosingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The closing handler should not allow removal.");
            Assert.That(() => processorClient.ProcessEventAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The processing handler should not allow removal.");
            Assert.That(() => processorClient.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The error handler should not allow removal.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void ProcessorDoesNotAllowRemovingUnregisteredEventHandlers()
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.PartitionInitializingAsync += eventArgs => Task.CompletedTask;
            processorClient.PartitionClosingAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processorClient.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Though these handlers have the same signature, they are not the same instance as those that were registered
            // and should trigger an exception.

            Assert.That(() => processorClient.PartitionInitializingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The initializing handler should not allow unregistered removal.");
            Assert.That(() => processorClient.PartitionClosingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The closing handler should not allow unregistered removal");
            Assert.That(() => processorClient.ProcessEventAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The processing handler should not allow unregistered removal");
            Assert.That(() => processorClient.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The error handler should not allow unregistered removal");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void ProcessorAllowsRemovingEventHandlers()
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            Func<PartitionInitializingEventArgs, Task> initHandler = eventArgs => Task.CompletedTask;
            Func<PartitionClosingEventArgs, Task> closeHandler = eventArgs => Task.CompletedTask;
            Func<ProcessEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;

            processorClient.PartitionInitializingAsync += initHandler;
            processorClient.PartitionClosingAsync += closeHandler;
            processorClient.ProcessEventAsync += eventHandler;
            processorClient.ProcessErrorAsync += errorHandler;

            Assert.That(() => processorClient.PartitionInitializingAsync -= initHandler, Throws.Nothing, "The initializing handler should allow removing registrations.");
            Assert.That(() => processorClient.PartitionClosingAsync -= closeHandler, Throws.Nothing, "The closing handler should allow removing registrations.");
            Assert.That(() => processorClient.ProcessEventAsync -= eventHandler, Throws.Nothing, "The processing handler should allow removing registrations.");
            Assert.That(() => processorClient.ProcessErrorAsync -= errorHandler, Throws.Nothing, "The error handler should allow removing registrations.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorDoesNotAllowEventHandlerChangesWhenRunning()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Func<ProcessEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventHandler;
            ;
            processorClient.ProcessErrorAsync += errorHandler;

            // Handlers should not be allowed when the processor is running.

            await processorClient.StartProcessingAsync(cancellationSource.Token);

            Assert.That(processorClient.IsRunning, Is.True, "The processor should have started.");
            Assert.That(() => processorClient.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>(), "The initializing handler should not allow registration.");
            Assert.That(() => processorClient.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>(), "The closing handler should not allow registration.");
            Assert.That(() => processorClient.ProcessEventAsync -= eventHandler, Throws.InstanceOf<InvalidOperationException>(), "The processing handler should not allow removing registrations.");
            Assert.That(() => processorClient.ProcessErrorAsync -= errorHandler, Throws.InstanceOf<InvalidOperationException>(), "The error handler should not allow removing registrations.");

            // Handlers should be allowed with the processor idle.

            await processorClient.StopProcessingAsync(cancellationSource.Token);

            Assert.That(processorClient.IsRunning, Is.False, "The processor should have stopped.");
            Assert.That(() => processorClient.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.Nothing, "The initializing handler should allow registration.");
            Assert.That(() => processorClient.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.Nothing, "The closing handler should allow registration.");
            Assert.That(() => processorClient.ProcessEventAsync -= eventHandler, Throws.Nothing, "The processing handler should allow removing registrations.");
            Assert.That(() => processorClient.ProcessErrorAsync -= errorHandler, Throws.Nothing, "The error handler should allow removing registrations.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorRaisesInitializeEventHandlerWhenPartitionIsInitialized()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var capturedEventArgs = default(PartitionInitializingEventArgs);
            var partitionId = "0";
            var startingPosition = EventPosition.FromOffset("433");
            var options = new EventProcessorOptions { DefaultStartingPosition = startingPosition };
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

            processorClient.PartitionInitializingAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnInitializingPartitionAsync(new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(capturedEventArgs, Is.Not.Null, "The event handler should have been fired.");
            Assert.That(capturedEventArgs.PartitionId, Is.EqualTo(partitionId), "The partition identifier should have been propagated.");
            Assert.That(capturedEventArgs.DefaultStartingPosition, Is.EqualTo(startingPosition), "The starting position should have been propagated.");
            Assert.That(capturedEventArgs.CancellationToken, Is.EqualTo(cancellationSource.Token), "The cancellation token should have been propagated.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorRaisesClosingEventHandlerWhenPartitionIsStopped()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var capturedEventArgs = default(PartitionClosingEventArgs);
            var partitionId = "0";
            var closeReason = ProcessingStoppedReason.Shutdown;
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.PartitionClosingAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnPartitionProcessingStoppedAsync(new TestEventProcessorPartition(partitionId), closeReason, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(capturedEventArgs, Is.Not.Null, "The event handler should have been fired.");
            Assert.That(capturedEventArgs.PartitionId, Is.EqualTo(partitionId), "The partition identifier should have been propagated.");
            Assert.That(capturedEventArgs.Reason, Is.EqualTo(closeReason), "The close reason should have been propagated.");
            Assert.That(capturedEventArgs.CancellationToken, Is.EqualTo(cancellationSource.Token), "The cancellation token should have been propagated.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorRaisesErrorEventHandlerWhenErrorsAreReportedForPartition()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var partitionId = "0";
            var exception = new DivideByZeroException("OMG, ZERO?!?!?!");
            var description = "Doing Stuff";
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.ProcessErrorAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnProcessingErrorAsync(exception, new TestEventProcessorPartition(partitionId), description, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(capturedEventArgs, Is.Not.Null, "The event handler should have been fired.");
            Assert.That(capturedEventArgs.PartitionId, Is.EqualTo(partitionId), "The partition identifier should have been propagated.");
            Assert.That(capturedEventArgs.Exception, Is.InstanceOf<DivideByZeroException>().And.Message.EqualTo(exception.Message), "The exception should have been propagated.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(description), "The operation description should have been propagated.");
            Assert.That(capturedEventArgs.CancellationToken, Is.EqualTo(cancellationSource.Token), "The cancellation token should have been propagated.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorRaisesErrorEventHandlerWhenErrorsAreReportedForNoPartition()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var exception = new DivideByZeroException("OMG, ZERO?!?!?!");
            var description = "Doing Stuff";
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.ProcessErrorAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnProcessingErrorAsync(exception, null, description, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(capturedEventArgs, Is.Not.Null, "The event handler should have been fired.");
            Assert.That(capturedEventArgs.PartitionId, Is.Null, "The partition identifier should have been null.");
            Assert.That(capturedEventArgs.Exception, Is.InstanceOf<DivideByZeroException>().And.Message.EqualTo(exception.Message), "The exception should have been propagated.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(description), "The operation description should have been propagated.");
            Assert.That(capturedEventArgs.CancellationToken, Is.EqualTo(cancellationSource.Token), "The cancellation token should have been propagated.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorRaisesProcessEventHandlerWhenEventsAreRead()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456)
            };

            var capturedEventArgs = new List<ProcessEventArgs>();
            var partitionId = "0";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockCheckpointStore
                .Setup(storage => storage.UpdateCheckpointAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CheckpointPosition>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            processorClient.ProcessEventAsync += eventArgs =>
            {
                capturedEventArgs.Add(eventArgs);
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(capturedEventArgs.Count, Is.EqualTo(eventBatch.Length), "The event handler should have been fired for each event in the batch.");

            for (var index = 0; index < eventBatch.Length; ++index)
            {
                Assert.That(capturedEventArgs[index].HasEvent, Is.True, $"The event arguments should contain an event at index { index }.");
                Assert.That(capturedEventArgs[index].Partition.FullyQualifiedNamespace, Is.EqualTo(processorClient.FullyQualifiedNamespace), "The fully qualified namespace should have been propagated.");
                Assert.That(capturedEventArgs[index].Partition.EventHubName, Is.EqualTo(processorClient.EventHubName), "The event hub name should have been propagated.");
                Assert.That(capturedEventArgs[index].Partition.ConsumerGroup, Is.EqualTo(processorClient.ConsumerGroup), "The consumer group should have been propagated.");
                Assert.That(capturedEventArgs[index].Partition.PartitionId, Is.EqualTo(partitionId), $"The partition identifier should have been propagated at index { index }.");
                Assert.That(capturedEventArgs[index].Data.IsEquivalentTo(eventBatch[index]), Is.True, $"The event should have been propagated and order preserved at index { index }.");
                Assert.That(capturedEventArgs[index].CancellationToken, Is.EqualTo(cancellationSource.Token), $"The cancellation token should have been propagated at index { index }.");
                Assert.That(async () => await capturedEventArgs[index].UpdateCheckpointAsync(), Throws.Nothing, $"A checkpoint should be allowed for the event at index { index }.");

                mockCheckpointStore
                    .Verify(storage => storage.UpdateCheckpointAsync(
                        processorClient.FullyQualifiedNamespace,
                        processorClient.EventHubName,
                        processorClient.ConsumerGroup,
                        capturedEventArgs[index].Partition.PartitionId,
                        processorClient.Identifier,
                        It.Is<CheckpointPosition>(csp =>
                            csp.SequenceNumber == capturedEventArgs[index].Data.SequenceNumber),
                        It.IsAny<CancellationToken>()),
                    Times.Once,
                    $"Creating a checkpoint for index { index } should have invoked the storage manager correctly.");
            }

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorRaisesProcessEventHandlerWithAnEmptyContextWhenThereAreNoEvents()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var capturedEventArgs = default(ProcessEventArgs);
            var partitionId = "0";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.ProcessEventAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnProcessingEventBatchAsync(Enumerable.Empty<EventData>(), new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(capturedEventArgs, Is.Not.Null, "The event handler should have been fired.");
            Assert.That(capturedEventArgs.HasEvent, Is.False, "The event arguments should not contain an event.");
            Assert.That(capturedEventArgs.Partition.FullyQualifiedNamespace, Is.EqualTo(processorClient.FullyQualifiedNamespace), "The fully qualified namespace should have been propagated.");
            Assert.That(capturedEventArgs.Partition.EventHubName, Is.EqualTo(processorClient.EventHubName), "The event hub name should have been propagated.");
            Assert.That(capturedEventArgs.Partition.ConsumerGroup, Is.EqualTo(processorClient.ConsumerGroup), "The consumer group should have been propagated.");
            Assert.That(capturedEventArgs.Partition.PartitionId, Is.EqualTo(partitionId), "The partition identifier should have been propagated.");
            Assert.That(capturedEventArgs.Data, Is.Null, "No event data should have been propagated.");
            Assert.That(capturedEventArgs.CancellationToken, Is.EqualTo(cancellationSource.Token), "The cancellation token should have been propagated.");
            Assert.That(async () => await capturedEventArgs.UpdateCheckpointAsync(), Throws.InstanceOf<InvalidOperationException>(), "A checkpoint cannot be created for an empty event.");

            mockCheckpointStore
                .Verify(storage => storage.UpdateCheckpointAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CheckpointPosition>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void EventProcessingToleratesAndSurfacesAnException()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456)
            };

            var invokeCount = 0;
            var halfBatchCount = (int)Math.Floor(eventBatch.Length / 2.0f);
            var expectedException = new DivideByZeroException("Ruh Roh, Raggy!");
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.ProcessEventAsync += eventArgs =>
            {
                if (invokeCount++ == halfBatchCount)
                {
                    throw expectedException;
                }

                return Task.CompletedTask;
            };

            Assert.That(async () => await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token), Throws.Exception.EqualTo(expectedException), "The processing should have surfaced the exception");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(invokeCount, Is.EqualTo(eventBatch.Length), "The event handler should have been fired for each event in the batch.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessingToleratesAndSurfacesMultipleExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var invokeCount = 0;
            var eventCount = 9;
            var exceptionCount = 0;
            var exceptionMultiple = 3;
            var exceptionMessage = "This is a processing exception";
            var capturedException = default(AggregateException);
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            var eventBatch = Enumerable
                .Range(0, eventCount)
                .Select(index => new MockEventData(Array.Empty<byte>(), offset: (1000 + index).ToString(), sequenceNumber: 2000 + index))
                .ToList();

            processorClient.ProcessEventAsync += eventArgs =>
            {
                if (invokeCount++ % exceptionMultiple == 0)
                {
                    ++exceptionCount;
                    throw new ApplicationException(exceptionMessage);
                }

                return Task.CompletedTask;
            };

            try
            {
                await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token);
            }
            catch (Exception ex)
            {
                capturedException = (ex as AggregateException);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(capturedException, Is.Not.Null, "An aggregate exception should have been thrown to contain each observed exception.");
            Assert.That(capturedException.Message, Does.StartWith(Resources.AggregateEventProcessingExceptionMessage), "The error message should reflect the aggregate.");
            Assert.That(capturedException.InnerExceptions.Count, Is.EqualTo(exceptionCount), "The aggregate should contain all of the processing exceptions.");
            Assert.That(capturedException.InnerExceptions.Any(ex => ex.Message != exceptionMessage), Is.False, "The aggregate should contain only the exceptions observed during processing.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessingLogsExecution()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456)
            };

            var partitionId = "3";
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition(partitionId), cancellationSource.Token);

            mockLogger
                .Verify(log => log.EventBatchProcessingStart(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    It.IsAny<string>()),
                Times.Once);

            mockLogger
                .Verify(log => log.EventBatchProcessingComplete(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    It.IsAny<string>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessingLogsExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456)
            };

            var partitionId = "3";
            var expectedException = new ApplicationException("Why is water wet?");
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += eventArgs => throw expectedException;

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition(partitionId), cancellationSource.Token).IgnoreExceptions();

            mockLogger
                .Verify(log => log.EventBatchProcessingError(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    expectedException.Message,
                    It.IsAny<string>()),
                Times.Exactly(eventBatch.Length));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessingRespectsCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456),
                new MockEventData(new byte[] { 0x33 }, offset: "789", sequenceNumber: 789),
                new MockEventData(new byte[] { 0x44 }, offset: "000", sequenceNumber: 000)
            };

            var processedEventsCount = 0;
            var partitionId = "0";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.ProcessEventAsync += eventArgs =>
            {
                ++processedEventsCount;
                cancellationSource.Cancel();

                return Task.CompletedTask;
            };

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition(partitionId), cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.True, "The cancellation token should have been signaled.");
            Assert.That(processedEventsCount, Is.EqualTo(1), "The event handler should not have been triggered after cancellation.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointAsyncDelegatesToTheStorageManager()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "5";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockCheckpointStore
                .Setup(storage => storage.GetCheckpointAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(EventProcessorCheckpoint));

            await processorClient.InvokeGetCheckpointAsync(partitionId, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockCheckpointStore
                .Verify(storage => storage.GetCheckpointAsync(
                    processorClient.FullyQualifiedNamespace,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    partitionId,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointIncludesInitializeEventHandlerStartingPositionWhenNoNaturalCheckpointExists()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "0";
            var startingPosition = EventPosition.FromOffset("433");
            var options = new EventProcessorOptions { DefaultStartingPosition = EventPosition.Latest };
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

            mockCheckpointStore
                .Setup(storage => storage.GetCheckpointAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(EventProcessorCheckpoint));

            processorClient.PartitionInitializingAsync += eventArgs =>
            {
                eventArgs.DefaultStartingPosition = startingPosition;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnInitializingPartitionAsync(new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var checkpoint = await processorClient.InvokeGetCheckpointAsync(partitionId, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(checkpoint, Is.Not.Null, "A checkpoint should have been injected for the partition.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(startingPosition), "The injected checkpoint should have respected the value that the initialization event handler set.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointPrefersNaturalCheckpointOverInitializeEventHandlerStartingPosition()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "0";
            var startingPosition = EventPosition.FromOffset("433");
            var checkpointStartingPosition = EventPosition.FromSequenceNumber(999);
            var options = new EventProcessorOptions { DefaultStartingPosition = EventPosition.Latest };
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

            mockCheckpointStore
                .Setup(storage => storage.GetCheckpointAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), partitionId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new EventProcessorCheckpoint { PartitionId = partitionId, StartingPosition = checkpointStartingPosition });

            processorClient.PartitionInitializingAsync += eventArgs =>
            {
                eventArgs.DefaultStartingPosition = startingPosition;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnInitializingPartitionAsync(new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var checkpoint = await processorClient.InvokeGetCheckpointAsync(partitionId, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(checkpoint, Is.Not.Null, "A checkpoints should have been found for the partition.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(checkpointStartingPosition), "The natural checkpoint should have respected the value that the initialization event handler set.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointReturnsNaturalCheckpointsWhenNoInitializeEventHandlerIsRegistered()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "0";
            var options = new EventProcessorOptions { DefaultStartingPosition = EventPosition.Latest };
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

            mockCheckpointStore
                .Setup(storage => storage.GetCheckpointAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(EventProcessorCheckpoint));

            await processorClient.InvokeOnInitializingPartitionAsync(new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var checkpoint = await processorClient.InvokeGetCheckpointAsync(partitionId, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(checkpoint, Is.Null, "No handler was registered for the partition; no checkpoint should have been injected.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipDelegatesToTheStorageManager()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockCheckpointStore
                .Setup(storage => storage.ListOwnershipAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(IEnumerable<EventProcessorPartitionOwnership>));

            await processorClient.InvokeListOwnershipAsync(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockCheckpointStore
                .Verify(storage => storage.ListOwnershipAsync(
                    processorClient.FullyQualifiedNamespace,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipDelegatesToTheStorageManager()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var desiredOwnership = new[] { new EventProcessorPartitionOwnership(), new EventProcessorPartitionOwnership() };
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockCheckpointStore
                .Setup(storage => storage.ClaimOwnershipAsync(It.IsAny<IEnumerable<EventProcessorPartitionOwnership>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(IEnumerable<EventProcessorPartitionOwnership>));

            await processorClient.InvokeClaimOwnershipAsync(desiredOwnership, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockCheckpointStore
                .Verify(storage => storage.ClaimOwnershipAsync(
                    desiredOwnership,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointDelegatesToTheStorageManager()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "3";
            var offset = "789";
            var checkpointStartingPosition = new CheckpointPosition(offset);
            var mockStorage = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            await processorClient.InvokeUpdateCheckpointAsync(partitionId, checkpointStartingPosition, cancellationSource.Token);

            mockStorage
                .Verify(storage => storage.UpdateCheckpointAsync(
                    processorClient.FullyQualifiedNamespace,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    partitionId,
                    processorClient.Identifier,
                    It.Is<CheckpointPosition>(csp =>
                        csp.OffsetString == offset),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointRespectsTheCancellationToken()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            Assert.That(async () => await processorClient.InvokeUpdateCheckpointAsync("0", new CheckpointPosition("123"), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointLogsExecution()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "3";
            var sequenceNumber = 789;
            var offset = "135";
            var checkpointStartingPosition = new CheckpointPosition(offset, sequenceNumber);
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            await processorClient.InvokeUpdateCheckpointAsync(partitionId, checkpointStartingPosition, cancellationSource.Token);

            mockLogger
                .Verify(log => log.UpdateCheckpointStart(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    sequenceNumber.ToString(),
                    offset),
                Times.Once);

            mockLogger
                .Verify(log => log.UpdateCheckpointComplete(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    sequenceNumber.ToString(),
                    offset),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointLogsExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new NotImplementedException("This didn't work.");
            var partitionId = "3";
            var checkpointStartingPosition = new CheckpointPosition("44", 789);
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var mockStorage = new Mock<CheckpointStore>();
            var processorClient = new TestEventProcessorClient(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockStorage
                .Setup(storage => storage.UpdateCheckpointAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CheckpointPosition>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            processorClient.Logger = mockLogger.Object;
            Assert.That(async () => await processorClient.InvokeUpdateCheckpointAsync(partitionId, checkpointStartingPosition, cancellationSource.Token), Throws.Exception.EqualTo(expectedException));

            mockLogger
                .Verify(log => log.UpdateCheckpointError(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    expectedException.Message,
                    "789",
                    "44"),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Validates that the <see cref="EventProcessorClientOptions" />
        ///   can be translated into the equivalent set of <see cref="EventProcessorOptions" />.
        /// </summary>
        ///
        [Test]
        public void ClientOptionsCanBeTranslated()
        {
            var clientOptions = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                RetryOptions = new EventHubsRetryOptions { MaximumRetries = 99 },
                Identifier = "OMG, HAI!",
                MaximumWaitTime = TimeSpan.FromDays(54),
                TrackLastEnqueuedEventProperties = true,
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy,
                PrefetchCount = 9990,
                PrefetchSizeInBytes = 400,
                LoadBalancingUpdateInterval = TimeSpan.FromSeconds(45),
                PartitionOwnershipExpirationInterval = TimeSpan.FromMilliseconds(44)
            };

            var defaultOptions = new EventProcessorOptions();
            var processorOptions = InvokeCreateOptions(clientOptions);

            Assert.That(processorOptions, Is.Not.Null, "The processor options should have been created.");
            Assert.That(processorOptions.ConnectionOptions, Is.Not.SameAs(clientOptions.ConnectionOptions), "The connection options should have been copied.");
            Assert.That(processorOptions.ConnectionOptions.TransportType, Is.EqualTo(clientOptions.ConnectionOptions.TransportType), "The connection options should have been set.");
            Assert.That(processorOptions.RetryOptions, Is.Not.SameAs(clientOptions.RetryOptions), "The retry options should have been copied.");
            Assert.That(processorOptions.RetryOptions.MaximumRetries, Is.EqualTo(clientOptions.RetryOptions.MaximumRetries), "The retry options should have been set.");
            Assert.That(processorOptions.Identifier, Is.EqualTo(clientOptions.Identifier), "The identifier should have been set.");
            Assert.That(processorOptions.MaximumWaitTime, Is.EqualTo(clientOptions.MaximumWaitTime), "The maximum wait time should have been set.");
            Assert.That(processorOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(clientOptions.TrackLastEnqueuedEventProperties), "The flag for last event tracking should have been set.");
            Assert.That(processorOptions.LoadBalancingStrategy, Is.EqualTo(clientOptions.LoadBalancingStrategy), "The load balancing strategy should have been set.");
            Assert.That(processorOptions.PrefetchCount, Is.EqualTo(clientOptions.PrefetchCount), "The prefetch count should have been set.");
            Assert.That(processorOptions.PrefetchSizeInBytes, Is.EqualTo(clientOptions.PrefetchSizeInBytes), "The prefetch byte size should have been set.");
            Assert.That(processorOptions.LoadBalancingUpdateInterval, Is.EqualTo(clientOptions.LoadBalancingUpdateInterval), "The load balancing interval should have been set.");
            Assert.That(processorOptions.PartitionOwnershipExpirationInterval, Is.EqualTo(clientOptions.PartitionOwnershipExpirationInterval), "The partition ownership interval should have been set.");

            Assert.That(processorOptions.DefaultStartingPosition, Is.EqualTo(defaultOptions.DefaultStartingPosition), "The default starting position should not have been set.");
        }

        /// <summary>
        ///   Retrieves the active set of options for the processor client's base
        ///   class using the base class private accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance to consider.</param>
        ///
        private static EventProcessorOptions GetBaseOptions(EventProcessorClient instance) =>
            (EventProcessorOptions)
                typeof(EventProcessor<EventProcessorPartition>)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(instance);

        /// <summary>
        ///   Invokes the private CreateOptions method on the processor client,
        ///   responsible for translating the client options into the equivalent general
        ///   event processing options.
        /// </summary>
        ///
        /// <param name="clientOptions">The options to translate.</param>
        ///
        /// <returns>The translated options.</returns>
        ///
        private static EventProcessorOptions InvokeCreateOptions(EventProcessorClientOptions clientOptions) =>
            (EventProcessorOptions)
                typeof(EventProcessorClient)
                    .GetMethod("CreateOptions", BindingFlags.Static | BindingFlags.NonPublic)
                    .Invoke(null, new object[] { clientOptions });

        /// <summary>
        ///   A mock <see cref="EventProcessorClient" /> used for testing purposes.
        /// </summary>
        ///
        public class TestEventProcessorClient : EventProcessorClient
        {
            private readonly EventHubConnection InjectedConnection;

            internal TestEventProcessorClient(CheckpointStore checkpointStore,
                                              string consumerGroup,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              TokenCredential credential,
                                              EventHubConnection connection,
                                              EventProcessorOptions options) : base(checkpointStore, consumerGroup, fullyQualifiedNamespace, eventHubName, 100, credential, options)
            {
                InjectedConnection = connection;
            }

            internal TestEventProcessorClient(BlobContainerClient containerClient,
                                              string consumerGroup,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              TokenCredential credential,
                                              EventHubConnection connection,
                                              EventProcessorClientOptions options) : base(containerClient, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
            {
                InjectedConnection = connection;
            }

            public Task InvokeOnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken) => base.OnProcessingEventBatchAsync(events, partition, cancellationToken);
            public Task InvokeOnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken) => base.OnProcessingErrorAsync(exception, partition, operationDescription, cancellationToken);
            public Task InvokeOnInitializingPartitionAsync(EventProcessorPartition partition, CancellationToken cancellationToken) => base.OnInitializingPartitionAsync(partition, cancellationToken);
            public Task InvokeOnPartitionProcessingStoppedAsync(EventProcessorPartition partition, ProcessingStoppedReason reason, CancellationToken cancellationToken) => base.OnPartitionProcessingStoppedAsync(partition, reason, cancellationToken);
            public Task<EventProcessorCheckpoint> InvokeGetCheckpointAsync(string partitionId, CancellationToken cancellationToken) => base.GetCheckpointAsync(partitionId, cancellationToken);
            public Task<IEnumerable<EventProcessorPartitionOwnership>> InvokeListOwnershipAsync(CancellationToken cancellationToken) => base.ListOwnershipAsync(cancellationToken);
            public Task<IEnumerable<EventProcessorPartitionOwnership>> InvokeClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) => base.ClaimOwnershipAsync(desiredOwnership, cancellationToken);
            public Task InvokeUpdateCheckpointAsync(string partitionId, CheckpointPosition checkpointStartingPosition, CancellationToken cancellationToken) => base.UpdateCheckpointAsync(partitionId, checkpointStartingPosition, cancellationToken);
            protected override EventHubConnection CreateConnection() => InjectedConnection;
            protected override Task ValidateProcessingPreconditions(CancellationToken cancellationToken = default) => Task.CompletedTask;
            public bool? IsBaseBatchTracingEnabled => EnableBatchTracing;
        }

        /// <summary>
        ///   A mock <see cref="EventProcessorPartition" /> used for testing purposes.
        /// </summary>
        ///
        public class TestEventProcessorPartition : EventProcessorPartition
        {
            public TestEventProcessorPartition(string partitionId) { PartitionId = partitionId; }
        }

        /// <summary>
        ///   A mock <see cref="BlobClient" /> used for testing purposes.
        /// </summary>
        ///
        public class MockBlobClient : BlobClient
        {
            public override string Name { get; }
            public Exception UploadException;
            public Exception DeleteException;

            public MockBlobClient(string blobName)
            {
                Name = blobName;
            }

            public override Task<Response<BlobContentInfo>> UploadAsync(Stream content, BlobHttpHeaders httpHeaders = null, IDictionary<string, string> metadata = null, BlobRequestConditions conditions = null, IProgress<long> progressHandler = null, AccessTier? accessTier = null, StorageTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
            {
                if (UploadException != null)
                {
                    throw UploadException;
                }

                return Task.FromResult(
                    Response.FromValue(
                        BlobsModelFactory.BlobContentInfo(new ETag("etag"), new DateTimeOffset(2015, 10, 27, 00, 00, 00, 00, TimeSpan.Zero), Array.Empty<byte>(), string.Empty, 0L),
                        Mock.Of<Response>()));
            }

            public override Response<BlobContentInfo> Upload(Stream content, BlobHttpHeaders httpHeaders = null, IDictionary<string, string> metadata = null, BlobRequestConditions conditions = null, IProgress<long> progressHandler = null, AccessTier? accessTier = null, StorageTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
            {
                if (UploadException != null)
                {
                    throw UploadException;
                }

                return Response.FromValue(
                    BlobsModelFactory.BlobContentInfo(new ETag("etag"), new DateTimeOffset(2015, 10, 27, 00, 00, 00, 00, TimeSpan.Zero), Array.Empty<byte>(), string.Empty, 0L),
                    Mock.Of<Response>());
            }

            public override Task<Response<bool>> DeleteIfExistsAsync(DeleteSnapshotsOption snapshotsOption = DeleteSnapshotsOption.None, BlobRequestConditions conditions = null, CancellationToken cancellationToken = default)
            {
                if (DeleteException != null)
                {
                    throw DeleteException;
                }

                return Task.FromResult(Response.FromValue(true, Mock.Of<Response>()));
            }

            public override Response<bool> DeleteIfExists(DeleteSnapshotsOption snapshotsOption = DeleteSnapshotsOption.None, BlobRequestConditions conditions = null, CancellationToken cancellationToken = default)
            {
                if (DeleteException != null)
                {
                    throw DeleteException;
                }

                return Response.FromValue(true, Mock.Of<Response>());
            }

            public override Task<Response<BlobProperties>> GetPropertiesAsync(BlobRequestConditions conditions = null, CancellationToken cancellationToken = default) =>
                 Task.FromResult(Response.FromValue(Mock.Of<BlobProperties>(), Mock.Of<Response>()));
        }
    }
}
