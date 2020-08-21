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
            Version dotnetSdkVersion = GetVersion(typeof(object));
            Version otelSdkVersion = GetVersion(typeof(OpenTelemetry.Sdk));
            Version extensionVersion = GetVersion(typeof(OpenTelemetry.Exporter.AzureMonitor.AzureMonitorTraceExporter));

            return string.Format(CultureInfo.InvariantCulture, $"dotnet{dotnetSdkVersion.ToString(2)}:otel{otelSdkVersion.ToString(3)}:ext{extensionVersion.ToString(3)}");
        }

        private static Version GetVersion(Type type)
        {
            // TODO: Distinguish preview/stable release and minor versions. e.g: 5.0.0-preview.8.20365.13
            var versionString = type.Assembly.GetCustomAttributes(false)
                                                .OfType<AssemblyFileVersionAttribute>()
                                                .First()
                                                .Version;

            // Return zeros rather then failing if the version string fails to parse
            return Version.TryParse(versionString, out var version) ? version : new Version();
        }
    }
}
