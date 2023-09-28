// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System.Reflection;
using System;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Versioning;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Static class to set the metric headers for each event trigger.
    /// </summary>
    public static class EventTriggerMetrics
    {
        /// <summary>
        /// The client library's product name
        /// </summary>
        public static string ProductName = "AuthenticationEvents";

        /// <summary>
        /// Platform of the event trigger. Example: windows, linux, macos
        /// </summary>
        public static string Platform { get; set; } = GetPlatform();

        /// <summary>
        /// Product version of the event trigger. Example: 1.0.0-beta, 1.0.0, 2.0.0
        /// </summary>
        public static string ProductVersion { get; set; } = GetProductVersion();

        /// <summary>
        /// Runtime of the event trigger. Example: .NET, JS, TS, PY
        /// </summary>
        public static string RunTime { get; set; } = ".NET";

        /// <summary>
        /// Header key to add the metrics to.
        /// User-Agent is the standard header to add metrics to recommended by Azure sdk guidelines.
        /// </summary>
        private static string MetricsHeader = "User-Agent";

        /// <summary>
        /// Set the metrics on the response message.
        /// </summary>
        /// <param name="message">The reponse message</param>
        internal static void SetMetricHeaders(HttpResponseMessage message)
        {
            if (message != null)
            {
                var headers = message.Headers;
                headers.AddOrReplaceToHeader(GetHeaderValue(Platform, ProductVersion, RunTime));
            }
        }

        /// <summary>
        /// Extension function to Add or Replace a header value.
        /// </summary>
        /// <param name="headers"><see cref="HttpHeaders"/> to add the key and value to</param>
        /// <param name="value">Header value to add</param>
        private static void AddOrReplaceToHeader(this HttpHeaders headers, string value)
        {
            if (headers.Contains(MetricsHeader))
            {
                value = headers.GetValues(MetricsHeader).ToString() + value;
                headers.Remove(MetricsHeader);
            }

            headers.Add(MetricsHeader, value);
        }

        private static string GetHeaderValue(string platform, string version, string runtime)
        {
            return $"azsdk-{runtime}-{ProductName}/{version} + {platform}";
        }

        /// <summary>
        /// Get the platform of the event trigger based on the OS.
        /// </summary>
        /// <returns>OS Name</returns>
        internal static string GetPlatform()
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
                return "macos";
            }

            return "unknown";
        }

        /// <summary>
        /// Get the product version of the event trigger based on the executing assembly version.
        /// </summary>
        /// <returns>String with version from the assembly</returns>
        internal static string GetProductVersion()
        {
            Assembly assembly = typeof(EventTriggerMetrics).Assembly;
            string Version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
            string Framework = assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return version.ToString();
        }
    }
}
