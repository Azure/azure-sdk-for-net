// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class ThroughputMonitor : IAsyncDisposable
    {
        private long _totalBytesTransferred;
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _isStopwatchRunning = false;

        private IProcessor<long> _bytesTransferredProcessor;
        public long TotalBytesTransferred { get => _totalBytesTransferred; }

        /// <summary>
        /// This is a measure of Bytes per second
        /// </summary>
        public decimal Throughput
        {
            get
            {
                if (_totalBytesTransferred == 0 || _stopwatch.Elapsed.TotalMilliseconds == 0)
                {
                    return 0.0M;
                }
                else
                {
                    return (decimal)(_totalBytesTransferred / (_stopwatch.Elapsed.TotalMilliseconds / 1000));
                }
            }
        }

        public long TimeElapsedInMilliseconds {
            get => _stopwatch.ElapsedMilliseconds;
        }

        public ThroughputMonitor() : this
            (
                ChannelProcessing.NewProcessor<long>(readers: 1)
            ){ }

        internal ThroughputMonitor(IProcessor<long> bytesTransferredProcessor)
        {
            _bytesTransferredProcessor = bytesTransferredProcessor;
            _bytesTransferredProcessor.Process = ProcessBytesTransferredAsync;
        }

        /// <summary>
        /// Processes the bytes transferred asynchronously.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred.</param>
        /// <param name="_">A token to monitor for cancellation requests. This is here to implment the interface, but does not do anything</param>
        private Task ProcessBytesTransferredAsync(long bytesTransferred, CancellationToken _)
        {
            if (!_isStopwatchRunning)
            {
                _stopwatch.Start();
            }

            _totalBytesTransferred += bytesTransferred;

            return Task.CompletedTask;
        }

        /// <summary>
        /// Enqueues the number of bytes transferred to be processed asynchronously.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred.</param>
        /// <param name="_">A token to monitor for cancellation requests. This is implmented to just comply with the interface</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async ValueTask QueueBytesTransferredAsync(long bytesTransferred, CancellationToken _)
        {
            await _bytesTransferredProcessor.QueueAsync(bytesTransferred, CancellationToken.None).ConfigureAwait(false);
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
