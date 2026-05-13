// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class SharesPathScanner
    {
        public static Lazy<SharesPathScanner> Singleton { get; } = new Lazy<SharesPathScanner>(() => new SharesPathScanner());

        public virtual async IAsyncEnumerable<StorageResource> ScanAsync(
            ShareDirectoryClient sourceDirectory,
            ShareClient destinationShare,
            ShareFileStorageResourceOptions sourceOptions,
            ShareFileTraits traits,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(sourceDirectory, nameof(sourceDirectory));

            Queue<ShareDirectoryClient> toScan = new();
            toScan.Enqueue(sourceDirectory);

            // Keep track of created Permission Keys to avoid creating duplicates.
            ShareClient sourceShare = sourceDirectory.GetParentShareClient();
            // Permissions keys <sourcePermissionKey, destinationPermissionKey>
            Dictionary<string, string> permissionKeys = new();

            while (toScan.Count > 0)
            {
                ShareDirectoryClient current = toScan.Dequeue();
                await foreach (ShareFileItem item in current.GetFilesAndDirectoriesAsync(
                    options: new() { Traits = traits },
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    string destinationPermissionKey = default;
                    if (destinationShare != default && item.PermissionKey != default)
                    {
                        // Check if the permission key is already created.
                        // If not, create it on the Share.
                        if (!permissionKeys.TryGetValue(item.PermissionKey, out string existingDestinationKey))
                        {
                            // Get the SDDL permission from the source Share (using the permission key). Then create it on the destination Share.
                            string sourcePermission = await sourceShare.GetPermissionAsync(item.PermissionKey, cancellationToken: cancellationToken).ConfigureAwait(false);
                            PermissionInfo permissionInfo = await destinationShare.CreatePermissionAsync(sourcePermission, cancellationToken: cancellationToken).ConfigureAwait(false);
                            destinationPermissionKey = permissionInfo.FilePermissionKey;
                            permissionKeys.Add(item.PermissionKey, destinationPermissionKey);
                        }
                        else
                        {
                            destinationPermissionKey = existingDestinationKey;
                        }
                    }
                    if (item.IsDirectory)
                    {
                        ShareDirectoryClient subdir = current.GetSubdirectoryClient(item.Name);
                        toScan.Enqueue(subdir);
                        yield return new ShareDirectoryStorageResourceContainer(
                            subdir,
                            item.ToResourceContainerProperties(destinationPermissionKey),
                            sourceOptions);
                    }
                    else
                    {
                        ShareFileClient fileClient = current.GetFileClient(item.Name);
                        yield return new ShareFileStorageResource(
                            fileClient,
                            item.ToResourceProperties(destinationPermissionKey),
                            sourceOptions);
                    }
                }
            }
        }
    }
}
