// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <exception cref="NotImplementedException"></exception>
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
        /// <exception cref="NotImplementedException"></exception>
        public override StorageResource GetStorageResource(List<string> path)
        {
            throw new NotImplementedException();
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
    }
}
