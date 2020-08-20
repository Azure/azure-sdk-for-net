// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/AspNetCore/tree/master/src/Http/WebUtilities/src

using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Prefix _ unexpected

namespace Azure.Core
{
    internal static class StreamHelperExtensions
    {
        private const int _maxReadBufferSize = 1024 * 4;

        public static Task DrainAsync(this Stream stream, CancellationToken cancellationToken)
        {
            return stream.DrainAsync(ArrayPool<byte>.Shared, null, cancellationToken);
        }

        public static Task DrainAsync(this Stream stream, long? limit, CancellationToken cancellationToken)
        {
            return stream.DrainAsync(ArrayPool<byte>.Shared, limit, cancellationToken);
        }

        public static async Task DrainAsync(this Stream stream, ArrayPool<byte> bytePool, long? limit, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var buffer = bytePool.Rent(_maxReadBufferSize);
            long total = 0;
            try
            {
                var read = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                while (read > 0)
                {
                    // Not all streams support cancellation directly.
                    cancellationToken.ThrowIfCancellationRequested();
                    if (limit.HasValue && limit.GetValueOrDefault() - total < read)
                    {
                        throw new InvalidDataException($"The stream exceeded the data limit {limit.GetValueOrDefault()}.");
                    }
                    total += read;
                    read = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                bytePool.Return(buffer);
            }
        }
    }
}
