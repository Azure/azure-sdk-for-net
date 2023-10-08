// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for the local filesystem.
    /// </summary>
    public class LocalFilesStorageResourceProvider : StorageResourceProvider
    {
        /// <inheritdoc/>
        protected internal override string TypeId => "LocalFile";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocalFilesStorageResourceProvider()
        {
        }

        /// <inheritdoc/>
        protected internal override Task<StorageResource> FromSourceAsync(DataTransferProperties properties, CancellationToken cancellationToken)
            => Task.FromResult(FromTransferProperties(properties, getSource: true));

        /// <inheritdoc/>
        protected internal override Task<StorageResource> FromDestinationAsync(DataTransferProperties properties, CancellationToken cancellationToken)
            => Task.FromResult(FromTransferProperties(properties, getSource: false));

        private StorageResource FromTransferProperties(DataTransferProperties properties, bool getSource)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            string storedPath = getSource ? properties.SourcePath : properties.DestinationPath;
            return properties.IsContainer
                ? new LocalDirectoryStorageResourceContainer(storedPath)
                : new LocalFileStorageResource(storedPath);
        }

        /// <summary>
        /// Creates a storage resource to the file at the given path.
        /// </summary>
        /// <param name="filePath">
        /// Path to the file.
        /// </param>
        /// <returns>
        /// Storage resource to this file.
        /// </returns>
        public StorageResourceItem FromFile(string filePath)
        {
            return new LocalFileStorageResource(filePath);
        }

        /// <summary>
        /// Creates a storage resource to the directory at the given path.
        /// </summary>
        /// <param name="directoryPath">
        /// Path to the directory.
        /// </param>
        /// <returns>
        /// Storage resource to this directory.
        /// </returns>
        public StorageResourceContainer FromDirectory(string directoryPath)
        {
            return new LocalDirectoryStorageResourceContainer(directoryPath);
        }
    }
}
