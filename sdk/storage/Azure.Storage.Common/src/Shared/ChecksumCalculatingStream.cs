// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Checksums stream contents as the stream is progressed through.
    /// Limited seek support on read. No seek support on write.
    /// <para/>
    /// All properties pass through except <see cref="Stream.CanRead"/>,
    /// <see cref="Stream.CanWrite"/>, <see cref="Stream.CanSeek"/>, and
    /// <see cref="Stream.Position"/> <c>set</c> (<c>get</c> will pass through).
    /// <para/>
    /// Passes thorugh properties traditionally locked behind seeking (e.g.
    /// <see cref="Stream.Length"/>) regardless of read or write mode, ensuring
    /// expected stream  checks are not interrupted and that exceptions only
    /// throw when unsupported behavior is actually attempted. This is done
    /// to maintain existing stream behavior as closely as possible, as this
    /// class is meant to only observe the stream contents as they flow.
    /// </summary>
    internal class ChecksumCalculatingStream : Stream
    {
        public delegate void AppendChecksumCalculation(ReadOnlySpan<byte> checksum);

        private readonly Stream _stream;
        private readonly AppendChecksumCalculation _appendChecksumCalculation;

        private readonly long _initialPosition;
        private long _nextToBeChecksummedPosition;

        public override bool CanRead { get; }

        public override bool CanWrite { get; }

        public override bool CanSeek => CanWrite ? false : _stream.CanSeek;

        public override long Length => _stream.Length;

        public override long Position
        {
            get => _stream.Position;
            set => Seek(value, SeekOrigin.Begin);
        }

        public override bool CanTimeout => _stream.CanTimeout;

        public override int ReadTimeout { get => _stream.ReadTimeout; set => _stream.ReadTimeout = value; }

        public override int WriteTimeout { get => _stream.WriteTimeout; set => _stream.WriteTimeout = value; }

        public static Stream GetReadStream(Stream stream, AppendChecksumCalculation appendChecksumCalculation)
            => new ChecksumCalculatingStream(stream, appendChecksumCalculation, isReadMode: true);

        public static Stream GetWriteStream(Stream stream, AppendChecksumCalculation appendChecksumCalculation)
            => new ChecksumCalculatingStream(stream, appendChecksumCalculation, isReadMode: false);

        private ChecksumCalculatingStream(Stream stream, AppendChecksumCalculation appendChecksumCalculation, bool isReadMode)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(appendChecksumCalculation, nameof(appendChecksumCalculation));

            CanRead = isReadMode;
            CanWrite = !isReadMode;
            if (CanRead && !stream.CanRead)
            {
                throw new ArgumentException("Created stream in read mode but base stream cannot read.");
            }
            else if (CanWrite && !stream.CanWrite)
            {
                throw new ArgumentException("Created stream in write mode but base stream cannot write.");
            }

            _stream = stream;
            _appendChecksumCalculation = appendChecksumCalculation;

            if (_stream.CanSeek)
            {
                _initialPosition = _stream.Position;
                _nextToBeChecksummedPosition = _stream.Position;
            }
            else
            {
                _initialPosition = -1;
                _nextToBeChecksummedPosition = -1;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return CanSeek
                ? ReadSeekableInternal(buffer, offset, count, async: false, cancellationToken: default).EnsureCompleted()
                : ReadUnseekableInternal(buffer, offset, count, async: false, cancellationToken: default).EnsureCompleted();
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return CanSeek
                ? await ReadSeekableInternal(buffer, offset, count, async: true, cancellationToken).ConfigureAwait(false)
                : await ReadUnseekableInternal(buffer, offset, count, async: true, cancellationToken).ConfigureAwait(false);
        }

        private async Task<int> ReadSeekableInternal(
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            AssertCanRead();
            Argument.AssertInRange(_stream.Position, _initialPosition, _nextToBeChecksummedPosition, nameof(Stream.Position));
            long startingPosition = _stream.Position;
            int read = await _stream.ReadInternal(buffer, offset, count, async, cancellationToken).ConfigureAwait(false);

            if (read > 0 && startingPosition + read >= _nextToBeChecksummedPosition)
            {
                int alreadyChecksummedDataLength = (int)(_nextToBeChecksummedPosition - startingPosition);
                _appendChecksumCalculation(new ReadOnlySpan<byte>(
                    buffer, offset + alreadyChecksummedDataLength, read - alreadyChecksummedDataLength));

                _nextToBeChecksummedPosition += read - alreadyChecksummedDataLength;
            }

            return read;
        }

        private async Task<int> ReadUnseekableInternal(
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            AssertCanRead();
            int read = await _stream.ReadInternal(buffer, offset, count, async, cancellationToken).ConfigureAwait(false);

            if (read > 0)
            {
                _appendChecksumCalculation(new ReadOnlySpan<byte>(buffer, offset, read));
            }

            _nextToBeChecksummedPosition += read;
            return read;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            WriteInternal(buffer, offset, count, async: false, cancellationToken: default).EnsureCompleted();
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await WriteInternal(buffer, offset, count, async: true, cancellationToken).ConfigureAwait(false);
        }

        private async Task WriteInternal(
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            AssertCanWrite();
            // if stream is seekable, ensure position wasn't moved out from under us
            if (CanSeek && _nextToBeChecksummedPosition != _stream.Position)
            {
                throw new InvalidOperationException("Stream position was moved, cannot properly checksum contents.");
            }

            _appendChecksumCalculation(new ReadOnlySpan<byte>(buffer, offset, count));
            await _stream.WriteInternal(buffer, offset, count, async, cancellationToken).ConfigureAwait(false);
            _nextToBeChecksummedPosition += count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (CanWrite)
            {
                throw new NotSupportedException("No seek support in write mode.");
            }

            // Seeking past data that has not yet been added ruins the checksum
            // Enforce that seeking is only done within bounds of already checksummed data
            if (_stream.CanSeek)
            {
                long absoluteOffset = origin switch
                {
                    SeekOrigin.Begin => offset,
                    SeekOrigin.Current => _stream.Position + offset,
                    SeekOrigin.End => _stream.Length + offset,
                    _ => throw new ArgumentException($"SeekOrigin '{origin}' not recognized"),
                };

                if (absoluteOffset < _initialPosition || _nextToBeChecksummedPosition < absoluteOffset)
                {
                    throw new NotSupportedException("Cannot seek past current checksum calculation point.");
                }
            }

            return _stream.Seek(offset, origin);
        }

        public override void Flush() => _stream.Flush();

        public override async Task FlushAsync(CancellationToken cancellationToken)
            => await _stream.FlushAsync(cancellationToken).ConfigureAwait(false);

        public override void Close() => _stream.Close();

        public override void SetLength(long value) => _stream.SetLength(value);

        private void AssertCanRead()
        {
            if (!CanRead)
            {
                throw new NotSupportedException("Cannot read from stream.");
            }
        }

        private void AssertCanWrite()
        {
            if (!CanWrite)
            {
                throw new NotSupportedException("Cannot write to stream.");
            }
        }
    }
}
