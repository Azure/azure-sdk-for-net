// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class PartitionContext
    {
        /// <summary>
        ///   The identifier of the Event Hub partition this context is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        ///
        protected internal PartitionContext(string partitionId)
        {
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            PartitionId = partitionId;
        }
    }
}
