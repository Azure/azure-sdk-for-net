//-----------------------------------------------------------------------
// <copyright file="MutableStorageCredentials.cs" company="Microsoft">
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
//    Contains code for the MutableStorageCredentials class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Microsoft.WindowsAzure.StorageClient;

    /// <summary>
    /// Represents a <see cref="StorageCredentials"/> object that is mutable to support key rotation.
    /// </summary>
    internal sealed class MutableStorageCredentials : StorageCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MutableStorageCredentials"/> class.
        /// </summary>
        public MutableStorageCredentials() 
        {
            this.Current = StorageCredentialsAnonymous.Anonymous;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MutableStorageCredentials"/> class.
        /// </summary>
        /// <param name="initialCredentials">The initial credentials.</param>
        public MutableStorageCredentials(StorageCredentials initialCredentials)
        {
            this.Current = initialCredentials;
        }

        /// <summary>
        /// Gets the name of the storage account associated with the specified credentials.
        /// </summary>
        /// <value>The account name.</value>
        public override string AccountName 
        {
            get { return this.Current.AccountName; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ComputeHmac"/> method will return a valid
        /// HMAC-encoded signature string when called with the specified credentials.
        /// </summary>
        /// <value>
        /// Returns <c>true</c> if these credentials will yield a valid signature string; otherwise, <c>false</c>.
        /// </value>
        public override bool CanComputeHmac
        {
            get { return this.Current.CanComputeHmac; }
        }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key authentication
        /// scheme using the specified credentials.
        /// </summary>
        /// <value>
        /// Returns <c>true</c> if a request can be signed with these credentials; otherwise, <c>false</c>.
        /// </value>
        public override bool CanSignRequest
        {
            get { return this.Current.CanSignRequest; }
        }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key Lite authentication
        /// scheme using the specified credentials.
        /// </summary>
        /// <value>
        /// Returns <c>true</c> if a request can be signed with these credentials; otherwise, <c>false</c>.
        /// </value>
        public override bool CanSignRequestLite
        {
            get { return this.Current.CanSignRequestLite; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="TransformUri"/> method must be called
        /// before generating a signature string with the specified credentials.
        /// </summary>
        /// <value>
        /// Returns <c>true</c> if [needs transform Uri]; otherwise, <c>false</c>. If <c>false</c>,
        /// calling <see cref="TransformUri"/> returns the original, unmodified Uri.
        /// </value>
        public override bool NeedsTransformUri
        {
            get { return this.Current.NeedsTransformUri; }
        }

        /// <summary>
        /// Gets or sets the current <see cref="StorageCredentials"/> object that this instance represents.
        /// </summary>
        internal StorageCredentials Current { get; set; }

        /// <summary>
        /// Updates the object with new credentials.
        /// </summary>
        /// <param name="newCredentials">The new credentials.</param>
        public void UpdateWith(StorageCredentials newCredentials)
        {
            this.Current = newCredentials;
        }

        /// <summary>
        /// Computes the HMAC signature of the specified string.
        /// </summary>
        /// <param name="stringToSign">The string to sign.</param>
        /// <returns>The computed signature.</returns>
        public override string ComputeHmac(string stringToSign)
        {
            return this.Current.ComputeHmac(stringToSign);
        }

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key authentication scheme.
        /// </summary>
        /// <param name="request">The request to be signed.</param>
        public override void SignRequest(HttpWebRequest request)
        {
            this.Current.SignRequest(request);
        }

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key Lite authentication scheme.
        /// </summary>
        /// <param name="request">The request to be signed.</param>
        public override void SignRequestLite(HttpWebRequest request)
        {
            this.Current.SignRequestLite(request);
        }

        /// <summary>
        /// Transforms the Uri.
        /// </summary>
        /// <param name="resourceURI">The resource Uri.</param>
        /// <returns>The transformed Uri.</returns>
        public override string TransformUri(string resourceURI)
        {
            return this.Current.TransformUri(resourceURI);
        }

        /// <summary>
        /// Computes the 512-bit HMAC signature of the specified string.
        /// </summary>
        /// <param name="stringToSign">The string to sign.</param>
        /// <returns>The computed signature.</returns>
        protected internal override string ComputeHmac512(string stringToSign)
        {
            return this.Current.ComputeHmac512(stringToSign);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="exportSecrets">If set to <c>true</c> the string exposes key information.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        protected internal override string ToString(bool exportSecrets)
        {
            return this.Current.ToString(exportSecrets);
        }
    }
}
