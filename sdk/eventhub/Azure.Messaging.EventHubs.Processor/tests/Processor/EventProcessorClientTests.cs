// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Storage.Blobs;
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
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), consumerGroup, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the consumer group.");
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
            Assert.That(() => new EventProcessorClient(null, "consumerGroup", "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentNullException>(), "The namespace constructor should validate the blob container client.");
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
        [TestCase("http://namspace.servciebus.windows.com")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
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
                Assert.That(actual.Identifier, Is.EqualTo(expected.Identifier),  $"The identifier is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.MaximumWaitTime, Is.EqualTo(expected.MaximumWaitTime),  $"The maximum wait time is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.TrackLastEnqueuedEventProperties, Is.EqualTo(expected.TrackLastEnqueuedEventProperties),  $"The last event tracking flag is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.DefaultStartingPosition, Is.EqualTo(expected.DefaultStartingPosition),  $"The default starting position is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.LoadBalancingUpdateInterval, Is.EqualTo(expected.LoadBalancingUpdateInterval),  $"The load balancing interval is incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.PartitionOwnershipExpirationInterval, Is.EqualTo(expected.PartitionOwnershipExpirationInterval),  $"The ownership expiration interval incorrect for the { constructorDescription } constructor.");
                Assert.That(actual.PrefetchCount, Is.EqualTo(expected.PrefetchCount),  $"The prefetch count is incorrect for the { constructorDescription } constructor.");
            }

            var clientOptions = new EventProcessorClientOptions
            {
               ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
               RetryOptions = new EventHubsRetryOptions { MaximumRetries = 99 },
               Identifier = "OMG, HAI!",
               MaximumWaitTime = TimeSpan.FromDays(54),
               TrackLastEnqueuedEventProperties = true
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

            // Internal testing constructor

            description = "{{ internal testing constructor }}";
            expectedOptions = new EventProcessorOptions();
            processorClient = new EventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "theHub", 100, Mock.Of<TokenCredential>(), expectedOptions);
            actualOptions = GetBaseOptions(processorClient);
            assertOptionsMatch(expectedOptions, actualOptions, description);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructors.
        /// </summary>
        ///
        [Test]
        public void ConstructorsPassesTheRetryPolicyToStorageManager()
        {
            void assertRetryPoliciesMatch(EventHubsRetryPolicy expected,
                                          EventProcessorClient target,
                                          string constructorDescription)
            {
                var storageManager = GetStorageManager(target);
                var retryPolicy = GetStorageManagerRetryPolicy(storageManager);

                Assert.That(retryPolicy, Is.EqualTo(expected), $"The retry policy was incorrect for the { constructorDescription } constructor.");
            }

            var expectedPolicy = Mock.Of<EventHubsRetryPolicy>();
            var clientOptions = new EventProcessorClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expectedPolicy } };

            string description;
            EventProcessorClient processorClient;

            // Connection String constructor

            description = "{{ connection string constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", clientOptions);
            assertRetryPoliciesMatch(expectedPolicy, processorClient, description);

            // Connection String and Event Hub Name constructor

            description = "{{ connection string with Event Hub name constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123", "theHub", clientOptions);
            assertRetryPoliciesMatch(expectedPolicy, processorClient, description);

            // Namespace constructor

            description = "{{ namespace constructor }}";
            processorClient = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "theHub", Mock.Of<TokenCredential>(), clientOptions);
            assertRetryPoliciesMatch(expectedPolicy, processorClient, description);
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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            Func<PartitionInitializingEventArgs, Task> initHandler = eventArgs => Task.CompletedTask;
            Func<PartitionClosingEventArgs, Task> closeHandler = eventArgs => Task.CompletedTask;
            Func<ProcessEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;

            processorClient.PartitionInitializingAsync += initHandler;
            processorClient.PartitionClosingAsync += closeHandler;
            processorClient.ProcessEventAsync += eventHandler;
            processorClient.ProcessErrorAsync +=errorHandler;

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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            processorClient.ProcessEventAsync += eventHandler;;
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
            var startingPosition = EventPosition.FromOffset(433);
            var options = new EventProcessorOptions { DefaultStartingPosition = startingPosition };
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
                new MockEventData(new byte[] { 0x11 }, offset: 123, sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: 456, sequenceNumber: 456)
            };

            var capturedEventArgs = new List<ProcessEventArgs>();
            var partitionId = "0";
            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockStorageManager
                .Setup(storage => storage.UpdateCheckpointAsync(It.IsAny<EventProcessorCheckpoint>(), It.IsAny<EventData>(), It.IsAny<CancellationToken>()))
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
                Assert.That(capturedEventArgs[index].Partition.PartitionId, Is.EqualTo(partitionId), $"The partition identifier should have been propagated at index { index }.");
                Assert.That(capturedEventArgs[index].Data.IsEquivalentTo(eventBatch[index]), Is.True, $"The event should have been propagated and order preserved at index { index }.");
                Assert.That(capturedEventArgs[index].CancellationToken, Is.EqualTo(cancellationSource.Token), $"The cancellation token should have been propagated at index { index }.");
                Assert.That(async () => await capturedEventArgs[index].UpdateCheckpointAsync(), Throws.Nothing, $"A checkpoint should be allowed for the event at index { index }.");

                var expectedStart = EventPosition.FromOffset(capturedEventArgs[index].Data.Offset);

                mockStorageManager
                    .Verify(storage => storage.UpdateCheckpointAsync(
                        It.Is<EventProcessorCheckpoint>(value => ((value.PartitionId == partitionId) && (value.StartingPosition == expectedStart))),
                        capturedEventArgs[index].Data,
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
            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.ProcessEventAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnProcessingEventBatchAsync(Enumerable.Empty<EventData>(), new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(capturedEventArgs, Is.Not.Null, "The event handler should have been fired.");
            Assert.That(capturedEventArgs.HasEvent, Is.False, "The event arguments should not contain an event.");
            Assert.That(capturedEventArgs.Partition.PartitionId, Is.EqualTo(partitionId), "The partition identifier should have been propagated.");
            Assert.That(capturedEventArgs.Data, Is.Null, "No event data should have been propagated.");
            Assert.That(capturedEventArgs.CancellationToken, Is.EqualTo(cancellationSource.Token), "The cancellation token should have been propagated.");
            Assert.That(async () => await capturedEventArgs.UpdateCheckpointAsync(), Throws.InstanceOf<InvalidOperationException>(), "A checkpoint cannot be created for an empty event.");

            mockStorageManager
                .Verify(storage => storage.UpdateCheckpointAsync(
                    It.IsAny<EventProcessorCheckpoint>(),
                    It.IsAny<EventData>(),
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
                new MockEventData(new byte[] { 0x11 }, offset: 123, sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: 456, sequenceNumber: 456)
            };

            var invokeCount = 0;
            var halfBatchCount = (int)Math.Floor(eventBatch.Length / 2.0f);
            var expectedException = new DivideByZeroException("Ruh Roh, Raggy!");
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

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
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            var eventBatch = Enumerable
                .Range(0, eventCount)
                .Select(index => new MockEventData(Array.Empty<byte>(), offset: 1000 + index,  sequenceNumber: 2000 + index))
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
                new MockEventData(new byte[] { 0x11 }, offset: 123, sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: 456, sequenceNumber: 456)
            };

            var partitionId = "3";
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += eventArgs => Task.CompletedTask;

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition(partitionId), cancellationSource.Token);

            mockLogger
                .Verify(log => log.EventBatchProcessingStart(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup),
                Times.Once);

            mockLogger
                .Verify(log => log.EventBatchProcessingComplete(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup),
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
                new MockEventData(new byte[] { 0x11 }, offset: 123, sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: 456, sequenceNumber: 456)
            };

            var partitionId = "3";
            var expectedException = new ApplicationException("Why is water wet?");
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += eventArgs => throw expectedException;

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition(partitionId), cancellationSource.Token).IgnoreExceptions();

            mockLogger
                .Verify(log => log.EventBatchProcessingError(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    expectedException.Message),
                Times.Exactly(eventBatch.Length));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsDelegatesToTheStorageManager()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockStorageManager
                .Setup(storage => storage.ListCheckpointsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(IEnumerable<EventProcessorCheckpoint>));

            await processorClient.InvokeListCheckpointsAsync(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockStorageManager
                .Verify(storage => storage.ListCheckpointsAsync(
                    processorClient.FullyQualifiedNamespace,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsIncludesInitializeEventHandlerStartingPositionWhenNoNaturalCheckpointExists()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "0";
            var startingPosition = EventPosition.FromOffset(433);
            var options = new EventProcessorOptions { DefaultStartingPosition = EventPosition.Latest };
            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

            var sourceCheckpoints = new[]
            {
                new EventProcessorCheckpoint { PartitionId = "7", StartingPosition = EventPosition.FromOffset(111) },
                new EventProcessorCheckpoint { PartitionId = "4", StartingPosition = EventPosition.FromOffset(222) }
            };

            mockStorageManager
                .Setup(storage => storage.ListCheckpointsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(sourceCheckpoints);

            processorClient.PartitionInitializingAsync += eventArgs =>
            {
                eventArgs.DefaultStartingPosition = startingPosition;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnInitializingPartitionAsync(new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var checkpoints = (await processorClient.InvokeListCheckpointsAsync(cancellationSource.Token))?.ToList();
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(checkpoints, Is.Not.Null, "A set of checkpoints should have been returned.");
            Assert.That(checkpoints.Count, Is.EqualTo(sourceCheckpoints.Length + 1), "The source checkpoints and the initialized partition should have been in the set.");

            var partitionCheckpoint = checkpoints.SingleOrDefault(checkpoint => checkpoint.PartitionId == partitionId);
            Assert.That(partitionCheckpoint, Is.Not.Null, "A checkpoint for the initialized partition should have been injected.");
            Assert.That(partitionCheckpoint.StartingPosition, Is.EqualTo(startingPosition), "The injected checkpoint should have respected the value that the initialization event handler set.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsPrefersNaturalCheckpointOverInitializeEventHandlerStartingPosition()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "0";
            var startingPosition = EventPosition.FromOffset(433);
            var checkpointStartingPosition = EventPosition.FromSequenceNumber(999);
            var options = new EventProcessorOptions { DefaultStartingPosition = EventPosition.Latest };
            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

            var sourceCheckpoints = new[]
            {
                new EventProcessorCheckpoint { PartitionId = "7", StartingPosition = EventPosition.FromOffset(111) },
                new EventProcessorCheckpoint { PartitionId = "4", StartingPosition = EventPosition.FromOffset(222) },
                new EventProcessorCheckpoint { PartitionId = partitionId, StartingPosition = checkpointStartingPosition }
            };

            mockStorageManager
                .Setup(storage => storage.ListCheckpointsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(sourceCheckpoints);

            processorClient.PartitionInitializingAsync += eventArgs =>
            {
                eventArgs.DefaultStartingPosition = startingPosition;
                return Task.CompletedTask;
            };

            await processorClient.InvokeOnInitializingPartitionAsync(new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var checkpoints = (await processorClient.InvokeListCheckpointsAsync(cancellationSource.Token))?.ToList();
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(checkpoints, Is.Not.Null, "A set of checkpoints should have been returned.");
            Assert.That(checkpoints.Count, Is.EqualTo(sourceCheckpoints.Length), "The source checkpoints should have been in the set.");

            var partitionCheckpoint = checkpoints.SingleOrDefault(checkpoint => checkpoint.PartitionId == partitionId);
            Assert.That(partitionCheckpoint, Is.Not.Null, "A checkpoint for the initialized partition should exist naturally.");
            Assert.That(partitionCheckpoint.StartingPosition, Is.EqualTo(checkpointStartingPosition), "The natural checkpoint should have respected the value that the initialization event handler set.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsReturnsNaturalCheckpointsWhenNoInitializeEventHandlerIsRegistered()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "0";
            var options = new EventProcessorOptions { DefaultStartingPosition = EventPosition.Latest };
            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), options);

            var sourceCheckpoints = new[]
            {
                new EventProcessorCheckpoint { PartitionId = "7", StartingPosition = EventPosition.FromOffset(111) },
                new EventProcessorCheckpoint { PartitionId = "4", StartingPosition = EventPosition.FromOffset(222) }
            };

            mockStorageManager
                .Setup(storage => storage.ListCheckpointsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(sourceCheckpoints);

            await processorClient.InvokeOnInitializingPartitionAsync(new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var checkpoints = (await processorClient.InvokeListCheckpointsAsync(cancellationSource.Token))?.ToList();
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(checkpoints, Is.Not.Null, "A set of checkpoints should have been returned.");
            Assert.That(checkpoints.Count, Is.EqualTo(sourceCheckpoints.Length), "The source checkpoints should have been in the set.");

            var partitionCheckpoint = checkpoints.SingleOrDefault(checkpoint => checkpoint.PartitionId == partitionId);
            Assert.That(partitionCheckpoint, Is.Null, "No handler was registered for the partition; no checkpoint should have been injected.");

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

            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockStorageManager
                .Setup(storage => storage.ListOwnershipAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(IEnumerable<EventProcessorPartitionOwnership>));

            await processorClient.InvokeListOwnershipAsync(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockStorageManager
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
            var mockStorageManager = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorageManager.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockStorageManager
                .Setup(storage => storage.ClaimOwnershipAsync(It.IsAny<IEnumerable<EventProcessorPartitionOwnership>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(IEnumerable<EventProcessorPartitionOwnership>));

            await processorClient.InvokeClaimOwnershipAsync(desiredOwnership, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockStorageManager
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
            var eventData = new MockEventData(Array.Empty<byte>(), offset: 456, sequenceNumber: 789);
            var mockStorage = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            await processorClient.UpdateCheckpointAsync(eventData, new Mock<PartitionContext>(partitionId).Object, cancellationSource.Token);

            mockStorage
                .Verify(storage => storage.UpdateCheckpointAsync(
                    It.Is<EventProcessorCheckpoint>(value => value.PartitionId == partitionId),
                    eventData,
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

            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            Assert.That(async () => await processorClient.UpdateCheckpointAsync(new EventData(Array.Empty<byte>()), default, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
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
            var eventData = new MockEventData(Array.Empty<byte>(), offset: 456, sequenceNumber: 789);
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            await processorClient.UpdateCheckpointAsync(eventData, new Mock<PartitionContext>(partitionId).Object, cancellationSource.Token);

            mockLogger
                .Verify(log => log.UpdateCheckpointStart(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup),
                Times.Once);

            mockLogger
                .Verify(log => log.UpdateCheckpointComplete(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup),
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
            var eventData = new MockEventData(Array.Empty<byte>(), offset: 456, sequenceNumber: 789);
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var mockStorage = new Mock<StorageManager>();
            var processorClient = new TestEventProcessorClient(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            mockStorage
                .Setup(storage => storage.UpdateCheckpointAsync(It.IsAny<EventProcessorCheckpoint>(), It.IsAny<EventData>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            processorClient.Logger = mockLogger.Object;
            Assert.That(async () => await processorClient.UpdateCheckpointAsync(eventData, new Mock<PartitionContext>(partitionId).Object, cancellationSource.Token), Throws.Exception.EqualTo(expectedException));

            mockLogger
                .Verify(log => log.UpdateCheckpointError(
                    partitionId,
                    processorClient.Identifier,
                    processorClient.EventHubName,
                    processorClient.ConsumerGroup,
                    expectedException.Message),
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
               PrefetchCount = 9990
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

            Assert.That(processorOptions.DefaultStartingPosition, Is.EqualTo(defaultOptions.DefaultStartingPosition), "The default starting position should not have been set.");
            Assert.That(processorOptions.LoadBalancingUpdateInterval, Is.EqualTo(defaultOptions.LoadBalancingUpdateInterval), "The load balancing interval should not have been set.");
            Assert.That(processorOptions.PartitionOwnershipExpirationInterval, Is.EqualTo(defaultOptions.PartitionOwnershipExpirationInterval), "The partition ownership interval should not have been set.");
        }

        /// <summary>
        ///   Retrieves the StorageManager for the processor client using its private accessor.
        /// </summary>
        ///
        private static BlobsCheckpointStore GetStorageManager(EventProcessorClient client) =>
            (BlobsCheckpointStore)
            typeof(EventProcessorClient)
                .GetProperty("StorageManager", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client);

        /// <summary>
        ///   Retrieves the RetryPolicy for the storage manager using its private accessor.
        /// </summary>
        ///
        private static EventHubsRetryPolicy GetStorageManagerRetryPolicy(BlobsCheckpointStore storageManager) =>
            (EventHubsRetryPolicy)
            typeof(BlobsCheckpointStore)
                .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageManager);

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

            internal TestEventProcessorClient(StorageManager storageManager,
                                              string consumerGroup,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              TokenCredential credential,
                                              EventHubConnection connection,
                                              EventProcessorOptions options) : base(storageManager, consumerGroup, fullyQualifiedNamespace, eventHubName, 100, credential, options)
            {
                InjectedConnection = connection;
            }

            public Task InvokeOnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken) => base.OnProcessingEventBatchAsync(events, partition, cancellationToken);
            public Task InvokeOnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken) => base.OnProcessingErrorAsync(exception, partition, operationDescription, cancellationToken);
            public Task InvokeOnInitializingPartitionAsync(EventProcessorPartition partition, CancellationToken cancellationToken) => base.OnInitializingPartitionAsync(partition, cancellationToken);
            public Task InvokeOnPartitionProcessingStoppedAsync(EventProcessorPartition partition, ProcessingStoppedReason reason, CancellationToken cancellationToken) => base.OnPartitionProcessingStoppedAsync(partition, reason, cancellationToken);
            public Task<IEnumerable<EventProcessorCheckpoint>> InvokeListCheckpointsAsync(CancellationToken cancellationToken) => base.ListCheckpointsAsync(cancellationToken);
            public Task<IEnumerable<EventProcessorPartitionOwnership>> InvokeListOwnershipAsync(CancellationToken cancellationToken) => base.ListOwnershipAsync(cancellationToken);
            public Task<IEnumerable<EventProcessorPartitionOwnership>> InvokeClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) => base.ClaimOwnershipAsync(desiredOwnership, cancellationToken);
            protected override EventHubConnection CreateConnection() => InjectedConnection;
        }

        /// <summary>
        ///   A mock <see cref="EventProcessorPartition" /> used for testing purposes.
        /// </summary>
        ///
        public class TestEventProcessorPartition : EventProcessorPartition
        {
            public TestEventProcessorPartition(string partitionId) { PartitionId = partitionId; }
        }
    }
}
