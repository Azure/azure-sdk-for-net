// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform
{
    internal class DefaultPlatform : IPlatform
    {
        private readonly IDictionary _environmentVariables;

        public DefaultPlatform()
        {
            try
            {
                _environmentVariables = Environment.GetEnvironmentVariables();
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToReadEnvironmentVariables(ex);
                _environmentVariables = new Dictionary<string, object>();
            }
        }

        public string? GetEnvironmentVariable(string name) => _environmentVariables[name]?.ToString();

        public string GetOSPlatformName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "windows";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "linux";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return "osx";
            }

            return "unknown";
        }

        public bool IsOSPlatform(OSPlatform osPlatform) => RuntimeInformation.IsOSPlatform(osPlatform);

        public bool CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.ErrorCreatingStorageFolder(path, ex);
                return false;
            }
        }

        public string GetEnvironmentUserName() => Environment.UserName;

        public string GetCurrentProcessName() => Process.GetCurrentProcess().ProcessName;

        public string GetApplicationBaseDirectory() => AppContext.BaseDirectory;
    }
}
