//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// Abstract RsaSignature.
    /// </summary>
    public abstract class RsaSignature : AsymmetricSignatureAlgorithm
    {
        protected RsaSignature( string name ) : base( name )
        {
        }
    }
}
