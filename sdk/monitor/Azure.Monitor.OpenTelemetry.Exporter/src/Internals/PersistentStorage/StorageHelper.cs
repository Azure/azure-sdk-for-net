// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage
{
    internal static class StorageHelper
    {
        private static string? s_defaultStorageDirectory;

        internal static string GetStorageDirectory(IPlatform platform, string? configuredStorageDirectory)
        {
            // get root directory
            var rootDirectory = configuredStorageDirectory
                ?? (s_defaultStorageDirectory ??= GetDefaultStorageDirectory(platform))
                ?? throw new InvalidOperationException("Unable to determine offline storage directory.");

            return rootDirectory;
        }

        internal static string? GetDefaultStorageDirectory(IPlatform platform)
        {
            string? dirPath;
            IDictionary environmentVars = platform.GetEnvironmentVariables();

            if (platform.IsOSPlatform(OSPlatform.Windows))
            {
                if (TryCreateTelemetryDirectory(platform: platform, path: environmentVars["LOCALAPPDATA"]?.ToString(), createdDirectoryPath: out dirPath)
                    || TryCreateTelemetryDirectory(platform: platform, path: environmentVars["TEMP"]?.ToString(), createdDirectoryPath: out dirPath))
                {
                    s_defaultStorageDirectory = dirPath;
                    return s_defaultStorageDirectory;
                }
            }
            else
            {
                if (TryCreateTelemetryDirectory(platform: platform, path: environmentVars["TMPDIR"]?.ToString(), createdDirectoryPath: out dirPath)
                    || TryCreateTelemetryDirectory(platform: platform, path: "/var/tmp/", createdDirectoryPath: out dirPath)
                    || TryCreateTelemetryDirectory(platform: platform, path: "/tmp/", createdDirectoryPath: out dirPath))
                {
                    s_defaultStorageDirectory = dirPath;
                    return s_defaultStorageDirectory;
                }
            }

            return s_defaultStorageDirectory;
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
            return platform.CreateDirectory(createdDirectoryPath);
        }
    }
}
