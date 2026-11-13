// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class StringRequestContent : RequestContent
    {
        private readonly byte[] _buffer;
        private readonly int _actualByteCount;

        public StringRequestContent(string value)
        {
#if NET6_0_OR_GREATER
            var byteCount = Encoding.UTF8.GetMaxByteCount(value.Length);
            _buffer = ArrayPool<byte>.Shared.Rent(byteCount);
            _actualByteCount = Encoding.UTF8.GetBytes(value, _buffer);
#else
            _buffer  = Encoding.UTF8.GetBytes(value);
            _actualByteCount = _buffer.Length;
#endif
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
#if NET6_0_OR_GREATER
            await stream.WriteAsync(_buffer.AsMemory(0, _actualByteCount), cancellation).ConfigureAwait(false);
#else
            await stream.WriteAsync(_buffer, 0, _actualByteCount, cancellation).ConfigureAwait(false);
#endif
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
#if NET6_0_OR_GREATER
            stream.Write(_buffer.AsSpan(0, _actualByteCount));
#else
            stream.Write(_buffer, 0, _actualByteCount);
#endif
        }

        public override bool TryComputeLength(out long length)
        {
            length = _actualByteCount;
            return true;
        }

        public override void Dispose()
        {
#if NET6_0_OR_GREATER
            ArrayPool<byte>.Shared.Return(_buffer, clearArray: true);
#endif
        }
    }
}
