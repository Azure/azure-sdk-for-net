// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the local directory to transfer to or from
    /// </summary>
    public class LocalDirectoryStorageResourceContainer : StorageResourceContainer
    {
        private string _path;

        /// <summary>
        /// Gets the path
        /// </summary>
        public override string Path => _path;

        /// <summary>
        /// Cannot produce Uri
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.NoUri;

        /// <summary>
        /// Cannot get Uri. Will throw NotSupportedException();
        /// </summary>
        public override Uri Uri => throw new NotSupportedException();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalDirectoryStorageResourceContainer(string path)
        {
            Argument.AssertNotNullOrWhiteSpace(path, nameof(path));
            _path = path;
        }

        /// <summary>
        /// Gets the storage Resource
        /// </summary>
        /// <param name="childPath"></param>
        /// <returns></returns>
        public override StorageResourceSingle GetChildStorageResource(string childPath)
        {
            string concatPath = System.IO.Path.Combine(Path, childPath);
            return new LocalFileStorageResource(concatPath);
        }

        /// <summary>
        /// Lists storage resource in the filesystem.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            PathScanner scanner = new PathScanner(_path);
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
