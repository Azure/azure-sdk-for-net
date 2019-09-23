// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Http;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// This is a representation of a range of bytes on an encrypted blob, which may be expanded from the requested range to
    /// included extra data needed for encryption.Note that this type is not strictly thread-safe as the download method
    /// will update the count in case the user did not specify one. Passing null as an EncryptedBlobRange value will default
    /// to the entire range of the blob.
    /// </summary>
    internal struct EncryptedBlobRange
    {
        public const int ENCRYPTION_BLOCK_SIZE = 16;

        /// <summary>
        /// The original blob range requested by the user.
        /// </summary>
        public HttpRange OriginalRange { get; }

        /// <summary>
        /// The blob range to actually request from the service that will allow
        /// decryption of the original range.
        /// </summary>
        public HttpRange AdjustedRange { get; }

        public EncryptedBlobRange(HttpRange originalRange)
        {
            this.OriginalRange = originalRange;

            int offsetAdjustment = 0;
            long? adjustedDownloadCount = default;

            // Calculate offsetAdjustment.
            if (this.OriginalRange.Offset != 0)
            {
                // Align with encryption block boundary.
                int diff;
                if ((diff = (int)(this.OriginalRange.Offset % ENCRYPTION_BLOCK_SIZE)) != 0)
                {
                    offsetAdjustment += diff;
                    if (adjustedDownloadCount != null)
                    {
                        adjustedDownloadCount += diff;
                    }
                }

                // Account for IV.
                if (this.OriginalRange.Offset >= ENCRYPTION_BLOCK_SIZE)
                {
                    offsetAdjustment += ENCRYPTION_BLOCK_SIZE;
                    // Increment adjustedDownloadCount if necessary.
                    if (adjustedDownloadCount != null)
                    {
                        adjustedDownloadCount += ENCRYPTION_BLOCK_SIZE;
                    }
                }
            }

            // Align adjustedDownloadCount with encryption block boundary at the end of the range. Note that it is impossible
            // to adjust past the end of the blob as an encrypted blob was padded to align to an encryption block boundary.
            if (adjustedDownloadCount != null)
            {
                adjustedDownloadCount += ENCRYPTION_BLOCK_SIZE - (int)(adjustedDownloadCount % ENCRYPTION_BLOCK_SIZE);
            }

            this.AdjustedRange = new HttpRange(this.OriginalRange.Offset - offsetAdjustment, adjustedDownloadCount);
        }
    }
}
