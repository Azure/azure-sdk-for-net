// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System.Reflection;
using System;
using System.Runtime.InteropServices;
using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Static class to set the metric headers for each event trigger.
    /// </summary>
    public static class EventTriggerMetrics
    {
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
        /// Header key names for the metric headers.
        /// </summary>
        internal static class HeaderKeys
        {
            /// <summary>
            /// The header key for platform. Example: windows, linux, macos
            /// </summary>
            public const string Platform = "ms-platform";

            /// <summary>
            /// The header key for product version. Example: 1.0.0-beta, 1.0.0, 2.0.0
            /// </summary>
            public const string ProductVersion = "ms-ver";

            /// <summary>
            /// The header key for product name. Example: .NET, JS, TS, PY
            /// </summary>
            public const string Runtime = "ms-runtime";
        }

        /// <summary>
        /// Set the metrics on the response message.
        /// </summary>
        /// <param name="message">The reponse message</param>
        internal static void SetMetricHeaders(HttpResponseMessage message)
        {
            if (message != null)
            {
                var headers = message.Headers;

                headers.Add(HeaderKeys.Platform, Platform);
                headers.Add(HeaderKeys.ProductVersion, ProductVersion);
                headers.Add(HeaderKeys.Runtime, RunTime);
            }
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
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return version.ToString();
        }
    }
}
