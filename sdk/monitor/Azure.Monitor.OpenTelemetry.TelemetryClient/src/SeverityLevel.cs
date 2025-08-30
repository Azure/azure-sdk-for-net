// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.TelemetryClient
{
    /// <summary>
    /// This enumeration is used by ExceptionTelemetry and TraceTelemetry to identify severity level.
    /// </summary>
    public enum SeverityLevel
    {
        /// <summary>
        /// Verbose severity level.
        /// </summary>
        Verbose,

        /// <summary>
        /// Information severity level.
        /// </summary>
        Information,

        /// <summary>
        /// Warning severity level.
        /// </summary>
        Warning,

        /// <summary>
        /// Error severity level.
        /// </summary>
        Error,

        /// <summary>
        /// Critical severity level.
        /// </summary>
        Critical,
    }
}
