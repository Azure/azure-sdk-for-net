// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
    internal class BlobCommittedAction : IBlobCommitedAction
    {
        private readonly ICloudBlob _blob;
        private readonly IBlobWrittenWatcher _blobWrittenWatcher;

        public BlobCommittedAction(ICloudBlob blob, IBlobWrittenWatcher blobWrittenWatcher)
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
    }
}
