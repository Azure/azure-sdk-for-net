// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents a content key that can be used for encryption and decryption.
    /// </summary>
    public partial interface IContentKey
    {
        /// <summary>
        /// Gets the decrypted content key value.
        /// </summary>
        /// <returns>The decrypted key value used for encryption.</returns>
        byte[] GetClearKeyValue();

        /// <summary>
        /// Gets the encrypted content key value.
        /// </summary>
        /// <param name="certToEncryptTo">The <see cref="X509Certificate2"/> to protect the key with.</param>
        /// <returns>The encrypted content key value.</returns>
        byte[] GetEncryptedKeyValue(X509Certificate2 certToEncryptTo);
    }
}
