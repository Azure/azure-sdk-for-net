// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Threading;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class Statsbeat : IDisposable
    {
        private readonly IDisposable _meterProvider;

        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        private const string ConnectionString = "<ConnectionString>";

        // TODO: Move IsWindowsOS() to new class
        // Do we need to support OSX?
        internal static string s_os = StorageHelper.IsWindowsOS() ? "windows" : "linux";

        internal const int AttachStatsBeatInterval = 86400000;

        private Statsbeat()
        {
            s_myMeter.CreateObservableGauge("AttachStatsBeat", () => GetAttachStatsBeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            _meterProvider = Sdk.CreateMeterProviderBuilder()
            .AddMeter("AttachStatsBeatMeter")
            .AddAzureMonitorStatsbeatExporter(o =>
            {
                o.ConnectionString = ConnectionString;
                o.DisableOfflineStorage = true;
                o.StatsbeatIntervalInMilliseconds = AttachStatsBeatInterval;
            })
            .Build();
        }

        public static Statsbeat StatsbeatInstance { get; } = new();

        internal static string Customer_Ikey { get; set; }

        private static Measurement<int> GetAttachStatsBeat()
        {
            // TODO: Add additional properties required for statbeat
            return new((int)1, new("ikey", Customer_Ikey), new("language", "DotNet"), new("os", s_os));
        }

        public void Dispose()
        {
            _meterProvider?.Dispose();
        }
    }
}
