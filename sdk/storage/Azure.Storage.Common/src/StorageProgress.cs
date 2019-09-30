// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Common
{
    /// <summary>
    /// Holds information about the progress data transfers for both request and response streams in a single operation.
    /// </summary>
    public sealed class StorageProgress
    {
        /// <summary>
        /// Progress in bytes of the request data transfer.
        /// </summary>
        public long BytesTransferred { get; }

        /// <summary>
        /// Creates a <see cref="StorageProgress"/> object.
        /// </summary>
        /// <param name="bytesTransferred">The progress value being reported.</param>
        public StorageProgress(long bytesTransferred) => BytesTransferred = bytesTransferred;

    }

    internal static class StorageProgressExtensions
    {
        public static Stream WithProgress(this Stream stream, IProgress<StorageProgress> progressHandler)
            =>
            progressHandler != null && stream != null
            ? new AggregatingProgressIncrementer(progressHandler).CreateProgressIncrementingStream(stream)
            : stream
            ;
    }
}
