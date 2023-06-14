// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
        public override StorageResource GetChildStorageResource(string childPath)
        {
            string concatPath = System.IO.Path.Combine(Path, childPath);
            return new LocalFileStorageResource(concatPath);
        }

        /// <summary>
        /// Gets the parent directory path by one level.
        /// </summary>
        /// <returns></returns>
        public override StorageResourceContainer GetParentStorageResourceContainer()
        {
            return new LocalDirectoryStorageResourceContainer(_path.Substring(0, _path.LastIndexOf('/')));
        }

        /// <summary>
        /// Lists storage resource in the filesystem.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<StorageResourceBase> GetStorageResourcesAsync(
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
        /// <param name="checkpointer">
        /// The checkpointer where the transfer state was saved to.
        /// </param>
        /// <param name="transferId">
        /// Transfer Id where we want to rehydrate the resource from the job from.
        /// </param>
        /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination.
        /// </param>
        /// <param name="cancellationToken">
        /// Whether or not to cancel the operation.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        public static async Task<LocalDirectoryStorageResourceContainer> RehydrateStorageResource(
            TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(checkpointer, nameof(checkpointer));

            LocalDirectoryStorageResourceContainer resource;

            int pathIndex = isSource ?
                DataMovementConstants.PlanFile.SourcePathIndex :
                DataMovementConstants.PlanFile.DestinationPathIndex;
            int pathLength = isSource ?
                (DataMovementConstants.PlanFile.SourcePathLengthIndex - DataMovementConstants.PlanFile.SourcePathIndex) :
                (DataMovementConstants.PlanFile.DestinationPathLengthIndex - DataMovementConstants.PlanFile.DestinationPathIndex);

            int partCount = await checkpointer.CurrentJobPartCountAsync(transferId).ConfigureAwait(false);
            string storedPath = default;
            for (int i = 0; i < partCount; i++)
            {
                using (Stream stream = await checkpointer.ReadableStreamAsync(
                    transferId: transferId,
                    partNumber: i,
                    offset: pathIndex,
                    readSize: pathLength,
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (string.IsNullOrEmpty(storedPath))
                    {
                        storedPath = stream.ToString();
                    }
                    else
                    {
                        string currentPath = stream.ToString();
                        int length = Math.Min(storedPath.Length, currentPath.Length);
                        int index = 0;

                        while (index < length && storedPath[index] == currentPath[index])
                        {
                            index++;
                        }

                        storedPath = storedPath.Substring(0, index);
                    }
                }
            }
            resource = new LocalDirectoryStorageResourceContainer(storedPath);
            return resource;
        }
    }
}
