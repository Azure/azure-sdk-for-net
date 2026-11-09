// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage
{
    internal static class StorageConfig
    {
        /// <summary>
        /// Replaces the process name and application base directory in the seed that names the
        /// persistent storage sub directory. Settable through <c>AppContext.SetData</c> or a
        /// runtimeconfig.json configProperty.
        /// </summary>
        /// <remarks>
        /// Components of one logical application can run with different process names or base
        /// directories, which would otherwise give each its own storage, so a component that runs
        /// rarely never drains its backlog. Setting the same value in each lets them share one.
        /// The instrumentation key and user name still contribute to the name, so the value is
        /// hashed rather than used as a path and different users or resources stay isolated.
        /// </remarks>
        internal const string SubDirectoryOverrideName = "Azure.Monitor.OpenTelemetry.Exporter.StorageSubDirectory";

        internal static string? GetSubDirectoryOverride()
        {
            var configured = AppContext.GetData(SubDirectoryOverrideName);

            switch (configured)
            {
                case null:
                    return null;

                case string text when string.IsNullOrWhiteSpace(text):
                    return null;

                case string text:
                    return text.Trim();

                default:
                    AzureMonitorExporterEventSource.Log.StorageSubDirectoryOverrideIgnored(SubDirectoryOverrideName, configured.GetType().Name);
                    return null;
            }
        }
    }
}
