// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Threading;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class StatsBeat : IDisposable
    {
        private readonly IDisposable _meterProvider;

        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        private const string ConnectionString = "<ConnectionString>";

        private static string s_roleName;

        private static string s_roleInstance;

        private static string s_ikey;

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

        internal static string Customer_Ikey { get => s_ikey; set => s_ikey = value; }
        internal static string Statsbeat_RoleName { get => s_roleName; set => s_roleName = value; }
        internal static string Statsbeat_RoleInstance { get => s_roleInstance; set => s_roleInstance = value; }

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
