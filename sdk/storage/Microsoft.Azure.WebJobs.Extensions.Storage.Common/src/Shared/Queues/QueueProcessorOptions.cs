// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
#if STORAGE_WEBJOBS_PUBLIC_QUEUE_PROCESSOR
    /// <summary>
    /// Provides options input for creating<see cref="QueueProcessor"/>.
    /// </summary>
    public partial class QueueProcessorOptions
#else
    internal partial class QueueProcessorOptions
#endif
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="queue">The queue the <see cref="QueueProcessor"/> will operate on.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to create an <see cref="ILogger"/> from.</param>
        /// <param name="options">The queue configuration.</param>
        /// <param name="poisonQueue">The queue to move messages to when unable to process a message after the maximum dequeue count has been exceeded. May be null.</param>
        internal QueueProcessorOptions(QueueClient queue, ILoggerFactory loggerFactory, QueuesOptions options, QueueClient poisonQueue = null)
        {
            Queue = queue ?? throw new ArgumentNullException(nameof(queue));
            PoisonQueue = poisonQueue;
            Logger = loggerFactory?.CreateLogger(LogCategories.CreateTriggerCategory("Queue"));
            Options = options;
        }

        /// <summary>
        /// Gets the queue the <see cref="QueueProcessor"/> will operate on.
        /// </summary>
        public QueueClient Queue { get; private set; }

        /// <summary>
        /// Gets the queue to move messages to when unable to process a message after the maximum dequeue count has been exceeded. May be null.
        /// </summary>
        public QueueClient PoisonQueue { get; private set; }

        /// <summary>
        /// Gets the <see cref="ILogger"/>.
        /// </summary>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// Gets the queue configuration.
        /// </summary>
        public QueuesOptions Options { get; private set; }
    }
}
