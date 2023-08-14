// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the local directory to transfer to or from
    /// </summary>
    public class LocalDirectoryStorageResourceContainer : StorageResourceContainer
    {
        private Uri _uri;

        /// <summary>
        /// Gets the path
        /// </summary>
        public override Uri Uri => _uri;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalDirectoryStorageResourceContainer(string path)
        {
            Argument.AssertNotNullOrWhiteSpace(path, nameof(path));
            UriBuilder uriBuilder= new UriBuilder()
            {
                Scheme = Uri.UriSchemeFile,
                Host = "",
                Path = path,
            };
            _uri = uriBuilder.Uri;
        }

        /// <summary>
        /// Gets the storage Resource
        /// </summary>
        /// <param name="childPath"></param>
        /// <returns></returns>
        protected internal override StorageResourceItem GetStorageResourceReference(string childPath)
        {
            Uri concatPath = _uri.AppendToPath(childPath);
            return new LocalFileStorageResource(concatPath);
        }

        /// <summary>
        /// Lists storage resource in the filesystem.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected internal override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            PathScanner scanner = new PathScanner(_uri.LocalPath);
            foreach (FileSystemInfo fileSystemInfo in scanner.Scan(false))
            {
                // Skip over directories for now since directory creation is unnecessary.
                if (!fileSystemInfo.Attributes.HasFlag(FileAttributes.Directory))
                {
                    yield return new LocalFileStorageResource(fileSystemInfo.FullName);
                }
            }
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="transferProperties">
        /// The properties of the transfer to rehydrate.
        /// </param>
        /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination. True if the source, false if the destination.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        internal static LocalDirectoryStorageResourceContainer RehydrateResource(
            DataTransferProperties transferProperties,
            bool isSource)
        {
            Argument.AssertNotNull(transferProperties, nameof(transferProperties));

            string storedPath = isSource ? transferProperties.SourcePath : transferProperties.DestinationPath;

            return new LocalDirectoryStorageResourceContainer(storedPath);
        }
    }
}
