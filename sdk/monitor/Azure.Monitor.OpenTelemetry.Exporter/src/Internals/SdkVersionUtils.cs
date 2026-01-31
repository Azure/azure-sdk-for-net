// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
#if AZURE_MONITOR_EXPORTER
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
#elif ASP_NET_CORE_DISTRO
using Azure.Monitor.OpenTelemetry.AspNetCore;
#endif
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class SdkVersionUtils
    {
        private static string? s_prefix;
        internal static string s_sdkVersion = GetSdkVersion();
        internal static SdkVersionType? s_sdkVersionType;
        internal static string? s_extensionVersion;
        internal static string? s_extensionVersionOverride;

        /// <summary>
        /// IsHydrated represents whether the SdkVersionUtils has been populated by CreateAzureMonitorResource.
        /// </summary>
        internal static bool IsHydrated => s_sdkVersionType != null || s_extensionVersionOverride != null;

        internal static string? SdkVersionPrefix
        {
            get { return s_prefix; }
            set
            {
                s_prefix = value;
                s_sdkVersion = GetSdkVersion();
            }
        }

        internal static SdkVersionType VersionType
        {
            get => s_sdkVersionType ?? SdkVersionType.Exporter;
            set
            {
                s_sdkVersionType = value;
                s_sdkVersion = GetSdkVersion();
            }
        }

        internal static string? ExtensionVersion
        {
            get => s_extensionVersionOverride ?? s_extensionVersion;
            set => s_extensionVersionOverride = value;
        }

        internal static string? ExtensionLabel { get; set; }

        internal static string? GetVersion(Type? type = null)
        {
            if (type == null)
            {
                return ExtensionLabel + ExtensionVersion;
            }

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
#elif ASP_NET_CORE_DISTRO
                    AzureMonitorAspNetCoreEventSource.Log.VersionStringUnexpectedLength(type.Name, versionString);
#elif LIVE_METRICS_PROJECT
                    LiveMetrics.AzureMonitorLiveMetricsEventSource.Log.VersionStringUnexpectedLength(type.Name, versionString);
#endif
                    return shortVersion.Substring(0, 20);
                }

                return shortVersion;
            }
            catch (Exception ex)
            {
#if AZURE_MONITOR_EXPORTER
                AzureMonitorExporterEventSource.Log.ErrorInitializingPartOfSdkVersion(type.Name, ex);
#elif ASP_NET_CORE_DISTRO
                AzureMonitorAspNetCoreEventSource.Log.ErrorInitializingPartOfSdkVersion(type.Name, ex);
#elif LIVE_METRICS_PROJECT
                LiveMetrics.AzureMonitorLiveMetricsEventSource.Log.ErrorInitializingPartOfSdkVersion(type.Name, ex);
#endif
                return null;
            }
        }

        internal static string GetSdkVersion()
        {
            try
            {
                string? sdkVersionPrefix = !string.IsNullOrWhiteSpace(SdkVersionPrefix) ? $"{SdkVersionPrefix}_" : null;
                string? dotnetSdkVersion = GetVersion(typeof(object));
                string? otelSdkVersion = GetVersion(typeof(Sdk));

#if AZURE_MONITOR_EXPORTER
                string? extensionVersion = GetVersion(typeof(AzureMonitorTraceExporter));
#elif ASP_NET_CORE_DISTRO
                string? extensionVersion = GetVersion(typeof(AzureMonitorAspNetCoreEventSource));
#elif LIVE_METRICS_PROJECT
                string? extensionVersion = GetVersion(typeof(LiveMetrics.AzureMonitorLiveMetricsEventSource));
#endif

                switch (VersionType)
                {
                    case SdkVersionType.Distro:
                        ExtensionLabel = "dst";
                        break;
                    case SdkVersionType.ShimBase:
                        ExtensionLabel = "sha";
                        break;
                    case SdkVersionType.ShimAspNetCore:
                        ExtensionLabel = "shc";
                        break;
                    case SdkVersionType.ShimWorkerService:
                        ExtensionLabel = "shw";
                        break;
                    case SdkVersionType.ShimWeb:
                        ExtensionLabel = "shf";
                        break;
                    case SdkVersionType.ShimNLog:
                        ExtensionLabel = "shn";
                        break;
                    case SdkVersionType.Exporter:
                    default:
                        ExtensionLabel = "ext";
                        // if we do not recognise the extension type, providing an extension version is meaningless,
                        // clear the extension version so that the exporter version is used instead.
                        s_extensionVersionOverride = null;
                        break;
                }

                s_extensionVersion = extensionVersion ?? "u"; // 'u' for Unknown

                return string.Format(CultureInfo.InvariantCulture, $"{sdkVersionPrefix}dotnet{dotnetSdkVersion}:otel{otelSdkVersion}:{ExtensionLabel}{ExtensionVersion}");
            }
            catch (Exception ex)
            {
#if AZURE_MONITOR_EXPORTER
                AzureMonitorExporterEventSource.Log.SdkVersionCreateFailed(ex);
#elif ASP_NET_CORE_DISTRO
                AzureMonitorAspNetCoreEventSource.Log.SdkVersionCreateFailed(ex);
#elif LIVE_METRICS_PROJECT
                LiveMetrics.AzureMonitorLiveMetricsEventSource.Log.SdkVersionCreateFailed(ex);
#endif

                // Return a default value in case of failure.
                // We don't think this will ever happen.
                // We will monitor internal telemetry and if we detect this we may explore an alternative approach to collecting version numbers.
                return "dotnetu:otelu:extu"; // 'u' for Unknown
            }
        }
    }

    /// <summary>
    /// Specifies the type of SDK for telemetry identification and version labeling.
    /// </summary>
    internal enum SdkVersionType
    {
        /// <summary>Default Azure Monitor OpenTelemetry Exporter.</summary>
        Exporter,
        /// <summary>Azure Monitor OpenTelemetry AspNetCore Distro.</summary>
        Distro,
        /// <summary>Application Insights base shim (Microsoft.ApplicationInsights).</summary>
        ShimBase,
        /// <summary>Application Insights AspNetCore shim (Microsoft.ApplicationInsights.AspNetCore).</summary>
        ShimAspNetCore,
        /// <summary>Application Insights WorkerService shim (Microsoft.ApplicationInsights.WorkerService).</summary>
        ShimWorkerService,
        /// <summary>Application Insights Web shim (Microsoft.ApplicationInsights.Web).</summary>
        ShimWeb,
        /// <summary>Application Insights NLog shim (Microsoft.ApplicationInsights.NLogTarget).</summary>
        ShimNLog,
    }
}
