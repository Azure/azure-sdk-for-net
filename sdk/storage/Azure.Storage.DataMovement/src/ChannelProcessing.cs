// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement;

internal delegate Task ProcessAsync<T>(T item);

internal interface IProcessor<TItem>
{
    ValueTask QueueAsync(TItem item, CancellationToken cancellationToken);
    Task<bool> TryCompleteAsync();
    ProcessAsync<TItem> Process { get; set; }
}

internal static class ChannelProcessing
{
    public static IProcessor<T> NewProcessor<T>(int readers, int? capacity = null)
    {
        Argument.AssertInRange(readers, 1, int.MaxValue, nameof(readers));
        if (capacity.HasValue)
        {
            Argument.AssertInRange(capacity.Value, 1, int.MaxValue, nameof(capacity));
        }

        Channel<T> channel = capacity.HasValue
            ? Channel.CreateBounded<T>(new BoundedChannelOptions(capacity.Value)
            {
                AllowSynchronousContinuations = true,
                SingleReader = readers == 1,
                FullMode = BoundedChannelFullMode.Wait,
            })
            : Channel.CreateUnbounded<T>(new UnboundedChannelOptions()
            {
                AllowSynchronousContinuations = true,
                SingleReader = readers == 1,
            });
        return readers == 1
            ? new SequentialChannelProcessor<T>(channel)
            : new ParallelChannelProcessor<T>(channel, readers);
    }

    private abstract class ChannelProcessor<TItem> : IProcessor<TItem>
    {
        /// <summary>
        /// Async channel reader task. Loops for lifetime of object.
        /// </summary>
        private Task _processorTask;
        internal TaskCompletionSource<bool> _processorTaskCompletionSource;

        /// <summary>
        /// Channel of items to process.
        /// </summary>
        protected readonly Channel<TItem, TItem> _channel;

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
            _processorTaskCompletionSource = new TaskCompletionSource<bool>(
                false,
                TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public async ValueTask QueueAsync(TItem item, CancellationToken cancellationToken = default)
        {
            await _channel.Writer.WriteAsync(item, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> TryCompleteAsync()
        {
            bool completionValue = _channel.Writer.TryComplete();
            await _processorTaskCompletionSource.Task.ConfigureAwait(false);
            return completionValue;
        }

        protected abstract ValueTask NotifyOfPendingItemProcessing();
    }

    private class SequentialChannelProcessor<TItem> : ChannelProcessor<TItem>
    {
        public SequentialChannelProcessor(Channel<TItem, TItem> channel)
            : base(channel)
        { }

        protected override async ValueTask NotifyOfPendingItemProcessing()
        {
            try
            {
                // Process all available items in the queue.
                while (await _channel.Reader.WaitToReadAsync().ConfigureAwait(false))
                {
                    TItem item = await _channel.Reader.ReadAsync().ConfigureAwait(false);
                    await Process(item).ConfigureAwait(false);
                }
            }
            finally
            {
                // Since the channel has it's own dedicated CancellationTokenSource (only called at Dispose)
                // we don't need a catch block to catch the exception since we know the cancellation either comes
                // from successful completion or another failure that has been already invoked.
                _processorTaskCompletionSource.TrySetResult(true);
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
            List<Task> chunkRunners = new List<Task>(_maxConcurrentProcessing);
            try
            {
                while (await _channel.Reader.WaitToReadAsync().ConfigureAwait(false))
                {
                    TItem item = await _channel.Reader.ReadAsync().ConfigureAwait(false);
                    if (chunkRunners.Count >= _maxConcurrentProcessing)
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
                    chunkRunners.Add(Task.Run(async () => await Process(item).ConfigureAwait(false)));
                }
            }
            finally
            {
                // Since the channel has it's own dedicated CancellationTokenSource (only called at Dispose)
                // we don't need a catch block to catch the exception since we know the cancellation either comes
                // from successful completion or another failure that has been already invoked.
                _processorTaskCompletionSource.TrySetResult(true);
            }
        }
    }
}
