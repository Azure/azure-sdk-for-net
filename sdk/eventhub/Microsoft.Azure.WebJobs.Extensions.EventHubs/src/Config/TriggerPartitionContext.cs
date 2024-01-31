// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs.Consumer;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// Represents an Event Hub partition, its relative state, and its trigger state.
    /// </summary>
    public class TriggerPartitionContext : PartitionContext
    {
        /// <summary>
        /// Determines whether this partition will checkpoint after this invocation succeeds.
        /// </summary>
        public bool IsCheckpointingAfterInvocation { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerPartitionContext"/> class.
        /// </summary>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this context is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub partition this context is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        public TriggerPartitionContext(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId)
            : base(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId)
        {
        }
    }
}
