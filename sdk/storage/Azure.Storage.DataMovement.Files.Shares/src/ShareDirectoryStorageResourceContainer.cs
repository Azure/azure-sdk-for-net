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
            if (ResourceOptions?.FilePermissions ?? false)
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

        protected override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new ShareFileSourceCheckpointDetails();
        }

        protected override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new ShareFileDestinationCheckpointDetails(
                isContentTypeSet: ResourceOptions?._isContentTypeSet ?? false,
                contentType: ResourceOptions?.ContentType,
                isContentEncodingSet: ResourceOptions?._isContentEncodingSet ?? false,
                contentEncoding: ResourceOptions?.ContentEncoding,
                isContentLanguageSet: ResourceOptions?._isContentLanguageSet ?? false,
                contentLanguage: ResourceOptions?.ContentLanguage,
                isContentDispositionSet: ResourceOptions?._isContentDispositionSet ?? false,
                contentDisposition: ResourceOptions?.ContentDisposition,
                isCacheControlSet: ResourceOptions?._isCacheControlSet ?? false,
                cacheControl: ResourceOptions?.CacheControl,
                isFileAttributesSet: ResourceOptions?._isFileAttributesSet ?? false,
                fileAttributes: ResourceOptions?.FileAttributes,
                filePermissions: ResourceOptions?.FilePermissions,
                isFileCreatedOnSet: ResourceOptions?._isFileChangedOnSet ?? false,
                fileCreatedOn: ResourceOptions?.FileCreatedOn,
                isFileLastWrittenOnSet: ResourceOptions?._isFileLastWrittenOnSet ?? false,
                fileLastWrittenOn: ResourceOptions?.FileLastWrittenOn,
                isFileChangedOnSet: ResourceOptions?._isFileChangedOnSet ?? false,
                fileChangedOn: ResourceOptions?.FileChangedOn,
                isFileMetadataSet: ResourceOptions?._isFileMetadataSet ?? false,
                fileMetadata: ResourceOptions?.FileMetadata,
                isDirectoryMetadataSet: ResourceOptions?._isDirectoryMetadataSet ?? false,
                directoryMetadata: ResourceOptions?.DirectoryMetadata)
            {
            };
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
