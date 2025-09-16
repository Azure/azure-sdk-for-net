// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    /// <summary>
    /// Helper class for tracking customer SDK statistics.
    /// </summary>
    internal static class CustomerSdkStatsHelper
    {
        private static bool? s_isEnabled;

        private static readonly IReadOnlyDictionary<int, string> StatusCodeDropReasons = new Dictionary<int, string>
        {
            [400] = "Bad request",
            [401] = "Unauthorized",
            [402] = "Daily quota exceeded",
            [403] = "Forbidden",
            [404] = "Not found",
            [408] = "Request timeout",
            [413] = "Payload too large",
            [429] = "Too many requests",
            [500] = "Internal server error",
            [502] = "Bad gateway",
            [503] = "Service unavailable",
            [504] = "Gateway timeout"
        };

        /// <summary>
        /// Checks if customer SDK stats are enabled.
        /// </summary>
        /// <returns>True if enabled, false otherwise</returns>
        public static bool IsEnabled()
        {
            if (s_isEnabled == null)
            {
                var enabledValue = DefaultPlatform.Instance.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_SDKSTATS_ENABLED_PREVIEW);
                s_isEnabled = string.Equals(enabledValue, "true", StringComparison.OrdinalIgnoreCase);
            }
            return s_isEnabled.Value;
        }

        /// <summary>
        /// Gets the configured export interval for customer SDK stats in milliseconds.
        /// </summary>
        /// <returns>Export interval in milliseconds (default: 900000 = 15 minutes)</returns>
        public static int GetExportIntervalMilliseconds()
        {
            var intervalValue = DefaultPlatform.Instance.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_SDKSTATS_EXPORT_INTERVAL);

            if (int.TryParse(intervalValue, out int intervalSeconds) && intervalSeconds > 0)
            {
                var intervalMs = Math.Max(60_000, intervalSeconds * 1_000); // Minimum 1 minute
                return Math.Min(intervalMs, 24 * 60 * 60 * 1_000); // Maximum 24 hours
            }

            return 900_000;
        }

        public static string? GetDropReason(Exception exception)
        {
            return exception switch
            {
                TimeoutException => "Timeout exception",
                TaskCanceledException when exception.InnerException is TimeoutException => "Timeout exception",
                OperationCanceledException => "Timeout exception",
                HttpRequestException => "Network exception",
                SocketException => "Network exception",
                DriveNotFoundException => "Storage exception",
                FileNotFoundException => "Storage exception",
                UnauthorizedAccessException => "Storage exception",
                PathTooLongException => "Storage exception",
                IOException => "Storage exception",
                _ => null
            };
        }

        /// <summary>
        /// Categorizes an HTTP status code into a human-readable drop reason.
        /// Follows the Python categorize_status_code function logic.
        /// </summary>
        /// <param name="statusCode">HTTP status code to categorize</param>
        /// <returns>Human-readable drop reason</returns>
        public static string CategorizeStatusCode(int statusCode)
        {
            if (StatusCodeDropReasons.TryGetValue(statusCode, out var reason))
            {
                return reason;
            }

            if (statusCode >= 400 && statusCode < 500)
            {
                return "Client error 4xx";
            }

            if (statusCode >= 500 && statusCode < 600)
            {
                return "Server error 5xx";
            }

            return $"status_{statusCode}";
        }

        /// <summary>
        /// Tracks successful telemetry transmission using pre-computed counts.
        /// </summary>
        /// <param name="telemetryCounter">Telemetry counter for tracking metrics</param>
        public static void TrackSuccess(TelemetryCounter? telemetryCounter)
        {
            if (!IsEnabled() || telemetryCounter == null)
                return;

            try
            {
                if (telemetryCounter._requestCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetBaseTags("REQUEST");
                    CustomerSdkStatsMeters.ItemSuccessCount.Add(telemetryCounter._requestCount, tags);
                }

                if (telemetryCounter._dependencyCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetBaseTags("DEPENDENCY");
                    CustomerSdkStatsMeters.ItemSuccessCount.Add(telemetryCounter._dependencyCount, tags);
                }

                if (telemetryCounter._exceptionCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetBaseTags("EXCEPTION");
                    CustomerSdkStatsMeters.ItemSuccessCount.Add(telemetryCounter._exceptionCount, tags);
                }

                if (telemetryCounter._eventCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetBaseTags("EVENT");
                    CustomerSdkStatsMeters.ItemSuccessCount.Add(telemetryCounter._eventCount, tags);
                }

                if (telemetryCounter._metricCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetBaseTags("METRIC");
                    CustomerSdkStatsMeters.ItemSuccessCount.Add(telemetryCounter._metricCount, tags);
                }

                if (telemetryCounter._traceCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetBaseTags("TRACE");
                    CustomerSdkStatsMeters.ItemSuccessCount.Add(telemetryCounter._traceCount, tags);
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.CustomerSdkStatsTrackingFailed("success", ex);
            }
        }

        /// <summary>
        /// Tracks dropped telemetry using pre-computed counts.
        /// According to the specification:
        /// - For non-retryable status codes: use the actual HTTP status code (401, 403, etc.) as dropCode
        /// - For other scenarios: use DropCode enum values (CLIENT_EXCEPTION, CLIENT_READONLY, etc.)
        /// </summary>
        /// <param name="persistentBlobProviderExists">Indicates if persistent blob storage is configured</param>
        /// <param name="telemetryCounter">Telemetry counter for tracking metrics</param>
        public static void TrackDropped(TelemetryCounter? telemetryCounter, bool persistentBlobProviderExists)
        {
            TrackDropped(telemetryCounter, (int)(persistentBlobProviderExists == false ? DropCode.ClientStorageDisabled : DropCode.ClientPersistenceIssue), null);
        }

        /// <summary>
        /// Tracks dropped telemetry using pre-computed counts.
        /// </summary>
        /// <param name="telemetryCounter">Telemetry counter for tracking metrics</param>
        /// <param name="dropCode">Drop code - either HTTP status code or DropCode enum value cast to int</param>
        /// <param name="dropReason">Optional detailed reason for the dropped telemetry</param>
        public static void TrackDropped(TelemetryCounter? telemetryCounter, int dropCode, string? dropReason = null)
        {
            if (!IsEnabled() || telemetryCounter == null)
                return;

            try
            {
                string? dropCodeString = null;

                if (dropCode > 0 && dropCode < 10)
                {
                    DropCode enumValue = (DropCode)dropCode;
                    dropCodeString = enumValue.ToString();
                }

                dropCodeString ??= dropCode.ToString();

                if (telemetryCounter._requestCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetDroppedTags("REQUEST", dropCodeString, dropReason);
                    CustomerSdkStatsMeters.ItemDroppedCount.Add(telemetryCounter._requestCount, tags);
                }

                if (telemetryCounter._dependencyCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetDroppedTags("DEPENDENCY", dropCodeString, dropReason);
                    CustomerSdkStatsMeters.ItemDroppedCount.Add(telemetryCounter._dependencyCount, tags);
                }

                if (telemetryCounter._exceptionCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetDroppedTags("EXCEPTION", dropCodeString, dropReason);
                    CustomerSdkStatsMeters.ItemDroppedCount.Add(telemetryCounter._exceptionCount, tags);
                }

                if (telemetryCounter._eventCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetDroppedTags("EVENT", dropCodeString, dropReason);
                    CustomerSdkStatsMeters.ItemDroppedCount.Add(telemetryCounter._eventCount, tags);
                }

                if (telemetryCounter._metricCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetDroppedTags("METRIC", dropCodeString, dropReason);
                    CustomerSdkStatsMeters.ItemDroppedCount.Add(telemetryCounter._metricCount, tags);
                }

                if (telemetryCounter._traceCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetDroppedTags("TRACE", dropCodeString, dropReason);
                    CustomerSdkStatsMeters.ItemDroppedCount.Add(telemetryCounter._traceCount, tags);
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.CustomerSdkStatsTrackingFailed("dropped", ex);
            }
        }

        /// <summary>
        /// Tracks retry telemetry using pre-computed counts.
        /// </summary>
        /// <param name="telemetryCounter">Telemetry counter for tracking metrics</param>
        /// <param name="retryCode">retry code - either HTTP status code or DropCode enum value cast to int</param>
        /// <param name="retryReason">Optional detailed reason for the retry telemetry</param>
        public static void TrackRetry(TelemetryCounter? telemetryCounter, int retryCode, string? retryReason = null)
        {
            if (!IsEnabled() || telemetryCounter == null)
                return;

            try
            {
                string? retryCodeString = null;

                if (retryCode > 0 && retryCode < 10)
                {
                    DropCode enumValue = (DropCode)retryCode;
                    retryCodeString = enumValue.ToString();
                }

                retryCodeString ??= retryCode.ToString();

                if (telemetryCounter._requestCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetRetryTags("REQUEST", retryCodeString, retryReason);
                    CustomerSdkStatsMeters.ItemRetryCount.Add(telemetryCounter._requestCount, tags);
                }

                if (telemetryCounter._dependencyCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetRetryTags("DEPENDENCY", retryCodeString, retryReason);
                    CustomerSdkStatsMeters.ItemRetryCount.Add(telemetryCounter._dependencyCount, tags);
                }

                if (telemetryCounter._exceptionCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetRetryTags("EXCEPTION", retryCodeString, retryReason);
                    CustomerSdkStatsMeters.ItemRetryCount.Add(telemetryCounter._exceptionCount, tags);
                }

                if (telemetryCounter._eventCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetRetryTags("EVENT", retryCodeString, retryReason);
                    CustomerSdkStatsMeters.ItemRetryCount.Add(telemetryCounter._eventCount, tags);
                }

                if (telemetryCounter._metricCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetRetryTags("METRIC", retryCodeString, retryReason);
                    CustomerSdkStatsMeters.ItemRetryCount.Add(telemetryCounter._metricCount, tags);
                }

                if (telemetryCounter._traceCount != 0)
                {
                    var tags = CustomerSdkStatsDimensions.GetRetryTags("TRACE", retryCodeString, retryReason);
                    CustomerSdkStatsMeters.ItemRetryCount.Add(telemetryCounter._traceCount, tags);
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.CustomerSdkStatsTrackingFailed("dropped", ex);
            }
        }
    }
}
