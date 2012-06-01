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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public class ConfigurationEncryption : IDisposable
    {
        public static readonly string SchemeVersion = "1.0";
        public static readonly string SchemeName = "ConfigurationEncryption";

        private SymmetricAlgorithm _encryptionAlgorithm;
        private const int aesKeySize = 16;

        public ConfigurationEncryption()
        {
            InternalInit(Guid.NewGuid(), null, null); // the SymmetricAlgorithm will randomly generate a key and IV for us
        }

        public ConfigurationEncryption(Guid keyIdentifier, byte[] contentKey, byte[] initializationVector)
        {
            if (keyIdentifier == Guid.Empty)
            {
                throw new ArgumentException("Guid.Empty is not a valid keyIdentifier");
            }

            InternalInit(keyIdentifier, contentKey, initializationVector);
        }

        public Guid KeyIdentifier { get; private set; }

        public byte[] GetContentKey()
        {
            return _encryptionAlgorithm.Key;
        }

        public string GetKeyIdentifierAsString()
        {
            return EncryptionUtils.GetKeyIdentifierAsString(KeyIdentifier);
        }

        public byte[] GetInitializationVector()
        {
            return _encryptionAlgorithm.IV;
        }

        public string GetInitializationVectorAsString()
        {
            return Convert.ToBase64String(_encryptionAlgorithm.IV);
        }

        public static byte[] GetInitializationVectorFromString(string initializationVector)
        {
            return Convert.FromBase64String(initializationVector);
        }

        public string GetChecksum()
        {
            return EncryptionUtils.CalculateChecksum(_encryptionAlgorithm.Key, KeyIdentifier);
        }

        public string Encrypt(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                throw new ArgumentException("The string to encrypt cannot be null or empty.", "original");
            }

            byte[] data = Encoding.UTF8.GetBytes(original);

            byte[] encryptedData = null;
            using (ICryptoTransform transform = _encryptionAlgorithm.CreateEncryptor())
            {
                encryptedData = transform.TransformFinalBlock(data, 0, data.Length);
            }

            return Convert.ToBase64String(encryptedData);
        }

        public string Decrypt(string encryptedValue)
        {
            if (String.IsNullOrEmpty(encryptedValue))
            {
                throw new ArgumentException("The string to decrypt cannot be null or empty.", "encryptedValue");
            }

            byte[] data = Convert.FromBase64String(encryptedValue);
            byte[] decryptedData = null;

            using (ICryptoTransform transform = _encryptionAlgorithm.CreateDecryptor())
            {
                decryptedData = transform.TransformFinalBlock(data, 0, data.Length);
            }

            return Encoding.UTF8.GetString(decryptedData);
        }

        public byte[] EncryptContentKeyToCertificate(X509Certificate2 certToUse)
        {
            return EncryptionUtils.EncryptSymmetricKey(certToUse, _encryptionAlgorithm);
        }

        private void InternalInit(Guid keyIdentifier, byte[] contentKey, byte[] initializationVector)
        {
            if ((contentKey != null) && (contentKey.Length != EncryptionUtils.KeySizeInBytesForAes256))
            {
                throw new ArgumentOutOfRangeException("contentKey", "Configuration Encryption content keys are 256-bits (32 bytes) in length.");
            }

            if ((initializationVector != null) && (initializationVector.Length != EncryptionUtils.IVSizeInBytesForAesCbc))
            {
                throw new ArgumentOutOfRangeException("initializationVector", "Configuration Encryption initialization vectors are 16 bytes in length.");            
            }

            KeyIdentifier = keyIdentifier;

            _encryptionAlgorithm = new AesCryptoServiceProvider();
            _encryptionAlgorithm.Mode = CipherMode.CBC;
            _encryptionAlgorithm.Padding = PaddingMode.PKCS7;
            if (contentKey != null)
            {
                _encryptionAlgorithm.Key = contentKey;
                _encryptionAlgorithm.IV = initializationVector;
            }
            else
            {
                _encryptionAlgorithm.KeySize = EncryptionUtils.KeySizeInBitsForAes256;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            // Take this object off the finalization queue and prevent the finalization
            // code from running a second time.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_encryptionAlgorithm != null)
                {
                    _encryptionAlgorithm.Dispose();
                    _encryptionAlgorithm = null;
                }
            }
        }
    }
}
