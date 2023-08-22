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
        private string _path;

        /// <summary>
        /// Gets the path
        /// </summary>
        public override string Path => _path;

        /// <summary>
        /// Defines whether the storage resource type can produce a web URL.
        /// </summary>
        protected internal override bool CanProduceUri => false;

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
        protected internal override StorageResourceItem GetStorageResourceReference(string childPath)
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
        protected internal override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
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
    }
}
