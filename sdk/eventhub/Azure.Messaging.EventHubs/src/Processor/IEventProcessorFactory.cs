// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public interface IEventProcessorFactory
    {
        /// <summary>
        ///   TODO. (partitionContext?)
        /// </summary>
        ///
        public IEventProcessor CreateEventProcessor(PartitionContext context);
    }
}
