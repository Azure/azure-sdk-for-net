// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Threading;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class Statsbeat
    {
        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        private const string StatsBeat_ConnectionString = "<StatsBeat_ConnectionString>";

        // TODO: Move IsWindowsOS() to new class
        // Do we need to support OSX?
        internal static string s_OS = StorageHelper.IsWindowsOS() ? "windows" : "linux";

        internal const int AttachStatsBeatInterval = 86400000;

        static Statsbeat()
        {
            s_myMeter.CreateObservableGauge("AttachStatsBeat", () => GetAttachStatsBeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            Sdk.CreateMeterProviderBuilder()
            .AddMeter("AttachStatsBeatMeter")
            .AddAzureMonitorStatsbeatExporter(o =>
            {
                o.ConnectionString = StatsBeat_ConnectionString;
                o.DisableOfflineStorage = true;
                o.StatsbeatIntervalInMilliseconds = AttachStatsBeatInterval;
            })
            .Build();
        }

        internal static string Customer_Ikey { get; set; }

        private static Measurement<int> GetAttachStatsBeat()
        {
            // TODO: Add additional properties required for statbeat
            return new(1, new("cikey", Customer_Ikey), new("language", "dotnet"), new("os", s_OS));
        }
    }
}
