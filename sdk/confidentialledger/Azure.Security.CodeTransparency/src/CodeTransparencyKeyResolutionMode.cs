// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Controls how <see cref="CodeTransparencyClient.VerifyTransparentStatement(byte[], CodeTransparencyVerificationOptions, CodeTransparencyClientOptions)"/>
    /// resolves the receipt-verification keys for an issuer.
    /// </summary>
    public enum CodeTransparencyKeyResolutionMode
    {
        /// <summary>
        /// Use keys from the configured <see cref="CodeTransparencyTrustStore"/> when available, otherwise
        /// download them from the issuing service.
        /// </summary>
        TrustStoreThenNetwork = 0,

        /// <summary>
        /// Use only keys from the configured <see cref="CodeTransparencyTrustStore"/>. If no key is present
        /// for an issuer, verification fails instead of making a network call.
        /// </summary>
        TrustStoreOnly = 1,
    }
}
