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
                return ValidationAlgorithm.StorageCrc64;
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
                    Validate = false // legacy arg forced users to validate the hash themselves
                }
                : default;
    }
}
