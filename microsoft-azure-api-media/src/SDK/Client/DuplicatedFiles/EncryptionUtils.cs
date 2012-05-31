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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Globalization;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public static class EncryptionUtils
    {
        private const string _keyIdentifierPrefix = "nb:kid:UUID:"; 

        public const int KeySizeInBytesForAes128 = 16;
        public const int KeySizeInBytesForAes256 = 32;
        public const int KeySizeInBitsForAes128 = 128;
        public const int KeySizeInBitsForAes256 = 256;

        public const int IVSizeInBytesForAesCbc = 16;

        public static string GetKeyIdentifierAsString(Guid keyIdentifier)
        {
            return _keyIdentifierPrefix + keyIdentifier.ToString();
        }

        public static Guid GetKeyIdAsGuid(string keyIdentifier)
        {
            if (string.IsNullOrEmpty(keyIdentifier))
            {
                throw new ArgumentException("Key Identifier string cannot be null or empty.", "keyIdentifier");
            }

            if (keyIdentifier.StartsWith(_keyIdentifierPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return new Guid(keyIdentifier.Substring(_keyIdentifierPrefix.Length));
            }
            else
            {
                throw new ArgumentException("Key Identifier string was not in the expected format.", "keyIdentifier");
            }
        }

        public static byte[] EncryptSymmetricKey(X509Certificate2 cert, SymmetricAlgorithm aes)
        {
            if (aes == null)
            {
                throw new ArgumentNullException("aes");
            }

            return EncryptSymmetricKeyData(cert, aes.Key);
        }

        public static byte[] EncryptSymmetricKeyData(X509Certificate2 cert, byte[] keyData)
        {
            if (cert == null)
            {
                throw new ArgumentNullException("cert");
            }

            if (keyData == null)
            {
                throw new ArgumentNullException("keyData");
            }

            RSACryptoServiceProvider rsaPublicKey = cert.PublicKey.Key as RSACryptoServiceProvider;

            RSAOAEPKeyExchangeFormatter keyFormatter = new RSAOAEPKeyExchangeFormatter(rsaPublicKey);

            return keyFormatter.CreateKeyExchange(keyData);
        }

        public static byte[] DecryptSymmetricKey(X509Certificate2 cert, byte[] encryptedData)
        {
            AsymmetricAlgorithm rsaPrivateKey = null;
            RSAOAEPKeyExchangeDeformatter keyFormatter = null;

            if (cert == null)
            {
                throw new ArgumentNullException("cert");
            }

            if (!cert.HasPrivateKey)
            {
                throw new ArgumentException("Certificate does not have a private key which is a requirment for decryption.", "cert");
            }

            try
            {
                rsaPrivateKey = cert.PrivateKey;
            }
            catch (CryptographicException ce)
            {
                if (ce.Message.Contains("Keyset does not exist"))
                {
                    IdentityReference currentUser = WindowsIdentity.GetCurrent().Owner as IdentityReference;
                    string message = String.Format(CultureInfo.CurrentCulture, "Unable to create the RSAOAEPKeyExchangeDeformatter likely due to the access permissions on the private key.  Check to see if the current user has access to the private key for the certificate with thumbprint={0}.  Current User is {1}.", cert.Thumbprint, currentUser.ToString());
                    throw new InvalidOperationException(message, ce);
                }
                else
                {
                    throw;
                }
            }

            keyFormatter = new RSAOAEPKeyExchangeDeformatter(rsaPrivateKey);

            return keyFormatter.DecryptKeyExchange(encryptedData);
        }

        public static X509Certificate2 GetCertificateFromStore(string certificateThumbprint)
        {
            return GetCertificateFromStore(certificateThumbprint, StoreLocation.CurrentUser) ??
                   GetCertificateFromStore(certificateThumbprint, StoreLocation.LocalMachine);
        }

        public static X509Certificate2 GetCertificateFromStore(string certificateThumbprint, StoreLocation location)
        {
            X509Certificate2 returnValue = null;

            if (string.IsNullOrEmpty(certificateThumbprint))
            {
                throw new ArgumentException("Cannot be null or empty", "certificateThumbprint");
            }

            //
            // Get the certificate store for the current user.
            //
            X509Store store = new X509Store(location);

            try
            {
                store.Open(OpenFlags.ReadOnly);

                // TODO: 18979, Design the solution for protecting content keys
                //              Right now we use the shared development certificate but that is a very
                //              weak story from a operational robustness standpoint.
                //
                //       Our current Nimbus certificate isn't necessarily in the trusted root store.  We likely will be
                //       using a download certificate anyway in the future but we need to come up with a long term plan
                //       for the root of trust of our content keys.
                //X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, true);
                X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, false);

                if (certs.Count > 0)
                {
                    returnValue = certs[0];
                }
            }
            finally
            {
                store.Close();
            }

            return returnValue;
        }

        public static void SaveCertificateToStore(X509Certificate2 certToStore)
        {
            X509Store store = new X509Store(StoreLocation.CurrentUser);

            try
            {
                store.Open(OpenFlags.ReadWrite);

                store.Add(certToStore);
            }
            finally
            {
                store.Close();
            }
        }

        public static string CalculateChecksum(byte[] contentKey, Guid keyId)
        {
            const int checksumLength = 8;
            const int keyIdLength = 16;
            byte[] encryptedKeyId = null;

            //
            // Checksum is computed by AES-ECB encrypting the KID
            // with the content key.
            //
            using (AesCryptoServiceProvider rijndael = new AesCryptoServiceProvider())
            {
                rijndael.Mode = CipherMode.ECB;
                rijndael.Key = contentKey;
                rijndael.Padding = PaddingMode.None;

                ICryptoTransform encryptor = rijndael.CreateEncryptor();
                encryptedKeyId = new byte[keyIdLength];
                encryptor.TransformBlock(keyId.ToByteArray(), 0, keyIdLength, encryptedKeyId, 0);
            }

            byte[] retVal = new byte[checksumLength];
            Array.Copy(encryptedKeyId, retVal, checksumLength);

            return Convert.ToBase64String(retVal);
        }
    }
}
