// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareDirectoryStorageResourceContainer : StorageResourceContainer
    {
        internal ShareDirectoryClient ShareDirectoryClient { get; }

        public override Uri Uri => ShareDirectoryClient.Uri;

        protected override StorageResourceItem GetStorageResourceReference(string path)
        {
            throw new NotImplementedException();
        }

        protected override IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
