// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Azure.Core
{
    /// <summary>
    /// Exposes client options related to logging, telemetry, and distributed tracing.
    /// </summary>
    public class DiagnosticsOptions
    {
        private const int MaxApplicationIdLength = 24;

        private string? _applicationId;

        /// <summary>
        /// Creates a new instance of <see cref="DiagnosticsOptions"/> with default values.
        /// </summary>
        protected internal DiagnosticsOptions() : this(ClientOptions.Default.Diagnostics)
        { }

        /// <summary>
        /// Initializes the newly created <see cref="DiagnosticsOptions"/> with the same settings as the specified <paramref name="diagnosticsOptions"/>.
        /// </summary>
        /// <param name="diagnosticsOptions">The <see cref="DiagnosticsOptions"/> to model the newly created instance on.</param>
        internal DiagnosticsOptions(DiagnosticsOptions? diagnosticsOptions)
        {
            if (diagnosticsOptions != null)
            {
                ApplicationId = diagnosticsOptions.ApplicationId;
                IsLoggingEnabled = diagnosticsOptions.IsLoggingEnabled;
                IsTelemetryEnabled = diagnosticsOptions.IsTelemetryEnabled;
                LoggedHeaderNames = new List<string>(diagnosticsOptions.LoggedHeaderNames);
                LoggedQueryParameters = new List<string>(diagnosticsOptions.LoggedQueryParameters);
                LoggedContentSizeLimit = diagnosticsOptions.LoggedContentSizeLimit;
                IsDistributedTracingEnabled = diagnosticsOptions.IsDistributedTracingEnabled;
                IsLoggingContentEnabled = diagnosticsOptions.IsLoggingContentEnabled;
            }
            else
            {
                // These values are similar to the default values in System.ClientModel.Primitives.ClientLoggingOptions and both
                // should be kept in sync. When updating, update the default values in both classes.
                LoggedHeaderNames = new List<string>()
                {
                    "x-ms-request-id",
                    "x-ms-client-request-id",
                    "x-ms-return-client-request-id",
                    "traceparent",
                    "MS-CV",
                    "Accept",
                    "Cache-Control",
                    "Connection",
                    "Content-Length",
                    "Content-Type",
                    "Date",
                    "ETag",
                    "Expires",
                    "If-Match",
                    "If-Modified-Since",
                    "If-None-Match",
                    "If-Unmodified-Since",
                    "Last-Modified",
                    "Pragma",
                    "Request-Id",
                    "Retry-After",
                    "Server",
                    "Transfer-Encoding",
                    "User-Agent",
                    "WWW-Authenticate" // OAuth Challenge header.
                };
                LoggedQueryParameters = new List<string> { "api-version" };
                IsTelemetryEnabled = !EnvironmentVariableToBool(Environment.GetEnvironmentVariable("AZURE_TELEMETRY_DISABLED")) ?? true;
                IsDistributedTracingEnabled = !EnvironmentVariableToBool(Environment.GetEnvironmentVariable("AZURE_TRACING_DISABLED")) ?? true;
            }
        }

        /// <summary>
        /// Get or sets value indicating whether HTTP pipeline logging is enabled.
        /// </summary>
        public bool IsLoggingEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets value indicating whether distributed tracing activities (<see cref="System.Diagnostics.Activity"/>) are going to be created for the clients methods calls and HTTP calls.
        /// </summary>
        public bool IsDistributedTracingEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets value indicating whether the "User-Agent" header containing <see cref="ApplicationId"/>, client library package name and version, <see cref="RuntimeInformation.FrameworkDescription"/>
        /// and <see cref="RuntimeInformation.OSDescription"/> should be sent.
        /// The default value can be controlled process wide by setting <c>AZURE_TELEMETRY_DISABLED</c> to <c>true</c>, <c>false</c>, <c>1</c> or <c>0</c>.
        /// </summary>
        public bool IsTelemetryEnabled { get; set; }

        /// <summary>
        /// Gets or sets value indicating if request or response content should be logged.
        /// </summary>
        public bool IsLoggingContentEnabled { get; set; }

        /// <summary>
        /// Gets or sets value indicating maximum size of content to log in bytes. Defaults to 4096.
        /// </summary>
        public int LoggedContentSizeLimit { get; set; } = 4 * 1024;

        /// <summary>
        /// Gets a list of header names that are not redacted during logging.
        /// </summary>
        public IList<string> LoggedHeaderNames { get; internal set; }

        /// <summary>
        /// Gets a list of query parameter names that are not redacted during logging.
        /// </summary>
        public IList<string> LoggedQueryParameters { get; internal set; }

        /// <summary>
        /// Gets or sets the value sent as the first part of "User-Agent" headers for all requests issues by this client. Defaults to <see cref="DefaultApplicationId"/>.
        /// </summary>
        public string? ApplicationId
        {
            get => _applicationId;
            set
            {
                if (value != null && value.Length > MaxApplicationIdLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(ApplicationId)} must be shorter than {MaxApplicationIdLength + 1} characters");
                }
                _applicationId = value;
            }
        }

        /// <summary>
        /// Gets or sets the default application id. Default application id would be set on all instances.
        /// </summary>
        public static string? DefaultApplicationId
        {
            get => ClientOptions.Default.Diagnostics.ApplicationId;
            set => ClientOptions.Default.Diagnostics.ApplicationId = value;
        }

        private static bool? EnvironmentVariableToBool(string? value)
        {
            if (string.Equals(bool.TrueString, value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("1", value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals(bool.FalseString, value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("0", value, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return null;
        }
    }
}
