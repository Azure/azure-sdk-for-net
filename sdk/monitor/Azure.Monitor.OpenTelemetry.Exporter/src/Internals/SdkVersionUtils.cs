// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class SdkVersionUtils
    {
        internal static string? s_sdkVersion = GetSdkVersion();

        private static string? GetSdkVersion()
        {
            try
            {
                string? dotnetSdkVersion = GetVersion(typeof(object));
                string? otelSdkVersion = GetVersion(typeof(Sdk));
                string? extensionVersion = GetVersion(typeof(AzureMonitorTraceExporter));

                return string.Format(CultureInfo.InvariantCulture, $"dotnet{dotnetSdkVersion}:otel{otelSdkVersion}:ext{extensionVersion}");
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("SdkVersionCreateFailed", ex);
                return null;
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

                // Informational version will be something like 1.1.0-beta2+a25741030f05c60c85be102ce7c33f3899290d49.
                // Ignoring part after '+' if it is present.
                string? shortVersion = versionString?.Split('+')[0];

                return shortVersion;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("ErrorInitializingPartOfSdkVersion", ex);
                return null;
            }
        }
    }
}
