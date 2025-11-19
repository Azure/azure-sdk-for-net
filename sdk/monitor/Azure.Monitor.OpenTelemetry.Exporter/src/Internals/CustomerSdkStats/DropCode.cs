// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    /// <summary>
    /// Represents different types of drop codes for telemetry items that cannot be transmitted.
    /// Based on the official specification for customer SDK stats.
    /// Note: For non-retryable status codes, the actual HTTP status code (401, 403, etc.) should be used as the drop code.
    /// </summary>
    internal enum DropCode
    {
        /// <summary>
        /// Items dropped due to exceptions thrown or when a response is not returned from Breeze.
        /// </summary>
        ClientException = 1,

        /// <summary>
        /// Items dropped due to READONLY filesystem.
        /// </summary>
        ClientReadonly = 2,

        /// <summary>
        /// Items dropped due to disk persistence issues (e.g., disk full, I/O errors).
        /// </summary>
        ClientPersistenceIssue = 3,

        /// <summary>
        /// Items that would have been retried but are dropped since client has local storage disabled.
        /// </summary>
        ClientStorageDisabled = 4,

        /// <summary>
        /// Items that are stored for retry due to a backoff period.
        /// </summary>
        BackOffEnabled = 5,
    }
}
