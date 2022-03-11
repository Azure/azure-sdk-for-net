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
    }
}
