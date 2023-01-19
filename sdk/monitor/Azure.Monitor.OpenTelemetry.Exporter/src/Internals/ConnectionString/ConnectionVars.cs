// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString
{
    /// <summary>
    /// Encapsulates variables from the ConnectionString.
    /// </summary>
    internal class ConnectionVars
    {
        public ConnectionVars(string instrumentationKey, string ingestionEndpoint)
        {
            this.InstrumentationKey = instrumentationKey;
            this.IngestionEndpoint = ingestionEndpoint;
        }

        public string InstrumentationKey { get; }

        public string IngestionEndpoint { get; }
    }
}
