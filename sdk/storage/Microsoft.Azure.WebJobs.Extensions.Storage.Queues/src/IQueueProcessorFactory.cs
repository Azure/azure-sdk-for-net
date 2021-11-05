// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    /// <summary>
    /// Factory for creating <see cref="QueueProcessor"/> instances.
    /// </summary>
    public interface IQueueProcessorFactory
    {
        /// <summary>
        /// Creates a <see cref="QueueProcessor"/> using the specified context.
        /// </summary>
        /// <param name="queueProcessorOptions">The <see cref="QueueProcessorOptions"/> to use.</param>
        /// <returns>A <see cref="QueueProcessor"/> instance.</returns>
        QueueProcessor Create(QueueProcessorOptions queueProcessorOptions);
    }
}
