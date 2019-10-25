// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class BlobContainerItemExtensions
    {
        internal static FileSystemItem ToFileSystemItem(this BlobContainerItem containerItem) =>
            new FileSystemItem()
            {
                Name = containerItem.Name,
                Properties = new FileSystemProperties()
                {
                    LastModified = containerItem.Properties.LastModified,
                    LeaseStatus = containerItem.Properties.LeaseStatus.HasValue
                        ? (Models.LeaseStatus)containerItem.Properties.LeaseStatus : default,
                    LeaseState = containerItem.Properties.LeaseState.HasValue
                        ? (Models.LeaseState)containerItem.Properties.LeaseState : default,
                    LeaseDuration = containerItem.Properties.LeaseDuration.HasValue
                        ? (Models.LeaseDurationType)containerItem.Properties.LeaseDuration : default,
                    PublicAccess = containerItem.Properties.PublicAccess.HasValue
                        ? (Models.PublicAccessType)containerItem.Properties.PublicAccess : default,
                    HasImmutabilityPolicy = containerItem.Properties.HasImmutabilityPolicy,
                    HasLegalHold = containerItem.Properties.HasLegalHold,
                    ETag = containerItem.Properties.ETag
                },
                Metadata = containerItem.Metadata
            };
    }
}
