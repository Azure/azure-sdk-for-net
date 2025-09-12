// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    /// <summary>
    /// Provides dimension values for customer SDK statistics metrics.
    /// </summary>
    internal static class CustomerSdkStatsDimensions
    {
        private static string? s_computeType;

        /// <summary>
        /// Gets base tags common to all customer SDK stats metrics.
        /// </summary>
        /// <param name="telemetryType">The type of telemetry (REQUEST, DEPENDENCY, etc.)</param>
        /// <returns>TagList with common dimensions</returns>
        public static TagList GetBaseTags(string telemetryType)
        {
            return new TagList
            {
                { "language", SdkVersionUtils.IsDistro ? "dotnet-distro" : "dotnet-exp" },
                { "version", SdkVersionUtils.ExtensionsVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength) },
                { "computeType", GetComputeType() },
                { "telemetry_type", telemetryType }
            };
        }

        /// <summary>
        /// Gets tags for dropped telemetry items.
        /// </summary>
        /// <param name="telemetryType">The type of telemetry</param>
        /// <param name="dropCode">The drop code (status code or error category)</param>
        /// <param name="dropReason">Optional drop reason description</param>
        /// <returns>TagList with dropped item dimensions</returns>
        public static TagList GetDroppedTags(string telemetryType, string dropCode, string? dropReason = null)
        {
            var tags = GetBaseTags(telemetryType);
            tags.Add("drop.code", dropCode);
            if (!string.IsNullOrEmpty(dropReason))
            {
                tags.Add("drop.reason", dropReason);
            }
            return tags;
        }

        /// <summary>
        /// Gets tags for retried telemetry items.
        /// </summary>
        /// <param name="telemetryType">The type of telemetry</param>
        /// <param name="retryCode">The retry code (status code or error category)</param>
        /// <param name="retryReason">Optional retry reason description</param>
        /// <returns>TagList with retry item dimensions</returns>
        public static TagList GetRetryTags(string telemetryType, string retryCode, string? retryReason = null)
        {
            var tags = GetBaseTags(telemetryType);
            tags.Add("retry.code", retryCode);
            if (!string.IsNullOrEmpty(retryReason))
            {
                tags.Add("retry.reason", retryReason);
            }
            return tags;
        }

        private static string GetComputeType()
        {
            if (s_computeType == null)
            {
                var platform = new DefaultPlatform();
                s_computeType = ResourceProviderHelper.DetermineResourceProvider(platform);
            }
            return s_computeType;
        }
    }
}
