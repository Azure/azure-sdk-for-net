// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareDirectoryStorageResourceContainer : StorageResourceContainer
    {
        internal ShareFileStorageResourceOptions ResourceOptions { get; set; }
        internal PathScanner PathScanner { get; set; }

        internal ShareDirectoryClient ShareDirectoryClient { get; }

        public override Uri Uri => ShareDirectoryClient.Uri;

        internal ShareDirectoryStorageResourceContainer(ShareDirectoryClient shareDirectoryClient, ShareFileStorageResourceOptions options)
        {
            ShareDirectoryClient = shareDirectoryClient;
            ResourceOptions = options;
        }

        protected override StorageResourceItem GetStorageResourceReference(string path)
        {
            throw new NotImplementedException();
        }

        protected override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await foreach (ShareFileClient client in PathScanner.ScanFilesAsync(
                ShareDirectoryClient, cancellationToken).ConfigureAwait(false))
            {
                yield return new ShareFileStorageResourceItem(client, ResourceOptions);
            }
        }
    }
}
