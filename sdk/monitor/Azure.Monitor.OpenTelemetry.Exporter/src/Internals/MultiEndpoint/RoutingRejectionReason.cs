// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    /// <summary>
    /// Why an Activity could not be routed. Reported instead of the endpoint itself, which may
    /// carry the credentials that caused the rejection.
    /// </summary>
    internal enum RoutingRejectionReason
    {
        None = 0,
        MissingInstrumentationKey,
        InstrumentationKeyTooLong,
        MissingIngestionEndpoint,
        IngestionEndpointTooLong,
        IngestionEndpointMalformed,
        IngestionEndpointNotHttps,
        IngestionEndpointHasCredentials,
        IngestionEndpointHasQueryOrFragment,
        IngestionEndpointHostInvalid,

        /// <summary>
        /// The exporter holds an Entra ID credential and the host is neither an Azure Monitor
        /// ingestion host nor the endpoint from the exporter's own connection string.
        /// </summary>
        IngestionEndpointNotTrusted,
    }
}
