// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The properties and Content returned from downloading a blob
    /// </summary>
    public class FileDownloadInfo
    {
        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content { get; internal set; }

        /// <summary>
        /// If the file has an MD5 hash and this operation is to read the full file,
        /// this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Properties returned when downloading a File
        /// </summary>
        public FileDownloadDetails Properties { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileDownloadInfo instances.
        /// You can use DataLakeModelFactory.FileDownloadInfo instead.
        /// </summary>
        internal FileDownloadInfo() { }
    }
}
