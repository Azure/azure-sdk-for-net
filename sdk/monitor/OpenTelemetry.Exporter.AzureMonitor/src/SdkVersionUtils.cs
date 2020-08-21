// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal class SdkVersionUtils
    {
        internal static string GetSdkVersion()
        {
            Version dotnetSdkVersion = GetVersion(typeof(object));
            Version otSdkVersion = GetVersion(typeof(OpenTelemetry.Sdk));
            Version extensionVersion = GetVersion(typeof(OpenTelemetry.Exporter.AzureMonitor.AzureMonitorTraceExporter));

            return string.Format(CultureInfo.InvariantCulture, $"dotnet{dotnetSdkVersion.ToString(2)}:ot{otSdkVersion.ToString(3)}:ext{extensionVersion.ToString(3)}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Version GetVersion(Type type)
        {
            var versionString = type.Assembly.GetCustomAttributes(false)
                                                .OfType<AssemblyFileVersionAttribute>()
                                                .First()
                                                .Version;

            // Return zeros rather then failing if the version string fails to parse
            return Version.TryParse(versionString, out var version) ? version : new Version();
        }
    }
}
