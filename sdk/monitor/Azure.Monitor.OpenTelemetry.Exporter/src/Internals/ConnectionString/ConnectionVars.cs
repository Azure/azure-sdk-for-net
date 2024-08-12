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
        {
            this.InstrumentationKey = instrumentationKey;
            this.IngestionEndpoint = ingestionEndpoint;
            this.LiveEndpoint = liveEndpoint;
            this.AadAudience = aadAudience;
        }

        public string InstrumentationKey { get; }

        public string IngestionEndpoint { get; }

        public string LiveEndpoint { get; }

        public string? AadAudience { get; }
    }
}
