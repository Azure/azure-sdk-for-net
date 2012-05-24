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
// limitations under the License.using System;

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public static class CommonEncryption
    {
        public static readonly string SchemeVersion = "1.0";
        public static readonly string SchemeName = "CommonEncryption";

        public static byte[] EncryptContentKeyToCertificate(X509Certificate2 cert, byte[] contentKey)
        {
            byte[] returnValue = null;

            if (cert == null)
            {
                throw new ArgumentNullException("cert");
            }

            if (contentKey == null)
            {
                throw new ArgumentNullException("contentKey");
            }

            if (contentKey.Length != EncryptionUtils.KeySizeInBytesForAes128)
            {
                throw new ArgumentOutOfRangeException("contentKey", "Common Encryption content keys are 128-bits (16 bytes) in length.");
            }

            using (AesCryptoServiceProvider key = new AesCryptoServiceProvider())
            {
                key.Key = contentKey;

                returnValue = EncryptionUtils.EncryptSymmetricKey(cert, key);
            }

            return returnValue;
        }

        public static byte[] GeneratePlayReadyContentKey(byte[] keySeed, Guid keyId)
        {
            if (keySeed == null)
            {
                throw new ArgumentNullException("keySeed");
            }

            byte[] contentKey = new byte[EncryptionUtils.KeySizeInBytesForAes128];

            //
            //  Truncate the key seed to 30 bytes 
            //
            byte[] truncatedKeySeed = new byte[30];
            if (keySeed.Length < truncatedKeySeed.Length)
            { 
                throw new ArgumentOutOfRangeException("keySeed", "KeySeed must be at least 30 bytes in length");
            }

            Array.Copy(keySeed, truncatedKeySeed, truncatedKeySeed.Length);

            //
            //  Get the keyId as a byte array
            //
            byte[] keyIdAsBytes = keyId.ToByteArray();

            using (SHA256Managed sha_A = new SHA256Managed())
            using (SHA256Managed sha_B = new SHA256Managed())
            using (SHA256Managed sha_C = new SHA256Managed())
            {
                //
                //  Create sha_A_Output buffer.  It is the SHA of the truncatedKeySeed and the keyIdAsBytes
                //
                sha_A.TransformBlock(truncatedKeySeed, 0, truncatedKeySeed.Length, truncatedKeySeed, 0);
                sha_A.TransformFinalBlock(keyIdAsBytes, 0, keyIdAsBytes.Length);
                byte[] sha_A_Output = sha_A.Hash;

                //
                //  Create sha_B_Output buffer.  It is the SHA of the truncatedKeySeed, the keyIdAsBytes, and
                //  the truncatedKeySeed again.
                //
                sha_B.TransformBlock(truncatedKeySeed, 0, truncatedKeySeed.Length, truncatedKeySeed, 0);
                sha_B.TransformBlock(keyIdAsBytes, 0, keyIdAsBytes.Length, keyIdAsBytes, 0);
                sha_B.TransformFinalBlock(truncatedKeySeed, 0, truncatedKeySeed.Length);
                byte[] sha_B_Output = sha_B.Hash;

                //
                //  Create sha_C_Output buffer.  It is the SHA of the truncatedKeySeed, the keyIdAsBytes, 
                //  the truncatedKeySeed again, and the keyIdAsBytes again.
                //
                sha_C.TransformBlock(truncatedKeySeed, 0, truncatedKeySeed.Length, truncatedKeySeed, 0);
                sha_C.TransformBlock(keyIdAsBytes, 0, keyIdAsBytes.Length, keyIdAsBytes, 0);
                sha_C.TransformBlock(truncatedKeySeed, 0, truncatedKeySeed.Length, truncatedKeySeed, 0);
                sha_C.TransformFinalBlock(keyIdAsBytes, 0, keyIdAsBytes.Length);
                byte[] sha_C_Output = sha_C.Hash;

                for (int i = 0; i < EncryptionUtils.KeySizeInBytesForAes128; i++)
                {
                    contentKey[i] = Convert.ToByte(  sha_A_Output[i] ^ sha_A_Output[i + EncryptionUtils.KeySizeInBytesForAes128]
                                                   ^ sha_B_Output[i] ^ sha_B_Output[i + EncryptionUtils.KeySizeInBytesForAes128]
                                                   ^ sha_C_Output[i] ^ sha_C_Output[i + EncryptionUtils.KeySizeInBytesForAes128]);
                }
            }
            return contentKey;
        }

    }
}
