// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal static class StorageHelper
    {
        private static string s_defaultStorageDirectory;
        private const string NonWindowsVarTmp = "/var/tmp/";

        // TODO: investigate if /tmp/ should be used.
        private const string NonWindowsTmp = "/tmp/";

        internal static string GetDefaultStorageDirectory()
        {
            if (s_defaultStorageDirectory != null)
            {
                return s_defaultStorageDirectory;
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
                            s_defaultStorageDirectory = dirPath;
                            return s_defaultStorageDirectory;
                        }

                        string temp = environmentVars["TEMP"]?.ToString();
                        if (temp != null)
                        {
                            dirPath = CreateTelemetryDirectory(temp);
                            if (dirPath != null)
                            {
                                s_defaultStorageDirectory = dirPath;
                                return s_defaultStorageDirectory;
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
                            s_defaultStorageDirectory = dirPath;
                            return s_defaultStorageDirectory;
                        }
                    }

                    dirPath = CreateTelemetryDirectory(NonWindowsVarTmp);
                    if (dirPath != null)
                    {
                        s_defaultStorageDirectory = dirPath;
                        return s_defaultStorageDirectory;
                    }

                    dirPath = CreateTelemetryDirectory(NonWindowsTmp);
                    if (dirPath != null)
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
                AzureMonitorExporterEventSource.Log.WriteError("ErrorCreatingDefaultStorageFolder", ex);
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
