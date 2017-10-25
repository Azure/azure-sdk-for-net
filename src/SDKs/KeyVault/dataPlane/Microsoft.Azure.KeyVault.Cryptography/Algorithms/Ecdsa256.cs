//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// Represents ECDSA with a generic 256 bit curve.
    /// </summary>
    public class Ecdsa256 : Ecdsa
    {
        public const string AlgorithmName = "ECDSA256";

        public Ecdsa256() : base( AlgorithmName )
        {
        }

        public override ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key )
        {
            return CreateSignatureTransform( key, AlgorithmName );
        }
    }
}
