// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for the local filesystem.
    /// </summary>
    public class LocalStorageResourceProvider
    {
        private readonly DataTransferProperties _properties;
        private readonly bool _asSource;
        private readonly bool _isFolder;

        internal LocalStorageResourceProvider(
            DataTransferProperties properties,
            bool asSource,
            bool isFolder)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            _properties = properties;
            _asSource = asSource;
            _isFolder = isFolder;
        }

        /// <summary>
        /// Creates the configured <see cref="StorageResource"/> instance.
        /// </summary>
        /// <returns>
        /// The <see cref="StorageResource"/> this provider is configured for.
        /// </returns>
        public StorageResource MakeResource()
        {
            if (_isFolder)
            {
                return LocalDirectoryStorageResourceContainer.RehydrateResource(_properties, _asSource);
            }
            else
            {
                return LocalFileStorageResource.RehydrateResource(_properties, _asSource);
            }
        }
    }
}
