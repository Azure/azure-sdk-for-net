// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

#if CommonSDK
using Internals = Azure.Storage.Shared.Common;
namespace Azure.Storage.Shared.Common
#else
using Internals = Azure.Storage.Shared;
namespace Azure.Storage.Shared
#endif
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
