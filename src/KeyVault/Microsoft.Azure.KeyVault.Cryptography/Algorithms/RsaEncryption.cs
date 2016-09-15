// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public abstract class RsaEncryption : AsymmetricEncryptionAlgorithm
    {
        protected RsaEncryption( string name ) : base( name )
        {
        }
    }
}
