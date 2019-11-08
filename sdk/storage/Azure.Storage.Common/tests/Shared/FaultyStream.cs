// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal class FaultyStream : Stream
    {
        private readonly Stream _innerStream;
        private readonly int _raiseExceptionAt;
        private readonly Exception _exceptionToRaise;
        private int _remainingExceptions;

        public FaultyStream(Stream innerStream, int raiseExceptionAt, int maxExceptions, Exception exceptionToRaise)
        {
            _innerStream = innerStream;
            _raiseExceptionAt = raiseExceptionAt;
            _exceptionToRaise = exceptionToRaise;
            _remainingExceptions = maxExceptions;
        }

        public override bool CanRead => _innerStream.CanRead;

        public override bool CanSeek => _innerStream.CanSeek;

        public override bool CanWrite => _innerStream.CanWrite;

        public override long Length => _innerStream.Length;

        public override long Position
        {
            get => _innerStream.Position;
            set => _innerStream.Position = value;
        }

        public override async Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken) =>
            await _innerStream.CopyToAsync(destination, bufferSize, cancellationToken);

        public override void Flush() => _innerStream.Flush();

        public override Task FlushAsync(CancellationToken cancellationToken) =>
            _innerStream.FlushAsync(cancellationToken);

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_remainingExceptions == 0 || Position + count <= _raiseExceptionAt || Position + count >= _innerStream.Length)
            {
                return _innerStream.Read(buffer, offset, count);
            }
            else
            {
                _remainingExceptions--;
                throw _exceptionToRaise;
            }
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (_remainingExceptions == 0 || Position + count <= _raiseExceptionAt || Position + count >= _innerStream.Length)
            {
                return _innerStream.ReadAsync(buffer, offset, count, cancellationToken);
            }
            else
            {
                _remainingExceptions--;
                throw _exceptionToRaise;
            }
        }

        public override int ReadByte()
        {
            if (_remainingExceptions == 0 || Position <= _raiseExceptionAt || Position >= _innerStream.Length)
            {
                return _innerStream.ReadByte();
            }
            else
            {
                _remainingExceptions--;
                throw _exceptionToRaise;
            }
        }

        public override long Seek(long offset, SeekOrigin origin) => _innerStream.Seek(offset, origin);

        public override void SetLength(long value) => _innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _innerStream.Write(buffer, offset, count);

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            _innerStream.WriteAsync(buffer, offset, count, cancellationToken);
    }
}
