// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Buffers;

namespace Azure.Core.Pipeline
{
    internal static class StreamExtensions
    {
        internal const int DefaultCopyBufferSize = 81920;

        public static async Task CopyToAsync(this Stream source, Stream destination, CancellationToken cancellationToken)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
            try
            {
                while (true)
                {
                    int bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                    if (bytesRead == 0) break;
                    await destination.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, bytesRead), cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        public static void CopyTo(this Stream source, Stream destination, CancellationToken cancellationToken)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
            try
            {
                int read;
                while ((read = source.Read(buffer, 0, buffer.Length)) != 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    destination.Write(buffer, 0, read);
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}