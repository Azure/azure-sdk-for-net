﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Logs;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    internal class LogFilteringProcessor : BatchLogRecordExportProcessor
    {
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
    }
}
