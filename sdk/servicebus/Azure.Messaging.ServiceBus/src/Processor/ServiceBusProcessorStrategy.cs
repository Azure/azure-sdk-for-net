// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Defines a customization strategy for <see cref="ServiceBusProcessor"/>.
    /// </summary>
    public abstract class ServiceBusProcessorStrategy
    {
        /// <summary>
        /// Called before spawning a new child receive task.
        /// </summary>
        /// <param name="createReceiveTask">Create a receiver</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task AdjustReceiverCountAsync(Func<CancellationToken, Task> createReceiveTask, CancellationToken cancellationToken);

        /// <summary>
        /// Called when a child receive task has completed.
        /// </summary>
        /// <param name="receiveTask">The receive task being stopped.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task StopReceiverAsync(Task receiveTask, CancellationToken cancellationToken);

        /// <summary>
        /// Gets status for a receiver.
        /// </summary>
        /// <returns>The status.</returns>
        public abstract ReceiverStatus GetReceiverStatus();

        /// <summary>
        /// Complete any outstanding receive tasks.
        /// </summary>
        /// <returns></returns>
        public abstract Task CompleteAsync();
    }
}
