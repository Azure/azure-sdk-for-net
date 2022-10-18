// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Produces local file sytem storage resources
    /// </summary>
    internal static class LocalStorageResourceFactory
    {
        /// <summary>
        /// Gets the file path resource
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static StorageResource GetFile(string path)
        {
            return new LocalFileStorageResource(path);
        }

        /// <summary>
        /// Get the directory path resource
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static StorageResourceContainer GetDirectory(string path)
        {
            return new LocalDirectoryStorageResourceContainer(path);
        }
    }
}
