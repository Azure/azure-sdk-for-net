// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Internal.Avro;
using Azure.Storage.Blobs.Models;
using System.Buffers;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// QuickQueryStream.
    /// </summary>
    internal class BlobQuickQueryStream : Stream
    {
        /// <summary>
        /// Underlying stream.
        /// </summary>
        internal Stream _avroStream;

        /// <summary>
        /// Avro Reader.
        /// </summary>
        internal AvroReader _avroReader;

        /// <summary>
        /// Buffer to hold bytes we haven't processed yet.
        /// </summary>
        internal byte[] _buffer;

        /// <summary>
        /// Current buffer offset.
        /// </summary>
        internal int _bufferOffset;

        /// <summary>
        /// The current length of the buffer.
        /// </summary>
        internal int _bufferLength;

        /// <summary>
        /// Progress handler.
        /// </summary>
        internal IProgress<long> _progressHandler;

        /// <summary>
        /// Error handler.
        /// </summary>
        internal Action<BlobQueryError> _errorHandler;

        public BlobQuickQueryStream(
            Stream avroStream,
            IProgress<long> progressHandler = default,
            Action<BlobQueryError> errorHandler = default)
        {
            _avroStream = avroStream;
            _avroReader = new AvroReader(_avroStream);
            _bufferOffset = 0;
            _bufferLength = 0;
            _progressHandler = progressHandler;
            _errorHandler = errorHandler;
        }

        /// <inheritdoc/>
        public override int Read(byte[] buffer, int offset, int count)
            => ReadInternal(async: false, buffer, offset, count).EnsureCompleted();

        /// <inheritdoc/>
        public new async Task<int> ReadAsync(byte[] buffer, int offset, int count)
            => await ReadInternal(async: true, buffer, offset, count).ConfigureAwait(false);

        // Note - offset is with respect to buffer.
        private async Task<int> ReadInternal(bool async, byte[] buffer, int offset, int count)
        {
            ValidateReadParameters(buffer, offset, count);

            int remainingBytes = _bufferLength - _bufferOffset;

            // We have enough bytes in the buffer and don't need to read the next Record.
            if (count <= remainingBytes)
            {
                Array.Copy(
                    sourceArray: _buffer,
                    sourceIndex: _bufferOffset,
                    destinationArray: buffer,
                    destinationIndex: offset,
                    length: count);
                _bufferOffset += count;
                return count;
            }

            // Copy remaining buffer
            if (remainingBytes > 0)
            {
                Array.Copy(
                    sourceArray: _buffer,
                    sourceIndex: _bufferOffset,
                    destinationArray: buffer,
                    destinationIndex: offset,
                    length: remainingBytes);
                _bufferOffset += remainingBytes;
                return remainingBytes;
            }

            // Reset _bufferOffset, _bufferLength, and remainingBytes
            _bufferOffset = 0;
            _bufferLength = 0;
            remainingBytes = 0;

            // We've caught up to the end of the _avroStream, but it isn't necessarly the end of the stream.
            if (!_avroReader.HasNext())
            {
                return 0;
            }

            // We need to keep getting the next record until we get a data record.
            while (remainingBytes == 0)
            {
                // Get next Record.
                Dictionary<string, object> record = (Dictionary<string, object>)await _avroReader.Next(async).ConfigureAwait(false);

                switch (record["$schema"])
                {
                    // Data Record
                    case Constants.QuickQuery.DataRecordName:
                        record.TryGetValue(Constants.QuickQuery.Data, out object byteObject);

                        if (byteObject == null)
                        {
                            throw new InvalidOperationException($"Avro data record is missing {Constants.QuickQuery.Data} property");
                        }

                        byte[] bytes = (byte[])byteObject;

                        // Return the buffer if it is not null and not big enough.
                        if (_buffer != null && _buffer.Length < bytes.Length)
                        {
                            ArrayPool<byte>.Shared.Return(_buffer, clearArray: true);
                        }

                        // Rent a new buffer if it is null or not big enough.
                        if (_buffer == null || _buffer.Length < bytes.Length)
                        {
                            _buffer = ArrayPool<byte>.Shared.Rent(Math.Max(4 * Constants.MB, bytes.Length));
                        }

                        Array.Copy(
                            sourceArray: bytes,
                            sourceIndex: 0,
                            destinationArray: _buffer,
                            destinationIndex: 0,
                            length: bytes.Length);

                        _bufferLength = bytes.Length;

                        // Don't remove this reset, it is used in the final array copy below.
                        remainingBytes = bytes.Length;
                        break;

                    // Progress Record
                    case Constants.QuickQuery.ProgressRecordName:
                        if (_progressHandler != default)
                        {
                            record.TryGetValue(Constants.QuickQuery.BytesScanned, out object progress);

                            if (progress == null)
                            {
                                throw new InvalidOperationException($"Avro progress record is mssing {Constants.QuickQuery.BytesScanned} property");
                            }

                            _progressHandler.Report((long)progress);
                        }
                        break;

                    // Error Record
                    case Constants.QuickQuery.ErrorRecordName:
                        ProcessErrorRecord(record);
                        break;

                    // End Record
                    case Constants.QuickQuery.EndRecordName:
                        if (_progressHandler != default)
                        {
                            record.TryGetValue(Constants.QuickQuery.TotalBytes, out object progress);

                            if (progress == null)
                            {
                                throw new InvalidOperationException($"Avro end record is missing {Constants.QuickQuery.TotalBytes} property");
                            }

                            _progressHandler.Report((long)progress);
                        }
                        return 0;
                }
            }

            int length = Math.Min(count, remainingBytes);
            Array.Copy(
                sourceArray: _buffer,
                sourceIndex: _bufferOffset,
                destinationArray: buffer,
                destinationIndex: offset,
                length: length);

            _bufferOffset += length;
            return length;
        }

        internal static void ValidateReadParameters(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException($"{nameof(buffer)}", "Parameter cannot be null.");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)}", "Parameter cannot be negative.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(count)}", "Parameter cannot be negative.");
            }

            if (offset + count > buffer.Length)
            {
                throw new ArgumentException($"The sum of {nameof(offset)} and {nameof(count)} cannot be greater than {nameof(buffer)} length.");
            }
        }

        internal void ProcessErrorRecord(Dictionary<string, object> record)
        {
            record.TryGetValue(Constants.QuickQuery.Fatal, out object fatal);
            record.TryGetValue(Constants.QuickQuery.Name, out object name);
            record.TryGetValue(Constants.QuickQuery.Description, out object description);
            record.TryGetValue(Constants.QuickQuery.Position, out object position);

            if (fatal == null)
            {
                throw new InvalidOperationException($"Avro error record is missing {nameof(fatal)} property");
            }

            if (name == null)
            {
                throw new InvalidOperationException($"Avro error record is missing {nameof(name)} property");
            }

            if (description == null)
            {
                throw new InvalidOperationException($"Avro error record is missing {nameof(description)} property");
            }

            if (position == null)
            {
                throw new InvalidOperationException($"Avro error record is missing {nameof(position)} property");
            }

            if (_errorHandler != null)
            {
                BlobQueryError blobQueryError = new BlobQueryError
                {
                    IsFatal = (bool)fatal,
                    Name = (string)name,
                    Description = (string)description,
                    Position = (long)position
                };
                _errorHandler(blobQueryError);
            }
        }

        /// <inheritdoc/>
        public override bool CanRead => true;

        /// <inheritdoc/>
        public override bool CanSeek => false;

        /// <inheritdoc/>
        public override bool CanWrite => false;

        /// <inheritdoc/>
        public override long Length => throw new NotSupportedException();

        /// <inheritdoc/>
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void Flush() => throw new NotSupportedException();

        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void SetLength(long value) => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(true);

            // Return the buffer to the pool if we're called from Dispose or a finalizer
            if (_buffer != null)
            {
                ArrayPool<byte>.Shared.Return(_buffer, clearArray: true);
                _buffer = null;
            }

            _avroStream.Dispose();
            if (_buffer != null)
            {
                ArrayPool<byte>.Shared.Return(_buffer, clearArray: true);
                _buffer = null;
            }

            _avroReader.Dispose();
        }
    }
}
