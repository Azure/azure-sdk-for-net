// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Test.Shared
{
    internal class FaultyStream : Stream
    {
        private readonly Stream _innerStream;
        private readonly int _raiseExceptionAt;
        private readonly Exception _exceptionToRaise;
        private int _remainingExceptions;
        private Action _onFault;
        private long _position = 0;

        public FaultyStream(
            Stream innerStream,
            int raiseExceptionAt,
            int maxExceptions,
            Exception exceptionToRaise,
            Action onFault)
        {
            _innerStream = innerStream;
            _raiseExceptionAt = raiseExceptionAt;
            _exceptionToRaise = exceptionToRaise;
            _remainingExceptions = maxExceptions;
            _onFault = onFault;
        }

        public override bool CanRead => _innerStream.CanRead;

        public override bool CanSeek => _innerStream.CanSeek;

        public override bool CanWrite => _innerStream.CanWrite;

        public override long Length => _innerStream.Length;

        public override long Position
        {
            get => CanSeek ? _innerStream.Position : _position;
            set => _innerStream.Position = value;
        }

        public override void Flush() => _innerStream.Flush();

        public override Task FlushAsync(CancellationToken cancellationToken) =>
            _innerStream.FlushAsync(cancellationToken);

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_remainingExceptions == 0 || Position + count <= _raiseExceptionAt || _raiseExceptionAt >= _innerStream.Length)
            {
                int read = _innerStream.Read(buffer, offset, count);
                _position += read;
                return read;
            }
            else
            {
                throw Fault();
            }
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (_remainingExceptions == 0 || Position + count <= _raiseExceptionAt || _raiseExceptionAt >= _innerStream.Length)
            {
                int read = await _innerStream.ReadAsync(buffer, offset, count, cancellationToken);
                _position += read;
                return read;
            }
            else
            {
                throw Fault();
            }
        }

        public override int ReadByte()
        {
            if (_remainingExceptions == 0 || Position <= _raiseExceptionAt || _raiseExceptionAt >= _innerStream.Length)
            {
                return _innerStream.ReadByte();
            }
            else
            {
                throw Fault();
            }
        }

        public override long Seek(long offset, SeekOrigin origin) => _innerStream.Seek(offset, origin);

        public override void SetLength(long value) => _innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _innerStream.Write(buffer, offset, count);

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            _innerStream.WriteAsync(buffer, offset, count, cancellationToken);

        private Exception Fault()
        {
            _remainingExceptions--;
            _onFault();
            return _exceptionToRaise;
        }
    }
}
