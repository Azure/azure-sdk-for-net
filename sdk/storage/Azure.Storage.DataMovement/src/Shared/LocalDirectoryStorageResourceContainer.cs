// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the local directory to transfer to or from
    /// </summary>
    public class LocalDirectoryStorageResourceContainer : StorageResourceContainer
    {
        private List<string> _path;
        private string _originalPath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalDirectoryStorageResourceContainer(string path)
        {
            _originalPath = path;
            _path = path.Split('/').ToList();
        }

        /// <summary>
        /// Gets the path
        /// </summary>
        /// <returns></returns>
        public override List<string> GetPath()
        {
            return _path;
        }

        /// <summary>
        /// Returns the full path concatenated
        /// </summary>
        /// <returns></returns>
        public string GetFullPath()
        {
            return _originalPath;
        }

        /// <summary>
        /// Gets the storage Resource
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override StorageResource GetStorageResource(List<string> path)
        {
            List<string> listPaths = new List<string>(_path.Count + path.Count);
            listPaths.AddRange(_path);
            listPaths.AddRange(path);
            string concatPath = listPaths.ToLocalPathString();
            return new LocalFileStorageResource(concatPath);
        }

        /// <summary>
        /// Gets the storage container resources
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override StorageResourceContainer GetStorageResourceContainer(List<string> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cannot produce Uri
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri()
        {
            return ProduceUriType.NoUri;
        }

        /// <summary>
        /// Cannot produce uri, will throw exception.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Uri GetUri()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Lists storage resource in the filesystem.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<StorageResource> ListStorageResources(
            ListStorageResourceOptions options = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            PathScanner scanner = new PathScanner(_originalPath);
            foreach (FileSystemInfo fileSystemInfo in scanner.Scan(false))
            {
                yield return GetStorageResource(fileSystemInfo.Name.Split('/').ToList());
            }
        }
    }
}
