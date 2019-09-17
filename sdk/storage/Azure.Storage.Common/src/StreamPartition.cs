// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Common
{
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

        public long ParentPosition { get; }

        public Task DisposalTask { get; }

#pragma warning disable IDE0069 // Disposable fields should be disposed // disposed in DisposalTask
        //ManualResetEventSlim disposalTaskCompletionSource;
        SemaphoreSlim disposalTaskCompletionSource;
#pragma warning restore IDE0069 // Disposable fields should be disposed

        public StreamPartition(ReadOnlyMemory<byte> buffer, long parentPosition, int count, Action disposeAction, CancellationToken ct)
        {
            this.memory = buffer;
            this.ParentPosition = parentPosition;
            this.Length = count;
            this.disposeAction = disposeAction;
            //this.disposalTaskCompletionSource = new ManualResetEventSlim(false);
            this.disposalTaskCompletionSource = new SemaphoreSlim(0);
            this.DisposalTask = this.DisposalTaskImpl(ct);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        async Task DisposalTaskImpl(CancellationToken ct)
        {
            //Console.WriteLine($"Waiting for partition {this.ParentPosition}");

            //this.disposalTaskCompletionSource.Wait(ct);
            await this.disposalTaskCompletionSource.WaitAsync(ct).ConfigureAwait(false);

            //Console.WriteLine($"Completed partition {this.ParentPosition}");

            this.disposalTaskCompletionSource.Dispose();
            this.disposalTaskCompletionSource = default;
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        protected override void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    base.Dispose(disposing);
                    this.disposeAction();
                }

                this.memory = default;
                this.disposeAction = default;

                this.disposedValue = true;

                //this.disposalTaskCompletionSource.Set();
                this.disposalTaskCompletionSource.Release();
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        public override void Flush() => throw Errors.NotImplemented();

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

        public override void SetLength(long value) => throw Errors.NotImplemented();

        public override void Write(byte[] buffer, int offset, int count) => throw Errors.NotImplemented();
    }
}
