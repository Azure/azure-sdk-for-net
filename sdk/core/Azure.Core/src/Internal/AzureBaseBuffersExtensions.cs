// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Buffers
{
    internal static class AzureBaseBuffersExtensions
    {
        // Same value as Stream.CopyTo uses by default
        private const int DefaultCopyBufferSize = 81920;

        public static async Task WriteAsync(this Stream stream, ReadOnlyMemory<byte> buffer, CancellationToken cancellation = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));
#if NETCOREAPP
            await stream.WriteAsync(buffer, cancellation).ConfigureAwait(false);
#else

            if (buffer.Length == 0)
                return;
            byte[]? array = null;
            try
            {
                if (MemoryMarshal.TryGetArray(buffer, out ArraySegment<byte> arraySegment))
                {
                    Debug.Assert(arraySegment.Array != null);
                    await stream.WriteAsync(arraySegment.Array, arraySegment.Offset, arraySegment.Count, cancellation).ConfigureAwait(false);
                }
                else
                {
                    array = ArrayPool<byte>.Shared.Rent(buffer.Length);

                    if (!buffer.TryCopyTo(array))
                        throw new Exception("could not rent large enough buffer.");
                    await stream.WriteAsync(array, 0, buffer.Length, cancellation).ConfigureAwait(false);
                }
            }
            finally
            {
                if (array != null)
                    ArrayPool<byte>.Shared.Return(array);
            }
#endif
        }

        public static async Task WriteAsync(this Stream stream, ReadOnlySequence<byte> buffer, CancellationToken cancellation = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            if (buffer.Length == 0)
                return;
            byte[]? array = null;
            try
            {
                foreach (ReadOnlyMemory<byte> segment in buffer)
                {
#if NETCOREAPP
                    await stream.WriteAsync(segment, cancellation).ConfigureAwait(false);
#else
                    if (MemoryMarshal.TryGetArray(segment, out ArraySegment<byte> arraySegment))
                    {
                        Debug.Assert(arraySegment.Array != null);
                        await stream.WriteAsync(arraySegment.Array, arraySegment.Offset, arraySegment.Count, cancellation).ConfigureAwait(false);
                    }
                    else
                    {
                        if (array == null || array.Length < segment.Length)
                        {
                            if (array != null)
                                ArrayPool<byte>.Shared.Return(array);
                            array = ArrayPool<byte>.Shared.Rent(segment.Length);
                        }
                        if (!segment.TryCopyTo(array))
                            throw new Exception("could not rent large enough buffer.");
                        await stream.WriteAsync(array, 0, segment.Length, cancellation).ConfigureAwait(false);
                    }
#endif
                }
            }
            finally
            {
                if (array != null)
                    ArrayPool<byte>.Shared.Return(array);
            }
        }

        public static async Task CopyToAsync(this Stream source, Stream destination, CancellationToken cancellationToken)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);

            try
            {
                while (true)
                {
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in all targets
                    int bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in all targets
                    if (bytesRead == 0)
                        break;
                    await destination.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, bytesRead), cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                await destination.FlushAsync(cancellationToken).ConfigureAwait(false);
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
                destination.Flush();
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
