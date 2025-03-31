// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class ThroughputMonitor : IAsyncDisposable
    {
        private long _totalBytesTransferred;

        private IProcessor<long> _bytesTransferredProcessor;

        public long BytesTransferred {  get; set; }
        public long TotalBytesTransferred { get => _totalBytesTransferred; }

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
        /// <param name="item">The number of bytes transferred.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task ProcessBytesTransferredAsync(long item, CancellationToken cancellationToken)
        {
            await Task.Run(() => _totalBytesTransferred += item, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Enqueues the number of bytes transferred to be processed asynchronously.
        /// </summary>
        /// <param name="bytesTransferred">The number of bytes transferred.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async ValueTask QueueBytesTransferredAsync(long bytesTransferred, CancellationToken cancellationToken)
        {
            await _bytesTransferredProcessor.QueueAsync(bytesTransferred, cancellationToken).ConfigureAwait(false);
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
