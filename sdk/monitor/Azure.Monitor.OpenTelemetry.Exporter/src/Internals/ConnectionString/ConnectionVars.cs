// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString
{
    /// <summary>
    /// Encapsulates variables from the ConnectionString.
    /// </summary>
    internal class ConnectionVars
    {
        public ConnectionVars(string instrumentationKey, string ingestionEndpoint, string liveEndpoint, string? aadAudience)
            : this(instrumentationKey, ingestionEndpoint, liveEndpoint, aadAudience, isRoutingOnly: false)
        {
        }

        private ConnectionVars(string instrumentationKey, string ingestionEndpoint, string liveEndpoint, string? aadAudience, bool isRoutingOnly)
        {
            this.InstrumentationKey = instrumentationKey;
            this.IngestionEndpoint = ingestionEndpoint;
            this.LiveEndpoint = liveEndpoint;
            this.AadAudience = aadAudience;
            this.IsRoutingOnly = isRoutingOnly;
        }

        /// <summary>
        /// Stands in for a connection string the process does not have. Multi-endpoint routing takes
        /// every destination from the telemetry itself, so there is no component that owns the
        /// exporter, and nothing is ever sent to these values: the endpoint only seeds the REST
        /// client, which rewrites the URI for each routed group.
        /// </summary>
        public static ConnectionVars CreateRoutingOnly() => new(
            instrumentationKey: string.Empty,
            ingestionEndpoint: Constants.DefaultIngestionEndpoint,
            liveEndpoint: Constants.DefaultLiveEndpoint,
            aadAudience: null,
            isRoutingOnly: true);

        public string InstrumentationKey { get; }

        public string IngestionEndpoint { get; }

        public string LiveEndpoint { get; }

        public string? AadAudience { get; }

        /// <summary>No connection string was configured; only routed telemetry can be sent.</summary>
        public bool IsRoutingOnly { get; }
    }
}
