// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class CheckpointManager
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private PartitionContext Context { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private IPartitionManager Manager { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        internal CheckpointManager(PartitionContext partitionContext,
                                   IPartitionManager partitionManager)
        {
            Context = partitionContext;
            Manager = partitionManager;
        }

        /// <summary>
        ///   TODO. (make it async)
        /// </summary>
        ///
        public void CreateCheckpoint(EventData eventData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   TODO. (make it async)
        /// </summary>
        ///
        public void CreateCheckpoint(long offset,
                                     long sequenceNumber)
        {
            throw new NotImplementedException();
        }
    }
}
