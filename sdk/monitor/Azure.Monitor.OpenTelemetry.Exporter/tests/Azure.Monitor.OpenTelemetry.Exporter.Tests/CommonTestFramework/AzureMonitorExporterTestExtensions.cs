// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    /// <summary>
    /// Extension methods to simplify registering of Azure Monitor Exporter for unit tests.
    /// </summary>
    public static class AzureMonitorExporterTestExtensions
    {
        /// <summary>
        /// Extension methods to simplify registering of <see cref="AzureMonitorLogExporter"/> with <see cref="MockTransmitter"/> for unit tests.
        /// </summary>
        internal static OpenTelemetryLoggerOptions AddAzureMonitorLogExporterForTest(this OpenTelemetryLoggerOptions loggerOptions, out List<TelemetryItem> telemetryItems)
        {
            if (loggerOptions == null)
            {
                throw new ArgumentNullException(nameof(loggerOptions));
            }

            telemetryItems = new List<TelemetryItem>();

            return loggerOptions.AddProcessor(new SimpleLogRecordExportProcessor(new AzureMonitorLogExporter(new MockTransmitter(telemetryItems))));
        }

        /// <summary>
        /// Extension methods to simplify registering of <see cref="AzureMonitorMetricExporter"/> with <see cref="MockTransmitter"/> for unit tests.
        /// </summary>
        internal static MeterProviderBuilder AddAzureMonitorMetricExporterForTest(this MeterProviderBuilder builder, out List<TelemetryItem> telemetryItems)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            telemetryItems = new List<TelemetryItem>();

            return builder.AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(new MockTransmitter(telemetryItems)))
            {
                TemporalityPreference = MetricReaderTemporalityPreference.Delta
            });
        }

        /// <summary>
        /// Extension methods to simplify registering of <see cref="AzureMonitorMetricExporter"/> with <see cref="MockTransmitter"/> for unit tests.
        /// </summary>
        internal static MeterProviderBuilder AddAzureMonitorMetricExporterForTest(this MeterProviderBuilder builder, out List<TelemetryItem> telemetryItems, out MetricReader metricReader)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            telemetryItems = new List<TelemetryItem>();

            metricReader = new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(new MockTransmitter(telemetryItems)));

            return builder.AddReader(metricReader);
        }

        /// <summary>
        /// Extension methods to simplify registering of <see cref="AzureMonitorTraceExporter"/> with <see cref="MockTransmitter"/> for unit tests.
        /// </summary>
        internal static TracerProviderBuilder AddAzureMonitorTraceExporterForTest(this TracerProviderBuilder builder, out List<TelemetryItem> telemetryItems, Action<AzureMonitorExporterOptions>? configure = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            telemetryItems = new List<TelemetryItem>();

            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            builder.SetSampler(new ApplicationInsightsSampler(options.SamplingRatio));

            return builder.AddProcessor(new SimpleActivityExportProcessor(new AzureMonitorTraceExporter(options, new MockTransmitter(telemetryItems))));
        }
    }
}
