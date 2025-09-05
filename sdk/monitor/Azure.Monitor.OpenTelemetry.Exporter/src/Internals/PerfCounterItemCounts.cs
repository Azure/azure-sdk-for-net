// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Thread-safe counters for performance metrics.
    /// </summary>
    internal sealed class PerfCounterItemCounts
    {
        private long _totalRequestCount = 0;
        private long _totalExceptionCount = 0;

        /// <summary>
        /// Atomically increments the total request count.
        /// </summary>
        /// <returns>The new value after incrementing.</returns>
        public long IncrementRequestCount()
        {
            return Interlocked.Increment(ref _totalRequestCount);
        }

        /// <summary>
        /// Atomically increments the total exception count.
        /// </summary>
        /// <returns>The new value after incrementing.</returns>
        public long IncrementExceptionCount()
        {
            return Interlocked.Increment(ref _totalExceptionCount);
        }

        /// <summary>
        /// Atomically reads the current total request count.
        /// </summary>
        /// <returns>The current request count.</returns>
        public long ReadRequestCount()
        {
            return Interlocked.Read(ref _totalRequestCount);
        }

        /// <summary>
        /// Atomically reads the current total exception count.
        /// </summary>
        /// <returns>The current exception count.</returns>
        public long ReadExceptionCount()
        {
            return Interlocked.Read(ref _totalExceptionCount);
        }
    }
}
