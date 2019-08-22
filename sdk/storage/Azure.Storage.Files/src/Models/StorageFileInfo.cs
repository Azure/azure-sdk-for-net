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
    /// Subset of the file's properties.
    /// </summary>
    public class StorageFileInfo
    {
        /// <summary>
        /// The internal RawStorageFileInfo.
        /// </summary>
        internal RawStorageFileInfo _rawStorageFileInfo;

        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public ETag ETag => this._rawStorageFileInfo.ETag;

        /// <summary>
        /// Returns the date and time the file was last modified.
        /// </summary>
        public DateTimeOffset LastModified => this._rawStorageFileInfo.LastModified;

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted => this._rawStorageFileInfo.IsServerEncrypted;

        /// <summary>
        /// The file's SMB properties.
        /// </summary>
        public FileSmbProperties? SmbProperties { get; set; }

        internal StorageFileInfo(RawStorageFileInfo rawStorageFileInfo)
        {
            this._rawStorageFileInfo = rawStorageFileInfo;
            this.SmbProperties = new FileSmbProperties(rawStorageFileInfo);
        }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileInfo instance for mocking.
        /// </summary>
        public static StorageFileInfo StorageFileInfo(RawStorageFileInfo rawStorageFileInfo)
            => new StorageFileInfo(rawStorageFileInfo);
    }
}
