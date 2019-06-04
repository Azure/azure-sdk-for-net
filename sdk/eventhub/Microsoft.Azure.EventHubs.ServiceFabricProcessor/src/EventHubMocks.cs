// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Mocks for the underlying event hub client. Using these instead of the regular wrappers allows unit testing without an event hub.
    /// By default, EventProcessorService.EventHubClientFactory is a EventHubWrappers.EventHubClientFactory.
    /// To use the mocks, change it to a EventHubMocks.EventHubClientFactoryMock.
    /// </summary>
    public class EventHubMocks
    {
        /// <summary>
        /// Mock of an Event Hub partition receiver.
        /// </summary>
        public class PartitionReceiverMock : EventHubWrappers.IPartitionReceiver
        {
            /// <summary>
            /// 
            /// </summary>
            public static Dictionary<string, PartitionReceiverMock> receivers = new Dictionary<string, PartitionReceiverMock>();

            /// <summary>
            /// 
            /// </summary>
            protected readonly string partitionId;
            /// <summary>
            /// 
            /// </summary>
            protected long sequenceNumber;
            /// <summary>
            /// 
            /// </summary>
            protected volatile IPartitionReceiveHandler outerHandler;
            /// <summary>
            /// 
            /// </summary>
            protected int handlerBatchSize;
            /// <summary>
            /// 
            /// </summary>
            public int HandlerBatchSize { get => this.handlerBatchSize; }
            /// <summary>
            /// 
            /// </summary>
            protected bool invokeWhenNoEvents;
            /// <summary>
            /// 
            /// </summary>
            protected TimeSpan pumpTimeout;
            /// <summary>
            /// 
            /// </summary>
            public TimeSpan ReceiveTimeout { get => this.pumpTimeout;  }
            /// <summary>
            /// Not meaningful in this mock but exposed so that tests can verify.
            /// </summary>
            public ReceiverOptions Options { get; private set; }
            /// <summary>
            /// 
            /// </summary>
            protected readonly CancellationToken token;

            /// <summary>
            /// Construct the partition receiver mock.
            /// </summary>
            /// <param name="partitionId"></param>
            /// <param name="sequenceNumber"></param>
            /// <param name="token"></param>
            /// <param name="pumpTimeout"></param>
            /// <param name="options"></param>
            /// <param name="tag"></param>
            public PartitionReceiverMock(string partitionId, long sequenceNumber, CancellationToken token, TimeSpan pumpTimeout,
                ReceiverOptions options, string tag)
            {
                this.partitionId = partitionId;
                this.sequenceNumber = sequenceNumber;
                this.token = token;
                this.pumpTimeout = pumpTimeout;
                this.Options = options;

                if (tag != null)
                {
                    PartitionReceiverMock.receivers[tag] = this;
                }
            }

            /// <summary>
            /// Not meaningful in this mock but exposed so that tests can verify.
            /// </summary>
            public int PrefetchCount { get; set; }

            /// <summary>
            /// Receive mock events.
            /// </summary>
            /// <param name="maxEventCount"></param>
            /// <param name="waitTime"></param>
            /// <returns></returns>
            public virtual Task<IEnumerable<EventData>> ReceiveAsync(int maxEventCount, TimeSpan waitTime)
            {
                List<EventData> events = null;
                events = new List<EventData>();
                long lastSeq = this.sequenceNumber + maxEventCount;
                for (int i = 0; i < maxEventCount; i++)
                {
                    this.sequenceNumber++;
                    byte[] body = new byte[] { 0x4D, 0x4F, 0x43, 0x4B, 0x42, 0x4F, 0x44, 0x59 }; // M O C K B O D Y
                    EventData e = new EventData(body);
                    PropertyInfo propertyInfo = e.GetType().GetProperty("LastSequenceNumber", BindingFlags.NonPublic | BindingFlags.Instance);
                    propertyInfo.SetValue(e, lastSeq);
                    e.SystemProperties = new EventData.SystemPropertiesCollection(this.sequenceNumber, DateTime.UtcNow, (this.sequenceNumber * 100).ToString(), "");
                    e.Properties.Add("userkey", "uservalue");
                    events.Add(e);
                }
                Thread.Sleep(50);
                EventProcessorEventSource.Current.Message($"MOCK ReceiveAsync returning {maxEventCount} events for partition {this.partitionId} ending at {this.sequenceNumber}");
                return Task.FromResult<IEnumerable<EventData>>(events);
            }

            /// <summary>
            /// Set a mock receive handler.
            /// </summary>
            /// <param name="receiveHandler"></param>
            /// <param name="invokeWhenNoEvents"></param>
            public virtual void SetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents = false)
            {
                EventProcessorEventSource.Current.Message("MOCK IPartitionReceiver.SetReceiveHandler");
                this.outerHandler = receiveHandler;
                this.invokeWhenNoEvents = invokeWhenNoEvents;
                if (this.outerHandler != null)
                {
                    this.handlerBatchSize = this.outerHandler.MaxBatchSize;
                    Task.Run(() => PumpLoop());
                }
                else
                {
                    EventProcessorEventSource.Current.Message("MOCK IPartitionReceiver.SetReceiveHandler with NULL handler");
                }
            }

            /// <summary>
            /// Close the mock receiver.
            /// </summary>
            /// <returns></returns>
            public virtual Task CloseAsync()
            {
                EventProcessorEventSource.Current.Message("MOCK IPartitionReceiver.CloseAsync");
                return Task.CompletedTask;
            }

            private async void PumpLoop()
            {
                while ((!this.token.IsCancellationRequested) && (this.outerHandler != null))
                {
                    // TODO random batch sizes
                    IEnumerable<EventData> events = ReceiveAsync(this.handlerBatchSize, this.pumpTimeout).Result;
                    IPartitionReceiveHandler capturedHandler = this.outerHandler;
                    if (capturedHandler != null)
                    {
                        if (events != null)
                        {
                            EventProcessorEventSource.Current.Message("MOCK Sending messages to handler");
                            await capturedHandler.ProcessEventsAsync(events);
                        }
                        else if (this.invokeWhenNoEvents)
                        {
                            EventProcessorEventSource.Current.Message("MOCK Sending empty batch to handler");
                            await capturedHandler.ProcessEventsAsync(events);
                        }
                        else
                        {
                            EventProcessorEventSource.Current.Message("MOCK Suppressing empty batch");
                        }
                    }
                    else
                    {
                        EventProcessorEventSource.Current.Message("MOCK Handler has been detached");
                    }
                }
                EventProcessorEventSource.Current.Message("MOCK Message generation ending");
            }
        }

        /// <summary>
        /// Mock of EventHubClient class.
        /// </summary>
        public class EventHubClientMock : EventHubWrappers.IEventHubClient
        {
            /// <summary>
            /// 
            /// </summary>
            protected readonly int partitionCount;
            /// <summary>
            /// 
            /// </summary>
            protected readonly EventHubsConnectionStringBuilder csb;
            /// <summary>
            /// 
            /// </summary>
            protected readonly string tag;
            /// <summary>
            /// 
            /// </summary>
            protected CancellationToken token = new CancellationToken();

            /// <summary>
            /// Construct the mock.
            /// </summary>
            /// <param name="partitionCount"></param>
            /// <param name="csb"></param>
            /// <param name="tag"></param>
            public EventHubClientMock(int partitionCount, EventHubsConnectionStringBuilder csb, string tag)
            {
                this.partitionCount = partitionCount;
                this.csb = csb;
                this.tag = tag;
            }

            internal void SetCancellationToken(CancellationToken t)
            {
                this.token = t;
            }

            /// <summary>
            /// Get runtime info of the fake event hub.
            /// </summary>
            /// <returns></returns>
            public virtual Task<EventHubRuntimeInformation> GetRuntimeInformationAsync()
            {
                EventHubRuntimeInformation ehri = new EventHubRuntimeInformation();
                ehri.PartitionCount = this.partitionCount;
                ehri.PartitionIds = new string[this.partitionCount];
                for (int i = 0; i < this.partitionCount; i++)
                {
                    ehri.PartitionIds[i] = i.ToString();
                }
                ehri.Path = this.csb.EntityPath;
                EventProcessorEventSource.Current.Message($"MOCK GetRuntimeInformationAsync for {ehri.Path}");
                return Task.FromResult<EventHubRuntimeInformation>(ehri);
            }

            /// <summary>
            /// Create a mock receiver on the fake event hub.
            /// </summary>
            /// <param name="consumerGroupName"></param>
            /// <param name="partitionId"></param>
            /// <param name="eventPosition"></param>
            /// <param name="epoch"></param>
            /// <param name="receiverOptions"></param>
            /// <returns></returns>
            public virtual EventHubWrappers.IPartitionReceiver CreateEpochReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, long epoch, ReceiverOptions receiverOptions)
            {
                EventProcessorEventSource.Current.Message($"MOCK CreateEpochReceiver(CG {consumerGroupName}, part {partitionId}, epoch {epoch})");
                // TODO implement epoch semantics
                long startSeq = CalculateStartSeq(eventPosition);
                return new PartitionReceiverMock(partitionId, startSeq, this.token, this.csb.OperationTimeout, receiverOptions, this.tag);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="eventPosition"></param>
            /// <returns></returns>
            protected long CalculateStartSeq(EventPosition eventPosition)
            {
                long startSeq = 0L;
                if (eventPosition.SequenceNumber.HasValue)
                {
                    startSeq = eventPosition.SequenceNumber.Value;
                }
                else
                {
                    PropertyInfo propertyInfo = eventPosition.GetType().GetProperty("Offset", BindingFlags.NonPublic | BindingFlags.Instance);
                    string offset = (string)propertyInfo.GetValue(eventPosition);
                    if (!string.IsNullOrEmpty(offset))
                    {
                        startSeq = (long.Parse(offset) / 100L);
                    }
                }
                return startSeq;
            }

            /// <summary>
            /// Close the mock EventHubClient.
            /// </summary>
            /// <returns></returns>
            public virtual Task CloseAsync()
            {
                EventProcessorEventSource.Current.Message("MOCK IEventHubClient.CloseAsync");
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// An EventHubClient factory which dispenses mocks.
        /// </summary>
        public class EventHubClientFactoryMock : EventHubWrappers.IEventHubClientFactory
        {
            /// <summary>
            /// 
            /// </summary>
            protected readonly int partitionCount;
            /// <summary>
            /// 
            /// </summary>
            protected readonly string tag;

            /// <summary>
            /// Construct the mock factory.
            /// </summary>
            /// <param name="partitionCount"></param>
            /// <param name="tag"></param>
            public EventHubClientFactoryMock(int partitionCount, string tag = null)
            {
                this.partitionCount = partitionCount;
                this.tag = tag;
            }

            /// <summary>
            /// Dispense a mock instance operating on a fake event hub with name taken from the connection string.
            /// </summary>
            /// <param name="connectionString"></param>
            /// <param name="receiveTimeout"></param>
            /// <returns></returns>
            public virtual EventHubWrappers.IEventHubClient Create(string connectionString, TimeSpan receiveTimeout)
            {
                EventProcessorEventSource.Current.Message($"MOCK Creating IEventHubClient {connectionString} with {this.partitionCount} partitions");
                EventHubsConnectionStringBuilder csb = new EventHubsConnectionStringBuilder(connectionString);
                csb.OperationTimeout = receiveTimeout;
                return new EventHubClientMock(this.partitionCount, csb, this.tag);
            }
        }
    }
}
