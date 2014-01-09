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

using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace Microsoft.WindowsAzure.Common.Platform
{
    internal class CryptographyProvider : ICryptographyProvider
    {
        /// <summary>
        /// Computes SHA256 hash from key and data using HMACSHA256.
        /// </summary>
        /// <param name="key">Key to use as hash salt.</param>
        /// <param name="data">Data to hash.</param>
        /// <returns>Hash value.</returns>
        public byte[] ComputeHmacSha256Hash(byte[] key, byte[] data)
        {
            MacAlgorithmProvider macAlgorithmProvider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA256");
            var dataBuffer = CryptographicBuffer.CreateFromByteArray(data);
            var keyBuffer = CryptographicBuffer.CreateFromByteArray(key);
            var hmacKey = macAlgorithmProvider.CreateKey(keyBuffer);
            var hmacBuffer = CryptographicEngine.Sign(hmacKey, dataBuffer);

            byte[] sha256Hash;
            CryptographicBuffer.CopyToByteArray(hmacBuffer, out sha256Hash);

            return sha256Hash;
        }
    }
}
