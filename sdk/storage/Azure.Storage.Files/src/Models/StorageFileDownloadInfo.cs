// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// The properties and content returned from downloading a file
    /// </summary>
    public partial class StorageFileDownloadInfo
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedStorageFileProperties _flattened;

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength => _flattened.ContentLength;

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content => _flattened.Content;

        /// <summary>
        /// If the file has an MD5 hash and this operation is to read the full content, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash => _flattened.ContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Properties returned when downloading a file
        /// </summary>
        public StorageFileDownloadProperties Properties { get; private set; }

        /// <summary>
        /// Creates a new StorageFileDownloadInfo backed by FlattenedStorageFileProperties
        /// </summary>
        /// <param name="flattened">The FlattenedStorageFileProperties returned with the request</param>
        internal StorageFileDownloadInfo(FlattenedStorageFileProperties flattened)
        {
            _flattened = flattened;
            Properties = new StorageFileDownloadProperties(flattened);
        }
    }
}
