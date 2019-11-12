// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage
{
    [Obsolete("This type is only available for backwards compatibility with the 12.0.0 version of Storage libraries. It should not be used for new development.", true)]
    internal static class StorageProgressExtensions
    {
        public static Stream WithProgress(this Stream stream, IProgress<long> progressHandler)
            =>
                progressHandler != null && stream != null
                    ? new AggregatingProgressIncrementer(progressHandler).CreateProgressIncrementingStream(stream)
                    : stream;
    }
}
