// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs
{
    using System;

    /// <summary>
    ///     The exception that is thrown when a call to claim ownership of a partition fails.  Callers retry the operation.
    /// </summary>
    public class EventHubsClaimPartitionException : EventHubsException
    {
        /// <summary>
        ///   The PartitionId for which the ownership claim failed.
        /// </summary>
        ///
        /// <value>The name value of the PartitionId.</value>
        ///
        public string PartitionId { get; }

        internal EventHubsClaimPartitionException(string partitionId, string message) : this(partitionId, message, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsClaimPartitionException"/> class.
        /// </summary>
        /// <param name="partitionId"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EventHubsClaimPartitionException(string partitionId, string message, Exception innerException)
            : base(true, null, message, innerException)
        {
            PartitionId = partitionId;
        }
    }
}
