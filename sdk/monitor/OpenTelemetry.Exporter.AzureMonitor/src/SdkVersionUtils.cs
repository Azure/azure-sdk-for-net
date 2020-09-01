// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal class SdkVersionUtils
    {
        private static string sdkVersion;

        internal static string SdkVersion {
            get
            {
                return sdkVersion ??= GetSdkVersion();
            }
        }

        private static string GetSdkVersion()
        {
            string sdkVer = null;

            try
            {
                Version dotnetSdkVersion = GetVersion(typeof(object));
                Version otelSdkVersion = GetVersion(typeof(OpenTelemetry.Sdk));
                Version extensionVersion = GetVersion(typeof(OpenTelemetry.Exporter.AzureMonitor.AzureMonitorTraceExporter));

                sdkVer = string.Format(CultureInfo.InvariantCulture, $"dotnet{dotnetSdkVersion.ToString(2)}:otel{otelSdkVersion.ToString(3)}:ext{extensionVersion.ToString(3)}");
            }
            catch (Exception ex)
            {
                AzureMonitorTraceExporterEventSource.Log.SdkVersionCreateFailed(ex);
            }

            return sdkVer;
        }

        private static Version GetVersion(Type type)
        {
            string versionString = null;

            try
            {
                // TODO: Distinguish preview/stable release and minor versions. e.g: 5.0.0-preview.8.20365.13
                versionString = type.Assembly.GetCustomAttributes(false)
                                                    .OfType<AssemblyFileVersionAttribute>()
                                                    .First()
                                                    .Version;
            }
            catch (Exception ex)
            {
                AzureMonitorTraceExporterEventSource.Log.SdkVersionCreateFailed(ex);
            }

            // Return zeros rather then failing if the version string fails to parse
            return Version.TryParse(versionString, out var version) ? version : new Version();
        }
    }
}
