// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
#if STORAGE_WEBJOBS_PUBLIC_QUEUE_PROCESSOR
    /// <summary>
    /// Represents configuration for <see cref="QueueTriggerAttribute"/>.
    /// </summary>
    public class QueuesOptions : IOptionsFormatter
#else
    internal class QueuesOptions : IOptionsFormatter
#endif
    {
        private const int DefaultMaxDequeueCount = 5;
        private const int DefaultBatchSize = 16;

        // Azure Queues currently limits the number of messages retrieved to 32. We enforce this constraint here because
        // the runtime error message the user would receive from the SDK otherwise is not as helpful.
        internal const int MaxBatchSize = 32;

        private int _batchSize = DefaultBatchSize;
        private int _newBatchThreshold;
        private int _processorCount = 1;
        private TimeSpan _maxPollingInterval = QueuePollingIntervals.DefaultMaximum;
        private TimeSpan _visibilityTimeout = TimeSpan.Zero;
        private int _maxDequeueCount = DefaultMaxDequeueCount;
        private QueueMessageEncoding _messageEncoding = QueueMessageEncoding.Base64;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueuesOptions"/> class.
        /// </summary>
        public QueuesOptions()
        {
            _newBatchThreshold = -1;
            _processorCount = SkuUtility.ProcessorCount;
        }

        /// <summary>
        /// Gets or sets the number of queue messages to retrieve and process in parallel (per job method).
        /// </summary>
        public int BatchSize
        {
            get { return _batchSize; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (value > MaxBatchSize)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _batchSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the threshold at which a new batch of messages will be fetched.
        /// </summary>
        public int NewBatchThreshold
        {
            get
            {
                if (_newBatchThreshold == -1)
                {
                    // if this hasn't been set explicitly, default it
                    return (_batchSize / 2) * _processorCount;
                }
                return _newBatchThreshold;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _newBatchThreshold = value;
            }
        }

        /// <summary>
        /// Gets or sets the longest period of time to wait before checking for a message to arrive when a queue remains
        /// empty.
        /// </summary>
        public TimeSpan MaxPollingInterval
        {
            get { return _maxPollingInterval; }

            set
            {
                if (value < QueuePollingIntervals.Minimum)
                {
                    string message = String.Format(CultureInfo.CurrentCulture,
                        "MaxPollingInterval must not be less than {0}.", QueuePollingIntervals.Minimum);
                    throw new ArgumentException(message, nameof(value));
                }

                _maxPollingInterval = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of times to try processing a message before moving it to the poison queue (where
        /// possible).
        /// </summary>
        /// <remarks>
        /// Some queues do not have corresponding poison queues, and this property does not apply to them. Specifically,
        /// there are no corresponding poison queues for any queue whose name already ends in "-poison" or any queue
        /// whose name is already too long to add a "-poison" suffix.
        /// </remarks>
        public int MaxDequeueCount
        {
            get { return _maxDequeueCount; }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("MaxDequeueCount must not be less than 1.", nameof(value));
                }

                _maxDequeueCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the default message visibility timeout that will be used
        /// for messages that fail processing. The default is TimeSpan.Zero. To increase
        /// the time delay between retries, increase this value.
        /// </summary>
        /// <remarks>
        /// When message processing fails, the message will remain in the queue and
        /// its visibility will be updated with this value. The message will then be
        /// available for reprocessing after this timeout expires.
        /// </remarks>
        public TimeSpan VisibilityTimeout
        {
            get
            {
                return _visibilityTimeout;
            }
            set
            {
                _visibilityTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets a message encoding that determines how queue message body is represented in HTTP requests and responses.
        /// The default is <see cref="QueueMessageEncoding.Base64"/>.
        /// </summary>
        public QueueMessageEncoding MessageEncoding
        {
            get
            {
                return _messageEncoding;
            }
            set
            {
                _messageEncoding = value;
            }
        }

        /// <inheritdoc/>
        public string Format()
        {
            JObject options = new JObject
            {
                { nameof(BatchSize), BatchSize },
                { nameof(NewBatchThreshold), NewBatchThreshold },
                { nameof(MaxPollingInterval), MaxPollingInterval },
                { nameof(MaxDequeueCount), MaxDequeueCount },
                { nameof(VisibilityTimeout), VisibilityTimeout },
                { nameof(MessageEncoding), MessageEncoding.ToString() }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
