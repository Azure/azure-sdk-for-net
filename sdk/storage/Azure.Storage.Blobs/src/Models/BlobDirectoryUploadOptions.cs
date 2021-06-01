using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;
{
    /// <summary>
    /// BlobDirectoryUploadOptions for
    /// </summary>
    public class BlobDirectoryUploadOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this append blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set for this block blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the upload of this Block Blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<StorageTransferStatus> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on the
        /// Block Blob.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }
        /// <summary>
        /// Optional. If set to false, the operation will terminate quickly on encountering user failures. If true, the operation will ignore
        /// user failures and proceed with the operation on other sub-entities of the directory.
        ///
        /// This is after retry attempts fail.
        /// </summary>
        public bool? ContinueOnFailure { get; set; }
}
