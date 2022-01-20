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
        private static readonly IDictionary environmentVars = Environment.GetEnvironmentVariables();
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
                bool result;
                if (IsWindowsOS())
                {
                    string localAppData = GetTelemetrySubDirectory(environmentVars["LOCALAPPDATA"].ToString());
                    if (localAppData != null)
                    {
                        result = TryCreateTelemetryFolder(localAppData);
                        if (result)
                        {
                            defaultStorageLocation = localAppData;
                            return defaultStorageLocation;
                        }

                        string temp = GetTelemetrySubDirectory(environmentVars["TEMP"].ToString());
                        result = TryCreateTelemetryFolder(temp);
                        if (result)
                        {
                            defaultStorageLocation = temp;
                            return defaultStorageLocation;
                        }
                    }
                }
                else
                {
                    string tmpdir = GetTelemetrySubDirectory(environmentVars["TMPDIR"].ToString());
                    if (tmpdir != null)
                    {
                        result = TryCreateTelemetryFolder(tmpdir);
                        if (result)
                        {
                            defaultStorageLocation = tmpdir;
                            return defaultStorageLocation;
                        }
                    }

                    string usrTmp = GetTelemetrySubDirectory(nonWindowsVarTmp);
                    result = TryCreateTelemetryFolder(usrTmp);
                    if (result)
                    {
                        defaultStorageLocation = usrTmp;
                        return defaultStorageLocation;
                    }

                    string tmp = GetTelemetrySubDirectory(nonWindowsTmp);
                    result = TryCreateTelemetryFolder(tmp);
                    if (result)
                    {
                        defaultStorageLocation = tmp;
                        return defaultStorageLocation;
                    }
                }

                return defaultStorageLocation;
            }
        }

        private static string GetTelemetrySubDirectory(string temp)
        {
            return Path.Combine(temp, "Microsoft", "ApplicationInsights");
        }

        private static bool TryCreateTelemetryFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"ErrorCreatingDefaultStorageFolder{EventLevelSuffix.Error}", $"{ex.ToInvariantString()}");
                return false;
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
