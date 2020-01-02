// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage
{
    internal static class StorageProgressExtensions
    {
        public static Stream WithProgress(this Stream stream, IProgress<long> progressHandler)
        {
            if (progressHandler != null && stream != null)
            {
                if (progressHandler is AggregatingProgressIncrementer handler)
                {
                    return handler.CreateProgressIncrementingStream(stream);
                }
                else
                {
                    return (new AggregatingProgressIncrementer(progressHandler))
                        .CreateProgressIncrementingStream(stream);
                }
            }
            else
            {
                return stream;
            }
        }
    }
}
