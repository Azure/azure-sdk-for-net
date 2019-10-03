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

namespace Azure.Storage.Common
{
    internal class StreamPartitioner : IDisposable
    {
        private MemoryPool<byte> _memoryPool;
        private readonly long? _contentLength;
        private Func<int, bool, CancellationToken, Task<StreamPartition>> _getNextPartitionCore;

        public StreamPartitioner(Stream stream, MemoryPool<byte> memoryPool = default)
        {
            if (stream.CanSeek)
            {
                _contentLength = stream.Length;
            }
            _memoryPool = memoryPool ?? MemoryPool<byte>.Shared;
            _getNextPartitionCore = (size, async, ct) => GetNextPartitionAsync(stream, size, async, ct);
        }

        public StreamPartitioner(FileInfo file, MemoryPool<byte> memoryPool = default)
        {
            _contentLength = file.Length;
            _memoryPool = memoryPool ?? MemoryPool<byte>.Shared;
            _getNextPartitionCore = (size, async, ct) => GetNextPartitionAsync(file, size, async, ct);
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

            while (!ct.IsCancellationRequested)
            {
                // try to keep as many partitions loaded as possible

                while (!sourceComplete && loadedPartitions.Count < maxLoadedPartitions)
                {
                    Task<StreamPartition> partitionTask = GetNextPartitionAsync(size, async, ct);

#pragma warning disable IDE0068 // Use recommended dispose pattern // disposal is performed by the uploader
                    StreamPartition partition =
                        async
                        ? await partitionTask.ConfigureAwait(false)
                        : partitionTask.EnsureCompleted();
#pragma warning restore IDE0068 // Use recommended dispose pattern

                    if (partition.Length == 0)
                    {
                        // we've run off the end of the source

                        if (_contentLength.HasValue)
                        {
                            // if we have a content length, then we should be able to guarantee this
                            Debug.Assert(partition.ParentPosition == _contentLength);
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

                    if (async)
                    {
                        await Task.WhenAny(activePartitionDisposalTasks).ConfigureAwait(false);
                    }
                    else
                    {
                        Task.WaitAny(activePartitionDisposalTasks.ToArray(), ct);
                    }
                }

                // now we are assured to have room for partitions to be worked on

                if (loadedPartitions.Any())
                {
                    StreamPartition partition = loadedPartitions.Dequeue();

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

                    if (async)
                    {
                        await Task.WhenAll(activePartitionDisposalTasks).ConfigureAwait(false);
                    }
                    else
                    {
                        Task.WaitAll(activePartitionDisposalTasks.ToArray(), ct);
                    }

                    //Console.WriteLine("All partitions complete...");
                    break;
                }
            }

            // we're out of partitions, or cancellation was requested and we need to dispose of remaining partitions

            foreach (StreamPartition partition in loadedPartitions)
            {
                //Console.WriteLine($"Disposing partition {partition.ParentPosition}");

                partition.Dispose();
            }
        }

        internal Task<StreamPartition> GetNextPartitionAsync(int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
            => _getNextPartitionCore == default
            ? throw new ObjectDisposedException(nameof(StreamPartitioner))
            : _getNextPartitionCore(size, async, ct);

        private readonly SemaphoreSlim _getNextPartitionAsync_Semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Generate a forward-only sequence of substreams based on bufferSize.
        /// </summary>
        /// <returns>StreamPartition</returns>
        private async Task<StreamPartition> GetNextPartitionAsync(Func<long, Stream> streamSource, bool disposeStream, Func<long> getStartPosition, Action<int> incrementStartPosition, int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
        {
            if (async)
            {
                await _getNextPartitionAsync_Semaphore.WaitAsync(ct).ConfigureAwait(false);
            }
            else
            {
                _getNextPartitionAsync_Semaphore.Wait();
            }

            var startPosition = getStartPosition();
            Stream stream = streamSource(startPosition);

            IMemoryOwner<byte> buffer;

            lock (_memoryPool)
            {
                // TODO these operations should be simplified with Memory- and Span-accepting APIs in future NET Standard
                buffer = _memoryPool.Rent(size);
            }

            //Console.WriteLine($"Rented buffer of size {size} bytes");
            //this.logger?.LogTrace($"Rented buffer of size {size} bytes");

            if (MemoryMarshal.TryGetArray<byte>(buffer.Memory, out ArraySegment<byte> segment))
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

                _getNextPartitionAsync_Semaphore.Release();

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

                _getNextPartitionAsync_Semaphore.Release();
                throw Errors.UnableAccessArray();
            }
        }

        /// <summary>
        /// Generate a forward-only sequence of substreams based on bufferSize.
        /// </summary>
        /// <returns>StreamPartition</returns>
        private Task<StreamPartition> GetNextPartitionAsync(Stream stream, int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
            => GetNextPartitionAsync(
                startPosition => stream,
                false,
                () => stream.Position,
                count => { },
                size,
                async,
                ct
                );

        private long _filePosition = 0;

        /// <summary>
        /// Generate a forward-only sequence of substreams based on bufferSize.
        /// </summary>
        /// <returns>StreamPartition</returns>
        private Task<StreamPartition> GetNextPartitionAsync(FileInfo file, int size = Constants.DefaultBufferSize, bool async = true, CancellationToken ct = default)
            => GetNextPartitionAsync(
                startPosition =>
                {
                    FileStream stream = file.OpenRead();
                    stream.Seek(startPosition, SeekOrigin.Begin);
                    return stream;
                },
                true,
                () => _filePosition,
                count => _filePosition += count,
                size,
                async,
                ct
                );

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                _getNextPartitionCore = default;
                _memoryPool = default;

                _disposedValue = true;
            }
        }

#pragma warning disable CA1063 // Implement IDisposable Correctly // false alert
        public void Dispose() => Dispose(true);
#pragma warning restore CA1063 // Implement IDisposable Correctly
    }
}
