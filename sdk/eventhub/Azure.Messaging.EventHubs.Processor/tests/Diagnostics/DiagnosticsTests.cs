// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Storage.Blobs;
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
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointManagerCreatesScope()
        {
            using ClientDiagnosticListener listener = new ClientDiagnosticListener(DiagnosticSourceName);

            var eventHubName = "SomeName";
            var endpoint = new Uri("amqp://some.endpoint.com/path");
            Func<EventHubConnection> fakeFactory = () => new MockConnection(endpoint, eventHubName);
            var context = new MockPartitionContext("partition");
            var data = new MockEventData(new byte[0], sequenceNumber: 0, offset: 0);

            var storageManager = new Mock<PartitionManager>();
            var eventProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "cg", endpoint.Host, eventHubName, fakeFactory, null, null);

            storageManager
                .Setup(manager => manager.UpdateCheckpointAsync(It.IsAny<Checkpoint>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            eventProcessor
                .Setup(processor => processor.CreateStorageManager(It.IsAny<BlobContainerClient>()))
                .Returns(storageManager.Object);

            await eventProcessor.Object.UpdateCheckpointAsync(data, context, default);

            ClientDiagnosticListener.ProducedDiagnosticScope scope = listener.Scopes.Single();
            Assert.That(scope.Name, Is.EqualTo(DiagnosticProperty.EventProcessorCheckpointActivityName));
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="PartitionPump" />
        ///   class.
        /// </summary>
        ///
        [Test]
        [Ignore("Needs to be updated because Partition Pump class does not exist anymore.")]
        public async Task PartitionPumpCreatesScopeForEventProcessing()
        {
            // ================================================================
            //  FIGURE OUT A WAY TO IMPLEMENT THIS MOCKING THE CONSUMER CLIENT
            //
            //  Likely needs an internal extension point within the processor
            // ================================================================


            //using ClientDiagnosticListener listener = new ClientDiagnosticListener(DiagnosticSourceName);
            //var processorCalledSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            //var consumerMock = new Mock<TransportConsumer>();
            //bool returnedItems = false;
            //consumerMock.Setup(c => c.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
            //    .Returns(() =>
            //    {
            //        if (returnedItems)
            //        {
            //            throw new InvalidOperationException("Something bad happened");
            //        }

            //        returnedItems = true;
            //        return Task.FromResult(
            //            (IEnumerable<EventData>)new[]
            //            {
            //                new EventData(Array.Empty<byte>())
            //                {
            //                    Properties =
            //                    {
            //                        { "Diagnostic-Id", "id" }
            //                    }
            //                },
            //                new EventData(Array.Empty<byte>())
            //                {
            //                    Properties =
            //                    {
            //                        { "Diagnostic-Id", "id2" }
            //                    }
            //                }
            //            });
            //    });

            //var connectionMock = new Mock<EventHubConnection>("namespace", "eventHubName", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            //connectionMock.Setup(c => c.CreateTransportConsumer("cg", "pid", It.IsAny<EventPosition>(), It.IsAny<EventHubsRetryPolicy>(), It.IsAny<bool>(), It.IsAny<long?>(), It.IsAny<uint?>())).Returns(consumerMock.Object);

            //Func<ProcessEventArgs, ValueTask> processEventAsync = eventArgs =>
            //{
            //    processorCalledSource.SetResult(null);
            //    return new ValueTask();
            //};

            // TODO: partition pump type does not exist anymore. Figure out how to call RunPartitionProcessingAsync.

            await Task.CompletedTask;

            /*

            var manager = new PartitionPump(connectionMock.Object, "cg", new PartitionContext("eventHubName", "pid"), EventPosition.Earliest, processEventAsync, new EventProcessorClientOptions());

            await manager.StartAsync();
            await processorCalledSource.Task;

            // TODO: figure out why an exception is being thrown. The problem has always existed, but now the Pump won't swallow exceptions
            // and throws them back to the caller.

            try
            {
                await manager.StopAsync();
            }
            catch (InvalidOperationException) { }

            */

            //ClientDiagnosticListener.ProducedDiagnosticScope scope = listener.Scopes.Single();
            //Assert.That(scope.Name, Is.EqualTo(DiagnosticProperty.EventProcessorProcessingActivityName));
            //Assert.That(scope.Links, Has.One.EqualTo("id"));
            //Assert.That(scope.Links, Has.One.EqualTo("id2"));
            //Assert.That(scope.Activity.Tags, Has.One.EqualTo(new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ServerKind)), "The activities tag should be server.");
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

        private class MockEventData : EventData
        {
            public MockEventData(ReadOnlyMemory<byte> eventBody,
                                 IDictionary<string, object> properties = null,
                                 IReadOnlyDictionary<string, object> systemProperties = null,
                                 long? sequenceNumber = null,
                                 long? offset = null,
                                 DateTimeOffset? enqueuedTime = null,
                                 string partitionKey = null) : base(eventBody, properties, systemProperties, sequenceNumber, offset, enqueuedTime, partitionKey)
            {
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
