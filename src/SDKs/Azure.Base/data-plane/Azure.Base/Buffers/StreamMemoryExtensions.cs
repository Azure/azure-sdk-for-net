﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Buffers
{
    internal static class AzureBaseBuffersExtensions
    {
        public static async Task WriteAsync(this Stream stream, ReadOnlyMemory<byte> buffer, CancellationToken cancellation = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (buffer.Length == 0) return;
            byte[] array = null;
            try
            {
                if (MemoryMarshal.TryGetArray(buffer, out var arraySegment))
                {
                    await stream.WriteAsync(arraySegment.Array, arraySegment.Offset, arraySegment.Count, cancellation).ConfigureAwait(false);
                }
                else
                {
                    if (array == null || buffer.Length < buffer.Length)
                    {
                        if (array != null) ArrayPool<byte>.Shared.Return(array);
                        array = ArrayPool<byte>.Shared.Rent(buffer.Length);
                    }
                    if (!buffer.TryCopyTo(array)) throw new Exception("could not rent large enough buffer.");
                    await stream.WriteAsync(array, 0, buffer.Length, cancellation).ConfigureAwait(false);
                }
                
            }
            finally
            {
                if (array != null) ArrayPool<byte>.Shared.Return(array);
            }
        }

        public static async Task WriteAsync(this Stream stream, ReadOnlySequence<byte> buffer, CancellationToken cancellation = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (buffer.Length == 0) return;
            byte[] array = null;
            try
            {
                foreach (var segment in buffer)
                {
                    if (MemoryMarshal.TryGetArray(segment, out var arraySegment))
                    {
                        await stream.WriteAsync(arraySegment.Array, arraySegment.Offset, arraySegment.Count, cancellation).ConfigureAwait(false);
                    }
                    else
                    {
                        if (array == null || buffer.Length < segment.Length)
                        {
                            if (array != null) ArrayPool<byte>.Shared.Return(array);
                            array = ArrayPool<byte>.Shared.Rent(segment.Length);
                        }
                        if (!segment.TryCopyTo(array)) throw new Exception("could not rent large enough buffer.");
                        await stream.WriteAsync(array, 0, segment.Length, cancellation).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                if (array != null) ArrayPool<byte>.Shared.Return(array);
            }
        }

        public static async Task<int> ReadAsync(this Stream stream, Memory<byte> buffer, CancellationToken cancellation = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (MemoryMarshal.TryGetArray(buffer, out ArraySegment<byte> segment))
            {
                var read = await stream.ReadAsync(segment.Array, 0, segment.Count, cancellation).ConfigureAwait(false);
                return read;
            }
            else
            {
                byte[] array = null;
                try
                {
                    array = ArrayPool<byte>.Shared.Rent(buffer.Length);
                    var read = await stream.ReadAsync(array, 0, array.Length, cancellation).ConfigureAwait(false);
                    array.AsSpan(0, read).CopyTo(buffer.Span);
                    return read;
                }
                finally
                {
                    if(array!=null) ArrayPool<byte>.Shared.Return(array, true);
                }
            }
        }
    }
}
