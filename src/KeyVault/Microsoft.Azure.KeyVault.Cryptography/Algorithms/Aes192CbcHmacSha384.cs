// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public class Aes192CbcHmacSha384 : AesCbcHmacSha2
    {
        public const string AlgorithmName = "A192CBC-HS384";

        public Aes192CbcHmacSha384() : base( AlgorithmName )
        {
        }
    }
}
