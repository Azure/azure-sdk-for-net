using System;
using System.Collections.Generic;
using System.Text;
using OpenTelemetry.Logs;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    internal class LogFilteringProcessor : BaseProcessor<LogRecord>
    {
        private readonly bool _enableSampling;
        private readonly BaseProcessor<LogRecord> _processor;

        public LogFilteringProcessor(BaseProcessor<LogRecord> processor)
        {
            _processor = processor;
        }

        public override void OnEnd(LogRecord logRecord)
        {
            if (logRecord.SpanId == default || logRecord.TraceFlags == ActivityTraceFlags.Recorded)
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
