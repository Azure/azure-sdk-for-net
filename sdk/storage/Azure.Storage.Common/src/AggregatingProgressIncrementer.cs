// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Common
{
    /// <summary>
    /// An accumulator for request and response data transfers.
    /// </summary>
    internal sealed class AggregatingProgressIncrementer : IProgress<long>
    {
        private long _currentValue;
        private bool _currentValueHasValue;
        private readonly IProgress<StorageProgress> _innerHandler;

        public Stream CreateProgressIncrementingStream(Stream stream) => _innerHandler != null && stream != null ? new ProgressIncrementingStream(stream, this) : stream;

        public AggregatingProgressIncrementer(IProgress<StorageProgress> innerHandler) => _innerHandler = innerHandler;

        /// <summary>
        /// Increments the current value and reports it to the progress handler
        /// </summary>
        /// <param name="bytes"></param>
        public void Report(long bytes)
        {
            Interlocked.Add(ref _currentValue, bytes);
            Volatile.Write(ref _currentValueHasValue, true);

            if (_innerHandler != null)
            {
                StorageProgress current = Current;

                if (current != null)
                {
                    _innerHandler.Report(current);
                }
            }
        }

        /// <summary>
        /// Zeroes out the current accumulation, and reports it to the progress handler
        /// </summary>
        public void Reset()
        {
            var currentActual = Volatile.Read(ref _currentValue);

            Report(-currentActual);
        }

        /// <summary>
        /// Returns an instance that no-ops accumulation.
        /// </summary>
        public static AggregatingProgressIncrementer None { get; } = new AggregatingProgressIncrementer(default);

        /// <summary>
        /// Returns a StorageProgress instance representing the current progress value.
        /// </summary>
        public StorageProgress Current
        {
            get
            {
                var result = default(StorageProgress);

                if (_currentValueHasValue)
                {
                    var currentActual = Volatile.Read(ref _currentValue);

                    result = new StorageProgress(currentActual);
                }

                return result;
            }
        }
    }
}
