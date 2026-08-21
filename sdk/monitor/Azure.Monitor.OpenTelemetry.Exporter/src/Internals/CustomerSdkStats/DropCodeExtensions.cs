// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    internal static class DropCodeExtensions
    {
        /// <summary>
        /// Converts a <see cref="DropCode"/> to its spec-defined dimension value
        /// (SCREAMING_SNAKE_CASE), matching the customer-facing SDKStats specification
        /// and the values emitted by the other language SDKs.
        /// </summary>
        public static string ToDimensionString(this DropCode dropCode) => dropCode switch
        {
            DropCode.ClientException => "CLIENT_EXCEPTION",
            DropCode.ClientReadonly => "CLIENT_READONLY",
            DropCode.ClientPersistenceIssue => "CLIENT_PERSISTENCE_CAPACITY",
            DropCode.ClientStorageDisabled => "CLIENT_STORAGE_DISABLED",

            // Items stored for later retry while the transmitter is backing off are a
            // client-side retry; the spec's nearest non-timeout retry bucket is CLIENT_EXCEPTION.
            DropCode.BackOffEnabled => "CLIENT_EXCEPTION",
            _ => "UNKNOWN"
        };
    }
}
