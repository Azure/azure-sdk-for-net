// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace FakeStorage
{
    internal class MemoryCloudAppendBlobStream : CloudBlobStream
    {
        private readonly MemoryStream _buffer;
        private readonly Action<byte[]> _commitAction;

        private bool _committed;
        private bool _disposed;

        public MemoryCloudAppendBlobStream(Action<byte[]> commitAction)
        {
            _buffer = new MemoryStream();
            _commitAction = commitAction;
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return _buffer.CanWrite; }
        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get { return _buffer.Position; }
            set { throw new NotSupportedException(); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    if (!_committed)
                    {
                        CommitAsync();
                    }

                    _buffer.Dispose();
                    _disposed = true;
                }
            }

            base.Dispose(disposing);
        }

        public override Task CommitAsync()
        {
            ThrowIfDisposed();
            ThrowIfCommitted();

            _commitAction.Invoke(_buffer.ToArray());
            _committed = true;

            return Task.CompletedTask;
        }

        public override void Flush()
        {
            _buffer.Flush();
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return _buffer.FlushAsync();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();
            ThrowIfCommitted();
            _buffer.Write(buffer, offset, count);
        }

        private void ThrowIfCommitted()
        {
            if (_committed)
            {
                throw new InvalidOperationException("The blob stream has already been committed once.");
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        public override void Commit()
        {
            throw new NotImplementedException();
        }

        public override ICancellableAsyncResult BeginCommit(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public override void EndCommit(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public override ICancellableAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public override void EndFlush(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}
