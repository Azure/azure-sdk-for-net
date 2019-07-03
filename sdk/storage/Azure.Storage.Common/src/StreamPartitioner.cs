// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Common
{
    class StreamPartitioner : IDisposable
    {
        Stream stream;
        MemoryPool<byte> memoryPool;

        public StreamPartitioner(Stream stream, MemoryPool<byte> memoryPool = default)
        {
            this.stream = stream;
            this.memoryPool = memoryPool ?? MemoryPool<byte>.Shared;
        }

        /// <summary>
        /// Generate a forward-only sequence of substreams based on bufferSize.
        /// </summary>
        /// <returns>StreamPartition</returns>
        public async Task<StreamPartition> ReadAsync(int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
        {
            // TODO these operations should be simplified with Memory- and Span-accepting APIs in future NET Standard
            var buffer = this.memoryPool.Rent(size);

            //this.logger?.LogTrace($"Rented buffer of size {size} bytes");

            if (MemoryMarshal.TryGetArray<byte>(buffer.Memory, out var segment))
            {
                var count = async ?
                    await this.stream.ReadAsync(segment.Array, 0, segment.Count, ct).ConfigureAwait(false) :
                    this.stream.Read(segment.Array, 0, segment.Count);

                //this.logger?.LogTrace($"Read {count} bytes");

                return new StreamPartition(
                    buffer.Memory,
                    count, 
                    () =>
                    {
                        buffer.Dispose();
                        //this.logger?.LogTrace($"Disposed buffer of size {size} bytes");
                    }
                    );
            }
            else
            {
                throw new Exception("Unable to get array from memory pool");
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                }
                
                this.stream = default;
                this.memoryPool = default;

                this.disposedValue = true;
            }
        }

#pragma warning disable CA1063 // Implement IDisposable Correctly // false alert
        public void Dispose() => this.Dispose(true);
#pragma warning restore CA1063 // Implement IDisposable Correctly
    }

    sealed class StreamPartition : Stream
    {
        Action disposeAction;
        ReadOnlyMemory<byte> memory;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length { get; }

        long position;

        public override long Position { get => this.position; set => this.position = value; }

        public StreamPartition(ReadOnlyMemory<byte> buffer, int count, Action disposeAction)
        {
            this.memory = buffer;
            this.Length = count;
            this.disposeAction = disposeAction;
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    base.Dispose(disposing);
                    this.disposeAction();
                }

                this.memory = null;
                this.disposeAction = default;

                this.disposedValue = true;
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        public override void Flush() => throw new NotImplementedException();

        public int Read(out ReadOnlyMemory<byte> buffer, int count)
        {
            var n = Math.Min(count, (int)(this.Length - this.position));

            buffer = this.memory.Slice((int)this.position, n);

            Interlocked.Add(ref this.position, n);

            return n;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var n = Math.Min(count, (int)(this.Length - this.position));

            this.memory.Slice((int)this.position, n).CopyTo(new Memory<byte>(buffer, offset, count));

            Interlocked.Add(ref this.position, n);

            return n;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Interlocked.Exchange(ref this.position, offset);
                    break;
                case SeekOrigin.Current:
                    Interlocked.Add(ref this.position, offset);
                    break;
                case SeekOrigin.End:
                    Interlocked.Exchange(ref this.position, this.Length - offset);
                    break;
            }

            return this.Position;
        }

        public override void SetLength(long value) => throw new NotImplementedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
    }
}
