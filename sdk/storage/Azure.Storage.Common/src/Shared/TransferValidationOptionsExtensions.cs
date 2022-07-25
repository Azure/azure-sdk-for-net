// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    internal static class TransferValidationOptionsExtensions
    {
        public static ValidationAlgorithm ResolveAuto(this ValidationAlgorithm validationAlgorithm)
        {
            if (validationAlgorithm == ValidationAlgorithm.Auto)
            {
#if BlobSDK || DataLakeSDK
                return ValidationAlgorithm.StorageCrc64;
#elif FileSDK // file shares don't support crc64
                return ValidationAlgorithm.MD5;
#endif
            }
            return validationAlgorithm;
        }

        public static UploadTransferValidationOptions ToValidationOptions(this byte[] md5)
            => md5 == default
                ? default
                : new UploadTransferValidationOptions
                {
                    Algorithm = ValidationAlgorithm.MD5,
                    PrecalculatedChecksum = md5
                };

        public static DownloadTransferValidationOptions ToValidationOptions(this bool requestTransactionalMD5)
            => requestTransactionalMD5
                ? new DownloadTransferValidationOptions
                {
                    Algorithm = ValidationAlgorithm.MD5,
                    // legacy arg forced users to validate the hash themselves
                    // maintain this behavior to avoid perf hit of double-validation
                    Validate = false
                }
                : default;
    }
}
