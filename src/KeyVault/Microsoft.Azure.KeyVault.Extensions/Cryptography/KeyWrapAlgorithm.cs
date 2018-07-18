//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    /// <summary>
    /// An abstract Key Wrap Algorithm
    /// </summary>
    public abstract class KeyWrapAlgorithm : Algorithm
    {
        protected KeyWrapAlgorithm( string name )
            : base( name )
        {
        }

        /// <summary>
        /// Create an encryptor for the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="iv">The initialization vector</param>
        /// <returns>An ICryptoTranform for encrypting data</returns>
        public abstract ICryptoTransform CreateEncryptor( byte[] key, byte[] iv );

        /// <summary>
        /// Crea a decryptor for the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="iv">The initialization vector</param>
        /// <returns>An ICryptoTransform for decrypting data</returns>
        public abstract ICryptoTransform CreateDecryptor( byte[] key, byte[] iv );
    }
}
