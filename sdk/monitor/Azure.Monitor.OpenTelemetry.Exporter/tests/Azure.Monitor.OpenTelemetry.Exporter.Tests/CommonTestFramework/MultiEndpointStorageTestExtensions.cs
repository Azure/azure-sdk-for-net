// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Most storage tests predate authenticated partitions and care only about the unauthenticated
    /// one. Production has no such default: filing authenticated telemetry in the unauthenticated
    /// partition would drain it forever without a token.
    /// </summary>
    internal static class MultiEndpointStorageTestExtensions
    {
        internal static MultiEndpointStorage.EndpointStorage? TryGet(this MultiEndpointStorage storage, string ingestionEndpoint)
            => storage.TryGet(ingestionEndpoint, useAadAuth: false);
    }
}
