//-----------------------------------------------------------------------
// <copyright file="StorageCredentialsAccountAndKey.cs" company="Microsoft">
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
//    Contains code for the StorageCredentialsAccountAndKey class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure
{
    using System;
    using System.Net;
    using Microsoft.WindowsAzure.StorageClient.Protocol;

    /// <summary>
    /// Represents storage account credentials for accessing the Windows Azure storage services.
    /// </summary>
    public sealed class StorageCredentialsAccountAndKey : StorageCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentialsAccountAndKey"/> class, using the storage account name and 
        /// access key.
        /// </summary>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="key">The account access key, as an array of bytes.</param>
        public StorageCredentialsAccountAndKey(string accountName, byte[] key)
        {
            this.Credentials = new Credentials(accountName, key);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentialsAccountAndKey"/> class, using the storage account name and 
        /// access key.
        /// </summary>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="key">The account access key, as a Base64-encoded string.</param>
        public StorageCredentialsAccountAndKey(string accountName, string key)
        {
            this.Credentials = new Credentials(accountName, key);
        }

        /// <summary>
        /// Gets a <see cref="Credentials"/> object that references the storage account name and access key.
        /// </summary>
        /// <value>An object containing a reference to the storage account name and access key.</value>
        public Credentials Credentials { get; internal set; }

        /// <summary>
        /// Gets the name of the storage account associated with the specified credentials.
        /// </summary>
        /// <value>The name of the storage account.</value>
        public override string AccountName
        {
            get { return Credentials.AccountName; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="TransformUri"/> method should be called
        /// to transform a resource URI to a URI that includes a token for a shared access signature.
        /// </summary>
        /// <value><c>False</c> for objects of type <see cref="StorageCredentialsAccountAndKey"/>.</value>
         public override bool NeedsTransformUri
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key authentication
        /// scheme using the specified credentials.
        /// </summary>
        /// <value><c>True</c> for objects of type <see cref="StorageCredentialsAccountAndKey"/>.</value>
        public override bool CanSignRequest
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key Lite authentication
        /// scheme using the specified credentials.
        /// </summary>
        /// <value><c>True</c> for objects of type <see cref="StorageCredentialsAccountAndKey"/>.</value>
        public override bool CanSignRequestLite
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ComputeHmac"/> method will return a valid
        /// HMAC-encoded signature string when called using the specified credentials.
        /// </summary>
        /// <value><c>True</c> for objects of type <see cref="StorageCredentialsAccountAndKey"/>.</value>
        public override bool CanComputeHmac
        {
            get { return true; }
        }

        /// <summary>
        /// Transforms a resource URI into a shared access signature URI, by appending a
        /// shared access token. For objects of type <see cref="StorageCredentialsAccountAndKey"/>, this operation
        /// returns the resource URI that is passed to it..
        /// </summary>
        /// <param name="resourceUri">The resource URI to be transformed.</param>
        /// <returns>The URI for a shared access signature, including the resource URI and the shared access token.</returns>
        public override string TransformUri(string resourceUri)
        {
            return resourceUri;
        }

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key authentication scheme.
        /// </summary>
        /// <param name="request">The web request to be signed.</param>
        public override void SignRequest(HttpWebRequest request)
        {
            Request.SignRequestForBlobAndQueue(request, Credentials);
        }

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key Lite authentication scheme.
        /// </summary>
        /// <param name="request">The web request to be signed.</param>
        public override void SignRequestLite(HttpWebRequest request)
        {
            Request.SignRequestForTablesSharedKeyLite(request, Credentials);            
        }

        /// <summary>
        /// Encodes a Shared Key or Shared Key Lite signature string by using the HMAC-SHA256 algorithm over a UTF-8-encoded string-to-sign.
        /// </summary>
        /// <param name="value">A UTF-8-encoded string-to-sign.</param>
        /// <returns>An HMAC-encoded signature string.</returns>
        public override string ComputeHmac(string value)
        {
            return StorageKey.ComputeMacSha256(Credentials.Key, value);
        }

        /// <summary>
        /// Gets the base64 encoded key.
        /// </summary>
        /// <returns>The base64 encoded key.</returns>
        internal string GetBase64EncodedKey()
        {
            return Credentials.Key.GetBase64EncodedKey();
        }

        /// <summary>
        /// Performs the computation of the signature based on the private key.
        /// </summary>
        /// <param name="value">The string that should be signed.</param>
        /// <returns>The signature for the string.</returns>
        protected internal override string ComputeHmac512(string value)
        {
            return StorageKey.ComputeMacSha512(Credentials.Key, value);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="exportSecrets">If set to <c>true</c> exports secrets.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        protected internal override string ToString(bool exportSecrets)
        {
            return String.Format(
                "{0}={1};{2}={3}",
                CloudStorageAccount.AccountNameName,
                this.AccountName,
                CloudStorageAccount.AccountKeyName,
                exportSecrets ? this.GetBase64EncodedKey() : "[key hidden]");
        }
    }
}
