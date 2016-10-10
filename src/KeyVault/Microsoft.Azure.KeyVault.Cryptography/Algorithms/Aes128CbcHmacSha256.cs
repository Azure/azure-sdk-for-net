// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// JWE A128CBC-HS256: https://tools.ietf.org/html/rfc7518#section-5.2.3
    /// </summary>
    public class Aes128CbcHmacSha256 : AesCbcHmacSha2
    {
        public const string AlgorithmName = "A128CBC-HS256";

        public Aes128CbcHmacSha256() : base( AlgorithmName )
        {
        }
    }
}
