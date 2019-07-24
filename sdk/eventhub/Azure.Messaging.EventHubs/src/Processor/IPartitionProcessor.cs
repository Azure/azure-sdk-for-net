// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO. (Disposable?)
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
        ///   TODO. (optional?)
        /// </summary>
        ///
        public Task Dispose(string reason); // TODO: CheckpointManager

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public Task ProcessEvents(EventData[] events); // TODO: CheckpointManager

        /// <summary>
        ///   TODO. (Exception or Error?)
        /// </summary>
        ///
        public Task ProcessError(Exception exception);
    }
}
