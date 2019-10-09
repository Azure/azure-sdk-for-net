// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized.Cryptography.Models
{
    /// <summary>
    /// This is a representation of a range of bytes on an encrypted blob, which may be expanded from the requested
    /// range to include extra data needed for decryption. It contains the original range as well as the calculated
    /// expanded range.
    /// </summary>
    internal struct EncryptedBlobRange
    {
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
            long? adjustedDownloadCount = originalRange.Count;

            // Calculate offsetAdjustment.
            if (this.OriginalRange.Offset != 0)
            {
                // Align with encryption block boundary.
                int diff;
                if ((diff = (int)(this.OriginalRange.Offset % EncryptionConstants.ENCRYPTION_BLOCK_SIZE)) != 0)
                {
                    offsetAdjustment += diff;
                    if (adjustedDownloadCount != default)
                    {
                        adjustedDownloadCount += diff;
                    }
                }

                // Account for IV.
                if (this.OriginalRange.Offset >= EncryptionConstants.ENCRYPTION_BLOCK_SIZE)
                {
                    offsetAdjustment += EncryptionConstants.ENCRYPTION_BLOCK_SIZE;
                    // Increment adjustedDownloadCount if necessary.
                    if (adjustedDownloadCount != default)
                    {
                        adjustedDownloadCount += EncryptionConstants.ENCRYPTION_BLOCK_SIZE;
                    }
                }
            }

            // Align adjustedDownloadCount with encryption block boundary at the end of the range. Note that it is impossible
            // to adjust past the end of the blob as an encrypted blob was padded to align to an encryption block boundary.
            if (adjustedDownloadCount != null)
            {
                adjustedDownloadCount += (
                    EncryptionConstants.ENCRYPTION_BLOCK_SIZE - (int)(adjustedDownloadCount
                    % EncryptionConstants.ENCRYPTION_BLOCK_SIZE)
                ) % EncryptionConstants.ENCRYPTION_BLOCK_SIZE;
            }

            this.AdjustedRange = new HttpRange(this.OriginalRange.Offset - offsetAdjustment, adjustedDownloadCount);
        }
    }
}
