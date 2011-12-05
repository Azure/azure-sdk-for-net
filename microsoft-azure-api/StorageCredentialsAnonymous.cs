//-----------------------------------------------------------------------
// <copyright file="StorageCredentialsAnonymous.cs" company="Microsoft">
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
//    Contains code for the StorageCredentialsAnonymous class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure
{
    using System;
    using System.Net;

    /// <summary>
    /// Class that represents credentials for anonymous access. Used by internal implementaion.
    /// </summary>
    internal sealed class StorageCredentialsAnonymous : StorageCredentials
    {
        /// <summary>
        /// Stores the singleton instance of this class.
        /// </summary>
        public static readonly StorageCredentials Anonymous = new StorageCredentialsAnonymous();

        /// <summary>
        /// Prevents a default instance of the <see cref="StorageCredentialsAnonymous"/> class from being created.
        /// </summary>
        private StorageCredentialsAnonymous()
        {
        }

        /// <summary>
        /// Gets account name information if available. Else returns null.
        /// </summary>
        public override string AccountName
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="TransformUri"/> method must be called
        /// before generating a signature string with the specified credentials.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if needs transform Uri; otherwise, <c>false</c>. If <c>false</c>,
        /// calling <see cref="TransformUri"/> returns the original, unmodified Uri.
        /// </value>
        public override bool NeedsTransformUri
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether SignRequest will perform signing when using this credentials.
        /// False means SignRequest will not do anything.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if a request can be signed with these credentials; otherwise, <c>false</c>.
        /// </value>
        public override bool CanSignRequest
        {
            get { return false; }
        }

        /// <summary>
        /// Returns whether SignRequestLite will perform signing when using this credentials. 
        /// False means SignRequestLite will not do anything.
        /// </summary>
        public override bool CanSignRequestLite
        {
            get { return false; }
        }

        /// <summary>
        /// Returns whether ComputeHMAC will return a valid HMAC when using this credentials.
        /// False means ComputeHmac will return null.
        /// </summary>
        /// <value>
        /// Returns <c>true</c> if these credentials will yield a valid signature string; otherwise, <c>false</c>.
        /// </value>
        public override bool CanComputeHmac
        {
            get { return false; }
        }

        /// <summary>
        /// A potential transformation to the Uri for signing purposes. The transformation may append to the string.
        /// </summary>
        /// <param name="resourceUri">The resource Uri to be transformed.</param>
        /// <returns>The new resource Uri that includes any transformations required for signing.</returns>
        /// <remarks>Identity operation for anonymous access.</remarks>
        public override string TransformUri(string resourceUri)
        {
            return resourceUri;
        }

        /// <summary>
        /// An operation that may add any required authentication headers based for the credential type. (SharedKey algorithm).
        /// </summary>
        /// <param name="request">The request that needs to be signed.</param>
        /// <remarks>No op for anonymous access.</remarks>
        public override void SignRequest(HttpWebRequest request)
        { 
            // No op 
        }

        /// <summary>
        /// An operation that may add any required authentication headers based for the credential type. (SharedKeyLite algorithm used for LINQ for Tables).
        /// </summary>
        /// <param name="request">The request that needs to be signed.</param>
        /// <remarks>No op for anonymous access.</remarks>
        public override void SignRequestLite(HttpWebRequest request)
        { 
            // No op
        }

        /// <summary>
        /// Performs the computation of the signature based on the private key.
        /// </summary>
        /// <param name="value">The string that should be signed.</param>
        /// <returns>The signature for the string.</returns>
        /// <remarks>Returns null representing no op.</remarks>
        public override string ComputeHmac(string value)
        {
            return null;
        }

        /// <summary>
        /// Performs the computation of the signature based on the private key.
        /// </summary>
        /// <param name="value">The string to be signed.</param>
        /// <returns>The signature for the string.</returns>
        /// <remarks> Need for D-SAS not public.</remarks>
        protected internal override string ComputeHmac512(string value)
        {
            return null;
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
            return String.Empty;
        }
    }
}
