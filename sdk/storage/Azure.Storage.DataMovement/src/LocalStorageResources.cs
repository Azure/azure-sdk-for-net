// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Utilities for storage resources with local filesystems.
    /// </summary>
    public static class LocalStorageResources
    {
        /// <summary>
        /// Gets a resource provider to rehydrate a local filesystem source resource based on the given transfer info.
        /// </summary>
        /// <param name="info">Information on a transfer.</param>
        /// <param name="sourceProvider">Provider of the source resource for a transfer, if found.</param>
        /// <param name="destinationProvider">Provider of the destination resource for a transfer, if found.</param>
        /// <returns>Whether either source or destination provider was found.</returns>
        public static bool TryGetResourceProviders(
            DataTransferProperties info,
            out LocalStorageResourceProvider sourceProvider,
            out LocalStorageResourceProvider destinationProvider)
        {
            bool result = false;
            (bool sourceIsFilesystem, bool destinationIsFilesystem) = IsFilesystemResource(info);

            if (sourceIsFilesystem)
            {
                sourceProvider = new LocalStorageResourceProvider(info, asSource: true, info.IsContainer);
                result = true;
            }
            else
            {
                sourceProvider = default;
            }

            if (destinationIsFilesystem)
            {
                destinationProvider = new LocalStorageResourceProvider(info, asSource: false, info.IsContainer);
                result = true;
            }
            else
            {
                destinationProvider = default;
            }

            return result;
        }

        internal static (bool Source, bool Destination) IsFilesystemResource(DataTransferProperties info)
        {
            Argument.AssertNotNull(info, nameof(info));

            const string expected = "LocalFile";
            return (info.SourceScheme == expected, info.DestinationScheme == expected);
        }
    }
}
