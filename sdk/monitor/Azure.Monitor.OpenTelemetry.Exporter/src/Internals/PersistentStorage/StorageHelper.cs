// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage
{
    internal static class StorageHelper
    {
        private static string? s_defaultStorageDirectory;

        internal static string? GetDefaultStorageDirectory()
        {
            if (s_defaultStorageDirectory != null)
            {
                return s_defaultStorageDirectory;
            }
            else
            {
                string? dirPath;
                IDictionary environmentVars = Environment.GetEnvironmentVariables();

                if (IsWindowsOS())
                {
                    if (TryCreateTelemetryDirectory(path: environmentVars["LOCALAPPDATA"]?.ToString(), createdDirectoryPath: out dirPath)
                        || TryCreateTelemetryDirectory(path: environmentVars["TEMP"]?.ToString(), createdDirectoryPath: out dirPath))
                    {
                        s_defaultStorageDirectory = dirPath;
                        return s_defaultStorageDirectory;
                    }
                }
                else
                {
                    if (TryCreateTelemetryDirectory(path: environmentVars["TMPDIR"]?.ToString(), createdDirectoryPath: out dirPath)
                        || TryCreateTelemetryDirectory(path: "/var/tmp/", createdDirectoryPath: out dirPath)
                        || TryCreateTelemetryDirectory(path: "/tmp/", createdDirectoryPath: out dirPath))
                    {
                        s_defaultStorageDirectory = dirPath;
                        return s_defaultStorageDirectory;
                    }
                }

                return s_defaultStorageDirectory;
            }
        }

        /// <summary>
        /// Creates directory for storing telemetry.
        /// </summary>
        /// <param name="path">Base directory.</param>
        /// <param name="createdDirectoryPath">Full directory.</param>
        /// <returns><see langword= "true"/> if directory is created.</returns>
        private static bool TryCreateTelemetryDirectory(string? path, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out string? createdDirectoryPath)
        {
            createdDirectoryPath = null;
            if (path == null)
            {
                return false;
            }

            try
            {
                createdDirectoryPath = Path.Combine(path, "Microsoft\\AzureMonitor");
                Directory.CreateDirectory(createdDirectoryPath);
                return true;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("ErrorCreatingDefaultStorageFolder", ex);
                return false;
            }
        }

        internal static bool IsWindowsOS() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}
