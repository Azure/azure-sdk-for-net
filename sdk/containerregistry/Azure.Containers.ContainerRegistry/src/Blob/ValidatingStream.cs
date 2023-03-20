// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    internal class ValidatingStream : Stream
    {
        private readonly Stream _stream;
        private readonly SHA256 _sha256;
        private readonly int _contentLength;
        private readonly string _digest;

        private int _received;
        private bool _validated;
        private bool _disposed;

        public ValidatingStream(Stream stream, int contentLength, string digest)
        {
            _stream = stream ?? throw new InvalidOperationException("The response content stream does not have any data.");
            _sha256 = SHA256.Create();
            _contentLength = contentLength;
            _digest = digest;
            _received = 0;
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public override void Flush() => _stream.Flush();

        public override int Read(byte[] buffer, int offset, int count)
        {
            int length = _stream.Read(buffer, offset, count);

            ProcessIncrement(buffer, offset, length);

            return length;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            int length = await _stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);

            ProcessIncrement(buffer, offset, length);

            return length;
        }

        private void ProcessIncrement(byte[] buffer, int offset, int length)
        {
            if (!_validated)
            {
                _received += length;
                _sha256.TransformBlock(buffer, offset, length, buffer, offset);

                if (_received == _contentLength)
                {
                    _sha256.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
                    string computedDigest = BlobHelper.FormatDigest(_sha256.Hash);
                    BlobHelper.ValidateDigest(computedDigest, _digest);
                    _validated = true;
                }
            }
        }

        public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

        public override void SetLength(long value) => _stream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _stream.Write(buffer, offset, count);

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _sha256?.Dispose();
                    _stream?.Dispose();
                }

                _sha256 = null;
                _stream = null;
                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
