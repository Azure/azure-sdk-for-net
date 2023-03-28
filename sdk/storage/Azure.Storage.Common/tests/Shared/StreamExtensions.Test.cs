// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    internal static partial class StreamExtensions
    {
        public static async Task CopyToInternalExactBufferSize(
            this Stream src,
            Stream dest,
            int bufferSize,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[bufferSize];
            int bytesRead;
            while ((bytesRead = async
                ? await src.ReadAsync(buffer, 0, buffer.Length, cancellationToken)
                : src.Read(buffer, 0, buffer.Length)) != 0)
            {
                if (async)
                {
                    await dest.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                }
                else
                {
                    dest.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
