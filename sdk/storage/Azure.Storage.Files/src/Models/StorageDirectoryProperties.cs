// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public IDictionary<string, string> Metadata => this._rawStorageDirectoryProperties.Metadata;

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public ETag ETag => this._rawStorageDirectoryProperties.ETag;

        /// <summary>
        /// Returns DateTimeOffest the directory was last modified. Operations on files within the directory 
        /// do not affect the last modified time of the directory.
        /// </summary>
        public DateTimeOffset LastModified => this._rawStorageDirectoryProperties.LastModified;

        /// <summary>
        /// Set to true if the directory metadata is completely encrypted using the specified algorithm. 
        /// Otherwise, the value is set to false.
        /// </summary>
        public bool IsServerEncrypted => this._rawStorageDirectoryProperties.IsServerEncrypted;

        /// <summary>
        /// The SMB properties for the directory.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        internal StorageDirectoryProperties(RawStorageDirectoryProperties rawStorageDirectoryProperties)
        {
            this._rawStorageDirectoryProperties = rawStorageDirectoryProperties;
            this.SmbProperties = new FileSmbProperties(rawStorageDirectoryProperties);
        }
    }
}
