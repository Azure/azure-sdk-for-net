// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement;

internal interface IProcessor<TItem> : IDisposable
{
    ValueTask QueueAsync(TItem item, CancellationToken cancellationToken = default);
}

internal static class ChannelProcessing
{
    public delegate Task ProcessAsync<T>(T item, CancellationToken cancellationToken);

    public static IProcessor<T> NewProcessor<T>(ProcessAsync<T> process, int parallelism)
    {
        Argument.AssertInRange(parallelism, 1, int.MaxValue, nameof(parallelism));
        return parallelism == 1
            ? new SequentialChannelProcessor<T, T>(
                Channel.CreateUnbounded<T>(new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                    SingleReader = true,
                }),
                process)
            : new ParallelChannelProcessor<T, T>(
                Channel.CreateUnbounded<T>(new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                }),
                process,
                parallelism);
    }

    private abstract class ChannelProcessor<TChannelWrite, TChannelRead> : IProcessor<TChannelWrite>, IDisposable
    {
        /// <summary>
        /// Async channel reader task. Loops for lifetime of object.
        /// </summary>
        private readonly Task _processorTask;

        /// <summary>
        /// Channel of Jobs waiting to divided into job parts/files.
        ///
        /// Limit 1 task to convert jobs to job parts.
        /// </summary>
        protected readonly Channel<TChannelWrite, TChannelRead> _channel;

        /// <summary>
        /// Cancels the channels operations when disposing.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;
        protected CancellationToken _cancellationToken => _cancellationTokenSource.Token;

        protected readonly ProcessAsync<TChannelRead> _process;

        protected ChannelProcessor(
            Channel<TChannelWrite, TChannelRead> channel,
            ProcessAsync<TChannelRead> processFromChannel)
        {
            Argument.AssertNotNull(channel, nameof(channel));
            Argument.AssertNotNull(processFromChannel, nameof(processFromChannel));
            _channel = channel;
            _process = processFromChannel;
            _cancellationTokenSource = new();
            _processorTask = Task.Run(NotifyOfPendingItemProcessing);
        }

        public async ValueTask QueueAsync(TChannelWrite item, CancellationToken cancellationToken = default)
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

    private class SequentialChannelProcessor<TChannelWrite, TChannelRead> : ChannelProcessor<TChannelWrite, TChannelRead>
    {
        public SequentialChannelProcessor(
            Channel<TChannelWrite, TChannelRead> channel,
            ProcessAsync<TChannelRead> processFromChannel)
            : base(channel, processFromChannel)
        { }

        protected override async ValueTask NotifyOfPendingItemProcessing()
        {
            // Process all available items in the queue.
            while (await _channel.Reader.WaitToReadAsync(_cancellationToken).ConfigureAwait(false))
            {
                TChannelRead item = await _channel.Reader.ReadAsync(_cancellationToken).ConfigureAwait(false);
                await _process(item, _cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private class ParallelChannelProcessor<TChannelWrite, TChannelRead> : ChannelProcessor<TChannelWrite, TChannelRead>
    {
        private readonly int _maxConcurrentProcessing;

        public ParallelChannelProcessor(
            Channel<TChannelWrite, TChannelRead> channel,
            ProcessAsync<TChannelRead> processFromChannel,
            int maxConcurrentProcessing)
            : base(channel, processFromChannel)
        {
            Argument.AssertInRange(maxConcurrentProcessing, 2, int.MaxValue, nameof(maxConcurrentProcessing));
            _maxConcurrentProcessing = maxConcurrentProcessing;
        }

        protected override async ValueTask NotifyOfPendingItemProcessing()
        {
            List<Task> chunkRunners = new List<Task>(DataMovementConstants.MaxJobPartReaders);
            while (await _channel.Reader.WaitToReadAsync(_cancellationToken).ConfigureAwait(false))
            {
                TChannelRead item = await _channel.Reader.ReadAsync(_cancellationToken).ConfigureAwait(false);
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
                chunkRunners.Add(Task.Run(async () => await _process(item, _cancellationToken).ConfigureAwait(false)));
            }
        }
    }
}
