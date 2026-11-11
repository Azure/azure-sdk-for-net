// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class LogFilteringProcessor : AzureMonitorBatchLogRecordExportProcessor
    {
        private readonly float _fallbackSampleRate;

        public LogFilteringProcessor(BaseExporter<LogRecord> exporter)
            : this(exporter, SampleRateHelper.FullSampleRate)
        {
        }

        /// <param name="exporter">The exporter that receives the logs kept by the filter.</param>
        /// <param name="fallbackSampleRate">
        /// Sample rate to report for a log in a sampled span when the span's own rate cannot be read.
        /// </param>
        public LogFilteringProcessor(BaseExporter<LogRecord> exporter, float fallbackSampleRate)
            : base(exporter)
        {
            _fallbackSampleRate = fallbackSampleRate;
        }

        public override void OnEnd(LogRecord logRecord)
        {
            if (logRecord.SpanId == default)
            {
                base.OnEnd(logRecord);
            }
            else if ((logRecord.TraceFlags & ActivityTraceFlags.Recorded) != 0)
            {
                // A log kept here stands in for the logs of the traces that were sampled out, so it
                // carries its span's sample rate for ingestion to derive itemCount.
                AddSampleRate(logRecord);
                base.OnEnd(logRecord);
            }
        }

        private void AddSampleRate(LogRecord logRecord)
        {
            var attributes = logRecord.Attributes;
            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    if (attribute.Key == SemanticConventions.AttributeMicrosoftSampleRate)
                    {
                        return;
                    }
                }
            }

            // OnEnd runs synchronously on the logging call, where the log's trace context was taken
            // from Activity.Current. A record whose context was set some other way falls back.
            var activity = Activity.Current;
            var sampleRate = activity != null
                && activity.SpanId == logRecord.SpanId
                && SampleRateHelper.TryGetSampleRate(activity.GetTagItem(SemanticConventions.AttributeMicrosoftSampleRate), out var spanSampleRate)
                    ? spanSampleRate
                    : _fallbackSampleRate;

            if (!SampleRateHelper.IsReportable(sampleRate))
            {
                return;
            }

            var merged = new List<KeyValuePair<string, object?>>((attributes?.Count ?? 0) + 1);
            if (attributes != null)
            {
                merged.AddRange(attributes);
            }

            merged.Add(new KeyValuePair<string, object?>(SemanticConventions.AttributeMicrosoftSampleRate, sampleRate));
            logRecord.Attributes = merged;
        }
    }
}
