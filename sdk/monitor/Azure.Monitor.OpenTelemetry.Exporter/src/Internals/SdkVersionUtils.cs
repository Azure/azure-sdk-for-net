// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
#if AZURE_MONITOR_EXPORTER
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
#elif LIVE_METRICS_EXPORTER
using Azure.Monitor.OpenTelemetry.LiveMetrics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
#endif
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class SdkVersionUtils
    {
        private static string? s_prefix;
        internal static string? s_sdkVersion = GetSdkVersion();
        internal static bool s_isDistro = false;

        internal static string? SdkVersionPrefix
        {
            get { return s_prefix; }
            set
            {
                s_prefix = value;
                s_sdkVersion = GetSdkVersion();
            }
        }

        internal static bool IsDistro
        {
            get => s_isDistro;
            set
            {
                s_isDistro = value;
                s_sdkVersion = GetSdkVersion();
            }
        }

        internal static string? GetVersion(Type type)
        {
            try
            {
                string versionString = type
                    .Assembly
                    .GetCustomAttributes<AssemblyInformationalVersionAttribute>()
                    .First()
                    .InformationalVersion;

                // Informational version may contain extra information.
                // 1) "1.1.0-beta2+a25741030f05c60c85be102ce7c33f3899290d49". Ignoring part after '+' if it is present.
                // 2) "4.6.30411.01 @BuiltBy: XXXXXX @Branch: XXXXXX @srccode: XXXXXX XXXXXX" Ignoring part after '@' if it is present.
                string shortVersion = versionString.Split('+', '@', ' ')[0];

                if (shortVersion.Length > 20)
                {
#if AZURE_MONITOR_EXPORTER
                    AzureMonitorExporterEventSource.Log.VersionStringUnexpectedLength(type.Name, versionString);
#elif LIVE_METRICS_EXPORTER
                    LiveMetricsExporterEventSource.Log.VersionStringUnexpectedLength(type.Name, versionString);
#endif
                    return shortVersion.Substring(0, 20);
                }

                return shortVersion;
            }
            catch (Exception ex)
            {
#if AZURE_MONITOR_EXPORTER
                AzureMonitorExporterEventSource.Log.ErrorInitializingPartOfSdkVersion(type.Name, ex);
#elif LIVE_METRICS_EXPORTER
                LiveMetricsExporterEventSource.Log.ErrorInitializingPartOfSdkVersion(type.Name, ex);
#endif
                return null;
            }
        }

        private static string? GetSdkVersion()
        {
            try
            {
                string? sdkVersionPrefix = !string.IsNullOrWhiteSpace(SdkVersionPrefix) ? $"{SdkVersionPrefix}_" : null;
                string? dotnetSdkVersion = GetVersion(typeof(object));
                string? otelSdkVersion = GetVersion(typeof(Sdk));
#if AZURE_MONITOR_EXPORTER
                string? extensionVersion = GetVersion(typeof(AzureMonitorTraceExporter));
#elif LIVE_METRICS_EXPORTER
                string? extensionVersion = GetVersion(typeof(LiveMetricsActivityProcessor));
#endif

                if (IsDistro)
                {
                    extensionVersion += "-d";
                }

                return string.Format(CultureInfo.InvariantCulture, $"{sdkVersionPrefix}dotnet{dotnetSdkVersion}:otel{otelSdkVersion}:ext{extensionVersion}");
            }
            catch (Exception ex)
            {
#if AZURE_MONITOR_EXPORTER
                AzureMonitorExporterEventSource.Log.SdkVersionCreateFailed(ex);
#elif LIVE_METRICS_EXPORTER
                LiveMetricsExporterEventSource.Log.SdkVersionCreateFailed(ex);
#endif
                return null;
            }
        }
    }
}
