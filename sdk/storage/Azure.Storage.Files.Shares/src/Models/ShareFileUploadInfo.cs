// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileUploadInfo
    /// </summary>
    public partial class ShareFileUploadInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the directory was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// This header is returned so that the client can check for message content integrity. The value of this header is computed by the File service; it is not necessarily the same value as may have been specified in the request headers.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileUploadInfo instances.
        /// You can use ShareModelFactory.ShareFileUploadInfo instead.
        /// </summary>
        internal ShareFileUploadInfo() { }
    }
}
