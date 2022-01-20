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
        private static string defaultStorageLocation;
        private const string nonWindowsVarTmp = "/var/tmp/";
        private const string nonWindowsTmp = "/tmp/";

        internal static string GetDefaultStorageLocation()
        {
            if (defaultStorageLocation != null)
            {
                return defaultStorageLocation;
            }
            else
            {
                string folderPath;
                IDictionary environmentVars = Environment.GetEnvironmentVariables();

                if (IsWindowsOS())
                {
                    string localAppData = environmentVars["LOCALAPPDATA"].ToString();
                    if (localAppData != null)
                    {
                        folderPath = TryCreateTelemetryFolder(localAppData);
                        if (folderPath != null)
                        {
                            defaultStorageLocation = folderPath;
                            return defaultStorageLocation;
                        }

                        string temp = environmentVars["TEMP"].ToString();
                        if (temp != null)
                        {
                            folderPath = TryCreateTelemetryFolder(temp);
                            if (folderPath != null)
                            {
                                defaultStorageLocation = folderPath;
                                return defaultStorageLocation;
                            }
                        }
                    }
                }
                else
                {
                    string tmpdir = environmentVars["TMPDIR"].ToString();
                    if (tmpdir != null)
                    {
                        folderPath = TryCreateTelemetryFolder(tmpdir);
                        if (folderPath != null)
                        {
                            defaultStorageLocation = folderPath;
                            return defaultStorageLocation;
                        }
                    }

                    folderPath = TryCreateTelemetryFolder(nonWindowsVarTmp);
                    if (folderPath != null)
                    {
                        defaultStorageLocation = folderPath;
                        return defaultStorageLocation;
                    }

                    folderPath = TryCreateTelemetryFolder(nonWindowsTmp);
                    if (folderPath != null)
                    {
                        defaultStorageLocation = folderPath;
                        return defaultStorageLocation;
                    }
                }

                return defaultStorageLocation;
            }
        }

        /// <summary>
        /// Creates directory for storing telemetry.
        /// </summary>
        /// <param name="path">Base directory.</param>
        /// <returns>Directory path if it is created else null.</returns>
        private static string TryCreateTelemetryFolder(string path)
        {
            try
            {
                string telemetryPath = Path.Combine(path, "Microsoft", "ApplicationInsights");
                Directory.CreateDirectory(telemetryPath);
                return telemetryPath;
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
