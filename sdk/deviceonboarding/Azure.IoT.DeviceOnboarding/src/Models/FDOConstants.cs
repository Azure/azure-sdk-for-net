// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Constants
    /// </summary>
    public class FDOConstants
    {
        /// <summary>
        /// Guid byte array size
        /// </summary>
        public const int GuidByteArraySize = 16;
        /// <summary>
        /// FDONonce byte array size
        /// </summary>
        public const int NonceByteArraySize = 16;
        /// <summary>
        /// EATguid byte array size
        /// </summary>
        public const int UeidByteArraySize = 17;
        /// <summary>
        /// Cose header parameter for nonce
        /// </summary>
        public const int CUPHNonce = 256;
        /// <summary>
        /// Cose header parameter for owner public key
        /// </summary>
        public const int CUPHOwnerPubKey = 257;
        /// <summary>
        /// Reserved for Private Use by CBOR Web Token
        /// </summary>
        public const int EUPHNonce = -259;
        /// <summary>
        /// Reserved for Private Use by CBOR Web Token
        /// </summary>
        public const int EatNonce = 10;
        /// <summary>
        /// Reserved for Private Use by CBOR Web Token
        /// </summary>
        public const int EatUeid = 11;
        /// <summary>
        /// Reserved for Private Use by CBOR Web Token
        /// </summary>
        public const int EatRand = 1;
        /// <summary>
        /// Reserved for Private Use by CBOR Web Token
        /// </summary>
        public const int EatFdo = -257;
        /// <summary>
        /// Reserved for Private Use by CBOR Web Token
        /// </summary>
        public const int EatMAROEPrefix = -258;
    }
}
