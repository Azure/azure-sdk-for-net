﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Http;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// Properites for a directory.
    /// </summary>
    public class StorageDirectoryProperties
    {
        /// <summary>
        /// The internal RawStorageDirectoryProperties
        /// </summary>
        internal RawStorageDirectoryProperties _rawStorageDirectoryProperties;

        /// <summary>
        /// A set of name-value pairs that contain metadata for the directory.
        /// </summary>
        public IDictionary<string, string> Metadata => _rawStorageDirectoryProperties.Metadata;

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public ETag ETag => _rawStorageDirectoryProperties.ETag;

        /// <summary>
        /// Returns DateTimeOffest the directory was last modified. Operations on files within the directory 
        /// do not affect the last modified time of the directory.
        /// </summary>
        public DateTimeOffset LastModified => _rawStorageDirectoryProperties.LastModified;

        /// <summary>
        /// Set to true if the directory metadata is completely encrypted using the specified algorithm. 
        /// Otherwise, the value is set to false.
        /// </summary>
        public bool IsServerEncrypted => _rawStorageDirectoryProperties.IsServerEncrypted;

        /// <summary>
        /// The SMB properties for the directory.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        internal StorageDirectoryProperties(RawStorageDirectoryProperties rawStorageDirectoryProperties)
        {
            _rawStorageDirectoryProperties = rawStorageDirectoryProperties;
            SmbProperties = new FileSmbProperties(rawStorageDirectoryProperties);
        }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageDirectoryProperties instance for mocking.
        /// </summary>
        public static StorageDirectoryProperties StorageDirectoryProperties(RawStorageDirectoryProperties rawStorageDirectoryProperties)
            => new StorageDirectoryProperties(rawStorageDirectoryProperties);
    }
}
