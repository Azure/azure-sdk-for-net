// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Wrappers for the underlying Event Hub client which allow mocking.
    /// The interfaces include only the client functionality used by the Service Fabric Processor.
    /// </summary>
    public class EventHubWrappers
    {
        /// <summary>
        /// Interface for a partition receiver.
        /// </summary>
        public interface IPartitionReceiver
        {
            /// <summary>
            /// 
            /// </summary>
            int PrefetchCount { get; set; }

            /// <summary>
            /// </summary>
            /// <param name="maxEventCount"></param>
            /// <param name="waitTime"></param>
            /// <returns></returns>
            Task<IEnumerable<EventData>> ReceiveAsync(int maxEventCount, TimeSpan waitTime);

            /// <summary>
            /// </summary>
            /// <param name="receiveHandler"></param>
            /// <param name="invokeWhenNoEvents"></param>
            void SetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents = false);

            /// <summary>
            /// </summary>
            /// <returns></returns>
            Task CloseAsync();
        }

        /// <summary>
        /// Interface representing EventHubClient
        /// </summary>
        public interface IEventHubClient
        {
            /// <summary>
            /// </summary>
            /// <returns></returns>
            Task<EventHubRuntimeInformation> GetRuntimeInformationAsync();

            /// <summary>
            /// </summary>
            /// <param name="consumerGroupName"></param>
            /// <param name="partitionId"></param>
            /// <param name="eventPosition"></param>
            /// <param name="epoch"></param>
            /// <param name="receiverOptions"></param>
            /// <returns></returns>
            IPartitionReceiver CreateEpochReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, long epoch, ReceiverOptions receiverOptions);

            /// <summary>
            /// </summary>
            /// <returns></returns>
            Task CloseAsync();
        }

        /// <summary>
        /// Interface for an EventHubClient factory so that we can have factories which dispense different implementations of IEventHubClient.
        /// </summary>
        public interface IEventHubClientFactory
        {
            /// <summary>
            /// </summary>
            /// <param name="connectionString"></param>
            /// <param name="receiveTimeout"></param>
            /// <returns></returns>
            IEventHubClient Create(string connectionString, TimeSpan receiveTimeout);
        }

        internal class PartitionReceiverWrapper : IPartitionReceiver
        {
            private readonly PartitionReceiver inner;

            internal PartitionReceiverWrapper(PartitionReceiver receiver)
            {
                this.inner = receiver;
                this.MaxBatchSize = 10; // TODO get this from somewhere real
            }

            public int PrefetchCount
            {
                get => this.inner.PrefetchCount;
                set
                {
                    this.inner.PrefetchCount = value;
                }
            }

            public Task<IEnumerable<EventData>> ReceiveAsync(int maxEventCount, TimeSpan waitTime)
            {
                return this.inner.ReceiveAsync(maxEventCount, waitTime);
            }

            public void SetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents = false)
            {
                this.inner.SetReceiveHandler(receiveHandler, invokeWhenNoEvents);
            }

            public Task CloseAsync()
            {
                return this.inner.CloseAsync();
            }

            public int MaxBatchSize { get; set; }
        }

        internal class EventHubClientWrapper : IEventHubClient
        {
            private readonly EventHubClient inner;

            internal EventHubClientWrapper(EventHubClient ehc)
            {
                this.inner = ehc;
            }

            public Task<EventHubRuntimeInformation> GetRuntimeInformationAsync()
            {
                return this.inner.GetRuntimeInformationAsync();
            }

            public IPartitionReceiver CreateEpochReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, long epoch, ReceiverOptions receiverOptions)
            {
                return new PartitionReceiverWrapper(this.inner.CreateEpochReceiver(consumerGroupName, partitionId, eventPosition, epoch, receiverOptions));
            }

            public Task CloseAsync()
            {
                return this.inner.CloseAsync();
            }
        }

        internal class EventHubClientFactory : IEventHubClientFactory
        {
            public IEventHubClient Create(string connectionString, TimeSpan receiveTimeout)
            {
                EventHubsConnectionStringBuilder csb = new EventHubsConnectionStringBuilder(connectionString);
                csb.OperationTimeout = receiveTimeout;
                return new EventHubClientWrapper(EventHubClient.Create(csb));
            }
        }
    }
}
