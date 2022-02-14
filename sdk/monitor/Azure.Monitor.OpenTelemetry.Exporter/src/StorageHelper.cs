// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal static class StorageHelper
    {
        private static string defaultStorageDirectory;
        private const string nonWindowsVarTmp = "/var/tmp/";

        // TODO: investigate if /tmp/ should be used.
        private const string nonWindowsTmp = "/tmp/";

        internal static string GetDefaultStorageDirectory()
        {
            if (defaultStorageDirectory != null)
            {
                return defaultStorageDirectory;
            }
            else
            {
                string dirPath;
                IDictionary environmentVars = Environment.GetEnvironmentVariables();

                if (IsWindowsOS())
                {
                    string localAppData = environmentVars["LOCALAPPDATA"]?.ToString();
                    if (localAppData != null)
                    {
                        dirPath = CreateTelemetryDirectory(localAppData);
                        if (dirPath != null)
                        {
                            defaultStorageDirectory = dirPath;
                            return defaultStorageDirectory;
                        }

                        string temp = environmentVars["TEMP"]?.ToString();
                        if (temp != null)
                        {
                            dirPath = CreateTelemetryDirectory(temp);
                            if (dirPath != null)
                            {
                                defaultStorageDirectory = dirPath;
                                return defaultStorageDirectory;
                            }
                        }
                    }
                }
                else
                {
                    string tmpdir = environmentVars["TMPDIR"]?.ToString();
                    if (tmpdir != null)
                    {
                        dirPath = CreateTelemetryDirectory(tmpdir);
                        if (dirPath != null)
                        {
                            defaultStorageDirectory = dirPath;
                            return defaultStorageDirectory;
                        }
                    }

                    dirPath = CreateTelemetryDirectory(nonWindowsVarTmp);
                    if (dirPath != null)
                    {
                        defaultStorageDirectory = dirPath;
                        return defaultStorageDirectory;
                    }

                    dirPath = CreateTelemetryDirectory(nonWindowsTmp);
                    if (dirPath != null)
                    {
                        defaultStorageDirectory = dirPath;
                        return defaultStorageDirectory;
                    }
                }

                return defaultStorageDirectory;
            }
        }

        /// <summary>
        /// Creates directory for storing telemetry.
        /// </summary>
        /// <param name="path">Base directory.</param>
        /// <returns>Directory path if it is created else null.</returns>
        private static string CreateTelemetryDirectory(string path)
        {
            try
            {
                string telemetryDirPath = Path.Combine(path, "Microsoft", "ApplicationInsights");
                Directory.CreateDirectory(telemetryDirPath);
                return telemetryDirPath;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"ErrorCreatingDefaultStorageFolder{EventLevelSuffix.Error}", $"{ex.ToInvariantString()}");
                return null;
            }
        }

        internal static bool IsWindowsOS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return true;
            }

            return false;
        }
    }
}
