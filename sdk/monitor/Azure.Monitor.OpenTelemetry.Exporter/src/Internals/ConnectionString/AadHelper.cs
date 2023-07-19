// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString
{
    internal static class AadHelper
    {
        /// <summary>
        /// Default AAD Scope for Ingestion.
        /// IMPORTANT: This value only works in the Public Azure Cloud.
        /// For Sovereign Azure Clouds, this value MUST be built from the Connection String.
        /// </summary>
        public const string DefaultAadScope = "https://monitor.azure.com//.default";

        /// <summary>
        /// Get the Scope value required for AAD authentication.
        /// </summary>
        /// <remarks>
        /// The AUDIENCE is a url that identifies Azure Monitor in a specific cloud (For example: "https://monitor.azure.com/").
        /// The SCOPE is the audience + the permission (For example: "https://monitor.azure.com//.default").
        /// </remarks>
        public static string GetScope(string? audience = null)
        {
            return string.IsNullOrWhiteSpace(audience)
                ? DefaultAadScope
                : audience + "/.default";
        }
    }
}
