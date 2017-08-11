//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// Represents ECDSA with curve P-384 from NIST.
    /// </summary>
    public class Es384 : Ecdsa
    {
        public const string AlgorithmName = "ES384";

        public Es384() : base( AlgorithmName )
        {
        }

        public override ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key )
        {
            return CreateSignatureTransform( key, AlgorithmName );
        }
    }
}