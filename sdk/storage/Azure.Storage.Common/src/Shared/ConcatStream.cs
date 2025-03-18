// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    internal class ConcatStream : Stream
    {
        private readonly Queue<(Stream Stream, bool Dispose)> _streams;

        public ConcatStream(IEnumerable<Stream> streams, bool dispose = false) => _streams = new(streams.Select(s => (s, dispose)));

        public ConcatStream(IEnumerable<(Stream Stream, bool Dispose)> streams) => _streams = new(streams);

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        private bool TryGetCurrentStream(out Stream stream)
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            if (_streams.TryPeek(out (Stream Stream, bool Dispose) peek))
            {
                stream = peek.Stream;
                return true;
            }
            stream = null;
            return false;
#else
            try
            {
                (stream, _) = _streams.Peek();
                return stream is not null;
            }
            catch (InvalidOperationException)
            {
                stream = null;
                return false;
            }
#endif
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async ValueTask StreamCompleted(bool async)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            if (_streams.TryDequeue(out (Stream Stream, bool Dispose) elem) && elem.Dispose)
            {
                if (async)
                {
                    await elem.Stream.DisposeAsync().ConfigureAwait(false);
                }
                else
                {
                    elem.Stream.Dispose();
                }
            }
#else
            try
            {
                (Stream stream, bool dispose) = _streams.Dequeue();
                if (dispose)
                {
                    stream?.Dispose();
                }
            }
            catch (InvalidOperationException)
            {
            }
#endif
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            while (TryGetCurrentStream(out Stream stream))
            {
                int result = stream.Read(buffer, offset, count);
                if (result == 0)
                {
                    StreamCompleted(async: false).EnsureCompleted();
                }
                else
                {
                    return result;
                }
            }
            return 0;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            while (TryGetCurrentStream(out Stream stream))
            {
                int result = await stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
                if (result == 0)
                {
                    await StreamCompleted(async: true).ConfigureAwait(false);
                }
                else
                {
                    return result;
                }
            }
            return 0;
        }

        public override void Flush() { }

        public override Task FlushAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => throw new NotSupportedException();

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        public override int Read(Span<byte> buffer)
        {
            while (TryGetCurrentStream(out Stream stream))
            {
                int result = stream.Read(buffer);
                if (result == 0)
                {
                    StreamCompleted(async: false).EnsureCompleted();
                }
                else
                {
                    return result;
                }
            }
            return 0;
        }

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            while (TryGetCurrentStream(out Stream stream))
            {
                int result = await stream.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);
                if (result == 0)
                {
                    await StreamCompleted(async: true).ConfigureAwait(false);
                }
                else
                {
                    return result;
                }
            }
            return 0;
        }

        public override void Write(ReadOnlySpan<byte> buffer) => throw new NotSupportedException();

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default) => throw new NotSupportedException();

#endif
    }
}
