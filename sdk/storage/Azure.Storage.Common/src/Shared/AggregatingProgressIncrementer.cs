// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// An accumulator for request and response data transfers.
    /// </summary>
    internal sealed class AggregatingProgressIncrementer : IProgress<long>
    {
        private long _currentValue;
        private readonly IProgress<long> _innerHandler;

        public Stream CreateProgressIncrementingStream(Stream stream) => _innerHandler != null && stream != null ? new ProgressIncrementingStream(stream, this) : stream;

        public AggregatingProgressIncrementer(IProgress<long> innerHandler) => _innerHandler = innerHandler;

        /// <summary>
        /// Increments the current value and reports it to the progress handler
        /// </summary>
        /// <param name="bytes"></param>
        public void Report(long bytes)
        {
            Interlocked.Add(ref _currentValue, bytes);

            _innerHandler?.Report(Current);
        }

        /// <summary>
        /// Zeroes out the current accumulation, and reports it to the progress handler
        /// </summary>
        public void Reset()
        {
            Volatile.Write(ref _currentValue, 0);
            Report(0);
        }

        /// <summary>
        /// Returns an instance that no-ops accumulation.
        /// </summary>
        public static AggregatingProgressIncrementer None { get; } = new AggregatingProgressIncrementer(default);

        /// <summary>
        /// Returns a long instance representing the current progress value.
        /// </summary>
        public long Current
        {
            get
            {
                return Volatile.Read(ref _currentValue);
            }
        }
    }
}
