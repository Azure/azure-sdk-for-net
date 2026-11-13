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
        public string? SessionId;
        public string? DeviceId;
        public string? DeviceModel;
        public string? DeviceType;
        public string? DeviceOsVersion;
        public string? SyntheticSource;
        public string? UserAccountId;

        /// <summary>
        /// Returns true if any context field has been set.
        /// </summary>
        internal readonly bool HasValues =>
            MicrosoftClientIp != null ||
            EndUserPseudoId != null ||
            EndUserId != null ||
            UserAgent != null ||
            OperationName != null ||
            SessionId != null ||
            DeviceId != null ||
            DeviceModel != null ||
            DeviceType != null ||
            DeviceOsVersion != null ||
            SyntheticSource != null ||
            UserAccountId != null;
    }
}
