// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Monitors the throughput of data transfer operations by tracking the total bytes transferred
    /// and calculating the throughput in bytes per second.
    /// </summary>
    internal class ThroughputMonitor : IDisposable
    {
        private long _totalBytesTransferred;
        private DateTimeOffset _startTime;
        private DateTimeOffset _previousTransferTime;
        private long _transferCount;

        private readonly IProcessor<long> _bytesTransferredProcessor;

        /// <summary>
        /// Gets the total number of bytes transferred since the monitor started.
        /// </summary>
        internal long TotalBytesTransferred => _totalBytesTransferred;

        /// <summary>
        /// Gets the current throughput in bytes per second, calculated for the last transfer event.
        /// </summary>
        internal virtual double Throughput { get; private set; }

        /// <summary>
        /// Gets the current throughput in megabits per second.
        /// </summary>
        internal virtual double ThroughputInMb => ((Throughput * 8) / 1024) / 1024;

        /// <summary>
        /// Gets the average throughput in bytes per second since the monitor started.
        /// </summary>
        internal virtual double AvgThroughput
        {
            get
            {
                if (_transferCount == 0)
                {
                    return 0.0;
                }

                DateTimeOffset currentTime = DateTimeOffset.UtcNow;
                TimeSpan elapsedTime = currentTime - _startTime;

                if (elapsedTime.TotalSeconds > 0)
                {
                    return (double)_totalBytesTransferred / elapsedTime.TotalSeconds;
                }
                else if (_totalBytesTransferred > 0 && elapsedTime.Ticks == 0)
                {
                    return double.MaxValue; // infinite throughput
                }
                else
                {
                    return 0.0;
                }
            }
        }

        /// <summary>
        /// Gets the average throughput in megabits per second since the monitor started.
        /// </summary>
        internal virtual double AvgThroughputInMb => ((AvgThroughput * 8) / 1024) / 1024;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThroughputMonitor"/> class with a custom processor.
        /// </summary>
        /// <param name="bytesTransferredProcessor">The processor to handle bytes transferred.</param>
        private ThroughputMonitor(IProcessor<long> bytesTransferredProcessor)
        {
            _bytesTransferredProcessor = bytesTransferredProcessor;
            _bytesTransferredProcessor.Process = ProcessBytesTransferredAsync;
            _startTime = default;
            _previousTransferTime = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThroughputMonitor"/> class.
        /// This constructor is typically used for production.
        /// </summary>
        internal ThroughputMonitor() :
            this(ChannelProcessing.NewProcessor<long>(readers: 1))
        { }

        /// <summary>
        /// Processes the bytes transferred asynchronously and calculates throughput.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred in this event.</param>
        /// <param name="_">A cancellation token (not used).</param>
        private Task ProcessBytesTransferredAsync(long bytesTransferred, CancellationToken _)
        {
            _totalBytesTransferred += bytesTransferred;
            DateTimeOffset currentTime = DateTimeOffset.UtcNow;

            if (_transferCount == 0)
            {
                _startTime = currentTime;
                Throughput = 0.0;
            }
            else
            {
                TimeSpan interval = currentTime - _previousTransferTime;

                if (interval.Ticks > 0)
                {
                    Throughput = (double)bytesTransferred / interval.TotalSeconds;
                }
                else
                {
                    if (bytesTransferred > 0)
                    {
                        Throughput = double.MaxValue; //infinite throughput
                    }
                    else // bytesTransferred == 0
                    {
                        Throughput = 0.0;
                    }
                }
            }

            _previousTransferTime = currentTime;
            _transferCount++;

            return Task.CompletedTask;
        }

        /// <summary>
        /// Queues the number of bytes transferred for processing.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public async ValueTask QueueBytesTransferredAsync(long bytesTransferred, CancellationToken cancellationToken = default)
        {
            await _bytesTransferredProcessor.QueueAsync(bytesTransferred, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="ThroughputMonitor"/> class asynchronously.
        /// </summary>
        public void Dispose()
        { }
    }
}
