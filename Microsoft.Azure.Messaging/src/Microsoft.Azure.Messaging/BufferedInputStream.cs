// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    class BufferedInputStream : Stream, ICloneable
    {
        BufferManagerByteArray data;
        MemoryStream innerStream;
        bool disposed;

        public BufferedInputStream(byte[] bytes, int bufferSize, InternalBufferManager bufferManager)
        {
            this.data = new BufferManagerByteArray(bytes, bufferManager);
            this.innerStream = new MemoryStream(bytes, 0, bufferSize);
        }

        BufferedInputStream(BufferManagerByteArray data, int bufferSize)
        {
            this.data = data;
            this.data.AddReference();
            this.innerStream = new MemoryStream(data.Bytes, 0, bufferSize);
        }

        public byte[] Buffer
        {
            get
            {
                this.ThrowIfDisposed();
                return this.data.Bytes;
            }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override long Length
        {
            get
            {
                this.ThrowIfDisposed();
                return this.innerStream.Length;
            }
        }

        public override long Position
        {
            get
            {
                this.ThrowIfDisposed();
                return this.innerStream.Position;
            }

            set
            {
                this.ThrowIfDisposed();
                this.innerStream.Position = value;
            }
        }

        public object Clone()
        {
            this.ThrowIfDisposed();
            return new BufferedInputStream(this.data, (int)this.innerStream.Length);
        }

        public override void Flush()
        {
            //TODO: throw FxTrace.Exception.AsError(new NotSupportedException());
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            this.ThrowIfDisposed();
            return this.innerStream.Read(buffer, offset, count);
        }

        //TODO
        //public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfDisposed();
        //    return new CompletedAsyncResult<int>(this.innerStream.Read(buffer, offset, count), callback, state);
        //}

        //public override int EndRead(IAsyncResult asyncResult)
        //{
        //    return CompletedAsyncResult<int>.End(asyncResult);
        //}

        public override long Seek(long offset, SeekOrigin origin)
        {
            this.ThrowIfDisposed();
            return this.innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            //TODO: throw FxTrace.Exception.AsError(new NotSupportedException());
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            //TODO: throw FxTrace.Exception.AsError(new NotSupportedException());
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!this.disposed && disposing)
                {
                    if (disposing)
                    {
                        this.innerStream.Dispose();
                    }

                    this.data.RemoveReference();
                    this.disposed = true;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                //TODO: throw FxTrace.Exception.AsError(new ObjectDisposedException("BufferedInputStream"));
                throw new ObjectDisposedException("BufferedInputStream");
            }
        }

        sealed class BufferManagerByteArray
        {
            volatile int references;

            public BufferManagerByteArray(byte[] bytes, InternalBufferManager bufferManager)
            {
                this.Bytes = bytes;
                this.BufferManager = bufferManager;
                this.references = 1;
            }

            public byte[] Bytes
            {
                get;
                private set;
            }

            InternalBufferManager BufferManager
            {
                get;
                set;
            }

            public void AddReference()
            {
#pragma warning disable 0420
                if (Interlocked.Increment(ref this.references) == 1)
#pragma warning restore 0420
                {
                    //TODO: throw FxTrace.Exception.AsError(new InvalidOperationException(SRClient.BufferAlreadyReclaimed));
                    throw new InvalidOperationException("Buffer already reclaimed");
                }
            }

            public void RemoveReference()
            {
                if (this.references > 0)
                {
#pragma warning disable 0420
                    if (Interlocked.Decrement(ref this.references) == 0)
#pragma warning restore 0420
                    {
                        this.BufferManager.ReturnBuffer(this.Bytes);
                        this.Bytes = null;
                    }
                }
            }
        }
    }
}
