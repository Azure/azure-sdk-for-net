//-----------------------------------------------------------------------
// <copyright file="StorageCredentials.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Auth
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a set of credentials used to authenticate access to a Windows Azure storage account.
    /// </summary>
    public sealed class StorageCredentials
    {
        private UriQueryBuilder queryBuilder;

        /// <summary>
        /// Gets the associated shared access signature token for the credentials.
        /// </summary>
        /// <value>The shared access signature token.</value>
        public string SASToken { get; private set; }

        /// <summary>
        /// Gets the associated account name for the credentials.
        /// </summary>
        /// <value>The account name.</value>
        public string AccountName { get; private set; }

        /// <summary>
        /// Gets the associated key name for the credentials.
        /// </summary>
        /// <value>The key name.</value>
        public string KeyName { get; private set; }

        internal byte[] KeyValue { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the credentials are for anonymous access.
        /// </summary>
        /// <value><c>true</c> if the credentials are for anonymous access; otherwise, <c>false</c>.</value>
        public bool IsAnonymous
        {
            get
            {
                return (this.SASToken == null) && (this.AccountName == null);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the credentials are a shared access signature token.
        /// </summary>
        /// <value><c>true</c> if the credentials are a shared access signature token; otherwise, <c>false</c>.</value>
        public bool IsSAS
        {
            get
            {
                return (this.SASToken != null) && (this.AccountName == null);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the credentials are a shared key.
        /// </summary>
        /// <value><c>true</c> if the credentials are a shared key; otherwise, <c>false</c>.</value>
        public bool IsSharedKey
        {
            get
            {
                return (this.SASToken == null) && (this.AccountName != null);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentials"/> class.
        /// </summary>
        public StorageCredentials()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentials"/> class with the specified account name and key value.
        /// </summary>
        /// <param name="accountName">A string that represents the name of the storage account.</param>
        /// <param name="keyValue">A string that represents the Base-64-encoded account access key.</param>
        public StorageCredentials(string accountName, string keyValue)
            : this(accountName, keyValue, null)
        {
        }

#if DNCP
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentials"/> class with the specified account name and key value.
        /// </summary>
        /// <param name="accountName">A string that represents the name of the storage account.</param>
        /// <param name="keyValue">An array of bytes that represent the account access key.</param>
        public StorageCredentials(string accountName, byte[] keyValue)
            : this(accountName, keyValue, null)
        {
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentials"/> class with the specified account name, key value, and key name.
        /// </summary>
        /// <param name="accountName">A string that represents the name of the storage account.</param>
        /// <param name="keyValue">A string that represents the Base-64-encoded account access key.</param>
        /// <param name="keyName">A string that represents the name of the key.</param>
        public StorageCredentials(string accountName, string keyValue, string keyName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException("accountName");
            }

            this.AccountName = accountName;
            this.UpdateKey(keyValue, keyName);
        }

#if DNCP
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentials"/> class with the specified account name, key value, and key name.
        /// </summary>
        /// <param name="accountName">A string that represents the name of the storage account.</param>
        /// <param name="keyValue">An array of bytes that represent the account access key.</param>
        /// <param name="keyName">A string that represents the name of the key.</param>
        public StorageCredentials(string accountName, byte[] keyValue, string keyName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException("accountName");
            }

            this.AccountName = accountName;
            this.UpdateKey(keyValue, keyName);
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentials"/> class with the specified shared access signature token.
        /// </summary>
        /// <param name="sasToken">A string representing the shared access signature token.</param>
        public StorageCredentials(string sasToken)
        {
            if (string.IsNullOrEmpty(sasToken))
            {
                throw new ArgumentNullException("sasToken");
            }

            this.queryBuilder = new UriQueryBuilder();
            IDictionary<string, string> parameters = HttpUtility.ParseQueryString(sasToken);
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                this.queryBuilder.Add(parameter.Key, parameter.Value);
            }

            this.SASToken = sasToken;
        }

        /// <summary>
        /// Updates the key value and key name for the credentials.
        /// </summary>
        /// <param name="keyValue">The key value, as a Base-64 encoded string, to update.</param>
        /// <param name="keyName">The key name to update.</param>
        public void UpdateKey(string keyValue, string keyName)
        {
            if (!this.IsSharedKey)
            {
                string errorMessage = string.Format(SR.CannotUpdateKeyWithoutAccountKeyCreds);
                throw new InvalidOperationException(errorMessage);
            }
            
            if (keyValue == null)
            {
                throw new ArgumentNullException("keyValue");
            }

            this.KeyName = keyName;
            this.KeyValue = Convert.FromBase64String(keyValue);
        }

#if DNCP
        /// <summary>
        /// Updates the key value and key name for the credentials.
        /// </summary>
        /// <param name="keyValue">The key value, as an array of bytes, to update.</param>
        /// <param name="keyName">The key name to update.</param>
        public void UpdateKey(byte[] keyValue, string keyName)
        {
            if (!this.IsSharedKey)
            {
                string errorMessage = string.Format(SR.CannotUpdateKeyWithoutAccountKeyCreds);
                throw new InvalidOperationException(errorMessage);
            }

            if (keyValue == null)
            {
                throw new ArgumentNullException("keyValue");
            }

            this.KeyName = keyName;
            this.KeyValue = (byte[])keyValue.Clone();
        }
#endif

        /// <summary>
        /// Returns the key for the credentials.
        /// </summary>
        /// <returns>An array of bytes that contains the key.</returns>
        public byte[] ExportKey()
        {
            return (byte[])this.KeyValue.Clone();
        }

        /// <summary>
        /// Transforms a resource URI into a shared access signature URI, by appending a shared access token.
        /// </summary>
        /// <param name="resourceUri">A <see cref="Uri"/> object that represents the resource URI to be transformed.</param>
        /// <returns>A <see cref="Uri"/> object that represents the signature, including the resource URI and the shared access token.</returns>
        public Uri TransformUri(Uri resourceUri)
        {
            if (this.IsSAS)
            {
                return this.queryBuilder.AddToUri(resourceUri);
            }
            else
            {
                return resourceUri;
            }
        }

        internal string GetBase64EncodedKey()
        {
            return (this.KeyValue == null) ? null : Convert.ToBase64String(this.KeyValue);
        }

        internal string ToString(bool exportSecrets)
        {
            if (this.IsSharedKey)
            {
                return string.Format(
                    "{0}={1};{2}={3}",
                    CloudStorageAccount.AccountNameSettingString,
                    this.AccountName,
                    CloudStorageAccount.AccountKeySettingString,
                    exportSecrets ? this.GetBase64EncodedKey() : "[key hidden]");
            }

            if (this.IsSAS)
            {
                return string.Format("{0}={1}", CloudStorageAccount.SharedAccessSignatureSettingString, exportSecrets ? this.SASToken : "[signature hidden]");
            }

            return string.Empty;
        }

        /// <summary>
        /// Determines whether an other <see cref="StorageCredentials"/> object is equal to this one by comparing their SAS tokens, account names, key names, and key values.
        /// </summary>
        /// <param name="other">The <see cref="StorageCredentials"/> object to compare to this one.</param>
        /// <returns><c>true</c> if the two <see cref="StorageCredentials"/> objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(StorageCredentials other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return string.Equals(this.SASToken, other.SASToken) &&
                    string.Equals(this.AccountName, other.AccountName) &&
                    string.Equals(this.KeyName, other.KeyName) &&
                    string.Equals(this.GetBase64EncodedKey(), other.GetBase64EncodedKey());
            }
        }
    }
}
