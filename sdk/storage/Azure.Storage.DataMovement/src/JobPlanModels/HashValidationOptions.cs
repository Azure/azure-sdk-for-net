// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.DataMovement
{
    internal enum HashValidationOptions
    {
        /// <summary>
        /// FailIfDifferent says fail if hashes different, but NOT fail if saved hash is
        /// totally missing. This is a balance of convenience (for cases where no hash is saved) vs strictness
        /// (to validate strictly when one is present)
        /// </summary>
        FailIfDifferent = 0,
        /// <summary>
        /// Do not check hashes at download time during the entire time.
        /// </summary>
        NoCheck = 1,
        /// <summary>
        /// LogOnly means only log if missing or different, don't fail the transfer
        /// </summary>
        LogOnly = 2,
        /// <summary>
        /// FailIfDifferentOrMissing is the strictest option, and useful for testing or validation in cases when
        /// we _know_ there should be a hash
        /// </summary>
        FailIfDifferentOrMissing = 3,
    }
}
