// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// PathProperties
    /// </summary>
    public class PathProperties
    {
        /// <summary>
        /// Returns the date and time the path  was last modified. Any operation that modifies the path,
        /// including an update of the path's metadata or properties, changes the last-modified time of the path.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Returns the date and time the path was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; internal set; }

        /// <summary>
        /// The Path's metdata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this path was the destination path.
        /// This value can specify the time of a completed, aborted, or failed copy attempt. This header does not appear
        /// if a copy is pending, if this path has never been the destination in a Copy path operation, or if this path
        /// has been modified after a concluded Copy Blob operation using Set path Properties, Put path, or Put Block List.
        /// </summary>
        public DateTimeOffset CopyCompletedOn { get; internal set; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or non-fatal copy
        /// operation failure. This header does not appear if this path has never been the destination in a Copy Blob operation,
        /// or if this path has been modified after a concluded Copy Blob operation using Set Path Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get Path Properties to check the status of this copy operation,
        /// or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation where this
        /// path was the destination pth. Can show between 0 and Content-Length bytes copied. This header does not appear if this
        /// path has never been the destination in a Copy Blob operation, or if this path has been modified after a concluded Copy
        /// Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source path or file used in the last attempted Copy Blob operation where
        /// this path was the destination path. This header does not appear if this path has never been the destination in a Copy
        /// Blob operation, or if this path has been modified after a concluded Copy Blob operation using Set Path Properties, Put
        /// Blob, or Put Block List.
        /// </summary>
        public Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// Included if the path is incremental copy blob.
        /// </summary>
        public bool IsIncrementalCopy { get; internal set; }

        /// <summary>
        /// When a path is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public DataLakeLeaseDuration LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the path.
        /// </summary>
        public DataLakeLeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the path.
        /// </summary>
        public DataLakeLeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the path. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer,
        /// the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// If the path has an MD5 hash and this operation is to read the full path, this response header is returned so that the client can
        /// check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header.
        /// The Content-Disposition response header field conveys additional information about how to process the response payload,
        /// and also can be used to attach additional metadata. For example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog with a filename other than the path name specified.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// This header is returned if it was previously specified for the path.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial path content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the path data and application metadata are completely encrypted using the
        /// specified algorithm. Otherwise, the value is set to false (when the path is unencrypted, or if only parts of the path/application
        /// metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the metadata. This header is only returned when the metadata
        /// was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// The tier of block blob on blob storage LRS accounts. For blob storage LRS accounts, valid values are Hot/Cool/Archive.
        /// </summary>
        public string AccessTier { get; internal set; }

        /// <summary>
        /// For blob storage LRS accounts, valid values are rehydrate-pending-to-hot/rehydrate-pending-to-cool.
        /// If the blob is being rehydrated and is not complete then this header is returned indicating that rehydrate is pending
        /// and also tells the destination tier.
        /// </summary>
        public string ArchiveStatus { get; internal set; }

        /// <summary>
        /// The time the tier was changed on the object. This is only returned if the tier on the block blob was ever set.
        /// </summary>
        public DateTimeOffset AccessTierChangedOn { get; internal set; }

        /// <summary>
        /// The time the path will be deleted.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; internal set; }

        /// <summary>
        /// Returns the name of the encryption scope used to encrypt the path contents and application metadata.
        /// Note that the absence of this header implies use of the default account encryption scope, or default
        /// file system encryption scope, if it has been set.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// If this path represents a directory.
        /// </summary>
        public bool IsDirectory
        {
            get => Metadata.TryGetValue(Constants.DataLake.IsDirectoryKey, out string isDirectoryValue)
                && bool.TryParse(isDirectoryValue, out bool isDirectory)
                && isDirectory;

            internal set
            {
                // True
                if (value)
                {
                    Metadata[Constants.DataLake.IsDirectoryKey] = bool.TrueString.ToLowerInvariant();
                }
                // False
                else
                {
                    Metadata.Remove(Constants.DataLake.IsDirectoryKey);
                }
            }
        }

        /// <summary>
        /// Prevent direct instantiation of PathProperties instances.
        /// You can use DataLakeModelFactory.PathProperties instead.
        /// </summary>
        internal PathProperties() { }
    }
}
