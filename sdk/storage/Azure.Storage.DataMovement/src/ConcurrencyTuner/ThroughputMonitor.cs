// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Monitors the throughput of data transfer operations.
    /// </summary>
    public class ThroughputMonitor : IAsyncDisposable
    {
        private long _totalBytesTransferred;
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _isStopwatchRunning = false;

        private IProcessor<long> _bytesTransferredProcessor;
        /// <summary>
        /// Returns Bytes transferred to the operation
        /// </summary>
        public long TotalBytesTransferred { get => _totalBytesTransferred; }

        /// <summary>
        /// This is a measure of Bytes per second
        /// </summary>
        public virtual decimal Throughput
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

        public long TimeElapsedInMilliseconds
        {
            get => _stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThroughputMonitor"/> class.
        /// </summary>
        public ThroughputMonitor() : this
            (
                ChannelProcessing.NewProcessor<long>(readers: 1)
            )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThroughputMonitor"/> class with a specified processor.
        /// </summary>
        /// <param name="bytesTransferredProcessor">The processor to use for processing bytes transferred.</param>
        internal ThroughputMonitor(IProcessor<long> bytesTransferredProcessor)
        {
            _bytesTransferredProcessor = bytesTransferredProcessor;
            _bytesTransferredProcessor.Process = ProcessBytesTransferredAsync;
        }

        /// <summary>
        /// Processes the bytes transferred asynchronously.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred.</param>
        /// <param name="_">A token to monitor for cancellation requests. This is here to implement the interface, but does not do anything</param>
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
        /// <param name="_">A token to monitor for cancellation requests. This is implemented to just comply with the interface</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async ValueTask QueueBytesTransferredAsync(long bytesTransferred, CancellationToken _)
        {
            await _bytesTransferredProcessor.QueueAsync(bytesTransferred, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="ThroughputMonitor"/> class asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous dispose operation.</returns>
        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
