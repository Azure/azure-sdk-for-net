// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for Page Blob Open Write.
    /// </summary>
    public class BlobOpenWriteOptions
    {
        /// <summary>
        /// The size of the buffer to use.  Default is 4 MB,
        /// max is 4000 MB.  See <see cref="BlockBlobClient.BlockBlobMaxStageBlockLongBytes"/>.
        /// </summary>
        public long? BufferSize { get; set; }

        /// <summary>
        /// Access conditions used to open the write stream.
        /// </summary>
        public BlobRequestConditions OpenConditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional standard HTTP header properties that can be set for this block blob.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this block blob.
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
        /// Optional override settings for this client's <see cref="BlobClientOptions.TransferValidation"/> settings.
        /// This operation does not allow <see cref="UploadTransferValidationOptions.PrecalculatedChecksum"/>
        /// to be set.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }
    }

    internal static class BlobOpenWriteOptionsExtensions
    {
        public static BlockBlobOpenWriteOptions ToBlockBlobOpenWriteOptions(this BlobOpenWriteOptions options)
            => new BlockBlobOpenWriteOptions
            {
                BufferSize = options.BufferSize,
                OpenConditions = options.OpenConditions,
                ProgressHandler = options.ProgressHandler,
                HttpHeaders = options.HttpHeaders,
                Metadata = options.Metadata,
                Tags = options.Tags,
                TransferValidation = options.TransferValidation,
                OperationName = $"{nameof(BlobClient)}.{nameof(BlockBlobClient.OpenWrite)}"
            };
    }
}
