﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// An Azure Data Lake file system
    /// </summary>
    public class FileSystemItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Properties of a file system.
        /// </summary>
        public FileSystemProperties Properties { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemItem instances.
        /// You can use DataLakeModelFactory.FileSystemItem instead.
        /// </summary>
        internal FileSystemItem() { }
    }
}
