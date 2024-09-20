// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareDirectoryStorageResourceContainer : StorageResourceContainerInternal
    {
        internal ShareFileStorageResourceOptions ResourceOptions { get; set; }
        internal PathScanner PathScanner { get; set; } = PathScanner.Singleton.Value;

        internal ShareDirectoryClient ShareDirectoryClient { get; }

        public override Uri Uri => ShareDirectoryClient.Uri;

        public override string ProviderId => "share";

        internal ShareDirectoryStorageResourceContainer(ShareDirectoryClient shareDirectoryClient, ShareFileStorageResourceOptions options)
        {
            ShareDirectoryClient = shareDirectoryClient;
            ResourceOptions = options;
        }

        protected override StorageResourceItem GetStorageResourceReference(string path, string resourceId)
        {
            List<string> pathSegments = path.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();
            ShareDirectoryClient dir = ShareDirectoryClient;
            foreach (string pathSegment in pathSegments.Take(pathSegments.Count - 1))
            {
                dir = dir.GetSubdirectoryClient(pathSegment);
            }
            ShareFileClient file = dir.GetFileClient(pathSegments.Last());
            return new ShareFileStorageResource(file, ResourceOptions);
        }

        protected override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            StorageResourceContainer destinationContainer = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            // Set the ShareFileTraits to send when listing.
            ShareFileTraits traits = ShareFileTraits.Attributes;
            if (ResourceOptions?.FilePermissions?.Preserve ?? false)
            {
                traits |= ShareFileTraits.PermissionKey;
            }
            ShareClient parentDestinationShare = default;
            if (destinationContainer != default)
            {
                parentDestinationShare = (destinationContainer as ShareDirectoryStorageResourceContainer)?.ShareDirectoryClient.GetParentShareClient();
            }
            await foreach (StorageResource resource in PathScanner.ScanAsync(
                sourceDirectory: ShareDirectoryClient,
                destinationShare: parentDestinationShare,
                sourceOptions: ResourceOptions,
                traits: traits,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                yield return resource;
            }
        }

        protected override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            return new ShareFileSourceCheckpointData();
        }

        protected override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            return new ShareFileDestinationCheckpointData(
                contentType: ResourceOptions?.ContentType,
                contentEncoding: ResourceOptions?.ContentEncoding,
                contentLanguage: ResourceOptions?.ContentLanguage,
                contentDisposition: ResourceOptions?.ContentDisposition,
                cacheControl: ResourceOptions?.CacheControl,
                fileAttributes: ResourceOptions?.FileAttributes,
                preserveFilePermission: ResourceOptions?.FilePermissions?.Preserve,
                fileCreatedOn: ResourceOptions?.FileCreatedOn,
                fileLastWrittenOn: ResourceOptions?.FileLastWrittenOn,
                fileChangedOn: ResourceOptions?.FileChangedOn,
                fileMetadata: ResourceOptions?.FileMetadata,
                directoryMetadata: ResourceOptions?.DirectoryMetadata);
        }

        protected override async Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
        {
            await ShareDirectoryClient.CreateIfNotExistsAsync(
                metadata: default,
                smbProperties: default,
                filePermission: default,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override StorageResourceContainer GetChildStorageResourceContainer(string path)
            => new ShareDirectoryStorageResourceContainer(ShareDirectoryClient.GetSubdirectoryClient(path), ResourceOptions);
    }
}
