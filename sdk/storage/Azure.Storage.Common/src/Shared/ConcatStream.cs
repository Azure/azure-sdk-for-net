// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// Read-only stream that manages in-place concatenation of multiple streams in a given order.
    /// If all sub-streams are seekable, this stream is also seekable and will maintain all given
    /// streams until this stream is disposed.
    /// Otherwise, sub-streams are disposed once completed.
    /// </summary>
    internal class ConcatStream : Stream
    {
        private readonly List<(Stream Stream, bool Dispose)> _streams;
        private int _currStreamIndex = 0;
        private readonly bool _allStreamsSeekable;

        public ConcatStream(IEnumerable<Stream> streams, bool dispose = false) : this(streams.Select(s => (s, dispose)))
        { }

        public ConcatStream(IEnumerable<(Stream Stream, bool Dispose)> streams)
        {
            _streams = [];
            bool allStreamsSeekable = true;
            foreach ((Stream stream, bool dispose) in streams)
            {
                allStreamsSeekable = allStreamsSeekable && stream.CanSeek;
                _streams.Add((stream, dispose));
            }
            _allStreamsSeekable = allStreamsSeekable;
        }

        public override bool CanRead => true;

        public override bool CanSeek => _allStreamsSeekable;

        public override bool CanWrite => false;

        public override long Length => CanSeek ? _streams.Select(tup => tup.Stream.Length).Sum() : throw new NotSupportedException();

        public override long Position
        {
            get
            {
                if (!CanSeek)
                {
                    throw new NotSupportedException();
                }
                Argument.AssertInRange(_currStreamIndex, 0, _streams.Count - 1, nameof(_currStreamIndex));

                long pos = 0;
                for (int i = 0; i < _currStreamIndex; i++)
                {
                    pos += _streams[i].Stream.Length;
                }
                pos += _streams[_currStreamIndex].Stream.Position;
                return pos;
            }
            set => Seek(value, SeekOrigin.Begin);
        }

        private bool TryGetCurrentStream(out Stream stream)
        {
            if (_currStreamIndex >= _streams.Count)
            {
                stream = null;
                return false;
            }
            stream = _streams[_currStreamIndex].Stream;
            return true;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async ValueTask StreamCompleted(bool async)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (_allStreamsSeekable)
            {
                _currStreamIndex++;
                return;
            }
            if (_currStreamIndex >= _streams.Count)
            {
                return; // TODO throw?
            }

            (Stream stream, bool dispose) = _streams[_currStreamIndex];
            _streams.RemoveAt(_currStreamIndex);
            if (dispose)
            {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
                if (async)
                {
                    await stream.DisposeAsync().ConfigureAwait(false);
                }
                else
                {
                    stream.Dispose();
                }
#else
                stream.Dispose();
#endif
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                return;
            }
            foreach ((Stream stream, bool dispose) in _streams)
            {
                if (dispose)
                {
                    stream.Dispose();
                }
            }
            _streams.Clear();
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

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (!CanSeek)
            {
                throw new NotSupportedException();
            }
            long target = origin switch
            {
                SeekOrigin.Begin => offset,
                SeekOrigin.Current => Position + offset,
                SeekOrigin.End => Length + offset,
                _ => throw Errors.InvalidArgument(nameof(origin)),
            };
            if (target < 0 || target > Length)
            {
                throw Errors.SeekOutsideStreamRange(target, Length);
            }

            long currPos = 0;
            for (int i = 0; i < _streams.Count; i++)
            {
                Stream s = _streams[i].Stream;
                if (currPos + s.Length < target)
                {
                    currPos += s.Length;
                    continue;
                }
                else
                {
                    s.Position = target - currPos;
                    break;
                }
            }
            return target;
        }

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
