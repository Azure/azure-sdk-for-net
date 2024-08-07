// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

#if AZURE_MONITOR_EXPORTER
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
#elif LIVE_METRICS_EXPORTER
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
#elif ASP_NET_CORE_DISTRO
using Azure.Monitor.OpenTelemetry.AspNetCore;
#endif

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform
{
#if ASP_NET_CORE_DISTRO
#pragma warning disable SA1649 // File name should match first type name
    internal class DefaultPlatformDistro : IPlatform
#pragma warning restore SA1649 // File name should match first type name
#else
    internal class DefaultPlatform : IPlatform
#endif
    {
        internal static readonly IPlatform Instance
#if ASP_NET_CORE_DISTRO
            = new DefaultPlatformDistro();
#else
            = new DefaultPlatform();
#endif

        private readonly IDictionary _environmentVariables;

#if ASP_NET_CORE_DISTRO
        public DefaultPlatformDistro()
#else
        public DefaultPlatform()
#endif
        {
            try
            {
                _environmentVariables = LoadEnvironmentVariables();
            }
            catch (Exception ex)
            {
#if AZURE_MONITOR_EXPORTER
                AzureMonitorExporterEventSource.Log.FailedToReadEnvironmentVariables(ex);
#elif LIVE_METRICS_EXPORTER
                LiveMetricsExporterEventSource.Log.FailedToReadEnvironmentVariables(ex);
#elif ASP_NET_CORE_DISTRO
                AzureMonitorAspNetCoreEventSource.Log.FailedToReadEnvironmentVariables(ex);
#endif
                _environmentVariables = new Dictionary<string, object>();
            }
        }

        private static IDictionary LoadEnvironmentVariables()
        {
            var variables = new Dictionary<string, string?>();
            foreach (var key in EnvironmentVariableConstants.HashSetDefinedEnvironmentVariables)
            {
                variables.Add(key, Environment.GetEnvironmentVariable(key));
            }
            return variables;
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

        /// <summary>
        /// Creates all directories and subdirectories in the specified path unless they already exist.
        /// </summary>
        /// <exception>This method does not catch any exceptions thrown by <see cref="Directory.CreateDirectory(string)"/>.</exception>
        /// <param name="path">The directory to create</param>
        public void CreateDirectory(string path) => Directory.CreateDirectory(path);

        public string GetEnvironmentUserName() => Environment.UserName;

        public string GetCurrentProcessName() => Process.GetCurrentProcess().ProcessName;

        public string GetApplicationBaseDirectory() => AppContext.BaseDirectory;
    }
}
