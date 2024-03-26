// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters for all Blob Storage resource types.
    /// </summary>
    public class BlobStorageResourceOptions
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlobStorageResourceOptions()
        {
        }

        internal BlobStorageResourceOptions(BlobStorageResourceOptions other)
        {
            Metadata = other?.Metadata;
            CacheControl = other?.CacheControl;
            ContentDisposition = other?.ContentDisposition;
            ContentEncoding = other?.ContentEncoding;
            ContentLanguage = other?.ContentLanguage;
            ContentType = other?.ContentType;
            AccessTier = other?.AccessTier;
        }

        /// <summary>
        /// Optional. For transferring metadata from the source to the destination storage resource.
        ///
        /// By default preserves the metadata from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<Metadata> Metadata { get; set; }

        /// <summary>
        /// Optional. Sets the Cache Control header which
        /// specifies directives for caching mechanisms.
        ///
        /// By default preserves the Cache Control from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> CacheControl { get; set; }

        /// <summary>
        /// Optional. Sets the Content Disposition header which
        /// conveys additional information about how to process the response
        /// payload, and also can be used to attach additional metadata.  For
        /// example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog
        /// with a filename other than the blob name specified.
        ///
        /// By default preserves the Content Disposition from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> ContentDisposition { get; set; }

        /// <summary>
        /// Optional. Sets the Content Encoding header which
        /// specifies which content encodings have been applied to the blob.
        /// This value is returned to the client when the Get Blob operation
        /// is performed on the blob resource. The client can use this value
        /// when returned to decode the blob content.
        ///
        /// By default preserves the Content Encoding from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> ContentEncoding { get; set; }

        /// <summary>
        /// Optional. Sets the Content Language header which
        /// specifies the natural languages used by this resource.
        ///
        /// By default preserves the Content Language from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> ContentLanguage { get; set; }

        /// <summary>
        /// Optional. Sets the Content Type header which
        /// specifies the MIME content type of the blob.
        ///
        /// By default preserves the Content Type from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> ContentType { get; set; }

        /// <summary>
        /// Optional. See <see cref="Storage.Blobs.Models.AccessTier"/>.
        /// Indicates the access tier to be set on the destination blob.
        ///
        /// By default preserves the Access Tier from the source.
        ///
        /// Applies to upload and copy transfers.
        /// Also respective Tier Values applies only to Block or Page Blobs.
        /// </summary>
        public DataTransferProperty<AccessTier?> AccessTier { get; set; }
    }
}
