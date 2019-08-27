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
    class StreamPartitioner : IDisposable
    {
        MemoryPool<byte> memoryPool;
        readonly long? contentLength;
        Func<int, bool, CancellationToken, Task<StreamPartition>> getNextPartitionImpl;

        public StreamPartitioner(Stream stream, MemoryPool<byte> memoryPool = default)
        {
            if (stream.CanSeek)
            {
                this.contentLength = stream.Length;
            }
            this.memoryPool = memoryPool ?? MemoryPool<byte>.Shared;
            this.getNextPartitionImpl = (size, async, ct) => this.GetNextPartitionAsync(stream, size, async, ct);
        }

        public StreamPartitioner(FileInfo file, MemoryPool<byte> memoryPool = default)
        {
            this.contentLength = file.Length;
            this.memoryPool = memoryPool ?? MemoryPool<byte>.Shared;
            this.getNextPartitionImpl = (size, async, ct) => this.GetNextPartitionAsync(file, size, async, ct);
        }

        public async IAsyncEnumerable<StreamPartition> GetPartitionsAsync(
            int maxActivePartitions,
            int maxLoadedPartitions,
            int size = Constants.DefaultBufferSize,
            bool async = true,
            [EnumeratorCancellation] CancellationToken ct = default
            )
        {
            var activePartitionDisposalTasks = new List<Task>();

            var loadedPartitions = new Queue<StreamPartition>();

            var sourceComplete = false;

            while(!ct.IsCancellationRequested)
            {
                // try to keep as many partitions loaded as possible

                while (!sourceComplete && loadedPartitions.Count < maxLoadedPartitions)
                {
                    var partitionTask = this.GetNextPartitionAsync(size, async, ct);

#pragma warning disable IDE0068 // Use recommended dispose pattern // disposal is performed by the uploader
                    var partition =
                        async
                        ? await partitionTask.ConfigureAwait(false)
                        : partitionTask.EnsureCompleted();
#pragma warning restore IDE0068 // Use recommended dispose pattern

                    if (partition.Length == 0)
                    {
                        // we've run off the end of the source

                        if (this.contentLength.HasValue)
                        {
                            // if we have a content length, then we should be able to guarantee this
                            Debug.Assert(partition.ParentPosition == this.contentLength);
                        }

                        // don't yield this partition, and instead just let the load exhaust itself

                        sourceComplete = true;

                        partition.Dispose();

                        //Console.WriteLine("Source exhausted");
                        break;
                    }
                    else
                    {
                        loadedPartitions.Enqueue(partition);

                        //Console.WriteLine($"Enqueued partition {partition.ParentPosition}");
                    }
                }

                // if we already have a full set of active partitions, wait until some have completed

                activePartitionDisposalTasks.RemoveAll(t => t.IsCompleted);

                if (activePartitionDisposalTasks.Any() && activePartitionDisposalTasks.Count == maxActivePartitions)
                {
                    //Console.WriteLine("Waiting for partition to complete...");

                    var t = Task.WhenAny(activePartitionDisposalTasks);

                    var completedTask =
                        async
                        ? await t.ConfigureAwait(false)
                        : t.EnsureCompleted();
                }

                // now we are assured to have room for partitions to be worked on

                if (loadedPartitions.Any())
                {
                    var partition = loadedPartitions.Dequeue();

                    //Console.WriteLine($"Activation partition {partition.ParentPosition}");

                    activePartitionDisposalTasks.Add(partition.DisposalTask);

                    // yield it to the consumer
                    yield return partition;
                }
                else
                {
                    // we've run out of buffered partitions, which means we've also run out of source

                    //Console.WriteLine("Partitions exhausted");

                    //Console.WriteLine("Waiting for remaining partitions to complete...");

                    var t = Task.WhenAll(activePartitionDisposalTasks);

                    if (async)
                    {
                        await t.ConfigureAwait(false);
                    }
                    else
                    {
                        t.EnsureCompleted();
                    }

                    //Console.WriteLine("All partitions complete...");
                    break;
                }
            }

            // we're out of partitions, or cancellation was requested and we need to dispose of remaining partitions

            foreach (var partition in loadedPartitions)
            {
                //Console.WriteLine($"Disposing partition {partition.ParentPosition}");

                partition.Dispose();
            }
        }

        internal Task<StreamPartition> GetNextPartitionAsync(int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
            => this.getNextPartitionImpl == default
            ? throw new ObjectDisposedException(nameof(StreamPartitioner))
            : this.getNextPartitionImpl(size, async, ct);

        readonly SemaphoreSlim getNextPartitionAsync_Semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Generate a forward-only sequence of substreams based on bufferSize.
        /// </summary>
        /// <returns>StreamPartition</returns>
        async Task<StreamPartition> GetNextPartitionAsync(Func<long, Stream> streamSource, bool disposeStream, Func<long> getStartPosition, Action<int> incrementStartPosition, int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
        {
            if (async)
            {
                await this.getNextPartitionAsync_Semaphore.WaitAsync(ct).ConfigureAwait(false);
            }
            else
            {
                this.getNextPartitionAsync_Semaphore.Wait();
            }

            var startPosition = getStartPosition();
            var stream = streamSource(startPosition);

            IMemoryOwner<byte> buffer;

            lock (this.memoryPool)
            {
                // TODO these operations should be simplified with Memory- and Span-accepting APIs in future NET Standard
                buffer = this.memoryPool.Rent(size);
            }

            //Console.WriteLine($"Rented buffer of size {size} bytes");
            //this.logger?.LogTrace($"Rented buffer of size {size} bytes");

            if (MemoryMarshal.TryGetArray<byte>(buffer.Memory, out var segment))
            {
                var count =
                    async
                    ? await stream.ReadAsync(segment.Array, 0, segment.Count, ct).ConfigureAwait(false)
                    : stream.Read(segment.Array, 0, segment.Count);

                if (disposeStream)
                {
                    stream.Dispose();
                }

                incrementStartPosition(count);

                this.getNextPartitionAsync_Semaphore.Release();

                //this.logger?.LogTrace($"Read {count} bytes");

                var partition = new StreamPartition(
                    buffer.Memory,
                    startPosition,
                    count,
                    () =>
                    {
                        buffer.Dispose();
                        //Console.WriteLine($"Disposed buffer of size {size} bytes");
                        //this.logger?.LogTrace($"Disposed buffer of size {size} bytes");
                    },
                    ct
                    );

                //Console.WriteLine($"Creating partition {partition.ParentPosition}");

                return partition;
            }
            else
            {
                if (disposeStream)
                {
                    stream.Dispose();
                }

                this.getNextPartitionAsync_Semaphore.Release();
                throw Errors.UnableAccessArray();
            }
        }

        /// <summary>
        /// Generate a forward-only sequence of substreams based on bufferSize.
        /// </summary>
        /// <returns>StreamPartition</returns>
        Task<StreamPartition> GetNextPartitionAsync(Stream stream, int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
            => this.GetNextPartitionAsync(
                startPosition => stream,
                false,
                () => stream.Position,
                count => { },
                size,
                async,
                ct
                );

        long filePosition = 0;

        /// <summary>
        /// Generate a forward-only sequence of substreams based on bufferSize.
        /// </summary>
        /// <returns>StreamPartition</returns>
        Task<StreamPartition> GetNextPartitionAsync(FileInfo file, int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
            => this.GetNextPartitionAsync(
                startPosition =>
                {
                    var stream = file.OpenRead();
                    stream.Seek(startPosition, SeekOrigin.Begin);
                    return stream;
                },
                true,
                () => this.filePosition,
                count => this.filePosition += count,
                size,
                async,
                ct
                );

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                }

                this.getNextPartitionImpl = default;
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

        public long ParentPosition { get; }

        public Task DisposalTask { get; }

#pragma warning disable IDE0069 // Disposable fields should be disposed // disposed in DisposalTask
        ManualResetEventSlim disposalTaskCompletionSource;
#pragma warning restore IDE0069 // Disposable fields should be disposed

        public StreamPartition(ReadOnlyMemory<byte> buffer, long parentPosition, int count, Action disposeAction, CancellationToken ct)
        {
            this.memory = buffer;
            this.ParentPosition = parentPosition;
            this.Length = count;
            this.disposeAction = disposeAction;
            this.disposalTaskCompletionSource = new ManualResetEventSlim(false);

            this.DisposalTask = Task.Factory.StartNew(
                () =>
                {
                    //Console.WriteLine($"Waiting for partition {this.ParentPosition}");

                    this.disposalTaskCompletionSource.Wait(ct);

                    //Console.WriteLine($"Completed partition {this.ParentPosition}");

                    this.disposalTaskCompletionSource.Dispose();
                    this.disposalTaskCompletionSource = default;
                },
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default
                );
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

                this.memory = default;
                this.disposeAction = default;

                this.disposedValue = true;

                this.disposalTaskCompletionSource.Set();
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
