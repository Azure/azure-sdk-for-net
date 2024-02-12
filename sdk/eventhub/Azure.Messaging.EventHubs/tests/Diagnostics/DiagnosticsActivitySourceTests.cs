// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Core.TestFramework;
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
#if NET5_0_OR_GREATER
    /// <summary>
    ///   The suite of tests for validating the diagnostics instrumentation
    ///   of the client library when ActivitySource is enabled.  These tests are not constrained to a specific
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
    public class DiagnosticsActivitySourceTests
    {
        /// <summary>
        ///   Resets the activity source feature switch after each test.
        /// </summary>
        ///
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            ActivityExtensions.ResetFeatureSwitch();
        }

        /// <summary>
        ///   Verifies diagnostics functionality is off without feature flag.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerActivitySourceDisabled()
        {
            using var testListener = new TestActivitySourceListener(DiagnosticProperty.DiagnosticNamespace);
            var fakeConnection = new MockConnection("SomeName", "endpoint");
            var transportMock = new Mock<TransportProducer>();

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);
            await producer.SendAsync(new[] { new EventData(ReadOnlyMemory<byte>.Empty) });

            Assert.IsEmpty(testListener.Activities);
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerCreatesDiagnosticScopeOnSend()
        {
            using var _ = SetAppConfigSwitch();
            using var testListener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            var activity = new Activity("SomeActivity").Start();

            var eventHubName = "SomeName";
            var endpoint = "endpoint";
            var fakeConnection = new MockConnection(endpoint, eventHubName);
            var transportMock = new Mock<TransportProducer>();

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            var eventData = new EventData(ReadOnlyMemory<byte>.Empty);
            await producer.SendAsync(new[] { eventData });

            activity.Stop();

            Activity messageActivity = testListener.AssertAndRemoveActivity(DiagnosticProperty.EventActivityName);
            AssertCommonTags(messageActivity, eventHubName, endpoint, default, 1);
            Assert.AreEqual(DiagnosticProperty.DiagnosticNamespace + ".Message", messageActivity.Source.Name);

            Activity sendActivity = testListener.AssertAndRemoveActivity(DiagnosticProperty.ProducerActivityName);
            AssertCommonTags(sendActivity, eventHubName, endpoint, MessagingDiagnosticOperation.Publish, 1);
            Assert.AreEqual(DiagnosticProperty.DiagnosticNamespace + ".EventHubProducerClient", sendActivity.Source.Name);

            Assert.That(eventData.Properties[MessagingClientDiagnostics.DiagnosticIdAttribute], Is.EqualTo(messageActivity.Id), "The diagnostics identifier should match.");
            // Kind attribute is not set for the OTel path as this is handled by the OTel exporter SDK
            Assert.That(messageActivity.Tags, Does.Not.Contain(new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ProducerKind)), "The activities tag should be internal.");
            Assert.That(messageActivity, Is.Not.SameAs(sendActivity), "The activities should not be the same instance.");
            Assert.That(sendActivity.ParentId, Is.EqualTo(activity.Id), "The send scope's parent identifier should match the activity in the active scope.");
            Assert.That(messageActivity.ParentId, Is.EqualTo(activity.Id), "The message scope's parent identifier should match the activity in the active scope.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerCreatesDiagnosticScopeOnBatchSend()
        {
            using var _ = SetAppConfigSwitch();
            using var testListener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            var activity = new Activity("SomeActivity").Start();

            var eventCount = 0;
            var eventHubName = "SomeName";
            var endpoint = "endpoint";
            var batchEvent = default(EventData);
            var fakeConnection = new MockConnection(endpoint, eventHubName);
            var batchTransportMock = new Mock<TransportEventBatch>();

            batchTransportMock
                .Setup(m => m.TryAdd(It.IsAny<EventData>()))
                .Callback<EventData>(addedEvent => batchEvent = addedEvent.Clone())
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
                .Setup(m => m.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
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

            Activity messageActivity = testListener.AssertAndRemoveActivity(DiagnosticProperty.EventActivityName);
            AssertCommonTags(messageActivity, eventHubName, endpoint, default, 1);

            Activity sendActivity = testListener.AssertAndRemoveActivity(DiagnosticProperty.ProducerActivityName);
            AssertCommonTags(sendActivity, eventHubName, endpoint, MessagingDiagnosticOperation.Publish, 1);

            Assert.That(batchEvent.Properties[MessagingClientDiagnostics.DiagnosticIdAttribute], Is.EqualTo(messageActivity.Id), "The diagnostics identifier should match.");
            Assert.That(messageActivity, Is.Not.SameAs(sendActivity), "The activities should not be the same instance.");
            Assert.That(messageActivity.ParentId, Is.EqualTo(activity.Id), "The send scope's parent identifier should match the activity in the active scope.");
            Assert.That(messageActivity.ParentId, Is.EqualTo(activity.Id), "The message scope's parent identifier should match the activity in the active scope.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerAppliesDiagnosticIdToEventsOnSend()
        {
            using var _ = SetAppConfigSwitch();

            Activity activity = new Activity("SomeActivity").Start();

            var eventHubName = "SomeName";
            var endpoint = "some.endpoint.com";
            var fakeConnection = new MockConnection(endpoint, eventHubName);
            var transportMock = new Mock<TransportProducer>();

            EventData[] writtenEventsData = null;

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
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
                Assert.That(eventData.Properties.TryGetValue(MessagingClientDiagnostics.DiagnosticIdAttribute, out object value), Is.True, "The events should have a diagnostic identifier property.");
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
            using var _ = SetAppConfigSwitch();

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
                    writtenEventsData.Add(e.Clone());
                    return hasSpace;
                });

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
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
            Assert.That(writtenEventsData.Count, Is.EqualTo(3), "Each of the events should have been instrumented when attempting to add them to the batch.");

            foreach (EventData eventData in writtenEventsData)
            {
                Assert.That(eventData.Properties.TryGetValue(MessagingClientDiagnostics.DiagnosticIdAttribute, out object value), Is.True, "The events should have a diagnostic identifier property.");
                Assert.That(value, Is.EqualTo(activity.Id), "The diagnostics identifier should match the activity in the active scope.");
            }
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerLinksSendScopeToMessageScopesOnSend()
        {
            using var _ = SetAppConfigSwitch();

            using var testListener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));
            var diagnosticId1 = "00-0af7651916cd43dd8448eb211c80319c-b9c7c989f97918e1-01";
            var diagnosticId2 = "00-0af7651916cd43dd8448eb211c80319c-c9c7c989f97918e1-01";

            var fakeConnection = new MockConnection("some.endpoint.com", "SomeName");
            var transportMock = new Mock<TransportProducer>();

            transportMock
                .Setup(m => m.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducerClient(fakeConnection, transportMock.Object);

            await producer.SendAsync(new[]
            {
                new EventData(new BinaryData(ReadOnlyMemory<byte>.Empty), new Dictionary<string, object> { { MessagingClientDiagnostics.DiagnosticIdAttribute, diagnosticId1 } }),
                new EventData(new BinaryData(ReadOnlyMemory<byte>.Empty), new Dictionary<string, object> { { MessagingClientDiagnostics.DiagnosticIdAttribute, diagnosticId2 } })
            });

            Activity sendActivity = testListener.AssertAndRemoveActivity(DiagnosticProperty.ProducerActivityName);

            var expectedLinks = new[] { new ActivityLink(ActivityContext.Parse(diagnosticId1, null)), new ActivityLink(ActivityContext.Parse(diagnosticId2, null)) };
            var links = sendActivity.Links.ToList();

            Assert.That(links.Count, Is.EqualTo(expectedLinks.Length), "The amount of links should be the same as the amount of events that were sent.");
            for (int i = 0; i < links.Count; i++)
            {
                Assert.That(links[i].Context.TraceId, Is.EqualTo(expectedLinks[i].Context.TraceId), "The trace ids should be the same.");
                Assert.That(links[i].Context.SpanId, Is.EqualTo(expectedLinks[i].Context.SpanId), "The span ids should be the same.");
            }
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventHubProducerClient" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerLinksSendScopeToMessageScopesOnBatchSend()
        {
            using var _ = SetAppConfigSwitch();
            using var testListener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            var diagnosticId1 = "00-0af7651916cd43dd8448eb211c80319c-b9c7c989f97918e1-01";
            var diagnosticId2 = "00-0af7651916cd43dd8448eb211c80319c-c9c7c989f97918e1-01";
            var writtenEventsData = new List<EventData>();
            var batchTransportMock = new Mock<TransportEventBatch>();
            var fakeConnection = new MockConnection("some.endpoint.com", "SomeName");
            var transportMock = new Mock<TransportProducer>();

            batchTransportMock
                .Setup(m => m.TryAdd(It.IsAny<EventData>()))
                .Returns<EventData>(e =>
                {
                    var hasSpace = writtenEventsData.Count <= 1;
                    if (hasSpace)
                    {
                        writtenEventsData.Add(e.Clone());
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

            var eventData1 = new EventData(new BinaryData(ReadOnlyMemory<byte>.Empty), new Dictionary<string, object> { { MessagingClientDiagnostics.DiagnosticIdAttribute, diagnosticId1 } });
            var eventData2 = new EventData(new BinaryData(ReadOnlyMemory<byte>.Empty), new Dictionary<string, object> { { MessagingClientDiagnostics.DiagnosticIdAttribute, diagnosticId2 } });
            var eventData3 = new EventData(new BinaryData(ReadOnlyMemory<byte>.Empty), new Dictionary<string, object> { { MessagingClientDiagnostics.DiagnosticIdAttribute, "id3" } });
            var batch = await producer.CreateBatchAsync();

            Assert.That(batch.TryAdd(eventData1), Is.True, "The first event should have been added to the batch.");
            Assert.That(batch.TryAdd(eventData2), Is.True, "The second event should have been added to the batch.");
            Assert.That(batch.TryAdd(eventData3), Is.False, "The third event should not have been added to the batch.");

            await producer.SendAsync(batch);

            Activity sendActivity = testListener.AssertAndRemoveActivity(DiagnosticProperty.ProducerActivityName);
            AssertCommonTags(sendActivity, "SomeName", "some.endpoint.com", MessagingDiagnosticOperation.Publish, 2);

            var expectedLinks = new[] { new ActivityLink(ActivityContext.Parse(diagnosticId1, null)), new ActivityLink(ActivityContext.Parse(diagnosticId2, null)) };
            var links = sendActivity.Links.ToList();

            Assert.That(links.Count, Is.EqualTo(expectedLinks.Length), "The amount of links should be the same as the amount of events that were sent.");
            for (int i = 0; i < links.Count; i++)
            {
                Assert.That(links[i].Context.TraceId, Is.EqualTo(expectedLinks[i].Context.TraceId), "The trace ids should be the same.");
                Assert.That(links[i].Context.SpanId, Is.EqualTo(expectedLinks[i].Context.SpanId), "The span ids should be the same.");
            }
        }

        /// <summary>
        ///   Verifies diagnostics functionality is off without feature flag.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProcessorActivitySourceDisabled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            using var testListener = new TestActivitySourceListener(DiagnosticProperty.DiagnosticNamespace);
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            var eventBatch = new List<EventData>
            {
                new EventData(new BinaryData(Array.Empty<byte>()))
            };

            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            Assert.IsEmpty(testListener.Activities);
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorCreatesScopeForEventProcessing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            using var _ = SetAppConfigSwitch();
            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            var diagnosticId1 = "00-0af7651916cd43dd8448eb211c80319c-b9c7c989f97918e1-01";
            var diagnosticId2 = "00-0af7651916cd43dd8448eb211c80319c-c9c7c989f97918e1-01";
            var enqueuedTime = DateTimeOffset.UtcNow;
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var fullyQualifiedNamespace = "namespace";
            var eventHubName = "eventHub";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", fullyQualifiedNamespace, eventHubName, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            var eventBatch = new List<EventData>
            {
                new EventData(new BinaryData(Array.Empty<byte>()), enqueuedTime: enqueuedTime),
                new EventData(new BinaryData(Array.Empty<byte>()), enqueuedTime: enqueuedTime)
            };

            eventBatch[0].Properties[MessagingClientDiagnostics.DiagnosticIdAttribute] = diagnosticId1;
            eventBatch[1].Properties[MessagingClientDiagnostics.DiagnosticIdAttribute] = diagnosticId2;

            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            // Validate the diagnostics.

            var activities = listener.Activities.ToList();

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(activities.Select(scope => scope.OperationName), Has.All.EqualTo(DiagnosticProperty.EventProcessorProcessingActivityName), "The processing scopes should have the correct name.");

            for (var index = 0; index < eventBatch.Count; ++index)
            {
                Assert.IsTrue(MessagingClientDiagnostics.TryExtractTraceContext(eventBatch[index].Properties, out var targetId, out var _));
                var targetSpanId = ActivityContext.Parse(targetId, null).SpanId;
                Assert.That(activities.SelectMany(scope => scope.Links.Select(l => l.Context.SpanId)), Has.One.EqualTo(targetSpanId), $"There should have been a link for the diagnostic identifier: { targetId }");
            }

            foreach (var activity in activities)
            {
                AssertCommonTags(activity, eventHubName, fullyQualifiedNamespace, MessagingDiagnosticOperation.Process, 1);
            }
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   class when processing a single event.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorSetsParentActivityForSingleEventProcessing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            using var _ = SetAppConfigSwitch();
            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            var enqueuedTime = DateTimeOffset.UtcNow;
            var diagnosticId = "00-0af7651916cd43dd8448eb211c80319c-b9c7c989f97918e1-01";
            var eventBatch = new List<EventData>
            {
                new EventData(new BinaryData(Array.Empty<byte>()), enqueuedTime: enqueuedTime)
            };
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var fullyQualifiedNamespace = "namespace";
            var eventHubName = "eventHub";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(1, "consumerGroup", fullyQualifiedNamespace, eventHubName, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            eventBatch.ForEach(evt => evt.Properties.Add(MessagingClientDiagnostics.DiagnosticIdAttribute, diagnosticId));
            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            // Validate the diagnostics.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var processingActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.EventProcessorProcessingActivityName);
            Assert.That(processingActivity, Is.Not.Null, "There should have been a single scope present for the processing activity.");

            Assert.That(processingActivity.ParentId, Is.EqualTo(diagnosticId), "The parent of the processing scope should have been equal to the diagnosticId.");
            AssertCommonTags(processingActivity, eventHubName, fullyQualifiedNamespace, MessagingDiagnosticOperation.Process, 1);
            Assert.AreEqual(DiagnosticProperty.DiagnosticNamespace + ".EventProcessor", processingActivity.Source.Name);

            var expectedTag =
                new KeyValuePair<string, string>(DiagnosticProperty.EnqueuedTimeAttribute,
                    enqueuedTime.ToUnixTimeMilliseconds().ToString());

            var tags = processingActivity.Tags;
            Assert.That(tags.Contains(expectedTag), Is.True, "The processing scope should have contained the enqueued time tag.");
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   class when processing a batch of events.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorAddsAttributesToLinkedActivitiesForBatchEventProcessing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            using var _ = SetAppConfigSwitch();
            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            var enqueuedTime = DateTimeOffset.UtcNow;
            var diagnosticId = "00-0af7651916cd43dd8448eb211c80319c-b9c7c989f97918e1-01";
            var eventBatch = new List<EventData>
            {
                new EventData(new BinaryData(Array.Empty<byte>()), enqueuedTime: enqueuedTime),
                new EventData(new BinaryData(Array.Empty<byte>()), enqueuedTime: enqueuedTime)
            };
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var fullyQualifiedNamespace = "namespace";
            var eventHubName = "eventHub";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", fullyQualifiedNamespace, eventHubName, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            eventBatch.ForEach(evt => evt.Properties.Add(MessagingClientDiagnostics.DiagnosticIdAttribute, diagnosticId));
            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            // Validate the diagnostics.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var processingScope = listener.AssertAndRemoveActivity(DiagnosticProperty.EventProcessorProcessingActivityName);
            Assert.That(processingScope, Is.Not.Null, "There should have been a single scope present for the processing activity.");

            var linkedActivities = processingScope.Links.Where(a => a.Context.TraceId == ActivityContext.Parse(diagnosticId, null).TraceId).ToList();
            Assert.That(linkedActivities.Count, Is.EqualTo(2), "There should have been a two activities linked to the diagnostic identifier.");

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.EnqueuedTimeAttribute, enqueuedTime.ToUnixTimeMilliseconds().ToString())
            };

            var tags = linkedActivities[0].Tags.ToList();
            Assert.That(tags, Is.EquivalentTo(expectedTags), "The first activity should have been tagged appropriately.");

            tags = linkedActivities[1].Tags.ToList();
            Assert.That(tags, Is.EquivalentTo(expectedTags), "The second activity should have been tagged appropriately.");
        }

        /// <summary>
        /// Asserts that the common tags are present in the activity.
        /// </summary>
        private void AssertCommonTags(Activity activity, string eventHubName, string endpoint, MessagingDiagnosticOperation operation, int eventCount)
        {
            var tags = activity.TagObjects.ToList();
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.ServerAddress, endpoint));

            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.MessagingSystem, DiagnosticProperty.EventHubsServiceContext));
            if (operation != default)
            {
                CollectionAssert.Contains(tags,
                    new KeyValuePair<string, string>(MessagingClientDiagnostics.MessagingOperation, operation.ToString()));
                CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.DestinationName, eventHubName));
            }
            else
            {
                CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.DestinationName, eventHubName));
            }

            if (eventCount > 1)
                CollectionAssert.Contains(tags, new KeyValuePair<string, int>(MessagingClientDiagnostics.BatchCount, eventCount));
            else
                CollectionAssert.DoesNotContain(tags, new KeyValuePair<string, int>(MessagingClientDiagnostics.BatchCount, eventCount));
        }

        /// <summary>
        ///   Sets and returns the app config switch to enable Activity Source. The switch must be disposed at the end of the test.
        /// </summary>
        ///
        private static TestAppContextSwitch SetAppConfigSwitch()
        {
            var s = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", "true");
            ActivityExtensions.ResetFeatureSwitch();
            return s;
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
                                                                    TimeSpan operationTimeout,
                                                                    EventHubTokenCredential credential,
                                                                    EventHubConnectionOptions options,
                                                                    bool useTls = true) => Mock.Of<TransportClient>();
        }
    }
#endif
}
