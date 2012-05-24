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
using System.Collections;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents a collection of content keys.
    /// </summary>
    public abstract class BaseContentKeyCollection : BaseCollection<IContentKey>
    {
        protected IQueryable<IContentKey> ContentKeyQueryable { get; set; }

        /// <summary>
        /// Creates a content key with the specifies key identifier and value.
        /// </summary>
        /// <param name="keyId">The key identifier.</param>
        /// <param name="contentKey">The value of the content key.</param>
        /// <returns>A <see cref="IContentKey"/> that can be associated with an <see cref="IAsset"/>.</returns>
        public IContentKey Create(Guid keyId, byte[] contentKey)
        {
            return Create(keyId, contentKey, string.Empty);
        }

        /// <summary>
        /// Creates a content key with the specifies key identifier and value.
        /// </summary>
        /// <param name="keyId">The key identifier.</param>
        /// <param name="contentKey">The value of the content key.</param>
        /// <param name="name">A friendly name for the content key.</param>
        /// <returns>A <see cref="IContentKey"/> that can be associated with an <see cref="IAsset"/>.</returns>
        public abstract IContentKey Create(Guid keyId, byte[] contentKey, string name);

        /// <summary>
        /// Deletes the specified content key.
        /// </summary>
        /// <param name="contentKey">The content key to delete.</param>
        public abstract void Delete(IContentKey contentKey);

        protected static void VerifyContentKey(IContentKey contentKey)
        {
            if (!(contentKey is ContentKeyData))
            {
                throw new InvalidCastException(StringTable.ErrorInvalidContentKeyType);
            }
        }

        internal static ContentKeyData CreateStorageContentKey(FileEncryption fileEncryption, X509Certificate2 cert)
        {
            byte[] encryptedContentKey = fileEncryption.EncryptContentKeyToCertificate(cert);

            ContentKeyData contentKeyData = new ContentKeyData
            {
                Id = fileEncryption.GetKeyIdentifierAsString(),
                EncryptedContentKey = Convert.ToBase64String(encryptedContentKey),
                ContentKeyType = (int)ContentKeyType.StorageEncryption,
                ProtectionKeyId = cert.Thumbprint,
                ProtectionKeyType = (int)ProtectionKeyType.X509CertificateThumbprint,
                Checksum = fileEncryption.GetChecksum()
            };

            return contentKeyData;
        }

        internal static ContentKeyData CreateCommonContentKey(Guid keyId, byte[] contentKey, string name, X509Certificate2 cert)
        {
            byte[] encryptedContentKey = CommonEncryption.EncryptContentKeyToCertificate(cert, contentKey);

            ContentKeyData contentKeyData = new ContentKeyData
            {
                Id = EncryptionUtils.GetKeyIdentifierAsString(keyId),
                EncryptedContentKey = Convert.ToBase64String(encryptedContentKey),
                ContentKeyType = (int)ContentKeyType.CommonEncryption,
                ProtectionKeyId = cert.Thumbprint,
                ProtectionKeyType = (int)ProtectionKeyType.X509CertificateThumbprint,
                Name = name,
                Checksum = EncryptionUtils.CalculateChecksum(contentKey, keyId)
            };

            return contentKeyData;
        }

        internal static ContentKeyData CreateConfigurationContentKey(ConfigurationEncryption configEncryption, X509Certificate2 cert)
        {
            byte[] encryptedContentKey = configEncryption.EncryptContentKeyToCertificate(cert);

            ContentKeyData contentKeyData = new ContentKeyData
            {
                Id = configEncryption.GetKeyIdentifierAsString(),
                EncryptedContentKey = Convert.ToBase64String(encryptedContentKey),
                ContentKeyType = (int)ContentKeyType.ConfigurationEncryption,
                ProtectionKeyId = cert.Thumbprint,
                ProtectionKeyType = (int)ProtectionKeyType.X509CertificateThumbprint,
                Checksum = configEncryption.GetChecksum()
            };

            return contentKeyData;
        }

        internal static string GetProtectionKeyIdForContentKey(DataServiceContext dataContext, ContentKeyType contentKeyType)
        {
            //
            //  First query Nimbus to find out what certificate to encrypt the content key with
            //
            string uriString = string.Format(CultureInfo.InvariantCulture, "/GetProtectionKeyId?contentKeyType={0}", Convert.ToInt32(contentKeyType, CultureInfo.InvariantCulture));
            Uri uriGetProtectionKeyId = new Uri(uriString, UriKind.Relative);
            IEnumerable<string> results = dataContext.Execute<string>(uriGetProtectionKeyId);
            return results.Single();        
        }

        internal static X509Certificate2 GetCertificateForProtectionKeyId(DataServiceContext dataContext, string protectionKeyId)
        {
            //
            //  First check to see if we have the cert in our store already
            //
            X509Certificate2 certToUse = EncryptionUtils.GetCertificateFromStore(protectionKeyId);

            if ((certToUse == null) && (dataContext != null))
            {
                //
                //  If not, download it from Nimbus to use
                //
                Uri uriGetProtectionKey = new Uri(string.Format(CultureInfo.InvariantCulture, "/GetProtectionKey?protectionKeyId='{0}'", protectionKeyId), UriKind.Relative);
                IEnumerable<string> results2 = dataContext.Execute<string>(uriGetProtectionKey);
                string certString = results2.Single();

                byte[] certBytes = Convert.FromBase64String(certString);
                certToUse = new X509Certificate2(certBytes);

                //
                //  Finally save it for next time
                //
                EncryptionUtils.SaveCertificateToStore(certToUse);
            }

            return certToUse;
        }

        internal static X509Certificate2 GetCertificateToEncryptContentKey(DataServiceContext dataContext, ContentKeyType contentKeyType)
        {
            string thumbprint = GetProtectionKeyIdForContentKey(dataContext, contentKeyType);

            return GetCertificateForProtectionKeyId(dataContext, thumbprint);
        }
    }
}
