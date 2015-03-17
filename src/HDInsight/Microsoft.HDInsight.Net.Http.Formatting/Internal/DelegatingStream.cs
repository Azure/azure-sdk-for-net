// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Internal
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Stream that delegates to inner stream. 
    /// This is taken from System.Net.Http
    /// </summary>
    internal abstract class DelegatingStream : Stream
    {
        private Stream _innerStream;

        protected DelegatingStream(Stream innerStream)
        {
            if (innerStream == null)
            {
                throw Error.ArgumentNull("innerStream");
            }
            this._innerStream = innerStream;
        }

        protected Stream InnerStream
        {
            get { return this._innerStream; }
        }

        public override bool CanRead
        {
            get { return this._innerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return this._innerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return this._innerStream.CanWrite; }
        }

        public override long Length
        {
            get { return this._innerStream.Length; }
        }

        public override long Position
        {
            get { return this._innerStream.Position; }
            set { this._innerStream.Position = value; }
        }

        public override int ReadTimeout
        {
            get { return this._innerStream.ReadTimeout; }
            set { this._innerStream.ReadTimeout = value; }
        }

        public override bool CanTimeout
        {
            get { return this._innerStream.CanTimeout; }
        }

        public override int WriteTimeout
        {
            get { return this._innerStream.WriteTimeout; }
            set { this._innerStream.WriteTimeout = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._innerStream.Dispose();
            }
            base.Dispose(disposing);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this._innerStream.Seek(offset, origin);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this._innerStream.Read(buffer, offset, count);
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return this._innerStream.ReadAsync(buffer, offset, count, cancellationToken);
        }

#if !NETFX_CORE // BeginX and EndX not supported on Streams in portable libraries
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return this._innerStream.BeginRead(buffer, offset, count, callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return this._innerStream.EndRead(asyncResult);
        }
#endif

        public override int ReadByte()
        {
            return this._innerStream.ReadByte();
        }

        public override void Flush()
        {
            this._innerStream.Flush();
        }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return this._innerStream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return this._innerStream.FlushAsync(cancellationToken);
        }

        public override void SetLength(long value)
        {
            this._innerStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this._innerStream.Write(buffer, offset, count);
        }

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return this._innerStream.WriteAsync(buffer, offset, count, cancellationToken);
        }

#if !NETFX_CORE // BeginX and EndX not supported on Streams in portable libraries
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return this._innerStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            this._innerStream.EndWrite(asyncResult);
        }
#endif

        public override void WriteByte(byte value)
        {
            this._innerStream.WriteByte(value);
        }
    }
}
