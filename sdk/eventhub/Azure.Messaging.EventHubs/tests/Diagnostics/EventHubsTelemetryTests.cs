// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Amqp.Transport;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class EventHubsTelemetryTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task ProducerRecordsOneOperationAndAcceptedEvents(bool batch)
        {
            using var telemetry = new Listener();
            var transport = new Mock<TransportProducer>();
            transport.Setup(p => p.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            transport.Setup(p => p.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            await using var connection = new EventHubConnection("namespace.example", "hub", Mock.Of<TokenCredential>());
            await using var producer = new EventHubProducerClient(connection, transport.Object);
            var events = new List<EventData> { new EventData("one"), new EventData("two") };
            if (batch)
            {
                using var eventBatch = EventHubsModelFactory.EventDataBatch(1024, events);
                await producer.SendAsync(eventBatch);
            }
            else
            {
                await producer.SendAsync(events);
            }

            telemetry.AssertOperation("send", "success", 2);
            var send = telemetry.Activities.Single(a => a.OperationName == "EventHubs.send");
            Assert.That(telemetry.Activities.Single(a => a.OperationName == "EventHubProducerClient.Send").ParentId, Is.EqualTo(send.Id));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task IdempotentPreparationFailureIsObserved(bool batch)
        {
            using var telemetry = new Listener();
            var transport = new Mock<TransportProducer>();
            transport.Setup(p => p.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new InvalidOperationException("preparation failed"));
            await using var connection = new EventHubConnection("namespace.example", "hub", Mock.Of<TokenCredential>());
            await using var producer = new EventHubProducerClient(connection, transport.Object, clientOptions: new EventHubProducerClientOptions { EnableIdempotentPartitions = true });
            var events = new List<EventData> { new EventData("payload") };
            if (batch)
            {
                using var eventBatch = EventHubsModelFactory.EventDataBatch(1024, events, new CreateBatchOptions { PartitionId = "0" });
                Assert.ThrowsAsync<InvalidOperationException>(() => producer.SendAsync(eventBatch));
            }
            else
            {
                Assert.ThrowsAsync<InvalidOperationException>(() => producer.SendAsync(events, new SendEventOptions { PartitionId = "0" }));
            }
            telemetry.AssertOperation("send", "error", 0);
            Assert.That(telemetry.Activities.Single(a => a.OperationName == "EventHubs.send").Status, Is.EqualTo(ActivityStatusCode.Error));
        }

        [Test]
        public async Task ProducerRetriesAreOneFailedLogicalOperation()
        {
            using var telemetry = new Listener();
            var scope = new Mock<AmqpConnectionScope>();
            var failure = new EventHubsException(true, "private broker description");
            scope.Setup(s => s.OpenProducerLinkAsync(It.IsAny<string>(), It.IsAny<TransportProducerFeatures>(), It.IsAny<PartitionPublishingOptions>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ThrowsAsync(failure);
            var retry = new BasicRetryPolicy(new EventHubsRetryOptions { MaximumRetries = 2, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(1) });
            var transport = new AmqpProducer("hub", null, "producer", scope.Object, new AmqpMessageConverter(), retry);
            await using var connection = new EventHubConnection("namespace.example", "hub", Mock.Of<TokenCredential>());
            await using var producer = new EventHubProducerClient(connection, transport);

            Assert.ThrowsAsync<EventHubsException>(() => producer.SendAsync(new[] { new EventData("payload") }));

            scope.Verify(s => s.OpenProducerLinkAsync(It.IsAny<string>(), It.IsAny<TransportProducerFeatures>(), It.IsAny<PartitionPublishingOptions>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Exactly(3));
            telemetry.AssertOperation("send", "error", 0);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ReceiveAttachmentFailureAndCancellationAreObserved(bool cancelled)
        {
            using var telemetry = new Listener();
            var scope = new Mock<AmqpConnectionScope>();
            var failure = new EventHubsException(true, "private broker description");
            scope.Setup(s => s.OpenConsumerLinkAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<uint>(), It.IsAny<long?>(), It.IsAny<long?>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ThrowsAsync(failure);
            var retry = new BasicRetryPolicy(new EventHubsRetryOptions { MaximumRetries = 2, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(1) });
            var consumer = new AmqpConsumer("hub", "$Default", "0", "consumer", EventPosition.Earliest, false, true, null, null, null, scope.Object, new AmqpMessageConverter(), retry);
            using var parent = new Activity("application").Start();
            using var cancellation = new CancellationTokenSource();
            if (cancelled)
            {
                cancellation.Cancel();
                Assert.ThrowsAsync<TaskCanceledException>(() => consumer.ReceiveAsync(1, TimeSpan.Zero, cancellation.Token));
            }
            else
            {
                Assert.ThrowsAsync<EventHubsException>(() => consumer.ReceiveAsync(1, TimeSpan.Zero, cancellation.Token));
            }
            await consumer.CloseAsync(CancellationToken.None);

            telemetry.AssertOperation("receive", cancelled ? "cancelled" : "error", 0);
            var activity = telemetry.Activities.Single(a => a.OperationName == "EventHubs.receive");
            Assert.That(activity.ParentId, Is.EqualTo(parent.Id));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(activity.Events, Is.Empty);
            Assert.That(activity.TagObjects.Any(t => t.Value?.ToString().Contains("private broker") == true), Is.False);
            scope.Verify(s => s.OpenConsumerLinkAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<uint>(), It.IsAny<long?>(), It.IsAny<long?>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Exactly(cancelled ? 0 : 3));
        }

        [Test]
        public async Task ReceiveTimeoutIsAnEmptySuccessfulOperation()
        {
            using var telemetry = new Listener();
            var scope = new Mock<AmqpConnectionScope>();
            scope.Setup(s => s.OpenConsumerLinkAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<uint>(), It.IsAny<long?>(), It.IsAny<long?>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new EventHubsException(true, "timeout", EventHubsException.FailureReason.ServiceTimeout));
            var consumer = new AmqpConsumer("hub", "$Default", "0", "consumer", EventPosition.Earliest, false, true, null, null, null, scope.Object, new AmqpMessageConverter(), new BasicRetryPolicy(new EventHubsRetryOptions()));
            var events = await consumer.ReceiveAsync(1, TimeSpan.Zero, CancellationToken.None);
            await consumer.CloseAsync(CancellationToken.None);
            Assert.That(events, Is.Empty);
            telemetry.AssertOperation("receive", "success", 0);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task BufferedPreparationFailureIsObserved(bool drain, bool hasEvent)
        {
            using var telemetry = new Listener();
            var producer = new Mock<EventHubProducerClient>("namespace.example", "hub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions());
            producer.Setup(p => p.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>())).ThrowsAsync(new InvalidOperationException("private preparation failure"));
            var options = new EventHubBufferedProducerClientOptions();
            await using var buffered = new EventHubBufferedProducerClient(producer.Object, options);
            var state = new EventHubBufferedProducerClient.PartitionPublishingState("0", options);
            var pending = new EventData("pending");
            if (hasEvent)
            {
                await state.PendingEventsWriter.WriteAsync(pending);
                state.BufferedEventCount = 1;
            }
            var failedEvents = new List<EventData>();
            buffered.SendEventBatchFailedAsync += args =>
            {
                failedEvents.AddRange(args.EventBatch);
                return Task.CompletedTask;
            };
            if (drain)
            {
                await buffered.DrainAndPublishPartitionEvents(state, null, CancellationToken.None);
            }
            else
            {
                await buffered.PublishBatchToPartition(state, false, CancellationToken.None, CancellationToken.None);
            }
            if (hasEvent && drain)
            {
                Assert.That(failedEvents, Is.EqualTo(new[] { pending }));
            }
            else if (hasEvent)
            {
                Assert.That(state.TryReadEvent(out var retained), Is.True);
                Assert.That(retained, Is.SameAs(pending));
            }
            telemetry.AssertOperation("send", "error", 0);
            Assert.That(telemetry.Activities.Single(a => a.OperationName == "EventHubBufferedProducerClient.Send").Status, Is.EqualTo(ActivityStatusCode.Error));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public async Task BufferedSendCompletesBeforeCallbackAndCountsOnce(bool drain, bool throttle)
        {
            using var telemetry = new Listener();
            var transport = new Mock<TransportProducer>();
            transport.Setup(p => p.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            if (throttle)
            {
                transport.SetupSequence(p => p.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                    .ThrowsAsync(new EventHubsException(true, "busy", EventHubsException.FailureReason.ServiceBusy))
                    .Returns(Task.CompletedTask);
            }
            transport.Setup(p => p.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<TransportEventBatch>(new AmqpEventBatch(new AmqpMessageConverter(), new CreateBatchOptions { MaximumSizeInBytes = 1024 }, TransportProducerFeatures.None)));
            await using var connection = new EventHubConnection("namespace.example", "hub", Mock.Of<TokenCredential>());
            await using var producer = new EventHubProducerClient(connection, transport.Object);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };
            await using var buffered = new EventHubBufferedProducerClient(producer, options);
            var state = new EventHubBufferedProducerClient.PartitionPublishingState("0", options);
            await state.PendingEventsWriter.WriteAsync(new EventData("payload"));
            state.BufferedEventCount = 1;
            var callbackObserved = false;
            var completedAtCallback = false;
            buffered.SendEventBatchSucceededAsync += args =>
            {
                callbackObserved = true;
                completedAtCallback = telemetry.Measurements.Count(m => m.Name == "az.eventhubs.operations") == 1
                    && telemetry.Activities.Any(a => a.OperationName == "EventHubBufferedProducerClient.Send");
                return Task.CompletedTask;
            };
            if (drain)
            {
                await buffered.DrainAndPublishPartitionEvents(state, null, CancellationToken.None);
            }
            else
            {
                await buffered.PublishBatchToPartition(state, false, CancellationToken.None, CancellationToken.None);
            }
            Assert.That(callbackObserved, Is.True);
            Assert.That(completedAtCallback, Is.True);
            telemetry.AssertOperation("send", "success", 1);
            var bufferedActivity = telemetry.Activities.Single(a => a.OperationName == "EventHubBufferedProducerClient.Send");
            var sends = telemetry.Activities.Where(a => a.OperationName == "EventHubProducerClient.Send").ToArray();
            Assert.That(sends.Length, Is.EqualTo(throttle ? 2 : 1));
            Assert.That(sends.Select(a => a.ParentId), Is.All.EqualTo(bufferedActivity.Id));
            Assert.That(sends.Count(a => a.Status == ActivityStatusCode.Error), Is.EqualTo(throttle ? 1 : 0));
            Assert.That(bufferedActivity.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task BufferedRejectedEventAndCancellationAreNotDelivered(bool cancelled)
        {
            using var telemetry = new Listener();
            var producer = new Mock<EventHubProducerClient>("namespace.example", "hub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions());
            producer.Setup(p => p.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1024, new List<EventData>(), options, _ => false)));
            if (cancelled)
            {
                producer.Setup(p => p.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>())).ThrowsAsync(new TaskCanceledException());
            }
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };
            await using var buffered = new EventHubBufferedProducerClient(producer.Object, options);
            var state = new EventHubBufferedProducerClient.PartitionPublishingState("0", options);
            await state.PendingEventsWriter.WriteAsync(new EventData("payload"));
            state.BufferedEventCount = 1;
            await buffered.PublishBatchToPartition(state, false, CancellationToken.None, CancellationToken.None);

            telemetry.AssertOperation("send", cancelled ? "cancelled" : "error", 0);
            producer.Verify(p => p.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task ProducerCancellationIsNotAnAcceptedSend()
        {
            using var telemetry = new Listener();
            var transport = new Mock<TransportProducer>();
            transport.Setup(p => p.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>())).ThrowsAsync(new TaskCanceledException());
            await using var connection = new EventHubConnection("namespace.example", "hub", Mock.Of<TokenCredential>());
            await using var producer = new EventHubProducerClient(connection, transport.Object);
            Assert.ThrowsAsync<TaskCanceledException>(() => producer.SendAsync(new[] { new EventData("payload") }));
            telemetry.AssertOperation("send", "cancelled", 0);
        }

        [Test]
        public async Task BackgroundPublisherDoesNotInheritTheEnqueueActivity()
        {
            using var listener = new Listener();
            var producer = new Mock<EventHubProducerClient>("namespace.example", "hub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions());
            producer.Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { "0" });
            producer.Setup(p => p.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, _) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1024, new List<EventData>(), options)));
            var published = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(20) };
            await using var buffered = new EventHubBufferedProducerClient(producer.Object, options);
            buffered.SendEventBatchSucceededAsync += _ => { published.TrySetResult(true); return Task.CompletedTask; };
            buffered.SendEventBatchFailedAsync += args => { published.TrySetException(args.Exception); return Task.CompletedTask; };
            using (var request = new Activity("enqueue").Start())
            {
                await buffered.EnqueueEventAsync(new EventData("payload"), new EnqueueEventOptions { PartitionId = "0" });
                Assert.That(Activity.Current, Is.SameAs(request));
            }
            Assert.That(await Task.WhenAny(published.Task, Task.Delay(TimeSpan.FromSeconds(10))), Is.SameAs(published.Task));
            await published.Task;
            Assert.That(listener.Activities.Single(a => a.OperationName == "EventHubBufferedProducerClient.Send").ParentId, Is.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task EmptyBufferedIterationProducesNoSend(bool drain)
        {
            using var listener = new Listener();
            var producer = new Mock<EventHubProducerClient>("namespace.example", "hub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions());
            producer.Setup(p => p.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, _) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1024, new List<EventData>(), options)));
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(20) };
            await using var buffered = new EventHubBufferedProducerClient(producer.Object, options);
            using var state = new EventHubBufferedProducerClient.PartitionPublishingState("0", options);
            if (drain)
            {
                await buffered.DrainAndPublishPartitionEvents(state, null, CancellationToken.None);
            }
            else
            {
                await buffered.PublishBatchToPartition(state, false, CancellationToken.None, CancellationToken.None);
            }
            Assert.That(listener.Activities, Is.Empty);
            Assert.That(listener.Measurements, Is.Empty);
        }

        [Test]
        public async Task LazyEnumerationFailureIsObservedAndEmptyEnumerationIsSilent()
        {
            static IEnumerable<EventData> Events(bool fail)
            {
                if (fail)
                {
                    throw new FormatException("private event source");
                }
                yield break;
            }

            using var telemetry = new Listener();
            await using var connection = new EventHubConnection("namespace.example", "hub", Mock.Of<TokenCredential>());
            await using var producer = new EventHubProducerClient(connection, Mock.Of<TransportProducer>());

            await producer.SendAsync(Events(false));
            Assert.That(telemetry.Activities, Is.Empty);
            Assert.That(telemetry.Measurements, Is.Empty);
            Assert.ThrowsAsync<FormatException>(() => producer.SendAsync(Events(true)));
            telemetry.AssertOperation("send", "error", 0);
            Assert.That(telemetry.Activities.Single().OperationName, Is.EqualTo("EventHubs.send"));
            Assert.That(telemetry.Activities.Single().Status, Is.EqualTo(ActivityStatusCode.Error));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task WrappedTransportFailurePreservesExceptionAndOutcome(bool cancel)
        {
            using var telemetry = new Listener();
            using var cancellation = new CancellationTokenSource();
            var failure = new OperationCanceledException("transport closed", new TimeoutException("private timeout"));
            var transport = new Mock<TransportProducer>();
            transport.Setup(t => t.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    if (cancel)
                    {
                        cancellation.Cancel();
                    }
                    return Task.FromException(failure);
                });
            await using var connection = new EventHubConnection("namespace.example", "hub", Mock.Of<TokenCredential>());
            await using var producer = new EventHubProducerClient(connection, transport.Object);
            Assert.That(Assert.ThrowsAsync<OperationCanceledException>(() => producer.SendAsync(new[] { new EventData("one") }, cancellation.Token)), Is.SameAs(failure));
            telemetry.AssertOperation("send", cancel ? "cancelled" : "error", 0);
        }

        [Test]
        public void DurationExcludesPausedBatchFillTime()
        {
            long timestamp = Stopwatch.Frequency;
            using var telemetry = new Listener();
            var diagnostics = new EventHubsTelemetry("namespace.example", "hub", () => timestamp);
            using var operation = diagnostics.StartOperation("send");
            timestamp += Stopwatch.Frequency;
            operation.Pause();
            timestamp += 100 * Stopwatch.Frequency;
            operation.Resume();
            timestamp += 2 * Stopwatch.Frequency;
            operation.Complete(1);
            Assert.That(telemetry.Measurements.Single(m => m.Name == "az.eventhubs.operation.duration").Value, Is.EqualTo(3));
        }

        [Test]
        public void LegacyListenerReceivesNoAdditionalScopesWithOptInDisabled()
        {
            using var telemetry = new Listener(false);
            using var legacy = new ClientDiagnosticListener(name => name.StartsWith(EventHubsTelemetry.MeterName));
            var diagnostics = new EventHubsTelemetry("namespace.example", "hub");
            using var operation = diagnostics.StartOperation("receive", "EventHubs.receive");
            using var link = diagnostics.StartLifecycle("receiver");
            using var wait = diagnostics.StartAmqp("EventHubs.amqp.receive");
            link.Complete();
            operation.Complete(2);
            telemetry.AssertOperation("receive", "success", 2);
            Assert.That(telemetry.LifecycleRecords, Has.Count.EqualTo(2));
            Assert.That(telemetry.Activities, Is.Empty);
            Assert.That(legacy.Scopes, Is.Empty);
        }

        [Test]
        public async Task ReceiveRecordsOneWaitAndTheReturnedBatchSize()
        {
            using var telemetry = new Listener();
            var settings = new AmqpSettings();
            var provider = new AmqpTransportProvider();
            provider.Versions.Add(new AmqpVersion(new Version(1, 0, 0, 0)));
            settings.TransportProviders.Add(provider);
            var connection = new AmqpConnection(new Mock<TransportBase>("test").Object, settings, new AmqpConnectionSettings());
            var session = new AmqpSession(connection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            var link = new ReceivingAmqpLink(session, new AmqpLinkSettings { Role = true, LinkName = "receiver", TotalLinkCredit = 10, AutoSendFlow = true, Source = new Source(), Target = new Target() });
            var opening = link.OpenAsync(TimeSpan.FromSeconds(2));
            var attach = new Attach { Handle = 0, LinkName = "receiver", Role = false, Source = new Source(), Target = new Target(), InitialDeliveryCount = 0 };
            using (var frame = new Frame())
            {
                frame.Decode(Frame.EncodeCommand(FrameType.Amqp, 0, attach, 0));
                link.ProcessFrame(frame);
            }
            await opening;
            var converter = new AmqpMessageConverter();
            for (uint id = 0; id < 2; ++id)
            {
                using var message = converter.CreateMessageFromEvent(new EventData($"event-{id}"));
                using var payload = message.ToStream();
                var transfer = new Transfer { Handle = 0, DeliveryId = id, DeliveryTag = new ArraySegment<byte>(BitConverter.GetBytes(id)), Settled = true };
                var encoded = Frame.EncodeCommand(FrameType.Amqp, 0, transfer, (int)payload.Length);
                var size = payload.Read(encoded.Buffer, encoded.WritePos, (int)payload.Length);
                encoded.Append(size);
                using var frame = new Frame();
                frame.Decode(encoded);
                link.ProcessFrame(frame);
                Assert.That(link.TerminalException, Is.Null);
                Assert.That(session.TerminalException, Is.Null);
            }

            var scope = new Mock<AmqpConnectionScope>();
            scope.Setup(s => s.OpenConsumerLinkAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<uint>(), It.IsAny<long?>(), It.IsAny<long?>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(link);
            var consumer = new AmqpConsumer("hub", "$Default", "0", "consumer", EventPosition.Earliest, false, true, null, null, null, scope.Object, converter, new BasicRetryPolicy(new EventHubsRetryOptions { MaximumRetries = 0 }));
            var events = await consumer.ReceiveAsync(2, TimeSpan.FromSeconds(1), CancellationToken.None);
            Assert.That(events.Select(e => e.EventBody.ToString()), Is.EqualTo(new[] { "event-0", "event-1" }));
            telemetry.AssertOperation("receive", "success", 2);
            var receive = telemetry.Activities.Single(a => a.OperationName == "EventHubs.receive");
            Assert.That(telemetry.Activities.Single(a => a.OperationName == "EventHubs.amqp.receive").ParentId, Is.EqualTo(receive.Id));
            link.Abort();
            await consumer.CloseAsync(CancellationToken.None);
        }

        [Test]
        public void LifecycleRecordsMatchAttemptsAndDoNotCountLogicalOperations()
        {
            using var listener = new Listener();
            var diagnostics = new EventHubsTelemetry("namespace.example", "hub");
            using var parent = diagnostics.StartOperation("receive", "EventHubs.receive");
            using (var failed = diagnostics.StartLifecycle("receiver"))
            {
                failed.Failed(new InvalidOperationException("private broker error"));
            }
            using (var succeeded = diagnostics.StartLifecycle("receiver"))
            {
                succeeded.Complete();
                succeeded.Invalidate();
                succeeded.Invalidate();
            }
            parent.Complete(1);

            listener.AssertOperation("receive", "success", 1);
            var lifecycle = listener.Measurements.Where(m => m.Name == "az.eventhubs.amqp.lifecycle").ToArray();
            Assert.That(lifecycle.Select(m => m.Tags["outcome"]), Is.EquivalentTo(new[] { "error", "success", "invalidated" }));
            var children = listener.Activities.Where(a => a.OperationName == "EventHubs.amqp.receiver.open").ToArray();
            var receive = listener.Activities.Single(a => a.OperationName == "EventHubs.receive");
            Assert.That(children.Select(a => a.ParentId), Is.All.EqualTo(receive.Id));
            Assert.That(children.Select(a => a.GetTagItem("az.eventhubs.generation")), Is.Unique);
            Assert.That(children.All(a => a.GetTagItem("messaging.operation") == null), Is.True);
            Assert.That(children.All(a => !a.Events.Any()), Is.True);
            Assert.That(listener.EventSourceErrors, Is.Empty);
            Assert.That(listener.LifecycleRecords.Count, Is.EqualTo(5));
            Assert.That(listener.LifecycleRecords.Select(r => r[5]), Is.EquivalentTo(new[] { "started", "error", "started", "success", "invalidated" }));
            foreach (var attempt in listener.LifecycleRecords.GroupBy(r => r[4]))
            {
                Assert.That(attempt.Select(r => r[2]).Distinct().Count(), Is.EqualTo(1));
                Assert.That(attempt.First()[5], Is.EqualTo("started"));
            }
        }

        private sealed class Listener : IDisposable
        {
            private readonly TestAppContextSwitch _switch;
            private readonly ActivityListener _activities;
            private readonly MeterListener _metrics = new MeterListener();
            private readonly AzureEventSourceListener _logs;
            internal ConcurrentQueue<object[]> LifecycleRecords { get; } = new ConcurrentQueue<object[]>();
            internal ConcurrentQueue<string> EventSourceErrors { get; } = new ConcurrentQueue<string>();
            internal ConcurrentQueue<Activity> Activities { get; } = new ConcurrentQueue<Activity>();
            internal ConcurrentQueue<(string Name, double Value, Dictionary<string, object> Tags)> Measurements { get; } = new ConcurrentQueue<(string, double, Dictionary<string, object>)>();

            internal Listener(bool enableTracing = true)
            {
                _switch = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", enableTracing ? "true" : "false");
                ActivityExtensions.ResetFeatureSwitch();
                _activities = new ActivityListener
                {
                    ShouldListenTo = source => source.Name.StartsWith(EventHubsTelemetry.MeterName),
                    Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
                    SampleUsingParentId = (ref ActivityCreationOptions<string> _) => ActivitySamplingResult.AllDataAndRecorded,
                    ActivityStopped = activity => Activities.Enqueue(activity)
                };
                ActivitySource.AddActivityListener(_activities);
                _metrics.InstrumentPublished = (instrument, listener) =>
                {
                    if (instrument.Meter.Name == EventHubsTelemetry.MeterName)
                    {
                        listener.EnableMeasurementEvents(instrument);
                    }
                };
                _metrics.SetMeasurementEventCallback<long>((instrument, value, tags, _) => Record(instrument.Name, value, tags));
                _metrics.SetMeasurementEventCallback<double>((instrument, value, tags, _) => Record(instrument.Name, value, tags));
                _metrics.Start();
                _logs = new AzureEventSourceListener((record, message) =>
                {
                    if (record.EventSource.Name == "Azure-Messaging-EventHubs")
                    {
                        if (record.EventId == 0)
                        {
                            EventSourceErrors.Enqueue(message);
                        }
                        else if (record.EventName == "AmqpLifecycle")
                        {
                            LifecycleRecords.Enqueue(record.Payload.ToArray());
                        }
                    }
                }, EventLevel.Verbose);
            }

            private void Record(string name, double value, ReadOnlySpan<KeyValuePair<string, object>> tags) => Measurements.Enqueue((name, value, tags.ToArray().ToDictionary(t => t.Key, t => t.Value)));

            internal void AssertOperation(string operation, string outcome, long events)
            {
                var measurement = Measurements.Single(m => m.Name == "az.eventhubs.operations");
                Assert.That(measurement.Value, Is.EqualTo(1));
                Assert.That(measurement.Tags["messaging.operation"], Is.EqualTo(operation));
                Assert.That(measurement.Tags["outcome"], Is.EqualTo(outcome));
                Assert.That(Measurements.Where(m => m.Name == "az.eventhubs.events").Sum(m => m.Value), Is.EqualTo(events));
                Assert.That(Measurements.Count(m => m.Name == "az.eventhubs.operation.duration"), Is.EqualTo(1));
                foreach (var item in Measurements)
                {
                    Assert.That(item.Tags.Keys, Is.SubsetOf(new[] { "server.address", "messaging.destination.name", "messaging.operation", "outcome", "component" }));
                }
            }

            public void Dispose()
            {
                _logs.Dispose();
                _metrics.Dispose();
                _activities.Dispose();
                _switch.Dispose();
                ActivityExtensions.ResetFeatureSwitch();
            }
        }
    }
}
