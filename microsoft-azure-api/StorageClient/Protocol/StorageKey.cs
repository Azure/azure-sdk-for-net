//-----------------------------------------------------------------------
// <copyright file="StorageKey.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the StorageKey class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Container for storage key.
    /// </summary>
    /// <remarks>
    /// May eventually use native APIs to keep key pinned and not memory.
    /// </remarks>
    internal class StorageKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageKey"/> class.
        /// </summary>
        /// <param name="key">The storage key.</param>
        public StorageKey(byte[] key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The storage key.</value>
        private byte[] Key { get; set; }

        /// <summary>
        /// Computes the mac sha256.
        /// </summary>
        /// <param name="storageKey">The storage key.</param>
        /// <param name="canonicalizedString">The canonicalized string.</param>
        /// <returns>The computed hash.</returns>
        internal static string ComputeMacSha256(StorageKey storageKey, string canonicalizedString)
        {
            byte[] dataToMAC = Encoding.UTF8.GetBytes(canonicalizedString);

            using (HMACSHA256 hmacsha1 = new HMACSHA256(storageKey.Key))
            {
                return System.Convert.ToBase64String(hmacsha1.ComputeHash(dataToMAC));
            }
        }

        /// <summary>
        /// Computes the mac sha512.
        /// </summary>
        /// <param name="storageKey">The storage key.</param>
        /// <param name="canonicalizedString">The canonicalized string.</param>
        /// <returns>The computed hash.</returns>
        internal static string ComputeMacSha512(StorageKey storageKey, string canonicalizedString)
        {
            byte[] dataToMAC = Encoding.UTF8.GetBytes(canonicalizedString);

            using (HMACSHA512 hmacsha1 = new HMACSHA512(storageKey.Key))
            {
                return System.Convert.ToBase64String(hmacsha1.ComputeHash(dataToMAC));
            }
        }

        /// <summary>
        /// Gets the base64 encoded key.
        /// </summary>
        /// <returns>The base64 encoded key.</returns>
        internal string GetBase64EncodedKey()
        {
            return System.Convert.ToBase64String(this.Key);
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>The storage key.</returns>
        internal byte[] GetKey()
        {
            byte[] keyCopy = (byte[])this.Key.Clone();
            return keyCopy;
        }
    }
}
