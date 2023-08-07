// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
        protected internal override StorageResource FromSource(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected internal override StorageResource FromDestination(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a storage resource to the file or directory at the given path.
        /// </summary>
        /// <param name="path">
        /// Path to the file or directory.
        /// </param>
        /// <returns>
        /// Storage resource to this file or directory.
        /// </returns>
        public StorageResource FromPath(string path)
        {
            throw new NotImplementedException();
        }
    }
}
