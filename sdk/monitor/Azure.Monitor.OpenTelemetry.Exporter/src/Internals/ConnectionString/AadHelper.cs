// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString
{
    /// <summary>
    /// Helper for working with AAD (Azure Activity Directory).
    /// </summary>
    /// <remarks>
    /// The AUDIENCE is a url that identifies Azure Monitor in a specific cloud (For example: "https://monitor.azure.com/").
    /// The SCOPE is the audience + the permission (For example: "https://monitor.azure.com//.default").
    /// </remarks>
    internal static class AadHelper
    {
        /// <summary>
        /// Default AAD Audience for Ingestion (aka Breeze).
        /// IMPORTANT: This value only works in the Public Azure Cloud.
        /// For Sovereign Azure Clouds, this value MUST come from the Connection String.
        /// </summary>
        public const string DefaultAADAudience = "https://monitor.azure.com//.default";

        public const string DefaultPermission = ".default";

        public static string GetScope(string? audience = null)
        {
            if (audience == null)
            {
                return DefaultAADAudience;
            }
            else
            {
                return audience + "/.default";
            }
        }
    }
}
