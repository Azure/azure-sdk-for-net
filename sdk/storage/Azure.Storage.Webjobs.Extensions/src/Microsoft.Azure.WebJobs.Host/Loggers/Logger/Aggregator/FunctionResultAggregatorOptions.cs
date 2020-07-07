// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Logging
{
    /// <summary>
    /// Configuration options for function result aggregation.
    /// </summary>
    public class FunctionResultAggregatorOptions : IOptionsFormatter
    {
        private int _batchSize;
        private TimeSpan _flushTimeout;

        private const int DefaultBatchSize = 1000;
        private const int MaxBatchSize = 10000;

        private static readonly TimeSpan DefaultFlushTimeout = TimeSpan.FromSeconds(30);
        private static readonly TimeSpan MaxFlushTimeout = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public FunctionResultAggregatorOptions()
        {
            _batchSize = DefaultBatchSize;
            _flushTimeout = DefaultFlushTimeout;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the aggregator is enabled.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating the the maximum batch size for aggregations. When this number is hit, the results are
        /// aggregated and sent to every registered <see cref="ILogger"/>.
        /// </summary>
        public int BatchSize
        {
            get { return _batchSize; }

            set
            {
                if (value <= 0 || value > MaxBatchSize)
                {
                    string message = $"'{nameof(BatchSize)}' value must be greater than 0 and less than or equal to {MaxBatchSize}.";
                    throw new ArgumentOutOfRangeException(null, value, message);
                }

                _batchSize = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating when the aggregator will send results to every registered <see cref="ILogger"/>.
        /// </summary>
        public TimeSpan FlushTimeout
        {
            get { return _flushTimeout; }

            set
            {
                if (value <= TimeSpan.Zero || value > MaxFlushTimeout)
                {
                    string message = $"'{nameof(FlushTimeout)}' value must be greater than '{TimeSpan.Zero.ToString()}' and less than or equal to '{MaxFlushTimeout.ToString()}'.";
                    throw new ArgumentOutOfRangeException(null, value, message);
                }

                _flushTimeout = value;
            }
        }

        public string Format()
        {
            JObject options = new JObject
            {
                { nameof(BatchSize), BatchSize },
                { nameof(FlushTimeout), FlushTimeout },
                { nameof(IsEnabled), IsEnabled }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
