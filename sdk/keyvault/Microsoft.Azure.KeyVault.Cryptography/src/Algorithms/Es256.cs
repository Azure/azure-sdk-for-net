//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// Represents ECDSA with curve P-256 from NIST.
    /// </summary>
    public class Es256 : Ecdsa
    {
        public const string AlgorithmName = "ES256";

        public Es256() : base( AlgorithmName )
        {
        }

        public override ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key )
        {
            return CreateSignatureTransform( key, AlgorithmName );
        }
    }
}
