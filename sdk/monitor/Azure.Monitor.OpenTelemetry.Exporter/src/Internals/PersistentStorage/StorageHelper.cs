// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage
{
    internal static class StorageHelper
    {
        internal static string GetStorageDirectory(IPlatform platform, string? configuredStorageDirectory, string instrumentationKey)
        {
            // get root directory
            var rootDirectory = configuredStorageDirectory
                ?? GetDefaultStorageDirectory(platform)
                ?? throw new InvalidOperationException("Unable to determine offline storage directory.");

            // get unique sub directory
            var userName = platform.GetEnvironmentUserName();
            var processName = platform.GetCurrentProcessName();
            var applicationDirectory = platform.GetApplicationBaseDirectory();
            string subDirectory = HashHelper.GetSHA256Hash($"{instrumentationKey};{userName};{processName};{applicationDirectory}");

            return Path.Combine(rootDirectory, subDirectory);
        }

        internal static string? GetDefaultStorageDirectory(IPlatform platform)
        {
            string? dirPath;

            if (platform.IsOSPlatform(OSPlatform.Windows))
            {
                if (TryCreateTelemetryDirectory(platform: platform, path: platform.GetEnvironmentVariable(EnvironmentVariableConstants.LOCALAPPDATA), createdDirectoryPath: out dirPath)
                    || TryCreateTelemetryDirectory(platform: platform, path: platform.GetEnvironmentVariable(EnvironmentVariableConstants.TEMP), createdDirectoryPath: out dirPath))
                {
                    return dirPath;
                }
            }
            else
            {
                if (TryCreateTelemetryDirectory(platform: platform, path: platform.GetEnvironmentVariable(EnvironmentVariableConstants.TMPDIR), createdDirectoryPath: out dirPath)
                    || TryCreateTelemetryDirectory(platform: platform, path: "/var/tmp/", createdDirectoryPath: out dirPath)
                    || TryCreateTelemetryDirectory(platform: platform, path: "/tmp/", createdDirectoryPath: out dirPath))
                {
                    return dirPath;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates directory for storing telemetry.
        /// </summary>
        /// <param name="platform">Platform abstraction.</param>
        /// <param name="path">Base directory.</param>
        /// <param name="createdDirectoryPath">Full directory.</param>
        /// <returns><see langword= "true"/> if directory is created.</returns>
        private static bool TryCreateTelemetryDirectory(IPlatform platform, string? path, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out string? createdDirectoryPath)
        {
            createdDirectoryPath = null;
            if (path == null)
            {
                return false;
            }

            // these names need to be separate to use the correct OS specific DirectorySeparatorChar.
            createdDirectoryPath = Path.Combine(path, "Microsoft", "AzureMonitor");
            try
            {
                platform.CreateDirectory(createdDirectoryPath);
                return true;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.ErrorCreatingStorageFolder(path, ex);
                return false;
            }
        }
    }
}
