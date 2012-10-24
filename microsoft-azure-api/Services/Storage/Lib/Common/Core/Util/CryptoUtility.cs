//-----------------------------------------------------------------------
// <copyright file="CryptoUtility.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
#if RT
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Storage.Streams;
#elif! COMMON
    using System;
    using System.Security.Cryptography;
    using System.Text;
#endif

    internal static class CryptoUtility
    {
        internal static string ComputeHmac256(byte[] key, string message)
        {
#if RT
            MacAlgorithmProvider macAlgorithmProvider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA256");
            IBuffer keyMaterial = CryptographicBuffer.CreateFromByteArray(key);
            CryptographicKey hmacKey = macAlgorithmProvider.CreateKey(keyMaterial);
            IBuffer messageBuffer = CryptographicBuffer.ConvertStringToBinary(message, BinaryStringEncoding.Utf8);
            IBuffer signedMessage = CryptographicEngine.Sign(hmacKey, messageBuffer);
            return CryptographicBuffer.EncodeToBase64String(signedMessage);
#elif COMMON
            return null;
#else
            using (HashAlgorithm hashAlgorithm = new HMACSHA256(key))
            {
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(messageBuffer));
            }
#endif
        }
    }
}
