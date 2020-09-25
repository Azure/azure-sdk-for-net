// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using System;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    /// <summary>
    /// Provides context input for <see cref="IQueueProcessorFactory"/>.
    /// </summary>
    public partial class QueueProcessorFactoryContext
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="queue">TODO.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to create an <see cref="ILogger"/> from.</param>
        /// <param name="poisonQueue">The queue to move messages to when unable to process a message after the maximum dequeue count has been exceeded. May be null.</param>
        public QueueProcessorFactoryContext(QueueClient queue, ILoggerFactory loggerFactory, QueueClient poisonQueue = null)
        {
            Queue = queue ?? throw new ArgumentNullException(nameof(queue));
            PoisonQueue = poisonQueue;
            Logger = loggerFactory?.CreateLogger(LogCategories.CreateTriggerCategory("Queue"));
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="queue">TODO.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to create an <see cref="ILogger"/> from.</param>
        /// <param name="options">The queue configuration.</param>
        /// <param name="poisonQueue">The queue to move messages to when unable to process a message after the maximum dequeue count has been exceeded. May be null.</param>
        // TODO (kasobol-msft) this was internal before check this.
        public QueueProcessorFactoryContext(QueueClient queue, ILoggerFactory loggerFactory, QueuesOptions options, QueueClient poisonQueue = null)
            : this(queue, loggerFactory, poisonQueue)
        {
            BatchSize = options.BatchSize;
            MaxDequeueCount = options.MaxDequeueCount;
            NewBatchThreshold = options.NewBatchThreshold;
            VisibilityTimeout = options.VisibilityTimeout;
            MaxPollingInterval = options.MaxPollingInterval;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        public QueueClient Queue { get; private set; }

        /// <summary>
        /// TODO.
        /// May be null.
        /// </summary>
        public QueueClient PoisonQueue { get; private set; }

        /// <summary>
        /// Gets the <see cref="ILogger"/>.
        /// </summary>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// Gets or sets the number of queue messages to retrieve and process in parallel (per job method).
        /// </summary>
        public int BatchSize { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times to try processing a message before moving
        /// it to the poison queue (if a poison queue is configured for the queue).
        /// </summary>
        public int MaxDequeueCount { get; set; }

        /// <summary>
        /// Gets or sets the threshold at which a new batch of messages will be fetched.
        /// </summary>
        public int NewBatchThreshold { get; set; }

        /// <summary>
        /// Gets or sets the longest period of time to wait before checking for a message to arrive when a queue remains
        /// empty.
        /// </summary>
        public TimeSpan MaxPollingInterval { get; set; }

        /// <summary>
        /// Gets or sets the message visibility that will be used for messages that
        /// fail processing.
        /// </summary>
        public TimeSpan VisibilityTimeout { get; set; }
    }
}
