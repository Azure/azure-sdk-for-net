// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about Partition Load Balancer.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, it is highly recommended that the
    ///   the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    ///
    [EventSource(Name = EventSourceName)]
    internal class PartitionLoadBalancerEventSource : AzureEventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-EventHubs-Processor-PartitionLoadBalancer";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static PartitionLoadBalancerEventSource Log { get; } = new PartitionLoadBalancerEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="PartitionLoadBalancerEventSource" /> class from being created
        ///   outside the scope of this library.
        /// </summary>
        ///
        protected PartitionLoadBalancerEventSource() : base(EventSourceName)
        {
        }

        /// <summary>
        ///   Indicates the minimum amount of partitions every event processor needs to own when the distribution is balanced.
        /// </summary>
        ///
        /// <param name="count"> Minimum partitions per event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(1, Level = EventLevel.Verbose, Message = "Expected minimum partitions per event processor '{0}' for Event Hub '{1}'.")]
        public virtual void MinimumPartitionsPerEventProcessor(int count, string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(1, count, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates the current ownership count.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the associated event processor.</param>
        /// <param name="count"> Current ownership count.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(2, Level = EventLevel.Informational, Message = "Current ownership count is {0} for Event Hub '{2}'. (Identifier: '{1}')")]
        public virtual void CurrentOwnershipCount(int count,
                                                  string identifier,
                                                  string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(2, count, identifier ?? string.Empty, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates the list of unclaimed partitions.
        /// </summary>
        ///
        /// <param name="unclaimedPartitions">List of unclaimed partitions.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(3, Level = EventLevel.Informational, Message = "Unclaimed partitions: '{0}' for Event Hub '{1}'.")]
        public virtual void UnclaimedPartitions(HashSet<string> unclaimedPartitions, string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(3, string.Join(", ", unclaimedPartitions), eventHubName);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to claim ownership for a specific partition has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose ownership claim attempt is starting.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(4, Level = EventLevel.Informational, Message = "Attempting to claim ownership of partition '{0}' for Event Hub '{1}'.")]
        public virtual void ClaimOwnershipStart(string partitionId, string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(4, partitionId ?? string.Empty, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while claiming ownership for a specific partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(5, Level = EventLevel.Error, Message = "Failed to claim ownership of partition '{0}' for Event Hub '{2}'. (ErrorMessage: '{1}')")]
        public virtual void ClaimOwnershipError(string partitionId,
                                                string errorMessage,
                                                string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(5, partitionId ?? string.Empty, errorMessage ?? string.Empty, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates that the load is unbalanced and the associated event processor should own more partitions.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the associated event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(6, Level = EventLevel.Informational, Message = "Load is unbalanced and this load balancer should steal a partition for Event Hub '{1}'. (Identifier: '{0}')")]
        public virtual void ShouldStealPartition(string identifier, string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(6, identifier ?? string.Empty, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates that stealable partitions were found, so randomly picking one of them to claim.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition that was selected to be stolen.</param>
        /// <param name="stolenFrom">The identifier of the event processor that is being stolen from.</param>
        /// <param name="identifier">A unique name used to identify the associated event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(7, Level = EventLevel.Informational, Message = "No unclaimed partitions, attempting to steal partition '{0}' from event processor '{1}' for Event Hub '{3}'. (Identifier: '{2}').")]
        public virtual void StealPartition(string partitionId,
                                           string stolenFrom,
                                           string identifier,
                                           string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(7, partitionId ?? string.Empty, stolenFrom ?? string.Empty, identifier ?? string.Empty, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to renew ownership has started, so they don't expire.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the associated event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(8, Level = EventLevel.Verbose, Message = "Attempting to renew ownership for Event Hub '{1}'. (Identifier: '{0}')")]
        public virtual void RenewOwnershipStart(string identifier, string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(8, identifier ?? string.Empty, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while renewing ownership.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the associated event processor.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(9, Level = EventLevel.Error, Message = "Failed to renew ownership for Event Hub '{2}'. (Identifier: '{0}'; ErrorMessage: '{1}')")]
        public virtual void RenewOwnershipError(string identifier,
                                                string errorMessage,
                                                string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(9, identifier ?? string.Empty, errorMessage ?? string.Empty, eventHubName);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to renew ownership has completed, so they don't expire.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the associated event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the load balancer is associated with.</param>
        ///
        [Event(10, Level = EventLevel.Verbose, Message = "Attempt to renew ownership has completed for Event Hub '{1}'. (Identifier: '{0}')")]
        public virtual void RenewOwnershipComplete(string identifier, string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(10, identifier ?? string.Empty, eventHubName);
            }
        }
    }
}
