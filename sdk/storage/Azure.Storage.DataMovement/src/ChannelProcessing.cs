// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement;

internal delegate Task ProcessAsync<T>(T item, CancellationToken cancellationToken);

internal interface IProcessor<TItem> : IDisposable
{
    ValueTask QueueAsync(TItem item, CancellationToken cancellationToken = default);
    ProcessAsync<TItem> Process { get; set; }
}

internal static class ChannelProcessing
{
    public static IProcessor<T> NewProcessor<T>(int parallelism)
    {
        Argument.AssertInRange(parallelism, 1, int.MaxValue, nameof(parallelism));
        return parallelism == 1
            ? new SequentialChannelProcessor<T>(
                Channel.CreateUnbounded<T>(new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                    SingleReader = true,
                }))
            : new ParallelChannelProcessor<T>(
                Channel.CreateUnbounded<T>(new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                }),
                parallelism);
    }

    private abstract class ChannelProcessor<TItem> : IProcessor<TItem>, IDisposable
    {
        /// <summary>
        /// Async channel reader task. Loops for lifetime of object.
        /// </summary>
        private Task _processorTask;

        /// <summary>
        /// Channel of items to process.
        /// </summary>
        protected readonly Channel<TItem, TItem> _channel;

        /// <summary>
        /// Cancellation token for disposal.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;
        protected CancellationToken _cancellationToken => _cancellationTokenSource.Token;

        private ProcessAsync<TItem> _process;
        public ProcessAsync<TItem> Process
        {
            get => _process;
            set
            {
                ProcessAsync<TItem> prev = Interlocked.Exchange(ref _process, value);
                if (prev == default)
                {
                    _processorTask = Task.Run(NotifyOfPendingItemProcessing);
                }
            }
        }

        protected ChannelProcessor(Channel<TItem, TItem> channel)
        {
            Argument.AssertNotNull(channel, nameof(channel));
            _channel = channel;
            _cancellationTokenSource = new();
        }

        public async ValueTask QueueAsync(TItem item, CancellationToken cancellationToken = default)
        {
            await _channel.Writer.WriteAsync(item, cancellationToken).ConfigureAwait(false);
        }

        protected abstract ValueTask NotifyOfPendingItemProcessing();

        public void Dispose()
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
            GC.SuppressFinalize(this);
        }
    }

    private class SequentialChannelProcessor<TItem> : ChannelProcessor<TItem>
    {
        public SequentialChannelProcessor(Channel<TItem, TItem> channel)
            : base(channel)
        { }

        protected override async ValueTask NotifyOfPendingItemProcessing()
        {
            // Process all available items in the queue.
            while (await _channel.Reader.WaitToReadAsync(_cancellationToken).ConfigureAwait(false))
            {
                TItem item = await _channel.Reader.ReadAsync(_cancellationToken).ConfigureAwait(false);
                await Process(item, _cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private class ParallelChannelProcessor<TItem> : ChannelProcessor<TItem>
    {
        private readonly int _maxConcurrentProcessing;

        public ParallelChannelProcessor(
            Channel<TItem, TItem> channel,
            int maxConcurrentProcessing)
            : base(channel)
        {
            Argument.AssertInRange(maxConcurrentProcessing, 2, int.MaxValue, nameof(maxConcurrentProcessing));
            _maxConcurrentProcessing = maxConcurrentProcessing;
        }

        protected override async ValueTask NotifyOfPendingItemProcessing()
        {
            List<Task> chunkRunners = new List<Task>(DataMovementConstants.MaxJobPartReaders);
            while (await _channel.Reader.WaitToReadAsync(_cancellationToken).ConfigureAwait(false))
            {
                TItem item = await _channel.Reader.ReadAsync(_cancellationToken).ConfigureAwait(false);
                if (chunkRunners.Count >= DataMovementConstants.MaxJobPartReaders)
                {
                    // Clear any completed blocks from the task list
                    int removedRunners = chunkRunners.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    // If no runners have finished..
                    if (removedRunners == 0)
                    {
                        // Wait for at least one runner to finish
                        await Task.WhenAny(chunkRunners).ConfigureAwait(false);
                        chunkRunners.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    }
                }
                chunkRunners.Add(Task.Run(async () => await Process(item, _cancellationToken).ConfigureAwait(false)));
            }
        }
    }
}
