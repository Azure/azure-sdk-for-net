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
        private readonly IDictionary _environmentVariables;
        private readonly bool _preCacheEnvironmentVariables;

        /// <remarks>
        /// When this class is used to initialize the entire SDK, it is recommended to set <paramref name="preCacheEnvironmentVariables"/> to true.
        /// This will avoid reading environment variables multiple times and simplifies the exception handling.
        /// An instance with this caching enabled should not be saved to allow GC to reclaim the memory.
        /// Some secenarios require reading a single environment variable after initialization, in which case you should set <paramref name="preCacheEnvironmentVariables"/> to false.
        /// </remarks>
#if ASP_NET_CORE_DISTRO
        public DefaultPlatformDistro(bool preCacheEnvironmentVariables = false)
#else
        public DefaultPlatform(bool preCacheEnvironmentVariables = false)
#endif
        {
            _preCacheEnvironmentVariables = preCacheEnvironmentVariables;

            if (preCacheEnvironmentVariables)
            {
                try
                {
                    _environmentVariables = Environment.GetEnvironmentVariables();
                }
                catch (Exception ex)
                {
#if AZURE_MONITOR_EXPORTER
                    AzureMonitorExporterEventSource.Log.FailedToReadEnvironmentVariables(ex);
#elif ASP_NET_CORE_DISTRO
                    AzureMonitorAspNetCoreEventSource.Log.FailedToReadEnvironmentVariables(ex);
#endif
                    _environmentVariables = new Dictionary<string, object>();
                }
            }
            else
            {
                _environmentVariables = new Dictionary<string, object>();
            }
        }

        public string? GetEnvironmentVariable(string name)
        {
            if (_preCacheEnvironmentVariables)
            {
                return _environmentVariables[name]?.ToString();
            }
            else
            {
                try
                {
                    return Environment.GetEnvironmentVariable(name);
                }
                catch (Exception ex)
                {
#if AZURE_MONITOR_EXPORTER
                    AzureMonitorExporterEventSource.Log.FailedToReadEnvironmentVariables(ex);
#elif ASP_NET_CORE_DISTRO
                    AzureMonitorAspNetCoreEventSource.Log.FailedToReadEnvironmentVariables(ex);
#endif
                    return null;
                }
            }
        }

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
