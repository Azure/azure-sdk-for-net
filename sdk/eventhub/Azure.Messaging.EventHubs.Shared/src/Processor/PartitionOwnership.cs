// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains all the information needed to describe the status of the owner of a partition.  It's used by
    ///   an <c>EventProcessorClient</c> for cooperative distribution of processing for the associated Event Hub.
    /// </summary>
    ///
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor" />
    ///
    internal class PartitionOwnership
    {
        /// <summary>
        ///   The fully qualified Event Hubs namespace this partition ownership is associated with.  This
        ///   is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the specific Event Hub this partition ownership is associated with, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this partition ownership is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the associated <c>EventProcessorClient</c> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this partition ownership is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   TODO: purpose not clear yet.
        /// </summary>
        ///
        internal long OwnerLevel { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last update was made to this ownership.
        /// </summary>
        ///
        public DateTimeOffset? LastModifiedTime { get; set; }

        /// <summary>
        ///   The entity tag needed to update this ownership.
        /// </summary>
        ///
        public string ETag { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionOwnership"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this partition ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <c>EventProcessorClient</c> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
        /// <param name="eTag">The entity tag needed to update this ownership.</param>
        ///
        public PartitionOwnership(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  string consumerGroup,
                                  string ownerIdentifier,
                                  string partitionId,
                                  DateTimeOffset? lastModifiedTime = null,
                                  string eTag = null)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(ownerIdentifier, nameof(ownerIdentifier));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnerIdentifier = ownerIdentifier;
            PartitionId = partitionId;
            LastModifiedTime = lastModifiedTime;
            ETag = eTag;
        }
    }
}
