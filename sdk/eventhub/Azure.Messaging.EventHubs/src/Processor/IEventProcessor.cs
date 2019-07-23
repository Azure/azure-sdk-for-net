// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public interface IEventProcessor
    {
        /// <summary>
        ///   TODO. (optional?)
        /// </summary>
        ///
        public Task PartitionStart();

        /// <summary>
        ///   TODO. (optional?)
        /// </summary>
        ///
        public Task PartitionStop();

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public Task ProcessEvents(EventData[] events,
                                  CheckpointContext checkpointContext);

        /// <summary>
        ///   TODO. (Exception or Error?)
        /// </summary>
        ///
        public Task ProcessError(Exception exception);
    }
}
