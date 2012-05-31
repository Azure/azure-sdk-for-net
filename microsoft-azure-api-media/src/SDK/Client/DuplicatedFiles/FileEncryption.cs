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
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public class FileEncryption : IDisposable
    {
        public static readonly string SchemeVersion = "1.0";
        public static readonly string SchemeName = "StorageEncryption";

        private Object _lockObject = new Object();
        private RNGCryptoServiceProvider _rng;
        private SymmetricAlgorithm _key;
        private Dictionary<string, ulong> _ivListByFileName = new Dictionary<string, ulong>();

        public FileEncryption()
        {
            InternalInit(null, Guid.NewGuid()); // the SymmetricAlgorithm will randomly generate a key for us
        }

        public FileEncryption(byte[] contentKey, Guid keyIdentifier)
        {
            if (keyIdentifier == Guid.Empty)
            {
                throw new ArgumentException("Guid.Empty is not a valid keyIdentifier");
            }

            InternalInit(contentKey, keyIdentifier);
        }

        public Guid KeyIdentifier { get; private set; }

        public string GetKeyIdentifierAsString()
        {
            return EncryptionUtils.GetKeyIdentifierAsString(KeyIdentifier);
        }

        public byte[] GetContentKey()
        {
            return _key.Key;
        }

        public string GetChecksum()
        {
            return EncryptionUtils.CalculateChecksum(_key.Key, KeyIdentifier);
        }

        private void InternalInit(byte[] contentKey, Guid keyIdentifier)
        {
            if ((contentKey != null) && (contentKey.Length != EncryptionUtils.KeySizeInBytesForAes256))
            {
                throw new ArgumentOutOfRangeException("contentKey", "StorageEncryption content keys are 256-bits in length.");
            }

            KeyIdentifier = keyIdentifier;

            _key = new AesCryptoServiceProvider();
            _key.Mode = CipherMode.ECB;
            _key.Padding = PaddingMode.None;
            if (contentKey != null)
            {
                _key.Key = contentKey;
            }
            else
            {
                _key.KeySize = EncryptionUtils.KeySizeInBitsForAes256;
            }
        }

        public bool IsInitializationVectorPresent(string fileName)
        {
            bool returnValue = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            using (CriticalSection.Enter(_lockObject))
			{
                returnValue = _ivListByFileName.ContainsKey(fileName);
            }

            return returnValue;
        
        }

        public ulong CreateInitializationVectorForFile(string fileName)
        {
            ulong iv = 0;
            bool duplicateIv = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            using (CriticalSection.Enter(_lockObject))
            {
                if (null == _rng)
                {
                    _rng = new RNGCryptoServiceProvider();
                }

                byte[] ivAsBytes = new byte[sizeof(UInt64)];

                do
                {
                    _rng.GetBytes(ivAsBytes);
                    iv = BitConverter.ToUInt64(ivAsBytes, 0);

                    // Each file protected by a given key must have a unique iv value.
                    // One of the issues with using CTR mode is that reusing counter
                    // values can lead to an attack on the encryption. To prevent that, 
                    // we use a unique 64-bit IV value per file.  The remaining 64 bits 
                    // of the counter value are a block counter ensuring that each block
                    // in the file has a unique counter value IF each file has a unique 
                    // 64-bit IV value.
                    duplicateIv = _ivListByFileName.ContainsValue(iv);

                } while (duplicateIv);

                _ivListByFileName.Add(fileName, iv);
            }

            return iv;
        }

        public ulong GetInitializationVectorForFile(string fileName)
        {
            ulong returnValue = 0;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            using (CriticalSection.Enter(_lockObject))
            {
                returnValue = _ivListByFileName[fileName];
            }

            return returnValue;
        }

        public void SetInitializationVectorForFile(string fileName, ulong ivToSet)
        {
            ulong temp = 0;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            using (CriticalSection.Enter(_lockObject))
            {
                if (!_ivListByFileName.TryGetValue(fileName, out temp))
                {
                    _ivListByFileName.Add(fileName, ivToSet);
                }
                else
                {
                    if (_ivListByFileName[fileName] != ivToSet)
                    {
                        string message = string.Format(CultureInfo.CurrentCulture, "An initialization vector is already set for {0}.", fileName);
                        throw new InvalidOperationException(message);
                    }
                }
            }
        }

        public byte[] EncryptContentKeyToCertificate(X509Certificate2 certToUse)
        {
            return EncryptionUtils.EncryptSymmetricKey(certToUse, _key);
        }

        public FileEncryptionTransform GetTransform(string fileName)
        {
            return GetTransform(fileName, 0);
        }

        public FileEncryptionTransform GetTransform(string fileName, long fileOffset)
        {
            ulong iv = 0;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            if (IsInitializationVectorPresent(fileName))
            {
                iv = GetInitializationVectorForFile(fileName);
            }
            else
            {
                iv = CreateInitializationVectorForFile(fileName);
            }

            return GetTransform(iv, fileOffset);
        }

        public FileEncryptionTransform GetTransform(ulong initializationVector)
        {
            return GetTransform(initializationVector, 0);
        }

        public FileEncryptionTransform GetTransform(ulong initializationVector, long fileOffset)
        {
            ICryptoTransform transform = null;

            using (CriticalSection.Enter(_lockObject))
            {
                transform = _key.CreateEncryptor(); // Note that ECB encrypt is always used for AES-CTR whether doing encryption or decryption
            }

            return new FileEncryptionTransform(transform, initializationVector, fileOffset);
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
                if (_key != null)
                {
                    _key.Dispose();
                    _key = null;
                }

                if (_rng != null)
                {
                    _rng.Dispose();
                    _rng = null;
                }            
            }
        }
    }
}
