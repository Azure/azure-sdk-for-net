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
            UriBuilder uriBuilder= new UriBuilder()
            {
                Scheme = Uri.UriSchemeFile,
                Host = "",
                Path = path,
            };
            _uri = uriBuilder.Uri;
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

        protected internal override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            return new LocalSourceCheckpointData();
        }

        protected internal override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            return new LocalDestinationCheckpointData();
        }

        protected internal override Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        protected internal override StorageResourceContainer GetChildStorageResourceContainer(string path)
        {
            UriBuilder uri = new UriBuilder(_uri);
            uri.Path = Path.Combine(uri.Path, path);
            return new LocalDirectoryStorageResourceContainer(uri.Uri);
        }
    }
}
