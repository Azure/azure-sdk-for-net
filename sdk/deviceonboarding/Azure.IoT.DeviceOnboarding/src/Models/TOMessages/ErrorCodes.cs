// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Error codes
    /// </summary>
    public enum ErrorCodes
    {
        /// <summary>
        /// JWT token is missing or invalid. Applies to non-JWT tokens as well.
        /// </summary>
        INVALID_JWT_TOKEN = 1,
        /// <summary>
        /// Ownership Voucher is invalid: One of Ownership Voucher verification checks has failed.
        /// </summary>
        INVALID_OWNERSHIP_VOUCHER = 2,
        /// <summary>
        /// Verification of signature of owner message failed.
        /// </summary>
        INVALID_OWNER_SIGN_BODY = 3,
        /// <summary>
        /// IP address is invalid. Bytes that are provided in the request do not represent a valid IPv4/IPv6 address.
        /// </summary>
        INVALID_IP_ADDRESS = 4,
        /// <summary>
        /// GUID is invalid. Bytes that are provided in the request do not represent a proper GUID.
        /// </summary>
        INVALID_GUID = 5,
        /// <summary>
        /// The owner connection info for GUID is not found.
        /// </summary>
        RESOURCE_NOT_FOUND = 6,
        /// <summary>
        /// Message Body is structurally unsound.
        /// </summary>
        MESSAGE_BODY_ERROR = 100,
        /// <summary>
        /// Message structurally sound, but failed validation tests. The nonce didn’t match, signature didn’t verify, hash, or mac didn’t verify, index out of bounds, etc...
        /// </summary>
        INVALID_MESSAGE_ERROR = 101,
        /// <summary>
        /// Credential reuse rejected.
        /// </summary>
        CRED_REUSE_ERROR = 102,
        /// <summary>
        /// Something went wrong which couldn’t be classified otherwise.
        /// </summary>
        INTERNAL_SERVER_ERROR = 500
    }
}
