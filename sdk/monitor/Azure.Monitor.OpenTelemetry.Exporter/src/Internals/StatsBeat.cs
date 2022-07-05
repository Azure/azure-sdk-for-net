// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class StatsBeat : IDisposable
    {
        private readonly IDisposable _meterProvider;

        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        private const string ConnectionString = "<ConnectionString>";

        internal static string s_roleName;

        internal static string s_roleInstance;

        internal static string s_ikey;

        internal static string s_os = StorageHelper.IsWindowsOS() ? "windows" : "linux";

        internal const int AttachStatsBeatInterval = 86400000;

        private StatsBeat()
        {
            s_myMeter.CreateObservableGauge("AttachStatsBeat", () => GetAttachStatsBeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            _meterProvider = Sdk.CreateMeterProviderBuilder()
            .AddMeter("AttachStatsBeatMeter")
            .AddAzureMonitorStatsBeatExporter(o =>
            {
                o.ConnectionString = ConnectionString;
                o.DisableOfflineStorage = true;
                o.StatsBeatInterval = AttachStatsBeatInterval;
            })
            .Build();
        }

        public static StatsBeat StatsBeatInstance { get; } = new();

        private static Measurement<int> GetAttachStatsBeat()
        {
            // TODO: Add additional properties required for statbeat
            return new((int)1, new("ikey", s_ikey), new("language", "DotNet"), new("os", s_os));
        }

        public void Dispose()
        {
            _meterProvider?.Dispose();
        }
    }
}
