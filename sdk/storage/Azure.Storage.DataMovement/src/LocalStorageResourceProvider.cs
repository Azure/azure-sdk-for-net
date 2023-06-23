// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for the local filesystem.
    /// </summary>
    public class LocalStorageResourceProvider
    {
        private readonly bool _isFolder;
        private readonly string _path;

        internal LocalStorageResourceProvider(bool isFolder, string path)
        {
            _isFolder = isFolder;
            _path = path;
        }

        /// <summary>
        /// Gets the resource this provider is configured for.
        /// </summary>
        /// <returns>
        /// The <see cref="StorageResource"/> this provider is configured for.
        /// </returns>
        public StorageResource MakeResource()
        {
            if (_isFolder)
            {
                return new LocalDirectoryStorageResourceContainer(_path);
            }
            else
            {
                return new LocalFileStorageResource(_path);
            }
        }
    }
}
