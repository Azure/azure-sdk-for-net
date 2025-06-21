// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// FDO allowed Key Sizes
    /// </summary>
    public enum KeySize
    {
        /// <summary>
        /// 2048 bit key
        /// </summary>
        KeySize2048 = 2048,
        /// <summary>
        /// 3072 bit key
        /// </summary>
        KeySize3072 = 3072,
        /// <summary>
        /// 256 bit key
        /// </summary>
        KeySize256 = 256,
        /// <summary>
        /// 384 bit key
        /// </summary>
        KeySize384 = 384
    }
}
