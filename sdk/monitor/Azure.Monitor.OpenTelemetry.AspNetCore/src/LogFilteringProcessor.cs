using System;
using System.Collections.Generic;
using System.Text;
using OpenTelemetry.Logs;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    internal class LogFilteringProcessor : BatchLogRecordExportProcessor
    {
        private readonly bool _enableSampling;
        private readonly BaseProcessor<LogRecord> _processor;

        public LogFilteringProcessor(BaseExporter<LogRecord> exporter)
            : base(exporter)
        {
        }

        public override void OnEnd(LogRecord logRecord)
        {
            if (logRecord.SpanId == default || logRecord.TraceFlags == ActivityTraceFlags.Recorded)
            {
                base.OnEnd(logRecord);
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
