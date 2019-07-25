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
    public interface IPartitionProcessor
    {
        /// <summary>
        ///   TODO. (optional?)
        /// </summary>
        ///
        public Task Initialize();

        /// <summary>
        ///   TODO. (optional?) (CheckpointManager?)
        /// </summary>
        ///
        public Task Close(string reason);

        /// <summary>
        ///   TODO. CheckpointManager?
        /// </summary>
        ///
        public Task ProcessEvents(EventData[] events);

        /// <summary>
        ///   TODO. (Exception or Error?)
        /// </summary>
        ///
        public Task ProcessError(Exception exception);
    }
}
