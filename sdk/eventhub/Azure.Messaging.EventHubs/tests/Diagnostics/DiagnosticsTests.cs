﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
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
    [TestFixture]
    public class DiagnosticsTests
    {
        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerCreatesDiagnosticScopeOnSend()
        {
            using var testListener = new ClientDiagnosticListener(EventDataInstrumentation.DiagnosticNamespace);
            var activity = new Activity("SomeActivity").Start();

            var eventHubName = "SomeName";
            var endpoint = "endpoint";
            var fakeConnection = new MockConnection(endpoint, eventHubName);
            var transportMock = new Mock<TransportProducer>();

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            var eventData = new EventData(ReadOnlyMemory<byte>.Empty);
            await producer.SendAsync(eventData);

            activity.Stop();

            ClientDiagnosticListener.ProducedDiagnosticScope sendScope = testListener.AssertScope(DiagnosticProperty.ProducerActivityName,
                new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ClientKind),
                new KeyValuePair<string, string>(DiagnosticProperty.ServiceContextAttribute, DiagnosticProperty.EventHubsServiceContext),
                new KeyValuePair<string, string>(DiagnosticProperty.EventHubAttribute, eventHubName),
                new KeyValuePair<string, string>(DiagnosticProperty.EndpointAttribute, endpoint));

            ClientDiagnosticListener.ProducedDiagnosticScope messageScope = testListener.AssertScope(DiagnosticProperty.EventActivityName,
                new KeyValuePair<string, string>(DiagnosticProperty.EventHubAttribute, eventHubName),
                new KeyValuePair<string, string>(DiagnosticProperty.EndpointAttribute, endpoint));

            Assert.That(eventData.Properties[DiagnosticProperty.DiagnosticIdAttribute], Is.EqualTo(messageScope.Activity.Id), "The diagnostics identifier should match.");
            Assert.That(messageScope.Activity.Tags, Has.One.EqualTo(new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ProducerKind)), "The activities tag should be internal.");
            Assert.That(messageScope.Activity, Is.Not.SameAs(sendScope.Activity), "The activities should not be the same instance.");
            Assert.That(sendScope.Activity.ParentId, Is.EqualTo(activity.Id), "The send scope's parent identifier should match the activity in the active scope.");
            Assert.That(messageScope.Activity.ParentId, Is.EqualTo(activity.Id), "The message scope's parent identifier should match the activity in the active scope.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerCreatesDiagnosticScopeOnBatchSend()
        {
            using var testListener = new ClientDiagnosticListener(EventDataInstrumentation.DiagnosticNamespace);
            var activity = new Activity("SomeActivity").Start();

            var eventCount = 0;
            var eventHubName = "SomeName";
            var endpoint = "endpoint";
            var batchEvent = default(EventData);
            var fakeConnection = new MockConnection(endpoint, eventHubName);
            var batchTransportMock = new Mock<TransportEventBatch>();

            batchTransportMock
                .Setup(m => m.TryAdd(It.IsAny<EventData>()))
                .Callback<EventData>(addedEvent => batchEvent = addedEvent)
                .Returns(() =>
                {
                    eventCount++;
                    return eventCount <= 1;
                });

            batchTransportMock
                .Setup(m => m.Count)
                .Returns(1);

            var transportMock = new Mock<TransportProducer>();

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            transportMock
                .Setup(m => m.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<TransportEventBatch>(Task.FromResult(batchTransportMock.Object)));

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            var eventData = new EventData(ReadOnlyMemory<byte>.Empty);
            var batch = await producer.CreateBatchAsync();
            Assert.That(batch.TryAdd(eventData), Is.True);

            await producer.SendAsync(batch);
            activity.Stop();

            ClientDiagnosticListener.ProducedDiagnosticScope sendScope = testListener.AssertScope(DiagnosticProperty.ProducerActivityName,
                new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ClientKind),
                new KeyValuePair<string, string>(DiagnosticProperty.ServiceContextAttribute, DiagnosticProperty.EventHubsServiceContext),
                new KeyValuePair<string, string>(DiagnosticProperty.EventHubAttribute, eventHubName),
                new KeyValuePair<string, string>(DiagnosticProperty.EndpointAttribute, endpoint));

            ClientDiagnosticListener.ProducedDiagnosticScope messageScope = testListener.AssertScope(DiagnosticProperty.EventActivityName,
                new KeyValuePair<string, string>(DiagnosticProperty.EventHubAttribute, eventHubName),
                new KeyValuePair<string, string>(DiagnosticProperty.EndpointAttribute, endpoint));

            Assert.That(batchEvent.Properties[DiagnosticProperty.DiagnosticIdAttribute], Is.EqualTo(messageScope.Activity.Id), "The diagnostics identifier should match.");
            Assert.That(messageScope.Activity, Is.Not.SameAs(sendScope.Activity), "The activities should not be the same instance.");
            Assert.That(sendScope.Activity.ParentId, Is.EqualTo(activity.Id), "The send scope's parent identifier should match the activity in the active scope.");
            Assert.That(messageScope.Activity.ParentId, Is.EqualTo(activity.Id), "The message scope's parent identifier should match the activity in the active scope.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerAppliesDiagnosticIdToEventsOnSend()
        {
            Activity activity = new Activity("SomeActivity").Start();

            var eventHubName = "SomeName";
            var endpoint = "some.endpoint.com";
            var fakeConnection = new MockConnection(endpoint, eventHubName);
            var transportMock = new Mock<TransportProducer>();

            EventData[] writtenEventsData = null;

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Callback<IEnumerable<EventData>, SendEventOptions, CancellationToken>((e, _, __) => writtenEventsData = e.ToArray())
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            await producer.SendAsync(new[]
            {
                new EventData(ReadOnlyMemory<byte>.Empty),
                new EventData(ReadOnlyMemory<byte>.Empty)
            });

            activity.Stop();
            Assert.That(writtenEventsData.Length, Is.EqualTo(2), "All events should have been instrumented.");

            foreach (EventData eventData in writtenEventsData)
            {
                Assert.That(eventData.Properties.TryGetValue(DiagnosticProperty.DiagnosticIdAttribute, out object value), Is.True, "The events should have a diagnostic identifier property.");
                Assert.That(value, Is.EqualTo(activity.Id), "The diagnostics identifier should match the activity in the active scope.");
            }
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerAppliesDiagnosticIdToEventsOnBatchSend()
        {
            Activity activity = new Activity("SomeActivity").Start();

            var eventHubName = "SomeName";
            var endpoint = "some.endpoint.com";
            var writtenEventsData = new List<EventData>();
            var batchTransportMock = new Mock<TransportEventBatch>();
            var fakeConnection = new MockConnection(endpoint, eventHubName);
            var transportMock = new Mock<TransportProducer>();

            batchTransportMock
                .Setup(m => m.TryAdd(It.IsAny<EventData>()))
                .Returns<EventData>(e =>
                {
                    var hasSpace = writtenEventsData.Count <= 1;
                    if (hasSpace)
                    {
                        writtenEventsData.Add(e);
                    }
                    return hasSpace;
                });

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            transportMock
                .Setup(m => m.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<TransportEventBatch>(Task.FromResult(batchTransportMock.Object)));

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            var eventData1 = new EventData(ReadOnlyMemory<byte>.Empty);
            var eventData2 = new EventData(ReadOnlyMemory<byte>.Empty);
            var eventData3 = new EventData(ReadOnlyMemory<byte>.Empty);

            EventDataBatch batch = await producer.CreateBatchAsync();

            Assert.That(batch.TryAdd(eventData1), Is.True, "The first event should have been added to the batch.");
            Assert.That(batch.TryAdd(eventData2), Is.True, "The second event should have been added to the batch.");
            Assert.That(batch.TryAdd(eventData3), Is.False, "The third event should not have been added to the batch.");

            await producer.SendAsync(batch);

            activity.Stop();
            Assert.That(writtenEventsData.Count, Is.EqualTo(2), "Each of the events in the batch should have been instrumented.");

            foreach (EventData eventData in writtenEventsData)
            {
                Assert.That(eventData.Properties.TryGetValue(DiagnosticProperty.DiagnosticIdAttribute, out object value), Is.True, "The events should have a diagnostic identifier property.");
                Assert.That(value, Is.EqualTo(activity.Id), "The diagnostics identifier should match the activity in the active scope.");
            }

            Assert.That(eventData3.Properties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute), Is.False, "Events that were not accepted into the batch should not have been instrumented.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerLinksSendScopeToMessageScopesOnSend()
        {
            using var testListener = new ClientDiagnosticListener(EventDataInstrumentation.DiagnosticNamespace);

            var fakeConnection = new MockConnection("some.endpoint.com", "SomeName");
            var transportMock = new Mock<TransportProducer>();

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            await producer.SendAsync(new[]
            {
                new EventData(ReadOnlyMemory<byte>.Empty, new Dictionary<string, object> { { DiagnosticProperty.DiagnosticIdAttribute, "id" } }),
                new EventData(ReadOnlyMemory<byte>.Empty, new Dictionary<string, object> { { DiagnosticProperty.DiagnosticIdAttribute, "id2" } })
            });

            ClientDiagnosticListener.ProducedDiagnosticScope sendScope = testListener.Scopes.Single(s => s.Name == DiagnosticProperty.ProducerActivityName);

            var expectedLinks = new List<string>() { "id", "id2" };
            var links = sendScope.Links.ToList();

            Assert.That(links.Count, Is.EqualTo(expectedLinks.Count), "The amount of links should be the same as the amount of events that were sent.");
            Assert.That(links, Is.EquivalentTo(expectedLinks), "The links should be identical to the diagnostic ids in the events that were sent.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerLinksSendScopeToMessageScopesOnBatchSend()
        {
            using var testListener = new ClientDiagnosticListener(EventDataInstrumentation.DiagnosticNamespace);

            var writtenEventsData = 0;
            var batchTransportMock = new Mock<TransportEventBatch>();
            var fakeConnection = new MockConnection("some.endpoint.com", "SomeName");
            var transportMock = new Mock<TransportProducer>();

            batchTransportMock
                .Setup(m => m.TryAdd(It.IsAny<EventData>()))
                .Returns<EventData>(e =>
                {
                    var hasSpace = writtenEventsData <= 1;
                    if (hasSpace)
                    {
                        ++writtenEventsData;
                    }
                    return hasSpace;
                });

            batchTransportMock
                .Setup(m => m.Count)
                .Returns(2);

            transportMock
                .Setup(m => m.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<TransportEventBatch>(Task.FromResult(batchTransportMock.Object)));

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            var eventData1 = new EventData(ReadOnlyMemory<byte>.Empty, new Dictionary<string, object> { { DiagnosticProperty.DiagnosticIdAttribute, "id" } });
            var eventData2 = new EventData(ReadOnlyMemory<byte>.Empty, new Dictionary<string, object> { { DiagnosticProperty.DiagnosticIdAttribute, "id2" } });
            var eventData3 = new EventData(ReadOnlyMemory<byte>.Empty, new Dictionary<string, object> { { DiagnosticProperty.DiagnosticIdAttribute, "id3" } });

            EventDataBatch batch = await producer.CreateBatchAsync();

            Assert.That(batch.TryAdd(eventData1), Is.True, "The first event should have been added to the batch.");
            Assert.That(batch.TryAdd(eventData2), Is.True, "The second event should have been added to the batch.");
            Assert.That(batch.TryAdd(eventData3), Is.False, "The third event should not have been added to the batch.");

            await producer.SendAsync(batch);

            ClientDiagnosticListener.ProducedDiagnosticScope sendScope = testListener.Scopes.Single(s => s.Name == DiagnosticProperty.ProducerActivityName);

            var expectedLinks = new List<string>() { "id", "id2" };
            var links = sendScope.Links.ToList();

            Assert.That(links.Count, Is.EqualTo(expectedLinks.Count), "The amount of links should be the same as the amount of events that were sent.");
            Assert.That(links, Is.EquivalentTo(expectedLinks), "The links should be identical to the diagnostic ids in the events that were sent.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventProcesorCreatesScopeForEventProcessing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            using var listener = new ClientDiagnosticListener(EventDataInstrumentation.DiagnosticNamespace);

            var enqueuedTime = DateTimeOffset.UtcNow;
            var diagnosticId = 12;
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var fullyQualifiedNamespace = "namespace";
            var eventHubName = "eventHub";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", fullyQualifiedNamespace, eventHubName, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            var eventBatch = new List<EventData>
            {
                new EventData(Array.Empty<byte>(), enqueuedTime: enqueuedTime),
                new EventData(Array.Empty<byte>(), enqueuedTime: enqueuedTime)
            };

            eventBatch.ForEach(evt => evt.Properties.Add(DiagnosticProperty.DiagnosticIdAttribute, (++diagnosticId).ToString()));
            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            // Validate the diagnostics.

            diagnosticId -= eventBatch.Count;

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ConsumerKind),
                new KeyValuePair<string, string>(DiagnosticProperty.EventHubAttribute, eventHubName),
                new KeyValuePair<string, string>(DiagnosticProperty.EndpointAttribute, fullyQualifiedNamespace)
            };

            var scopes = listener.Scopes.ToList();

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(scopes.Select(scope => scope.Name), Has.All.EqualTo(DiagnosticProperty.EventProcessorProcessingActivityName), "The processing scopes should have the correct name.");

            for (var index = 0; index < eventBatch.Count; ++index)
            {
                var targetId = (++diagnosticId).ToString();
                Assert.That(scopes.SelectMany(scope => scope.Links), Has.One.EqualTo(targetId), $"There should have been a link for the diagnostic identifier: { targetId }");
            }

            foreach (var scope in scopes)
            {
                Assert.That(expectedTags, Is.SubsetOf(scope.Activity.Tags.ToList()));
            }
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventProcesorAddsAttributesToLinkedActivitiesForEventProcessing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            using var listener = new ClientDiagnosticListener(EventDataInstrumentation.DiagnosticNamespace);

            var enqueuedTime = DateTimeOffset.UtcNow;
            var diagnosticId = "OMGHAI2U!";
            var eventBatch = new List<EventData> { new EventData(Array.Empty<byte>(), enqueuedTime: enqueuedTime) };
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var fullyQualifiedNamespace = "namespace";
            var eventHubName = "eventHub";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", fullyQualifiedNamespace, eventHubName, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            eventBatch.ForEach(evt => evt.Properties.Add(DiagnosticProperty.DiagnosticIdAttribute, diagnosticId));
            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            // Validate the diagnostics.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var processingScope = listener.Scopes.SingleOrDefault(scope => scope.Name == DiagnosticProperty.EventProcessorProcessingActivityName);
            Assert.That(processingScope, Is.Not.Null, "There should have been a single scope present for the processing activity.");

            var linkedActivity = processingScope.LinkedActivities.SingleOrDefault(a => a.ParentId == diagnosticId);
            Assert.That(linkedActivity, Is.Not.Null, "There should have been a single activity linked to the diagnostic identifier.");

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.EnqueuedTimeAttribute, enqueuedTime.ToUnixTimeMilliseconds().ToString())
            };

            var tags = linkedActivity.Tags.ToList();
            Assert.That(tags, Is.EquivalentTo(expectedTags), "The activity should have been tagged appropriately.");
        }

        /// <summary>
        ///   A minimal mock connection, allowing the public attributes
        ///   used with diagnostics to be set.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            private const string MockConnectionStringFormat = "Endpoint={0};SharedAccessKeyName=[value];SharedAccessKey=[value];";

            public MockConnection(string serviceEndpoint,
                                  string eventHubName) : base(string.Format(MockConnectionStringFormat, serviceEndpoint), eventHubName)
            {
            }

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace,
                                                                    string eventHubName,
                                                                    EventHubTokenCredential credential,
                                                                    EventHubConnectionOptions options) => Mock.Of<TransportClient>();
        }
    }
}
