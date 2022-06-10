// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;
using OpenTelemetry.Contrib.Extensions.PersistentStorage;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class PersistentStorageExtensions
    {
        internal static ExportResult SaveTelemetry(this IPersistentStorage storage, byte[] content, int leaseTime)
        {
            var blob = storage.CreateBlob(content, leaseTime);

            return blob == null ? ExportResult.Failure : ExportResult.Success;
        }
    }
}
