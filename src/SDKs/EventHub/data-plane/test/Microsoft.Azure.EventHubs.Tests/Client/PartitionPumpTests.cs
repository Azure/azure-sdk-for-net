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
        [DisplayTestMethodName]
        async Task SendReceiveBasic()
        {
            TestUtility.Log("Receiving Events via PartitionReceiver.SetReceiveHandler()");
            string partitionId = "1";
            PartitionReceiver partitionReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromEnqueuedTime(DateTime.UtcNow.AddMinutes(-10)));
            PartitionSender partitionSender = this.EventHubClient.CreatePartitionSender(partitionId);

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
                await partitionSender.CloseAsync();
                await partitionReceiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task ReceiveHandlerReregister()
        {
            int totalNumberOfMessagesToSend = 100;
            string partitionId = "0";

            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionId);

            PartitionReceiver partitionReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromOffset(pInfo.LastEnqueuedOffset));
            await TestUtility.SendToPartitionAsync(this.EventHubClient, partitionId, $"{partitionId} event.", totalNumberOfMessagesToSend);

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
                await TestUtility.SendToPartitionAsync(this.EventHubClient, partitionId, $"{partitionId} event.", totalNumberOfMessagesToSend);

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
                await partitionReceiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task InvokeOnNull()
        {
            PartitionReceiver partitionReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromEnd());

            try
            {
                EventWaitHandle nullReceivedEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
                var handler = new TestPartitionReceiveHandler();

                handler.EventsReceived += (s, eventDatas) =>
                {
                    if (eventDatas == null)
                    {
                        TestUtility.Log("Received null.");
                        nullReceivedEvent.Set();
                    }
                };

                partitionReceiver.SetReceiveHandler(handler, true);

                if (!nullReceivedEvent.WaitOne(TimeSpan.FromSeconds(120)))
                {
                    throw new InvalidOperationException("Did not receive null.");
                }
            }
            finally
            {
                // Unregister handler.
                partitionReceiver.SetReceiveHandler(null);

                // Close clients.
                await partitionReceiver.CloseAsync();
            }
        }


        [Fact]
        [DisplayTestMethodName]
        async Task DefaultBehaviorNoInvokeOnNull()
        {
            PartitionReceiver partitionReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromEnd());

            try
            {
                EventWaitHandle nullReceivedEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
                EventWaitHandle dataReceivedEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
                var handler = new TestPartitionReceiveHandler();

                handler.EventsReceived += (s, eventDatas) =>
                {
                    if (eventDatas == null)
                    {
                        TestUtility.Log("Received null.");
                        nullReceivedEvent.Set();
                    }
                    else
                    {
                        TestUtility.Log("Received message.");
                        dataReceivedEvent.Set();
                    }
                };

                partitionReceiver.SetReceiveHandler(handler);

                if (nullReceivedEvent.WaitOne(TimeSpan.FromSeconds(120)))
                {
                    throw new InvalidOperationException("Received null.");
                }

                // Send one message. Pump should receive this.
                await TestUtility.SendToPartitionAsync(this.EventHubClient, "0", "new event");

                if (!dataReceivedEvent.WaitOne(TimeSpan.FromSeconds(60)))
                {
                    throw new InvalidOperationException("Data Received Event was not signaled.");
                }
            }
            finally
            {
                // Unregister handler.
                partitionReceiver.SetReceiveHandler(null);

                // Close clients.
                await partitionReceiver.CloseAsync();
            }
        }

        class TestPartitionReceiveHandler : IPartitionReceiveHandler
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
