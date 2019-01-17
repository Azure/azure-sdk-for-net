//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// Represents ECDSA with a P-256K curve.
    /// </summary>
    public class ES256K : Ecdsa
    {
        public const string AlgorithmName = "ES256K";

        public ES256K() : base( AlgorithmName )
        {
        }

        public override ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key )
        {
            return CreateSignatureTransform( key, AlgorithmName );
        }
    }
}
