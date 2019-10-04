// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    public class DiagnosticsOptions
    {
        public DiagnosticsOptions()
        {
            IsTelemetryEnabled = !EnvironmentVariableToBool(Environment.GetEnvironmentVariable("AZURE_TELEMETRY_DISABLED")) ?? true;
            ApplicationId = DefaultApplicationId;
            LoggingAllowedHeaderNames = new List<string>()
            {
                "Date",
                "traceparent",
                "x-ms-client-request-id",
                "x-ms-request-id"
            };
            LoggingAllowedQueryParameters = new List<string>();
        }

        public bool IsLoggingEnabled { get; set; } = true;

        public bool IsDistributedTracingEnabled { get; set; } = true;

        public bool IsTelemetryEnabled { get; set; }

        /// <summary>
        /// Gets or sets value indicating if request or response content should be logged.
        /// </summary>
        public bool IsLoggingContentEnabled { get; set; }

        /// <summary>
        /// Gets or sets value indicating maximum size of content to log in bytes. Defaults to 4096.
        /// </summary>
        public int LoggingContentSizeLimit { get; set; } = 4 * 1024;

        /// <summary>
        /// Gets a list of headers names that are not redacted during logging.
        /// </summary>
        public IList<string> LoggingAllowedHeaderNames { get; }

        /// <summary>
        /// Gets a list of query parameter names that are not redacted during logging.
        /// </summary>
        public IList<string> LoggingAllowedQueryParameters { get; }

        public string? ApplicationId { get; set; }

        public static string? DefaultApplicationId { get; set; }

        private static bool? EnvironmentVariableToBool(string value)
        {
            if (string.Equals("true", value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("1", value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals("false", value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("0", value, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return null;
        }
    }
}
