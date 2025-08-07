// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString
{
    internal static class Constants
    {
        /// <summary>
        /// Default endpoint for Ingestion (aka Breeze).
        /// </summary>
        internal const string DefaultIngestionEndpoint = "https://dc.services.visualstudio.com/";

        /// <summary>
        /// Default endpoint for Live Metrics (aka QuickPulse).
        /// </summary>
        internal const string DefaultLiveEndpoint = "https://rt.services.visualstudio.com/";

        /// <summary>
        /// Sub-domain for Ingestion endpoint (aka Breeze). (https://dc.applicationinsights.azure.com/).
        /// </summary>
        internal const string IngestionPrefix = "dc";

        /// <summary>
        /// Sub-domain for Live Metrics endpoint (aka QuickPulse). (https://live.applicationinsights.azure.com/).
        /// </summary>
        internal const string LivePrefix = "live";

        /// <summary>
        /// This is the key that a customer would use to specify an explicit endpoint in the connection string.
        /// </summary>
        internal const string IngestionExplicitEndpointKey = "IngestionEndpoint";

        /// <summary>
        /// This is the key that a customer would use to specify an explicit endpoint in the connection string.
        /// </summary>
        internal const string LiveExplicitEndpointKey = "LiveEndpoint";

        /// <summary>
        /// This is the key that a customer would use to specify an instrumentation key in the connection string.
        /// </summary>
        internal const string InstrumentationKeyKey = "InstrumentationKey";

        /// <summary>
        /// This is the key that a customer would use to specify an endpoint suffix in the connection string.
        /// </summary>
        internal const string EndpointSuffixKey = "EndpointSuffix";

        /// <summary>
        /// This is the key that a customer would use to specify a location in the connection string.
        /// </summary>
        internal const string LocationKey = "Location";

        /// <summary>
        /// This is the key that a customer would use to specify an AAD Audience in the connection string.
        /// </summary>
        internal const string AADAudienceKey = "AADAudience";

        /// <summary>
        /// Maximum allowed length for connection string.
        /// </summary>
        /// <remarks>
        /// Currently 9 accepted keywords (~200 characters).
        /// Assuming 200 characters per value (~1800 characters).
        /// Total theoretical max length = (1800 + 200) = 2000.
        /// Setting an over-exaggerated max length to protect against malicious injections (2^12 = 4096).
        /// </remarks>
        internal const int ConnectionStringMaxLength = 4096;
    }
}
