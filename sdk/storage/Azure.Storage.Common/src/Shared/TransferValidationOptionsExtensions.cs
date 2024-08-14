// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    internal static class TransferValidationOptionsExtensions
    {
        public static StorageChecksumAlgorithm ResolveAuto(this StorageChecksumAlgorithm checksumAlgorithm)
        {
            if (checksumAlgorithm == StorageChecksumAlgorithm.Auto)
            {
                return StorageChecksumAlgorithm.StorageCrc64;
            }
            return checksumAlgorithm;
        }

        public static UploadTransferValidationOptions ToValidationOptions(this byte[] md5)
            => md5 == default
                ? default
                : new UploadTransferValidationOptions
                {
                    ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                    PrecalculatedChecksum = md5
                };

        public static DownloadTransferValidationOptions ToValidationOptions(this bool requestTransactionalMD5)
            => requestTransactionalMD5
                ? new DownloadTransferValidationOptions
                {
                    ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                    // legacy arg forced users to validate the hash themselves
                    // maintain this behavior to avoid perf hit of double-validation
                    AutoValidateChecksum = false
                }
                : default;

        public static void CopyTo(this TransferValidationOptions source, TransferValidationOptions dest)
        {
            source.Upload.CopyTo(dest.Upload);
            source.Download.CopyTo(dest.Download);
        }

        public static void CopyTo(this UploadTransferValidationOptions source, UploadTransferValidationOptions dest)
        {
            dest.ChecksumAlgorithm = source.ChecksumAlgorithm;
            dest.PrecalculatedChecksum = source.PrecalculatedChecksum;
        }

        public static void CopyTo(this DownloadTransferValidationOptions source, DownloadTransferValidationOptions dest)
        {
            dest.ChecksumAlgorithm = source.ChecksumAlgorithm;
            dest.AutoValidateChecksum = source.AutoValidateChecksum;
        }
    }
}
