// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

namespace Azure.Storage
{
    internal sealed class StreamPartition : Stream
    {
        private Action _disposeAction;
        private ReadOnlyMemory<byte> _memory;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length { get; }

        private long _position;

        public override long Position { get => _position; set => _position = value; }

        public long ParentPosition { get; }

        public Task DisposalTask { get; }

#pragma warning disable IDE0069, CA2213 // Disposable fields should be disposed // disposed in DisposalTask
        //ManualResetEventSlim disposalTaskCompletionSource;
        private SemaphoreSlim _disposalTaskCompletionSource;
#pragma warning restore IDE0069, CA2213 // Disposable fields should be disposed

        public StreamPartition(ReadOnlyMemory<byte> buffer, long parentPosition, int count, Action disposeAction, CancellationToken ct)
        {
            _memory = buffer;
            ParentPosition = parentPosition;
            Length = count;
            _disposeAction = disposeAction;
            //this.disposalTaskCompletionSource = new ManualResetEventSlim(false);
            _disposalTaskCompletionSource = new SemaphoreSlim(0);
            DisposalTask = DisposalTaskCore(ct);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task DisposalTaskCore(CancellationToken ct)
        {
            //Console.WriteLine($"Waiting for partition {this.ParentPosition}");

            //this.disposalTaskCompletionSource.Wait(ct);
            await _disposalTaskCompletionSource.WaitAsync(ct).ConfigureAwait(false);

            //Console.WriteLine($"Completed partition {this.ParentPosition}");

            _disposalTaskCompletionSource.Dispose();
            _disposalTaskCompletionSource = default;
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    base.Dispose(disposing);
                    _disposeAction();
                }

                _memory = default;
                _disposeAction = default;

                _disposedValue = true;

                //this.disposalTaskCompletionSource.Set();
                _disposalTaskCompletionSource.Release();
            }
        }

        private bool _disposedValue; // To detect redundant calls

        public override void Flush()
        {
            // Flush is allowed on read-only stream
        }

        public int Read(out ReadOnlyMemory<byte> buffer, int count)
        {
            var n = Math.Min(count, (int)(Length - _position));

            buffer = _memory.Slice((int)_position, n);

            Interlocked.Add(ref _position, n);

            return n;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var n = Math.Min(count, (int)(Length - _position));

            _memory.Slice((int)_position, n).CopyTo(new Memory<byte>(buffer, offset, count));

            Interlocked.Add(ref _position, n);

            return n;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Interlocked.Exchange(ref _position, offset);
                    break;
                case SeekOrigin.Current:
                    Interlocked.Add(ref _position, offset);
                    break;
                case SeekOrigin.End:
                    Interlocked.Exchange(ref _position, Length - offset);
                    break;
            }

            return Position;
        }

        public override void SetLength(long value) => throw Errors.NotImplemented();

        public override void Write(byte[] buffer, int offset, int count) => throw Errors.NotImplemented();
    }
}
