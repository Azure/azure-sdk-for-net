// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Type of Hash.
    /// </summary>
    public enum HashType
    {
        /// <summary>
        /// Hash algorithm produing 256 bit output.
        /// </summary>
        SHA256 = -16,
        /// <summary>
        /// Hash algorithm producing 384 bit output.
        /// </summary>
        SHA384 = -43,
        /// <summary>
        /// Keyed hash algorithm using SHA256 hash function with secret key.
        /// </summary>
        HMAC_SHA256 = 5,
        /// <summary>
        /// Keyed hash algorithm using SHA384 hash function with secret key.
        /// </summary>
        HMAC_SHA384 = 6,
    }
}
