// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence
{
    /// <summary>
    /// Storage write policy owned by the exporter, kept separate from the vendored
    /// PersistentStorage helpers.
    /// </summary>
    internal static class TelemetryStorageExtensions
    {
        private const int MaxBlobsToEvict = 32;

        /// <summary>
        /// Saves telemetry, making room oldest-first when the storage directory has reached its size
        /// cap. The storage provider drops new telemetry when full and never evicts, which would
        /// otherwise let a stale backlog permanently starve current telemetry.
        /// </summary>
        internal static ExportResult SaveTelemetryWithEviction(this PersistentBlobProvider storage, byte[] content, string? storageDirectory, long maxSizeInBytes)
        {
            var result = storage.SaveTelemetry(content);
            if (result == ExportResult.Success)
            {
                return result;
            }

            // A write can also fail for reasons eviction cannot help with - permissions, a full
            // disk, a locked file. Deleting the backlog in those cases would destroy telemetry
            // without saving anything, so evict only when the directory is genuinely at capacity.
            if (!IsAtCapacity(storageDirectory, maxSizeInBytes))
            {
                return result;
            }

            // The provider enumerates newest-first, so this walks backwards to reach the oldest
            // telemetry, retrying after each eviction to discard no more than necessary.
            var blobs = new List<PersistentBlob>(storage.GetBlobs());
            for (int i = blobs.Count - 1, evicted = 0; i >= 0 && evicted < MaxBlobsToEvict; i--)
            {
                if (!blobs[i].TryDelete())
                {
                    continue;
                }

                evicted++;

                result = storage.SaveTelemetry(content);
                if (result == ExportResult.Success)
                {
                    return result;
                }
            }

            return result;
        }

        private static bool IsAtCapacity(string? storageDirectory, long maxSizeInBytes)
        {
            if (storageDirectory == null)
            {
                return false;
            }

            try
            {
                long size = 0;
                foreach (var file in Directory.EnumerateFiles(storageDirectory, "*", SearchOption.TopDirectoryOnly))
                {
                    size += new FileInfo(file).Length;
                    if (size >= maxSizeInBytes)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                // Cannot prove the directory is full, so do not risk deleting anything.
            }

            return false;
        }
    }
}
