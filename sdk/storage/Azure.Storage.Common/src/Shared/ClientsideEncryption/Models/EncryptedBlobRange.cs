// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Cryptography;

namespace Azure.Storage.Blobs.Specialized.Models
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
            OriginalRange = originalRange;

            int offsetAdjustment = 0;
            long? adjustedDownloadCount = originalRange.Length;

            // Calculate offsetAdjustment.
            if (OriginalRange.Offset != 0)
            {
                // Align with encryption block boundary.
                int diff;
                if ((diff = (int)(OriginalRange.Offset % EncryptionConstants.EncryptionBlockSize)) != 0)
                {
                    offsetAdjustment += diff;
                    if (adjustedDownloadCount != default)
                    {
                        adjustedDownloadCount += diff;
                    }
                }

                // Account for IV.
                if (OriginalRange.Offset >= EncryptionConstants.EncryptionBlockSize)
                {
                    offsetAdjustment += EncryptionConstants.EncryptionBlockSize;
                    // Increment adjustedDownloadCount if necessary.
                    if (adjustedDownloadCount != default)
                    {
                        adjustedDownloadCount += EncryptionConstants.EncryptionBlockSize;
                    }
                }
            }

            // Align adjustedDownloadCount with encryption block boundary at the end of the range. Note that it is impossible
            // to adjust past the end of the blob as an encrypted blob was padded to align to an encryption block boundary.
            if (adjustedDownloadCount != null)
            {
                adjustedDownloadCount += (
                    EncryptionConstants.EncryptionBlockSize - (int)(adjustedDownloadCount
                    % EncryptionConstants.EncryptionBlockSize)
                ) % EncryptionConstants.EncryptionBlockSize;
            }

            AdjustedRange = new HttpRange(OriginalRange.Offset - offsetAdjustment, adjustedDownloadCount);
        }
    }
}
