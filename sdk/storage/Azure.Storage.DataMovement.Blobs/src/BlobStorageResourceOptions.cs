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
        private Metadata _metadata = default;
        internal bool _isMetadataSet = false;

        private string _cacheControl = default;
        internal bool _isCacheControlSet = false;

        private string _contentDisposition = default;
        internal bool _isContentDispositionSet = false;

        private string _contentEncoding = default;
        internal bool _isContentEncodingSet = false;

        private string _contentLanguage = default;
        internal bool _isContentLanguageSet = false;

        private string _contentType = default;
        internal bool _isContentTypeSet = false;

        private AccessTier? _accessTier = default;
        internal bool _isAccessTierSet = false;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlobStorageResourceOptions()
        {
        }

        internal BlobStorageResourceOptions(BlobStorageResourceOptions other)
        {
            Metadata = other?.Metadata;
            _isMetadataSet = other?._isMetadataSet ?? false;
            CacheControl = other?.CacheControl;
            _isCacheControlSet = other?._isCacheControlSet ?? false;
            ContentDisposition = other?.ContentDisposition;
            _isContentDispositionSet = other?._isContentDispositionSet ?? false;
            ContentEncoding = other?.ContentEncoding;
            _isContentEncodingSet = other?._isContentEncodingSet ?? false;
            ContentLanguage = other?.ContentLanguage;
            _isContentLanguageSet = other?._isContentLanguageSet ?? false;
            ContentType = other?.ContentType;
            _isContentTypeSet = other?._isContentTypeSet ?? false;
            AccessTier = other?.AccessTier;
            _isAccessTierSet = other?._isAccessTierSet ?? false;
        }

        internal BlobStorageResourceOptions(BlobDestinationCheckpointDetails checkpointDetails)
        {
            Metadata = checkpointDetails.Metadata;
            _isMetadataSet = checkpointDetails.IsMetadataSet;
            CacheControl = checkpointDetails.CacheControl;
            _isCacheControlSet = checkpointDetails.IsCacheControlSet;
            ContentDisposition = checkpointDetails.ContentDisposition;
            _isContentDispositionSet = checkpointDetails.IsContentDispositionSet;
            ContentEncoding = checkpointDetails.ContentEncoding;
            _isContentEncodingSet = checkpointDetails.IsContentEncodingSet;
            ContentLanguage = checkpointDetails.ContentLanguage;
            _isContentLanguageSet = checkpointDetails.IsContentLanguageSet;
            ContentType = checkpointDetails.ContentType;
            _isContentTypeSet = checkpointDetails.IsContentTypeSet;
            AccessTier = checkpointDetails.AccessTierValue;
            _isAccessTierSet = checkpointDetails.IsAccessTierSet;
        }

        /// <summary>
        /// Optional. For transferring metadata from the source to the destination storage resource.
        ///
        /// By default preserves the metadata from the source. If explicitly set to null, the metadata will not be preserved and set to null.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public Metadata Metadata
        {
            get => _metadata;
            set
            {
                _metadata = value;
                _isMetadataSet = true;
            }
        }

        /// <summary>
        /// Optional. Sets the Cache Control header which
        /// specifies directives for caching mechanisms.
        ///
        /// By default preserves the Cache Control from the source. If explicitly set to null, the Cache Control will not be preserved and set to null.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public string CacheControl
        {
            get => _cacheControl;
            set
            {
                _cacheControl = value;
                _isCacheControlSet = true;
            }
        }

        /// <summary>
        /// Optional. Sets the Content Disposition header which
        /// conveys additional information about how to process the response
        /// payload, and also can be used to attach additional metadata.  For
        /// example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog
        /// with a filename other than the blob name specified.
        ///
        /// By default preserves the Content Disposition from the source. If explicitly set to null, the Content Disposition will not be preserved and set to null.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public string ContentDisposition
        {
            get => _contentDisposition;
            set
            {
                _contentDisposition = value;
                _isContentDispositionSet = true;
            }
        }

        /// <summary>
        /// Optional. Sets the Content Encoding header which
        /// specifies which content encodings have been applied to the blob.
        /// This value is returned to the client when the Get Blob operation
        /// is performed on the blob resource. The client can use this value
        /// when returned to decode the blob content.
        ///
        /// By default preserves the Content Encoding from the source. If explicitly set to null, the Content Encoding will not be preserved and set to null.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public string ContentEncoding
        {
            get => _contentEncoding;
            set
            {
                _contentEncoding = value;
                _isContentEncodingSet = true;
            }
        }

        /// <summary>
        /// Optional. Sets the Content Language header which
        /// specifies the natural languages used by this resource.
        ///
        /// By default preserves the Content Language from the source. If explicitly set to null, the Content Language will not be preserved and set to null.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public string ContentLanguage
        {
            get => _contentLanguage;
            set
            {
                _contentLanguage = value;
                _isContentLanguageSet = true;
            }
        }

        /// <summary>
        /// Optional. Sets the Content Type header which
        /// specifies the MIME content type of the blob.
        ///
        /// By default preserves the Content Type from the source. If explicitly set to null, the Content Type will not be preserved and set to null.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public string ContentType
        {
            get => _contentType;
            set
            {
                _contentType = value;
                _isContentTypeSet = true;
            }
        }

        /// <summary>
        /// Optional. See <see cref="Storage.Blobs.Models.AccessTier"/>.
        /// Indicates the access tier to be set on the destination blob.
        ///
        /// Access Tier is automatically preserved during blob to blob copies. If explicitly set to null, the Access Tier will not be preserved from source to destination.
        ///
        /// Applies to upload and copy transfers.
        /// Also respective Tier Values applies only to Block or Page Blobs.
        /// </summary>
        public AccessTier? AccessTier
        {
            get => _accessTier;
            set
            {
                _accessTier = value;
                _isAccessTierSet = true;
            }
        }
    }
}
