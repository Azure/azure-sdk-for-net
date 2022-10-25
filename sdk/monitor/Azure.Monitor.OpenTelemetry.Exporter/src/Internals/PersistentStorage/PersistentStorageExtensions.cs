// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;
using OpenTelemetry.Extensions.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage
{
    internal static class PersistentStorageExtensions
    {
        internal static ExportResult SaveTelemetry(this PersistentBlobProvider storage, byte[] content, int leaseTime)
        {
            return storage.TryCreateBlob(content, leaseTime, out _) ? ExportResult.Success : ExportResult.Failure;
        }
    }
}
