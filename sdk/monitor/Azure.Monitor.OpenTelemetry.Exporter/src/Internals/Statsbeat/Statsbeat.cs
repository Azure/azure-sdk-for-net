// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Metrics;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class Statsbeat
    {
        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        private const string StatsBeat_ConnectionString = "<StatsBeat_ConnectionString>";

        internal const int AttachStatsBeatInterval = 86400000;

        static Statsbeat()
        {
            s_myMeter.CreateObservableGauge("AttachStatsBeat", () => GetAttachStatsBeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            var exporterOptions = new AzureMonitorExporterOptions();
            exporterOptions.DisableOfflineStorage = true;
            exporterOptions.ConnectionString = StatsBeat_ConnectionString;

            Sdk.CreateMeterProviderBuilder()
                .AddMeter("AttachStatsBeatMeter")
            .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), AttachStatsBeatInterval)
            { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
            .Build();
        }

        internal static string Customer_Ikey { get; set; }

        private static Measurement<int> GetAttachStatsBeat()
        {
            // TODO: Add additional properties required for statbeat
            return new(1, new("cikey", Customer_Ikey), new("language", "dotnet"));
        }
    }
}
