using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Common
{
    internal class IdleCancellingStream : Stream
    {
        /// <summary>
        /// The <see cref="Stream"/> wrapped stream that is being read or written to.
        /// </summary>
        readonly Stream stream;

        /// <summary>
        /// A <see cref="System.Threading.CancellationToken"/> which fires if the stream has
        /// not been read from or written to within the idle timeout.
        /// </summary>
        public CancellationToken CancellationToken => this.cancellationTokenSource.Token;

        readonly int maxIdleTimeInMs;
        readonly CancellationTokenSource cancellationTokenSource;

        public override bool CanRead => this.stream.CanRead;

        public override bool CanSeek => this.stream.CanSeek;

        public override bool CanWrite => this.stream.CanWrite;

        public override long Length => this.stream.Length;

        public override long Position
        {
            get => this.stream.Position;
            set => this.stream.Position = value;
        }

        public override int ReadTimeout
        {
            get => this.stream.ReadTimeout;
            set => this.stream.ReadTimeout = value;
        }

        public override int WriteTimeout
        {
            get => this.stream.WriteTimeout;
            set => this.stream.WriteTimeout = value;
        }

        public IdleCancellingStream(Stream downloadStream, int maxIdleTimeInMs)
        {
            this.stream = downloadStream;
            this.maxIdleTimeInMs = maxIdleTimeInMs;
            this.cancellationTokenSource = new CancellationTokenSource(this.maxIdleTimeInMs);
        }

        public override long Seek(long offset, SeekOrigin origin) => this.stream.Seek(offset, origin);

        public override void SetLength(long value) => this.stream.SetLength(value);

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            this.cancellationTokenSource.CancelAfter(this.maxIdleTimeInMs);
            return this.stream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            this.cancellationTokenSource.CancelAfter(this.maxIdleTimeInMs);
            return this.stream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            this.cancellationTokenSource.CancelAfter(this.maxIdleTimeInMs);
            return this.stream.Read(buffer, offset, count);
        }

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            this.cancellationTokenSource.CancelAfter(this.maxIdleTimeInMs);
            return this.stream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.cancellationTokenSource.CancelAfter(this.maxIdleTimeInMs);
            this.stream.Write(buffer, offset, count);
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            this.cancellationTokenSource.CancelAfter(this.maxIdleTimeInMs);
            return this.stream.FlushAsync(cancellationToken);
        }

        public override void Flush()
        {
            this.cancellationTokenSource.CancelAfter(this.maxIdleTimeInMs);
            this.stream.Flush();
        }

        public override void Close() => this.cancellationTokenSource.Dispose();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // this.stream.Dispose(); // We don't dispose of the inner stream, because we didn't create it.
                this.cancellationTokenSource.Dispose();
            }
        }
    }
}
