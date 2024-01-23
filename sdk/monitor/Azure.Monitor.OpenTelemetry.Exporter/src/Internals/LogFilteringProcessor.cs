// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class LogFilteringProcessor : BaseProcessor<LogRecord>
    {
        private readonly bool _enableSampling;
        private readonly BaseProcessor<LogRecord> _processor;

        public LogFilteringProcessor(bool enableSampling, BaseProcessor<LogRecord> processor)
        {
            _enableSampling = enableSampling;
            _processor = processor;
        }

        public override void OnEnd(LogRecord logRecord)
        {
            if (!_enableSampling || logRecord.SpanId == default || logRecord.TraceFlags == ActivityTraceFlags.Recorded)
            {
                _processor.OnEnd(logRecord);
            }
        }

        protected override bool OnForceFlush(int timeoutMilliseconds)
        {
            return _processor.ForceFlush(timeoutMilliseconds);
        }

        protected override bool OnShutdown(int timeoutMilliseconds)
        {
           return _processor.Shutdown();
        }

        protected override void Dispose(bool disposing)
        {
            _processor.Dispose();
        }
    }
}
