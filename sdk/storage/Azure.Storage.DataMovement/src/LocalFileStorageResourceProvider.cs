// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for the local filesystem.
    /// </summary>
    public class LocalFileStorageResourceProvider : StorageResourceProvider
    {
        /// <inheritdoc/>
        protected internal override string TypeId => "LocalFile";

        /// <inheritdoc/>
        protected internal override StorageResource FromSource(DataTransferProperties props)
            => GetResource(props, isSource: true);

        /// <inheritdoc/>
        protected internal override StorageResource FromDestination(DataTransferProperties props)
            => GetResource(props, isSource: false);

        private StorageResource GetResource(DataTransferProperties props, bool isSource)
        {
            if (props.IsContainer)
            {
                return LocalDirectoryStorageResourceContainer.RehydrateResource(props, isSource);
            }
            return LocalFileStorageResource.RehydrateResource(props, isSource);
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
