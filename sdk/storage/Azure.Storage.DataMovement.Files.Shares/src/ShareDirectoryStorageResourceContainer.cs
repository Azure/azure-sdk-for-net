// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareDirectoryStorageResourceContainer : StorageResourceContainerInternal
    {
        internal ShareFileStorageResourceOptions ResourceOptions { get; set; }
        internal SharesPathScanner PathScanner { get; set; } = SharesPathScanner.Singleton.Value;

        internal ShareDirectoryClient ShareDirectoryClient { get; }

        public override Uri Uri => ShareDirectoryClient.Uri;

        public override string ProviderId => "share";

        internal ShareDirectoryStorageResourceContainer(ShareDirectoryClient shareDirectoryClient, ShareFileStorageResourceOptions options)
        {
            ShareDirectoryClient = shareDirectoryClient;
            ResourceOptions = options ?? new ShareFileStorageResourceOptions();
        }

        internal ShareDirectoryStorageResourceContainer(
            ShareDirectoryClient shareDirectoryClient,
            StorageResourceContainerProperties properties,
            ShareFileStorageResourceOptions options = default)
            : this(shareDirectoryClient, options)
        {
            ResourceProperties = properties;
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
            ShareFileTraits traits = new();

            // Copy transfer
            if (destinationContainer is ShareDirectoryStorageResourceContainer)
            {
                ShareDirectoryStorageResourceContainer destinationStorageResourceContainer
                    = destinationContainer as ShareDirectoryStorageResourceContainer;
                ShareFileStorageResourceOptions destinationOptions = destinationStorageResourceContainer.ResourceOptions;
                // both source and destination must be SMB
                if ((!ResourceOptions?.IsNfs ?? true) && (!destinationOptions?.IsNfs ?? true))
                {
                    traits = ShareFileTraits.Attributes;
                    if (destinationOptions?.FilePermissions ?? false)
                    {
                        traits |= ShareFileTraits.PermissionKey;
                    }
                }
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

        protected override async Task<StorageResourceContainerProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Response<ShareDirectoryProperties> response = await ShareDirectoryClient.GetPropertiesAsync(
                cancellationToken: cancellationToken).ConfigureAwait(false);
            if (ResourceProperties != default)
            {
                ResourceProperties.AddToStorageResourceContainerProperties(response.Value);
            }
            else
            {
                ResourceProperties = response.Value.ToStorageResourceContainerProperties();
            }
            ResourceProperties.Uri = Uri;
            return ResourceProperties;
        }

        protected override async Task CreateIfNotExistsAsync(
            StorageResourceContainerProperties sourceProperties,
            CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> metadata = ResourceOptions?.GetFileMetadata(sourceProperties?.RawProperties);
            string filePermission = ResourceOptions?.GetFilePermission(sourceProperties);
            FileSmbProperties smbProperties = ResourceOptions?.GetFileSmbProperties(sourceProperties);
            FilePosixProperties filePosixProperties = ResourceOptions?.GetFilePosixProperties(sourceProperties);

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                Metadata = metadata,
                SmbProperties = smbProperties,
                FilePermission = new() { Permission = filePermission },
                PosixProperties = filePosixProperties
            };

            await ShareDirectoryClient.CreateIfNotExistsAsync(
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override async Task ValidateTransferAsync(StorageResource sourceResource, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (sourceResource is ShareDirectoryStorageResourceContainer sourceShareDirectory)
            {
                // Make sure the transfer is supported (NFS -> NFS and SMB -> SMB)
                if ((ResourceOptions?.IsNfs ?? false) != (sourceShareDirectory.ResourceOptions?.IsNfs ?? false))
                {
                    throw Errors.ShareTransferNotSupported();
                }

                // validate the source protocol
                if (!sourceShareDirectory.ResourceOptions?.SkipProtocolValidation ?? true)
                {
                    try
                    {
                        ShareClient sourceParentShare = sourceShareDirectory.ShareDirectoryClient.GetParentShareClient();
                        ShareProperties sourceProperties = await sourceParentShare.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                        ShareProtocols setProtocolSource = (sourceShareDirectory.ResourceOptions?.IsNfs ?? false) ? ShareProtocols.Nfs : ShareProtocols.Smb;
                        ShareProtocols actualProtocolSource = sourceProperties.Protocols ?? ShareProtocols.Smb;
                        if (actualProtocolSource != setProtocolSource)
                        {
                            throw Errors.ProtocolSetMismatch("source", setProtocolSource, actualProtocolSource);
                        }
                    }
                    catch (RequestFailedException ex) when (ex.Status == 403)
                    {
                        throw Errors.NoShareLevelPermissions("source");
                    }
                }
            }

            // validate the destination protocol
            if (!ResourceOptions?.SkipProtocolValidation ?? true)
            {
                try
                {
                    ShareClient parentShare = ShareDirectoryClient.GetParentShareClient();
                    ShareProperties properties = await parentShare.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                    ShareProtocols setProtocol = (ResourceOptions?.IsNfs ?? false) ? ShareProtocols.Nfs : ShareProtocols.Smb;
                    ShareProtocols actualProtocol = properties.Protocols ?? ShareProtocols.Smb;
                    if (actualProtocol != setProtocol)
                    {
                        throw Errors.ProtocolSetMismatch("destination", setProtocol, actualProtocol);
                    }
                }
                catch (RequestFailedException ex) when (ex.Status == 403)
                {
                    throw Errors.NoShareLevelPermissions("destination");
                }
            }
        }
    }
}
