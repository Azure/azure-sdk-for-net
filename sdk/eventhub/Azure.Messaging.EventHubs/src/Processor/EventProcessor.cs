// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TODO: check if used
using System;
using System.ComponentModel;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO. (private => internal members?)
    /// </summary>
    ///
    public class EventProcessor
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string Name { get; }

        /// <summary>
        ///   TODO. (name?)
        /// </summary>
        ///
        private EventHubClient Client { get; }

        /// <summary>
        ///   TODO. (name?)
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private IPartitionProcessorFactory PartitionProcessorFactory { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private EventProcessorOptions Options { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public EventProcessor(EventHubClient eventHubClient,
                              string consumerGroup,
                              IPartitionProcessorFactory partitionProcessorFactory,
                              IPartitionManager partitionManager) : this(eventHubClient, consumerGroup, partitionProcessorFactory, partitionManager, null)
        {
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public EventProcessor(EventHubClient eventHubClient,
                              string consumerGroup,
                              IPartitionProcessorFactory partitionProcessorFactory,
                              IPartitionManager partitionManager,
                              EventProcessorOptions options)
        {
            Client = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionProcessorFactory = partitionProcessorFactory;
            Options = options?.Clone() ?? new EventProcessorOptions();

            // TODO
            Name = "I am unique";
        }

        /// <summary>
        ///   TODO. (make it async)
        /// </summary>
        ///
        public void Start()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   TODO. (make it async)
        /// </summary>
        ///
        public void Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
