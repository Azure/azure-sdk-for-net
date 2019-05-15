// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Common
{
    /// <summary>
    /// Holds information about the progress data transfers for both request and response streams in a single operation.
    /// </summary>
    public sealed class StorageProgress
    {
        /// <summary>
        /// Progress in bytes of the request data transfer.
        /// </summary>
        public long BytesTransferred { get; }

        /// <summary>
        /// Creates a <see cref="StorageProgress"/> object.
        /// </summary>
        /// <param name="bytesTransferred">The progress value being reported.</param>
        public StorageProgress(long bytesTransferred) => this.BytesTransferred = bytesTransferred;

    }

    internal static class StorageProgressExtensions
    {
        public static Stream WithProgress(this Stream stream, IProgress<StorageProgress> progressHandler)
            =>
            progressHandler != null && stream != null
            ? new AggregatingProgressIncrementer(progressHandler).CreateProgressIncrementingStream(stream)
            : stream
            ;
    }

    /// <summary>
    /// An accumulator for request and response data transfers.
    /// </summary>
    internal sealed class AggregatingProgressIncrementer : IProgress<long>
    {
        long currentValue;
        bool currentValueHasValue;
        readonly IProgress<StorageProgress> innerHandler;

        public Stream CreateProgressIncrementingStream(Stream stream) => this.innerHandler != null && stream != null ? new ProgressIncrementingStream(stream, this) : stream;

        public AggregatingProgressIncrementer(IProgress<StorageProgress> innerHandler) => this.innerHandler = innerHandler;

        /// <summary>
        /// Increments the current value and reports it to the progress handler
        /// </summary>
        /// <param name="bytes"></param>
        public void Report(long bytes)
        {
            Interlocked.Add(ref this.currentValue, bytes);
            Volatile.Write(ref this.currentValueHasValue, true);

            if (this.innerHandler != null)
            {
                var current = this.Current;

                if (current != null)
                {
                    this.innerHandler.Report(current);
                }
            }
        }

        /// <summary>
        /// Zeroes out the current accumulation, and reports it to the progress handler
        /// </summary>
        public void Reset()
        {
            var currentActual = Volatile.Read(ref this.currentValue);

            this.Report(-currentActual);
        }

        /// <summary>
        /// Returns an instance that no-ops accumulation.
        /// </summary>
        public static AggregatingProgressIncrementer None { get; } = new AggregatingProgressIncrementer(default);

        /// <summary>
        /// Returns a StorageProgress instance representing the current progress value.
        /// </summary>
        public StorageProgress Current
        {
            get
            {
                var result = default(StorageProgress);

                if (this.currentValueHasValue)
                {
                    var currentActual = Volatile.Read(ref this.currentValue);

                    result = new StorageProgress(currentActual);
                }

                return result;
            }
        }
    }

    /// <summary>
    /// Wraps a stream, and reports position updates to a progress incrementer
    /// </summary>
    internal class ProgressIncrementingStream : Stream
    {
        readonly Stream innerStream;
        readonly AggregatingProgressIncrementer incrementer;

        public ProgressIncrementingStream(Stream stream, AggregatingProgressIncrementer incrementer)
        {
            this.innerStream = stream ?? throw Errors.ArgumentNull(nameof(stream));
            this.incrementer = incrementer ?? throw Errors.ArgumentNull(nameof(incrementer));
        }

        public override bool CanRead => this.innerStream.CanRead;

        public override bool CanSeek => this.innerStream.CanSeek;

        public override bool CanTimeout => this.innerStream.CanTimeout;

        public override bool CanWrite => this.innerStream.CanWrite;

        protected override void Dispose(bool disposing) => this.innerStream.Dispose();

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            var oldPosition = this.innerStream.Position;

            await this.innerStream.FlushAsync(cancellationToken).ConfigureAwait(false);

            var newPosition = this.innerStream.Position;

            this.incrementer.Report(newPosition - oldPosition);
        }

        public override void Flush()
        {
            var oldPosition = this.innerStream.Position;

            this.innerStream.Flush();

            var newPosition = this.innerStream.Position;

            this.incrementer.Report(newPosition - oldPosition);
        }

        public override long Length => this.innerStream.Length;

        public override long Position
        {
            get => this.innerStream.Position;

            set
            {
                var delta = value - this.innerStream.Position;

                this.innerStream.Position = value;

                this.incrementer.Report(delta);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var n = this.innerStream.Read(buffer, offset, count);
            this.incrementer.Report(n);
            return n;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var n = await this.innerStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            this.incrementer.Report(n);
            return n;
        }

        public override int ReadByte()
        {
            var b = this.innerStream.ReadByte();

            if (b != -1) // -1 = end of stream sentinel
            {
                this.incrementer.Report(1);
            }

            return b;
        }

        public override int ReadTimeout
        {
            get => this.innerStream.ReadTimeout;

            set => this.innerStream.ReadTimeout = value;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            var oldPosition = this.innerStream.Position;

            var newPosition = this.innerStream.Seek(offset, origin);

            this.incrementer.Report(newPosition - oldPosition);

            return newPosition;
        }

        public override void SetLength(long value) => this.innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.innerStream.Write(buffer, offset, count);

            this.incrementer.Report(count);
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await this.innerStream.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);

            this.incrementer.Report(count);
        }

        public override void WriteByte(byte value)
        {
            this.innerStream.WriteByte(value);

            this.incrementer.Report(1);
        }

        public override int WriteTimeout
        {
            get => this.innerStream.WriteTimeout;

            set => this.innerStream.WriteTimeout = value;
        }
    }
}
