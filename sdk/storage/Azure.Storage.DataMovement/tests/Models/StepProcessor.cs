// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Processor that only processes items one by one from
    /// its queue only when invoked for each item.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class StepProcessor<T> : IProcessor<T>
    {
        private readonly ConcurrentQueue<T> _queue = new();

        public int ItemsInQueue => _queue.Count;

        /// <inheritdoc/>
        public ProcessAsync<T> Process { get; set; }

        /// <inheritdoc/>
        public ValueTask QueueAsync(T item, CancellationToken cancellationToken = default)
        {
            _queue.Enqueue(item);
            return new(Task.CompletedTask);
        }

        public bool TryComplete() => true;

        /// <summary>
        /// Attmpts to read an item from internal queue, then completes
        /// a call to <see cref="Process"/> on it.
        /// </summary>
        /// <returns>
        /// Whether or not an item was successfully read from the queue.
        /// </returns>
        public async ValueTask<bool> TryStepAsync(CancellationToken cancellationToken = default)
        {
            if (_queue.Count > 0)
            {
                _queue.TryDequeue(out T result);
                await Process?.Invoke(result);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async ValueTask<int> StepMany(int maxSteps, CancellationToken cancellationToken = default)
        {
            int steps = 0;
            while (steps < maxSteps && await TryStepAsync(cancellationToken))
            {
                steps++;
            }
            return steps;
        }

        public async ValueTask<int> StepAll(CancellationToken cancellationToken = default)
        {
            int steps = 0;
            while (await TryStepAsync(cancellationToken))
            {
                steps++;
            }
            return steps;
        }

        public Task<bool> TryCompleteAsync()
        {
            return Task.FromResult(true);
        }
    }
}
