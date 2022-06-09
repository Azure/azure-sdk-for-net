// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography
{
    internal class AuthenticatedRegionCryptoStream : Stream
    {
        private readonly Stream _innerStream;
        private readonly CryptoStreamMode _mode;
        private readonly IAuthenticatedCryptographicTransform _transform;
        private bool _flushedFinal;

        private readonly byte[] _buffer;
        private int _bufferPos;
        // in read mode, innerStream content length may not allign with buffer size
        // need to record how much data in buffer is legitimate
        private int _bufferPopulatedLength;

        private readonly int _tempRefilBufferSize;

        public override bool CanRead => _mode == CryptoStreamMode.Read;

        public override bool CanWrite => _mode == CryptoStreamMode.Write && !_flushedFinal;

        public override bool CanSeek => false;

        public override long Length => throw new NotSupportedException();

        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        public AuthenticatedRegionCryptoStream(
            Stream innerStream,
            IAuthenticatedCryptographicTransform transform,
            int regionDataSize,
            CryptoStreamMode streamMode)
        {
            _innerStream = innerStream;
            _transform = transform;
            _mode = streamMode;

            // determine size of buffers. ciphertextLength = nonceLength + plaintextLength + tagLength.
            // determine if the stream's main buffer will hold ciphertext or plaintext and size accordingly.
            // do this calculation once in the constructor and never worry again in the read/write code.
            int bufferSize;
                // write plaintext to _buffer, then encrypt buffer and push ciphertext to innerStream
            if ((transform.TransformMode == TransformMode.Encrypt && streamMode == CryptoStreamMode.Write) ||
                // read and decrypt ciphertext from innerStream, then store plaintext results in _buffer to be read by caller
                (transform.TransformMode == TransformMode.Decrypt && streamMode == CryptoStreamMode.Read))
            {
                bufferSize = regionDataSize;
                _tempRefilBufferSize = transform.NonceLength + regionDataSize + transform.TagLength;
            }
                // read and encrypt plaintext from innerStream, then store ciphertext results in _buffer to be read by caller
            else if ((transform.TransformMode == TransformMode.Encrypt && streamMode == CryptoStreamMode.Read) ||
                // write ciphertext to _buffer, then decrypt buffer and push ciphertext to innerStream
                (transform.TransformMode == TransformMode.Decrypt && streamMode == CryptoStreamMode.Write))
            {
                bufferSize = transform.NonceLength + regionDataSize + transform.TagLength;
                _tempRefilBufferSize = regionDataSize;
            }
            else
            {
                throw Errors.InvalidArgument(nameof(transform));
            }

            _buffer = new byte[bufferSize];
            _bufferPopulatedLength = _buffer.Length;

            // handle first read/write
            _bufferPos = streamMode switch
            {
                // buffer needs refilling from source on first read
                CryptoStreamMode.Read => _buffer.Length,
                // buffer is ready to write to immediately
                CryptoStreamMode.Write => 0,
                _ => throw Errors.InvalidArgument(nameof(streamMode)),
            };
        }

        #region Read
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (!CanRead)
            {
                throw new NotSupportedException();
            }
            return ReadInternal(buffer, offset, count, false, default).EnsureCompleted();
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (!CanRead)
            {
                throw new NotSupportedException();
            }
            return await ReadInternal(buffer, offset, count, true, cancellationToken).ConfigureAwait(false);
        }

        private async Task<int> ReadInternal(byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
        {
            // refill _buffer with transformed contents from innerStream
            if (_bufferPos >= _buffer.Length)
            {
                var transformInputBuffer = new byte[_tempRefilBufferSize];

                int totalRead = 0;
                while (totalRead < transformInputBuffer.Length)
                {
                    int read = async
                        ? await _innerStream.ReadAsync(
                            transformInputBuffer,
                            totalRead,
                            transformInputBuffer.Length - totalRead,
                            cancellationToken).ConfigureAwait(false)
                        : _innerStream.Read(
                            transformInputBuffer,
                            totalRead,
                            transformInputBuffer.Length - totalRead);

                    totalRead += read;
                    if (read == 0)
                    {
                        break;
                    }
                }
                if (totalRead == 0)
                {
                    return 0;
                }

                _bufferPopulatedLength = _transform.TransformAuthenticationBlock(
                    input: new ReadOnlySpan<byte>(transformInputBuffer, 0, totalRead),
                    output: _buffer);
                _bufferPos = 0;
            }

            // return buffered content
            int bytesToRead = Math.Min(count, _bufferPopulatedLength - _bufferPos);
            Array.Copy(_buffer, _bufferPos, buffer, offset, bytesToRead);
            _bufferPos += bytesToRead;
            return bytesToRead;
        }
        #endregion

        #region Write
        public override void Write(byte[] buffer, int offset, int count)
            => WriteInternal(buffer, offset, count, false, default).EnsureCompleted();

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => await WriteInternal(buffer, offset, count, true, cancellationToken).ConfigureAwait(false);

        private async Task WriteInternal(byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
        {
            if (!CanWrite)
            {
                throw new NotSupportedException();
            }

            // write buffered content
            int written = 0;
            while (written < count)
            {
                // clear buffer if full
                await FlushIfReadyInternal(async, cancellationToken).ConfigureAwait(false);

                int bytesToWrite = Math.Min(count - written, _buffer.Length - _bufferPos);
                Array.Copy(buffer, offset + written, _buffer, _bufferPos, bytesToWrite);
                _bufferPos += bytesToWrite;
                written += bytesToWrite;
            }
        }
        #endregion

        public override void Flush()
            => FlushIfReadyInternal(false, default).Wait();

        public override async Task FlushAsync(CancellationToken cancellationToken)
            => await FlushIfReadyInternal(true, cancellationToken).ConfigureAwait(false);

        private async Task FlushIfReadyInternal(bool async, CancellationToken cancellationToken)
        {
            if (!CanWrite)
            {
                throw new NotSupportedException();
            }

            // flush buffer if full, else ignore
            if (_bufferPos >= _buffer.Length)
            {
                var transformedContentsBuffer = new byte[_tempRefilBufferSize];
                int outputBytes = _transform.TransformAuthenticationBlock(
                    input: _buffer,
                    output: transformedContentsBuffer);

                if (async)
                {
                    await _innerStream.WriteAsync(
                        transformedContentsBuffer,
                        offset: 0,
                        count: outputBytes,
                        cancellationToken).ConfigureAwait(false);
                    await _innerStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _innerStream.Write(
                        transformedContentsBuffer,
                        offset: 0,
                        count: outputBytes);
                    _innerStream.Flush();
                }

                _bufferPos = 0;
            }
        }

        public async Task FlushFinalInternal(bool async, CancellationToken cancellationToken)
        {
            if (!CanWrite)
            {
                throw new NotSupportedException();
            }

            if (_flushedFinal)
            {
                return;
            }

            await FlushIfReadyInternal(async, cancellationToken).ConfigureAwait(false);

            // if there is a final partial block, force-flush
            if (_bufferPos != 0)
            {
                var transformedContentsBuffer = new byte[_tempRefilBufferSize];
                int outputBytes = _transform.TransformAuthenticationBlock(
                    input: new ReadOnlySpan<byte>(_buffer, 0, _bufferPos),
                    output: transformedContentsBuffer);

                if (async)
                {
                    await _innerStream.WriteAsync(
                        transformedContentsBuffer,
                        offset: 0,
                        count: outputBytes,
                        cancellationToken).ConfigureAwait(false);
                    await _innerStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _innerStream.Write(
                        transformedContentsBuffer,
                        offset: 0,
                        count: outputBytes);
                    _innerStream.Flush();
                }
            }

            _flushedFinal = true;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (CanWrite)
            {
                FlushFinalInternal(async: false, cancellationToken: default).EnsureCompleted();
            }
            base.Dispose(disposing);
            _transform.Dispose();
            _innerStream?.Dispose();
        }
    }
}
