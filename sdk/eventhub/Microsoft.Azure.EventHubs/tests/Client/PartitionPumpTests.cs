// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class PartitionPumpTests : ClientTestBase
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendReceiveBasic()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                TestUtility.Log("Receiving Events via PartitionReceiver.SetReceiveHandler()");

                var partitionId = "1";
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromEnqueuedTime(DateTime.UtcNow.AddMinutes(-10)));
                var partitionSender = ehClient.CreatePartitionSender(partitionId);

                try
                {
                    string uniqueEventId = Guid.NewGuid().ToString();
                    TestUtility.Log($"Sending an event to Partition {partitionId} with custom property EventId {uniqueEventId}");
                    var sendEvent = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
                    sendEvent.Properties["EventId"] = uniqueEventId;
                    await partitionSender.SendAsync(sendEvent);

                    EventWaitHandle dataReceivedEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
                    var handler = new TestPartitionReceiveHandler();

                    // Not expecting any errors.
                    handler.ErrorReceived += (s, e) =>
                    {
                        throw new Exception($"TestPartitionReceiveHandler.ProcessError {e.GetType().Name}: {e.Message}");
                    };

                    handler.EventsReceived += (s, eventDatas) =>
                    {
                        int count = eventDatas != null ? eventDatas.Count() : 0;
                        TestUtility.Log($"Received {count} event(s):");

                        if (eventDatas != null)
                        {
                            foreach (var eventData in eventDatas)
                            {
                                object objectValue;
                                if (eventData.Properties != null && eventData.Properties.TryGetValue("EventId", out objectValue))
                                {
                                    TestUtility.Log($"Received message with EventId {objectValue}");
                                    string receivedId = objectValue.ToString();
                                    if (receivedId == uniqueEventId)
                                    {
                                        TestUtility.Log("Success");
                                        dataReceivedEvent.Set();
                                        break;
                                    }
                                }
                            }
                        }
                    };

                    partitionReceiver.SetReceiveHandler(handler);

                    await Task.Delay(TimeSpan.FromSeconds(60));

                    if (!dataReceivedEvent.WaitOne(TimeSpan.FromSeconds(20)))
                    {
                        throw new InvalidOperationException("Data Received Event was not signaled.");
                    }
                }
                finally
                {
                    // Unregister handler.
                    partitionReceiver.SetReceiveHandler(null);

                    // Close clients.

                    await Task.WhenAll(
                        partitionSender.CloseAsync(),
                        partitionReceiver.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiveHandlerReregister()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var totalNumberOfMessagesToSend = 100;
                var partitionId = "0";
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(partitionId);
                var partitionReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromOffset(pInfo.LastEnqueuedOffset));

                await TestUtility.SendToPartitionAsync(ehClient, partitionId, $"{partitionId} event.", totalNumberOfMessagesToSend);

                try
                {
                    var handler = new TestPartitionReceiveHandler();
                    handler.MaxBatchSize = 1;

                    // Not expecting any errors.
                    handler.ErrorReceived += (s, e) =>
                    {
                        // SetReceiveHandler will ignore any exception thrown so log here for output.
                        TestUtility.Log($"TestPartitionReceiveHandler.ProcessError {e.GetType().Name}: {e.Message}");
                        throw new Exception($"TestPartitionReceiveHandler.ProcessError {e.GetType().Name}: {e.Message}");
                    };

                    int totalnumberOfMessagesReceived = 0;
                    handler.EventsReceived += (s, eventDatas) =>
                    {
                        int count = eventDatas != null ? eventDatas.Count() : 0;
                        Interlocked.Add(ref totalnumberOfMessagesReceived, count);
                        TestUtility.Log($"Received {count} event(s).");
                    };

                    TestUtility.Log("Registering");
                    partitionReceiver.SetReceiveHandler(handler);
                    TestUtility.Log("Unregistering");
                    partitionReceiver.SetReceiveHandler(null);
                    TestUtility.Log("Registering");
                    partitionReceiver.SetReceiveHandler(handler);
                    await Task.Delay(3000);

                    // Second register call will trigger error handler but throw from handler should be ignored
                    // so below register call should not fail.
                    TestUtility.Log("Registering when already registered");
                    partitionReceiver.SetReceiveHandler(handler);

                    TestUtility.Log("All register calls done.");

                    // Send another set of messages.
                    // Since handler is still registered we should be able to receive these messages just fine.
                    await TestUtility.SendToPartitionAsync(ehClient, partitionId, $"{partitionId} event.", totalNumberOfMessagesToSend);

                    // Allow 1 minute to receive all messages.
                    await Task.Delay(TimeSpan.FromSeconds(60));
                    TestUtility.Log($"Received {totalnumberOfMessagesReceived}.");
                    Assert.True(totalnumberOfMessagesReceived == totalNumberOfMessagesToSend * 2, $"Did not receive {totalNumberOfMessagesToSend * 2} messages, received {totalnumberOfMessagesReceived}.");
                }
                finally
                {
                    // Unregister handler.
                    partitionReceiver.SetReceiveHandler(null);

                    // Close clients.

                    await Task.WhenAll(
                        partitionReceiver.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InvokeOnNull()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromEnd());

                try
                {
                    var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                    var handler = new TestPartitionReceiveHandler();

                    handler.EventsReceived += (s, eventDatas) =>
                    {
                        if (eventDatas == null)
                        {
                            TestUtility.Log("Received null.");
                            tcs.TrySetResult(true);
                        }
                    };

                    partitionReceiver.SetReceiveHandler(handler, true);
                    await tcs.Task.WithTimeout(TimeSpan.FromSeconds(240));
                }
                finally
                {
                    // Unregister handler.
                    partitionReceiver.SetReceiveHandler(null);

                    // Close clients.

                    await Task.WhenAll(
                        partitionReceiver.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task DefaultBehaviorNoInvokeOnNull()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromEnd());

                try
                {
                    var nullCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                    var dataCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                    var handler = new TestPartitionReceiveHandler();

                    handler.EventsReceived += (s, eventDatas) =>
                    {
                        if (eventDatas == null)
                        {
                            TestUtility.Log("Received null.");
                            nullCompletionSource.TrySetResult(true);
                        }
                        else
                        {
                            TestUtility.Log("Received message.");
                            dataCompletionSource.TrySetResult(true);
                        }
                    };

                    partitionReceiver.SetReceiveHandler(handler);
                    await Assert.ThrowsAsync<TimeoutException>(() => nullCompletionSource.Task.WithTimeout(TimeSpan.FromSeconds(120)));

                    // Send one message. Pump should receive this.
                    await TestUtility.SendToPartitionAsync(ehClient, "0", "new event");
                    await dataCompletionSource.Task.WithTimeout(TimeSpan.FromSeconds(60), timeoutCallback: () => throw new TimeoutException("The data event was not received"));
                }
                finally
                {
                    // Unregister handler.
                    partitionReceiver.SetReceiveHandler(null);

                    // Close clients.
                    await Task.WhenAll(
                        partitionReceiver.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        private class TestPartitionReceiveHandler : IPartitionReceiveHandler
        {
            public event EventHandler<IEnumerable<EventData>> EventsReceived;
            public event EventHandler<Exception> ErrorReceived;

            public int MaxBatchSize { get; set; }

            Task IPartitionReceiveHandler.ProcessErrorAsync(Exception error)
            {
                this.ErrorReceived?.Invoke(this, error);
                return Task.CompletedTask;
            }

            Task IPartitionReceiveHandler.ProcessEventsAsync(IEnumerable<EventData> events)
            {
                this.EventsReceived?.Invoke(this, events);
                return Task.CompletedTask;
            }
        }
    }
}
