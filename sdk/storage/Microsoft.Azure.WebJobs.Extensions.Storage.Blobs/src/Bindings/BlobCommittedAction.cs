// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal class BlobCommittedAction : IBlobCommitedAction
    {
        private readonly BlobWithContainer<BlobBaseClient> _blob;
        private readonly IBlobWrittenWatcher _blobWrittenWatcher;

        public BlobCommittedAction(BlobWithContainer<BlobBaseClient> blob, IBlobWrittenWatcher blobWrittenWatcher)
        {
            _blob = blob;
            _blobWrittenWatcher = blobWrittenWatcher;
        }

        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (_blobWrittenWatcher != null)
            {
                _blobWrittenWatcher.Notify(_blob);
            }

            return Task.FromResult(0);
        }

        public void Execute()
        {
            if (_blobWrittenWatcher != null)
            {
                _blobWrittenWatcher.Notify(_blob);
            }
        }
    }
}
