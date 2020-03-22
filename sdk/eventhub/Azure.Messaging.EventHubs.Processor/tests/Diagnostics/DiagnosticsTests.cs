// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Tests;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   The suite of tests for validating the diagnostics instrumentation
    ///   of the client library.  These tests are not constrained to a specific
    ///   class or functional area.
    /// </summary>
    ///
    /// <remarks>
    ///   Every instrumented operation will trigger diagnostics activities as
    ///   long as they are being listened to, making it possible for other
    ///   tests to interfere with these. For this reason, these tests are
    ///   marked as non-parallelizable.
    /// </remarks>
    ///
    [NonParallelizable]
    public class DiagnosticsTests
    {
        /// <summary>The name of the diagnostics source being tested.</summary>
        private const string DiagnosticSourceName = "Azure.Messaging.EventHubs";

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [Ignore("Unstable test. (Tracked by: #10067)")]
        public async Task UpdateCheckpointAsyncCreatesScope()
        {
            using ClientDiagnosticListener listener = new ClientDiagnosticListener(DiagnosticSourceName);

            var eventHubName = "SomeName";
            var endpoint = new Uri("amqp://some.endpoint.com/path");
            Func<EventHubConnection> fakeFactory = () => new MockConnection(endpoint, eventHubName);
            var context = new MockPartitionContext("partition");
            var data = new MockEventData(new byte[0], sequenceNumber: 0, offset: 0);

            var storageManager = new Mock<StorageManager>();
            var eventProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "cg", endpoint.Host, eventHubName, fakeFactory, null, null);

            // UpdateCheckpointAsync does not invoke the handlers, but we are setting them here in case
            // this fact changes in the future.

            eventProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            eventProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            await eventProcessor.Object.UpdateCheckpointAsync(data, context, default);

            ClientDiagnosticListener.ProducedDiagnosticScope scope = listener.Scopes.Single();
            Assert.That(scope.Name, Is.EqualTo(DiagnosticProperty.EventProcessorCheckpointActivityName));
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.RunPartitionProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [Ignore("Unstable test. (Tracked by: #10067)")]
        public async Task RunPartitionProcessingAsyncCreatesScopeForEventProcessing()
        {
            string fullyQualifiedNamespace = "namespace";
            string eventHubName = "eventHub";

            var mockStorage = new MockCheckPointStorage();
            var mockConsumer = new Mock<EventHubConsumerClient>("cg", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(mockStorage, "cg", fullyQualifiedNamespace, eventHubName, Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            using ClientDiagnosticListener listener = new ClientDiagnosticListener(DiagnosticSourceName);
            var completionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            var processEventCalls = 0;

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partitionId, position, options, token) =>
                {
                    async IAsyncEnumerable<PartitionEvent> mockPartitionEventEnumerable()
                    {
                        var context = new MockPartitionContext(partitionId);

                        yield return new PartitionEvent(context, new EventData(Array.Empty<byte>()) { Properties = { { DiagnosticProperty.DiagnosticIdAttribute, "id" } } });
                        yield return new PartitionEvent(context, new EventData(Array.Empty<byte>()) { Properties = { { DiagnosticProperty.DiagnosticIdAttribute, "id2" } } });

                        while (!completionSource.Task.IsCompleted && !token.IsCancellationRequested)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                            yield return new PartitionEvent();
                        }

                        yield break;
                    };

                    return mockPartitionEventEnumerable();
                });

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs =>
            {
                if (++processEventCalls == 2)
                {
                    completionSource.SetResult(null);
                }

                return Task.CompletedTask;
            };

            // RunPartitionProcessingAsync does not invoke the error handler, but we are setting it here in case
            // this fact changes in the future.

            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Start processing and wait for the consumer to be invoked.  Set a cancellation for backup to ensure
            // that the test completes deterministically.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            using var partitionProcessingTask = Task.Run(() => mockProcessor.Object.RunPartitionProcessingAsync("pid", default, cancellationSource.Token));
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), partitionProcessingTask);

            // Validate that cancellation did not take place.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            // Validate diagnostics functionality.

            Assert.That(listener.Scopes.Select(s => s.Name), Has.All.EqualTo(DiagnosticProperty.EventProcessorProcessingActivityName));
            Assert.That(listener.Scopes.SelectMany(s => s.Links), Has.One.EqualTo("id"));
            Assert.That(listener.Scopes.SelectMany(s => s.Links), Has.One.EqualTo("id2"));

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ConsumerKind),
                new KeyValuePair<string, string>(DiagnosticProperty.EventHubAttribute, eventHubName),
                new KeyValuePair<string, string>(DiagnosticProperty.EndpointAttribute, fullyQualifiedNamespace)
            };

            foreach (var scope in listener.Scopes)
            {
                Assert.That(expectedTags, Is.SubsetOf(scope.Activity.Tags.ToList()));
            }
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.RunPartitionProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task RunPartitionProcessingAsyncAddsAttributesToLinkedActivities()
        {
            string fullyQualifiedNamespace = "namespace";
            string eventHubName = "eventHub";

            var mockStorage = new MockCheckPointStorage();
            var mockConsumer = new Mock<EventHubConsumerClient>("cg", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(mockStorage, "cg", fullyQualifiedNamespace, eventHubName, Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };
            var enqueuedTime = DateTimeOffset.UtcNow;

            using ClientDiagnosticListener listener = new ClientDiagnosticListener(DiagnosticSourceName);
            var completionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            var processEventCalled = false;

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partitionId, position, options, token) =>
                {
                    async IAsyncEnumerable<PartitionEvent> mockPartitionEventEnumerable()
                    {
                        var context = new MockPartitionContext(partitionId);

                        yield return new PartitionEvent(context, new MockEventData(Array.Empty<byte>(), enqueuedTime: enqueuedTime) { Properties = { { DiagnosticProperty.DiagnosticIdAttribute, "id" } } });

                        while (!completionSource.Task.IsCompleted && !token.IsCancellationRequested)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                            yield return new PartitionEvent();
                        }

                        yield break;
                    };

                    return mockPartitionEventEnumerable();
                });

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs =>
            {
                if (!processEventCalled)
                {
                    processEventCalled = true;
                    completionSource.SetResult(null);
                }

                return Task.CompletedTask;
            };

            // RunPartitionProcessingAsync does not invoke the error handler, but we are setting it here in case
            // this fact changes in the future.

            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Start processing and wait for the consumer to be invoked.  Set a cancellation for backup to ensure
            // that the test completes deterministically.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            using var partitionProcessingTask = Task.Run(() => mockProcessor.Object.RunPartitionProcessingAsync("pid", default, cancellationSource.Token));
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), partitionProcessingTask);

            // Validate that cancellation did not take place.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            // Validate diagnostics functionality.

            var processingScope = listener.Scopes.Single(s => s.Name == DiagnosticProperty.EventProcessorProcessingActivityName);
            var linkedActivity = processingScope.LinkedActivities.Single(a => a.ParentId == "id");

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.EnqueuedTimeAttribute, enqueuedTime.ToUnixTimeMilliseconds().ToString())
            };

            Assert.That(linkedActivity.Tags, Is.EquivalentTo(expectedTags));
        }

        private class MockConnection : EventHubConnection
        {
            private const string MockConnectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];";
            public Uri ServiceEndpoint;

            public MockConnection(Uri serviceEndpoint,
                                  string eventHubName) : base(MockConnectionString, eventHubName)
            {
                ServiceEndpoint = serviceEndpoint;
            }
        }

        private class MockPartitionContext : PartitionContext
        {
            public MockPartitionContext(string partitionId) : base(partitionId)
            {
            }
        }
    }
}
