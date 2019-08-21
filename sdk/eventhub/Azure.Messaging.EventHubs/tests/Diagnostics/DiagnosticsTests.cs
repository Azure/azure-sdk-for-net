// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    [NonParallelizable]
    public class DiagnosticsTests
    {
        [Test]
        public async Task CreatesDiagnosticScope()
        {
            using var testListener = new ClientDiagnosticListener();

            var transportMock = new Mock<TransportEventHubProducer>();
            transportMock.Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducer(transportMock.Object, new Uri("http://endpoint"), "Name", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            var eventData = new EventData(ReadOnlyMemory<byte>.Empty);
            await producer.SendAsync(eventData);
            
            var sendScope = testListener.AssertScope("Azure.Messaging.EventHubs.EventHubProducer.Send", 
                new KeyValuePair<string, string>("kind", "producer"),
                new KeyValuePair<string, string>("component", "eventhubs"), 
                new KeyValuePair<string, string>("peer.address", "http://endpoint/"), 
                new KeyValuePair<string, string>("message_bus.destination", "Name"));

            var messageScope = testListener.AssertScope("Azure.Messaging.EventHubs.Message");

            Assert.AreEqual(eventData.Properties["Diagnostic-Id"], messageScope.Activity.Id);
            Assert.AreNotSame(messageScope.Activity, sendScope.Activity);
        }

        [Test]
        public async Task CreatesDiagnosticScopeForBatchSend()
        {
            using var testListener = new ClientDiagnosticListener();

            int eventCount = 0;
            var batchTransportMock = new Mock<TransportEventBatch>();
            batchTransportMock.Setup(m => m.TryAdd(It.IsAny<EventData>())).Returns(
                () => {
                    eventCount ++;
                    return eventCount <= 3;
                });

            var transportMock = new Mock<TransportEventHubProducer>();
            transportMock.Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            transportMock.Setup(m => m.CreateBatchAsync(It.IsAny<BatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(batchTransportMock.Object));

            var producer = new EventHubProducer(transportMock.Object, new Uri("http://endpoint"), "Name", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            var eventData = new EventData(ReadOnlyMemory<byte>.Empty);
            var batch = await producer.CreateBatchAsync();
            Assert.True(batch.TryAdd(eventData));
            
            await producer.SendAsync(batch);
            
            var sendScope = testListener.AssertScope("Azure.Messaging.EventHubs.EventHubProducer.Send", 
                new KeyValuePair<string, string>("kind", "producer"),
                new KeyValuePair<string, string>("component", "eventhubs"), 
                new KeyValuePair<string, string>("peer.address", "http://endpoint/"), 
                new KeyValuePair<string, string>("message_bus.destination", "Name"));

            var messageScope = testListener.AssertScope("Azure.Messaging.EventHubs.Message");

            Assert.AreEqual(eventData.Properties["Diagnostic-Id"], messageScope.Activity.Id);
            
            Assert.AreNotSame(messageScope.Activity, sendScope.Activity);
        }
        
        [Test]
        public async Task DiagnosticIdSetOnEvents()
        {
            var activity = new Activity("SomeActivity").Start();

            EventData[] writtenEventsData = null;
            var transportMock = new Mock<TransportEventHubProducer>();
            transportMock.Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Callback<IEnumerable<EventData>, SendOptions, CancellationToken>((e, _, __)=> writtenEventsData = e.ToArray())
                .Returns(Task.CompletedTask);

            var producer = new EventHubProducer(transportMock.Object, null, "Name", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(new []
            {
                new EventData(ReadOnlyMemory<byte>.Empty),
                new EventData(ReadOnlyMemory<byte>.Empty)
            });

            activity.Stop();
            Assert.AreEqual(2, writtenEventsData.Length);

            foreach (var eventData in writtenEventsData)
            {
                Assert.True(eventData.Properties.TryGetValue("Diagnostic-Id", out object value));
                Assert.AreEqual(activity.Id, value);   
            }
        }

        [Test]
        public async Task DiagnosticIdSetOnBatchEvents()
        {
            var activity = new Activity("SomeActivity").Start();
            
            List<EventData> writtenEventsData = new List<EventData>();
            var batchTransportMock = new Mock<TransportEventBatch>();
            batchTransportMock.Setup(m => m.TryAdd(It.IsAny<EventData>())).Returns<EventData>(
                e => {
                    var hasSpace = writtenEventsData.Count <= 1;
                    if (hasSpace)
                    {
                        writtenEventsData.Add(e);
                    }
                    return hasSpace;
                });

            var transportMock = new Mock<TransportEventHubProducer>();
            transportMock.Setup(m => m.SendAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            transportMock.Setup(m => m.CreateBatchAsync(It.IsAny<BatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(batchTransportMock.Object));

            var producer = new EventHubProducer(transportMock.Object, null, "Name", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            var eventData1 = new EventData(ReadOnlyMemory<byte>.Empty);
            var eventData2 = new EventData(ReadOnlyMemory<byte>.Empty);
            var eventData3 = new EventData(ReadOnlyMemory<byte>.Empty);

            var batch = await producer.CreateBatchAsync();
            Assert.True(batch.TryAdd(eventData1));
            Assert.True(batch.TryAdd(eventData2));
            Assert.False(batch.TryAdd(eventData3));
            
            await producer.SendAsync(batch);

            activity.Stop();
            Assert.AreEqual(2, writtenEventsData.Count);

            foreach (var eventData in writtenEventsData)
            {
                Assert.True(eventData.Properties.TryGetValue("Diagnostic-Id", out object value));
                Assert.AreEqual(activity.Id, value);   
            }                
            Assert.False(eventData3.Properties.ContainsKey("Diagnostic-Id"));

        }
    }
}