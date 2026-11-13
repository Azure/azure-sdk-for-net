// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the local directory to transfer to or from
    /// </summary>
    internal class LocalDirectoryStorageResourceContainer : StorageResourceContainer
    {
        private Uri _uri;

        public override Uri Uri => _uri;

        public override string ProviderId => "local";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalDirectoryStorageResourceContainer(string path)
        {
            Argument.AssertNotNullOrWhiteSpace(path, nameof(path));
            path = path.TrimEnd(Path.DirectorySeparatorChar);
            _uri = PathScanner.GetEncodedUriFromPath(path);
        }

        /// <summary>
        /// Internal Constructor for uri
        /// </summary>
        /// <param name="uri"></param>
        internal LocalDirectoryStorageResourceContainer(Uri uri)
        {
            Argument.AssertNotNull(uri, nameof(uri));
            Argument.AssertNotNullOrWhiteSpace(uri.AbsoluteUri, nameof(uri));
            _uri = uri;
        }

        /// <summary>
        /// Gets the storage Resource
        /// </summary>
        /// <param name="childPath"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        protected internal override StorageResourceItem GetStorageResourceReference(string childPath, string resourceId)
        {
            Uri concatPath = _uri.AppendToPath(childPath);
            return new LocalFileStorageResource(concatPath);
        }

        /// <summary>
        /// Lists storage resource in the filesystem.
        /// </summary>
        /// <param name="destinationContainer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected internal override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            StorageResourceContainer destinationContainer = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            PathScanner scanner = new PathScanner(_uri.LocalPath);
            foreach (FileSystemInfo fileSystemInfo in scanner.Scan(false))
            {
                if (fileSystemInfo.Attributes.HasFlag(FileAttributes.Directory))
                {
                    // Directory - but check for the case where it returns the directory you're currently listing
                    if (fileSystemInfo.FullName != _uri.LocalPath)
                    {
                        yield return new LocalDirectoryStorageResourceContainer(fileSystemInfo.FullName);
                    }
                }
                else
                {
                    // File
                    yield return new LocalFileStorageResource(fileSystemInfo.FullName);
                }
            }
        }

        protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new LocalSourceCheckpointDetails();
        }

        protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new LocalDestinationCheckpointDetails();
        }

        protected internal override Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        protected internal override StorageResourceContainer GetChildStorageResourceContainer(string path)
        {
            Uri concatPath = _uri.AppendToPath(path);
            return new LocalDirectoryStorageResourceContainer(concatPath);
        }

        protected internal override Task<StorageResourceContainerProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            // Will implement this when implementing NFS Upload
            return Task.FromResult(new StorageResourceContainerProperties());
        }
    }
}
