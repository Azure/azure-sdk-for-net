// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.TelemetryClient
{
    /// <summary>
    /// Encapsulates the global telemetry configuration
    /// </summary>
    public sealed class TelemetryConfiguration
    {
        private string connectionString = string.Empty;

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }
    }
}
