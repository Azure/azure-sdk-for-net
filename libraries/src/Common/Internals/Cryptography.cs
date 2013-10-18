//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using Microsoft.WindowsAzure.Common.Platform;

namespace Microsoft.WindowsAzure.Common.Internals
{
    /// <summary>
    /// Provides cryptography functionality to libraries.
    /// </summary>
    public static class Cryptography
    {
        private static ICryptographyProvider _cryptoProvider = null;

        private static ICryptographyProvider CryptoProvider
        {
            get
            {
                if (_cryptoProvider == null)
                {
                    _cryptoProvider = PortablePlatformAbstraction.Get<ICryptographyProvider>();
                }
                return _cryptoProvider;
            }
        }

        /// <summary>
        /// Computes a Hash-based Message Authentication Code (HMAC) 
        /// by using the SHA256 hash function.
        /// </summary>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <param name="data">The input to compute the hash code
        /// for.</param>
        /// <returns>Returns the computed hash code.</returns>
        public static byte[] ComputeHmacSha256Hash(byte[] key, byte[] data)
        {
            return CryptoProvider.ComputeHmacSha256Hash(key, data);
        }
    }
}
