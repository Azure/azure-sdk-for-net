// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for downloading a range of a blob.
    /// </summary>
    public class BlobDownloadOptions
    {
        /// <summary>
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Options for transfer validation settings on this operation.
        /// When transfer validation options are set in the client, setting this parameter
        /// acts as an override.
        /// Set <see cref="DownloadTransferValidationOptions.Validate"/> to false if you
        /// would like to skip SDK checksum validation and validate the checksum found
        /// in the <see cref="Response"/> object yourself.
        /// Range must be provided explicitly, stating a range withing Azure
        /// Storage size limits for requesting a transactional hash. See the
        /// <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob">
        /// REST documentation</a> for range limitation details.
        /// </summary>
        public DownloadTransferValidationOptions TransferValidationOptions { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlobDownloadOptions()
        {
        }

        /// <summary>
        /// Deep copy constructor.
        /// </summary>
        /// <param name="deepCopySource"></param>
        private BlobDownloadOptions(BlobDownloadOptions deepCopySource)
        {
            Argument.AssertNotNull(deepCopySource, nameof(deepCopySource));

            Range = new HttpRange(offset: deepCopySource.Range.Offset, length: deepCopySource.Range.Length);
            Conditions = BlobRequestConditions.CloneOrDefault(deepCopySource.Conditions);
            ProgressHandler = deepCopySource.ProgressHandler;
            // can't access an internal deep copy in Storage.Common
            TransferValidationOptions = deepCopySource.TransferValidationOptions == default
                ? default
                : new DownloadTransferValidationOptions()
                {
                    Algorithm = deepCopySource.TransferValidationOptions.Algorithm,
                    Validate = deepCopySource.TransferValidationOptions.Validate
                };
        }

        /// <summary>
        /// Creates a deep copy of the given instance, if any.
        /// </summary>
        /// <param name="deepCopySource">Instance to deep copy.</param>
        /// <returns>The deep copy, or null.</returns>
        internal static BlobDownloadOptions CloneOrDefault(BlobDownloadOptions deepCopySource)
        {
            if (deepCopySource == default)
            {
                return default;
            }
            return new BlobDownloadOptions(deepCopySource);
        }
    }
}
