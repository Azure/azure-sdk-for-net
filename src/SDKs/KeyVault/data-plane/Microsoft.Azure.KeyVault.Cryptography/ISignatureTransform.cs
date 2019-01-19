//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.KeyVault.Cryptography
{
    /// <summary>
    /// Abstract signature transform.
    /// </summary>
    public interface ISignatureTransform
    {
        /// <summary>
        /// Signs the supplied digest value.
        /// </summary>
        /// <param name="digest">The message digest.</param>
        /// <returns>The signature value.</returns>
        byte[] Sign( byte[] digest );

        /// <summary>
        /// Verifies that the supplied signature corresponds with
        /// the supplied message digest.
        /// </summary>
        /// <param name="digest">The message digest.</param>
        /// <param name="signature">The signature to be verified.</param>
        /// <returns>true if the signature is valid.</returns>
        bool Verify( byte[] digest, byte[] signature );
    }
}
