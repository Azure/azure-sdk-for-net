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
            : this(instrumentationKey, ingestionEndpoint, liveEndpoint, aadAudience, isUnconfigured: false)
        {
        }

        private ConnectionVars(string instrumentationKey, string ingestionEndpoint, string liveEndpoint, string? aadAudience, bool isUnconfigured)
        {
            this.InstrumentationKey = instrumentationKey;
            this.IngestionEndpoint = ingestionEndpoint;
            this.LiveEndpoint = liveEndpoint;
            this.AadAudience = aadAudience;
            this.IsUnconfigured = isUnconfigured;
        }

        /// <summary>
        /// Stands in for a connection string the process does not have. The endpoint seeds the REST
        /// client host, which every routed send replaces with the endpoint its own group names.
        /// </summary>
        /// <remarks>
        /// The endpoint is deliberately the same value <see cref="ConnectionStringParser"/> defaults
        /// to, so it cannot be told apart from a real destination by inspection. Callers must branch
        /// on <see cref="IsUnconfigured"/> rather than on the values.
        /// </remarks>
        public static ConnectionVars CreateUnconfigured() => new(
            instrumentationKey: string.Empty,
            ingestionEndpoint: Constants.DefaultIngestionEndpoint,
            liveEndpoint: Constants.DefaultLiveEndpoint,
            aadAudience: null,
            isUnconfigured: true);

        public string InstrumentationKey { get; }

        public string IngestionEndpoint { get; }

        public string LiveEndpoint { get; }

        public string? AadAudience { get; }

        /// <summary>No connection string was configured, so these values name no destination.</summary>
        public bool IsUnconfigured { get; }
    }
}
