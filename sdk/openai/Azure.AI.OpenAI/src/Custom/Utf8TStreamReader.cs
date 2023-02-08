// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;

namespace Azure.Core.Sse
{
    public sealed class Utf8TStreamReader : IDisposable
    {
        private Stream _stream;
        private byte[] _buffer;
        private int _read;
        private int _written;

        public Utf8TStreamReader(Stream stream, int bufferSize = 1024)
        {
            if (stream == null || !stream.CanRead)
                throw new ArgumentOutOfRangeException(nameof(stream));
            _stream = stream;
            _buffer = new byte[bufferSize];
            _read = 0;
            _written = 0;
        }

        public ReadOnlyMemory<byte>? ReadLine(ReadOnlySpan<byte> eol) //, CancellationToken ct = default)
        {
            if (IsEmpty)
            {
                var free = Free;
                if (Free >= 256)
                {
                    var read = _stream.Read(_buffer, _written, free);
                    if (read == 0)
                        return null;
                    _written += read;
                }
            }

            var unconsumed = UnconsumedMemory;
            var newline = unconsumed.Span.IndexOf(eol);
            if (newline >= 0)
            {
                _read += newline + eol.Length;
                return unconsumed.Slice(0, newline);
            }

            throw new NotImplementedException();
        }

        public int UnconsumedCount => _written - _read;
        public ReadOnlySpan<byte> UnconsumedSpan => _buffer.AsSpan(_read, UnconsumedCount);
        public ReadOnlyMemory<byte> UnconsumedMemory => _buffer.AsMemory(_read, UnconsumedCount);
        public int Free => _buffer.Length - _written;

        public bool IsEmpty => UnconsumedCount == 0;

        public void Dispose()
        {
            _stream.Dispose();
            _stream = null;
        }
    }
}
