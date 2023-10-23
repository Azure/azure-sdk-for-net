// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Static class to set the metric headers for each event trigger.
    /// </summary>
    public class EventTriggerMetrics
    {
        /// <summary>
        /// Default constructor for eventmetrics
        /// </summary>
        public EventTriggerMetrics()
        {
            var assembly = GetType().Assembly;

            ProductVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
            Framework = assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            Platform = RuntimeInformation.OSDescription ?? "unknown";
        }

        /// <summary>
        /// The client library's product name
        /// </summary>
        public static string ProductName = "AuthenticationEvents";

        /// <summary>
        /// Get the platform of the event trigger based on the OS.
        /// </summary>
        /// <returns>OS Name</returns>
        private static string Platform;

        /// <summary>
        /// Product version of the event trigger. Example: 1.0.0-beta, 1.0.0, 2.0.0
        /// </summary>
        private static string ProductVersion;

        /// <summary>
        /// Framework of the event trigger. Example: .NET, JS, TS, PY
        /// </summary>
        private static string Framework;

        /// <summary>
        /// Header key to add the metrics to.
        /// User-Agent is the standard header to add metrics to recommended by Azure sdk guidelines.
        /// </summary>
        public static string MetricsHeader = "User-Agent";

        /// <summary>
        /// Set the metrics on the response message.
        /// </summary>
        /// <param name="message">The reponse message</param>
        internal void SetMetricHeaders(HttpResponseMessage message)
        {
            if (message != null)
            {
                var headers = message.Headers;
                AddOrReplaceToHeader(headers, GetHeaderValue(Platform, ProductVersion, Framework));
            }
        }

        /// <summary>
        /// Extension function to Add or Replace a header value.
        /// </summary>
        /// <param name="headers"><see cref="HttpHeaders"/> to add the key and value to</param>
        /// <param name="value">Header value to add</param>
        private static void AddOrReplaceToHeader(HttpHeaders headers, string value)
        {
            if (headers.Contains(MetricsHeader))
            {
                value = headers.GetValues(MetricsHeader).First() + " " + value;
                headers.Remove(MetricsHeader);
            }

            headers.Add(MetricsHeader, value);
        }

        private static string GetHeaderValue(string platform, string version, string runtime)
        {
            return $"azsdk-net-{ProductName}/{version} ({runtime}; {platform.Trim()})";
        }
    }
}
