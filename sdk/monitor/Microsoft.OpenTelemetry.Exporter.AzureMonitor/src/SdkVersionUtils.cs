// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using OpenTelemetry;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal static class SdkVersionUtils
    {
        internal static string SdkVersion = GetSdkVersion();

        private static string GetSdkVersion()
        {
            try
            {
                Version dotnetSdkVersion = GetVersion(typeof(object));
                Version otelSdkVersion = GetVersion(typeof(Sdk));
                Version extensionVersion = GetVersion(typeof(AzureMonitorTraceExporter));

                return string.Format(CultureInfo.InvariantCulture, $"dotnet{dotnetSdkVersion.ToString(2)}:otel{otelSdkVersion.ToString(3)}:ext{extensionVersion.ToString(3)}");
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"SdkVersionCreateFailed{EventLevelSuffix.Warning}", ex);
                return null;
            }
        }

        private static Version GetVersion(Type type)
        {
            // TODO: Distinguish preview/stable release and minor versions. e.g: 5.0.0-preview.8.20365.13
            string versionString = type
                .Assembly
                .GetCustomAttributes(false)
                .OfType<AssemblyFileVersionAttribute>()
                .First()
                .Version;

            // Return zeros rather then failing if the version string fails to parse
            return Version.TryParse(versionString, out var version) ? version : new Version();
        }
    }
}
