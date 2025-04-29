// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Monitors the throughput of data transfer operations by tracking the total bytes transferred
    /// and calculating the throughput in bytes per second.
    /// </summary>
    public class ThroughputMonitor : IAsyncDisposable
    {
        private long _totalBytesTransferred;
        private long _bytesTransferredInCurrentInterval;
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _isStopwatchRunning = false;
        private readonly System.Timers.Timer _timer;
        private readonly int _timerInterval;

        private IProcessor<long> _bytesTransferredProcessor;

        /// <summary>
        /// Gets the total number of bytes transferred since the monitor started.
        /// </summary>
        internal long TotalBytesTransferred { get => _totalBytesTransferred; }

        /// <summary>
        /// Gets the current throughput in bytes per second.
        /// </summary>
        internal virtual decimal Throughput { get; set; }

        /// <summary>
        /// Gets the current throughput in megabits per second.
        /// </summary>
        internal virtual decimal ThroughputInMb { get => ((Throughput * 8) / 1024) / 1024; }

        /// <summary>
        /// Gets the average throughput in bytes per second since the monitor started.
        /// </summary>
        internal virtual decimal AvgThroughput
        {
            get
            {
                if (TimeElapsedInMilliseconds > 0)
                {
                    decimal timeInSeconds = (decimal)TimeElapsedInMilliseconds / 1000;
                    return (decimal)TotalBytesTransferred / timeInSeconds;
                }
                else
                {
                    return 0M;
                }
            }
        }

        /// <summary>
        /// Gets the average throughput in megabits per second since the monitor started.
        /// </summary>
        internal virtual decimal AvgThroughputInMb { get => ((AvgThroughput * 8) / 1024) / 1024; }

        /// <summary>
        /// Gets the total time elapsed in milliseconds since the monitor started.
        /// </summary>
        internal long TimeElapsedInMilliseconds { get => _stopwatch.ElapsedMilliseconds; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThroughputMonitor"/> class with a custom processor.
        /// </summary>
        /// <param name="bytesTransferredProcessor">The processor to handle bytes transferred.</param>
        private ThroughputMonitor(IProcessor<long> bytesTransferredProcessor)
        {
            _bytesTransferredProcessor = bytesTransferredProcessor;
            _bytesTransferredProcessor.Process = ProcessBytesTransferredAsync;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThroughputMonitor"/> class for testing.
        /// </summary>

        internal ThroughputMonitor() :
            this(ChannelProcessing.NewProcessor<long>(readers: 1))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThroughputMonitor"/> class.
        /// </summary>
        internal ThroughputMonitor(int timerInterval = 1000) :
            this(ChannelProcessing.NewProcessor<long>(readers: 1))
        {
            _timerInterval = timerInterval;
            _timer = new System.Timers.Timer(timerInterval);
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Elapsed += UpdateThroughput;
        }

        /// <summary>
        /// Processes the bytes transferred asynchronously.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred.</param>
        /// <param name="_">A cancellation token (not used).</param>
        private Task ProcessBytesTransferredAsync(long bytesTransferred, CancellationToken _)
        {
            _totalBytesTransferred += bytesTransferred;
            _bytesTransferredInCurrentInterval += bytesTransferred;

            if (_totalBytesTransferred == 0)
                return Task.CompletedTask;

            if (!_isStopwatchRunning)
            {
                _stopwatch.Start();
                _isStopwatchRunning = true;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Updates the throughput calculation.
        /// </summary>
        private void UpdateThroughput(object sender, ElapsedEventArgs e)
        {
            decimal timeInSeconds = (decimal)_timerInterval / 1000;
            Throughput = (decimal)(_bytesTransferredInCurrentInterval / timeInSeconds);
            _bytesTransferredInCurrentInterval = 0;
        }

        /// <summary>
        /// Queues the number of bytes transferred for processing.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred.</param>
        /// <param name="_">A cancellation token (not used).</param>
        public async ValueTask QueueBytesTransferredAsync(long bytesTransferred, CancellationToken _)
        {
            await _bytesTransferredProcessor.QueueAsync(bytesTransferred, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="ThroughputMonitor"/> class asynchronously.
        /// </summary>
        public ValueTask DisposeAsync()
        {
            _timer?.Dispose();
            return new ValueTask(Task.CompletedTask);
        }
    }
}
