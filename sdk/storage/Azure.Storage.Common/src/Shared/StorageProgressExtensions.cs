// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage
{
    internal static class StorageProgressExtensions
    {
        public static Stream WithProgress(this Stream stream, IProgress<long> progressHandler)
            =>
                progressHandler != null && stream != null
                    ? new AggregatingProgressIncrementer(progressHandler).CreateProgressIncrementingStream(stream)
                    : stream;
    }
}
