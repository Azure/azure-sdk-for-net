// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Utilities for storage resources with Azure Blob Storage.
    /// </summary>
    public static class BlobStorageResources
    {
        internal enum ResourceType
        {
            Unknown = 0,
            BlockBlob = 1,
            PageBlob = 2,
            AppendBlob = 3,
            BlobContainer = 4,
        }

        /// <summary>
        /// Attempts to get Azure Blob Storage resource providers for the source and destination of a given transfer, if applicable.
        /// </summary>
        /// <param name="info">Information on a transfer.</param>
        /// <param name="sourceProvider">Provider of the source resource for a transfer, if found.</param>
        /// <param name="destinationProvider">Provider of the destination resource for a transfer, if found.</param>
        /// <returns>Whether either source or destination provider was found.</returns>
        public static bool TryGetResourceProviders(
            DataTransferProperties info,
            out BlobStorageResourceProvider sourceProvider,
            out BlobStorageResourceProvider destinationProvider)
        {
            bool result = false;
            (ResourceType sourceType, ResourceType destinationType) = GetTypes(info);

            if (sourceType != ResourceType.Unknown)
            {
                sourceProvider = new BlobStorageResourceProvider(info, asSource: true, sourceType);
                result = true;
            }
            else
            {
                sourceProvider = default;
            }

            if (destinationType != ResourceType.Unknown)
            {
                destinationProvider = new BlobStorageResourceProvider(info, asSource: false, destinationType);
                result = true;
            }
            else
            {
                destinationProvider = default;
            }

            return result;
        }

        private static (ResourceType SourceType, ResourceType DestinationType) GetTypes(DataTransferProperties info)
        {
            Argument.AssertNotNull(info, nameof(info));

            ResourceType GetType(string scheme)
            {
                return scheme switch
                {
                    // TODO figure out actual strings
                    "BlockBlob" => info.IsContainer ? ResourceType.BlobContainer : ResourceType.BlockBlob,
                    "PageBlob" => info.IsContainer ? ResourceType.BlobContainer : ResourceType.PageBlob,
                    "AppendBlob" => info.IsContainer ? ResourceType.BlobContainer : ResourceType.AppendBlob,
                    _ => ResourceType.Unknown
                };
            }

            return (GetType(info.SourceScheme), GetType(info.DestinationScheme));
        }
    }
}
