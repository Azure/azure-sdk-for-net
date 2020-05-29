// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared
{
    internal class LazyLoadingReadOnlyStream : Stream
    {
        /// <summary>
        /// The current position within the blob or file.
        /// </summary>
        private long _position;

        /// <summary>
        /// Last known length of underlying blob or file.
        /// </summary>
        private long _length;

        /// <summary>
        /// The backing buffer.
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// The current offset within the buffer.
        /// </summary>
        private int _bufferOffset;

        /// <summary>
        /// The stream we will download to.
        /// </summary>
        private Stream _stream;

        /// <summary>
        /// If the position has been changed or Seek() has been called since the last
        /// Read(), or if the LazyLoadingReadOnlyStream was just created.
        /// </summary>
        private bool _positionChanged;

        /// <summary>
        /// Request conditions to send on the download requests.
        /// </summary>
        private readonly RequestConditions _requestConditions;

        /// <summary>
        /// Async DownloadTo() function.
        /// </summary>
        private Func<Stream, RequestConditions, CancellationToken, Task<Response>> _downloadToAsyncFunc;

        /// <summary>
        /// Sync DownloadTo() function.
        /// </summary>
        private Func<Stream, RequestConditions, CancellationToken, Response> _downloadToFunc;

        public LazyLoadingReadOnlyStream(
            Func<Stream, RequestConditions, CancellationToken, Task<Response>> downloadToAsyncFunc,
            Func<Stream, RequestConditions, CancellationToken, Response> downloadToFunc,
            long position = 0,
            RequestConditions requestConditions = default)
        {
            _downloadToAsyncFunc = downloadToAsyncFunc;
            _downloadToFunc = downloadToFunc;
            _position = position;
            _requestConditions requestConditions;
            _positionChanged = true;
        }

        public override int Read(byte[] buffer, int offset, int count)
            => ReadInternal(
                async: false,
                buffer,
                offset,
                count,
                default)
            .EnsureCompleted();

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => await ReadInternal(
                async: true,
                buffer,
                offset,
                count,
                cancellationToken)
                .ConfigureAwait(false);

        public async Task<int> ReadInternal(bool async, byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            ValidateReadParameters(buffer, offset, count);

            // If this is the first time calling read, the position has changed since the last Read() call,
            // or we have ran out of bytes in the buffer.
            if (_buffer == null || _positionChanged || _bufferOffset == _buffer.Length)
            {
                // Calculate download length.  The Read bytes counts could be really small, so we want to download at least
                // Constants.MinimumStreamingDownloadSize bytes.
                int downloadLength = Math.Min(Constants.MinimumStreamingDownloadSize, (int)(_length - _position));

                // Return the _buffer and rent a new one.
                if (_buffer != null)
                {
                    ArrayPool<byte>.Shared.Return(_buffer);
                }
                _buffer = ArrayPool<byte>.Shared.Rent(downloadLength);
                _stream = new MemoryStream(_buffer);

                Response response;
                if (async)
                {
                    response = await _downloadToAsyncFunc(_stream, _requestConditions, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = _downloadToFunc(_stream, _requestConditions, cancellationToken);
                }

                _length = GetBlobLength(response);
                _bufferOffset = 0;
                _positionChanged = false;
            }

            // If we still have bytes in the buffer;
            if (_bufferOffset < _buffer.Length)
            {
                int totalCopiedBytes = 0;
                int copiedBytes = -1;
                while (totalCopiedBytes < count && copiedBytes != 0 && _position < _length)
                {
                    copiedBytes = async
                        ? await _stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false)
                        : _stream.Read(buffer, offset, count);

                    offset += copiedBytes;
                    count -= copiedBytes;
                    totalCopiedBytes += copiedBytes;
                    _position += copiedBytes;
                }
                return totalCopiedBytes;
            }
        }

        private static void ValidateReadParameters(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException($"{nameof(buffer)}", $"{nameof(buffer)} cannot be null.");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} cannot be less than 0.");
            }

            if (offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} cannot exceed {nameof(buffer)} length.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(count)} cannot be less than 0.");
            }

            if (offset + count > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} + {nameof(count)} cannot exceed {nameof(buffer)} length.");
            }
        }

        private static long GetBlobLength(Response response)
        {
            response.Headers.TryGetValue("ContentRange", out string lengthString);
            string[] split = lengthString.Split('/');
            return Convert.ToInt64(split[1], CultureInfo.InvariantCulture);
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _length;

        public override long Position
        {
            get => _position;
            set
            {
                _position = value;
                _positionChanged = true;
            }
        }

        // Seek is setting relative position.
        public override long Seek(long offset, SeekOrigin origin)
        {
            // Relative to beginning of blob or file.
            if (origin == SeekOrigin.Begin)
            {
                _position = offset;
            }
            // Relative to end of blob or file.
            else if (origin == SeekOrigin.End)
            {
                _position = _length + offset;
            }
            // Relative to current position.
            else
            {
                _position += offset;
            }

            if (_position < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "New position cannot be less than 0");
            }

            if (_position >= _length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "New position must be less than the length of the blob or file");
            }

            _positionChanged = true;
            return _position;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override void Flush() { }
    }
}
