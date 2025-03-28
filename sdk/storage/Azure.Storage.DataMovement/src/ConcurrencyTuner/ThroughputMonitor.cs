// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class ThroughputMonitor : IAsyncDisposable
    {
        private int _totalBytesTransferred;

        private IProcessor<int> _bytesTransferredProcessor;

        public int BytesTransferred {  get; set; }
        public int TotalBytesTransferred { get => _totalBytesTransferred; }

        public ThroughputMonitor(ThroughputMonitorOptions options = default) : this
            (
                ChannelProcessing.NewProcessor<int>(readers: 1)
            ){ }

        internal ThroughputMonitor(IProcessor<int> bytesTransferredProcessor)
        {
            _bytesTransferredProcessor = bytesTransferredProcessor;
            _bytesTransferredProcessor.Process = ProcessBytesTransferredAsync;
        }

        private async Task ProcessBytesTransferredAsync(int item, CancellationToken cancellationToken)
        {
            await Task.Run(() => _totalBytesTransferred += item, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask Add(int bytesTransferred, CancellationToken cancellationToken)
        {
            await _bytesTransferredProcessor.QueueAsync(bytesTransferred, cancellationToken).ConfigureAwait(false);
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
