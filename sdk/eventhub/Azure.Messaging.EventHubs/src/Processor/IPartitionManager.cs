// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public interface IPartitionManager
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public Task<PartitionOwnership[]> ListOwnerships(string eventHubName,
                                                         string consumerGroupName);

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public Task<PartitionOwnership[]> ClaimOwnerships(PartitionOwnership[] partitionOwnerships);

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public Task CreateCheckpoint(Checkpoint checkpoint);
    }
}
