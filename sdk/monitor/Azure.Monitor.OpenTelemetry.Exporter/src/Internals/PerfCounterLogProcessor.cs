// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class PerfCounterLogProcessor : BaseProcessor<LogRecord>
    {
        private bool _disposed;
        private readonly PerfCounterItemCounts _itemCounts;

        internal PerfCounterLogProcessor(PerfCounterItemCounts itemCounts)
        {
            _itemCounts = itemCounts;
        }

        public override void OnEnd(LogRecord data)
        {
            if (data.Exception is not null)
            { 
                _itemCounts.IncrementExceptionCount();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // cleanup if needed
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
