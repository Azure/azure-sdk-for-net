// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Struct to hold user/operation context information extracted from log attributes
    /// for mapping to Application Insights envelope tags instead of customDimensions.
    /// </summary>
    internal struct LogContextInfo
    {
        public string? MicrosoftClientIp;
        public string? EndUserPseudoId;
        public string? EndUserId;
        public string? UserAgent;
        public string? OperationName;

        /// <summary>
        /// Returns true if any context field has been set.
        /// </summary>
        internal readonly bool HasValues =>
            MicrosoftClientIp != null ||
            EndUserPseudoId != null ||
            EndUserId != null ||
            UserAgent != null ||
            OperationName != null;
    }
}
