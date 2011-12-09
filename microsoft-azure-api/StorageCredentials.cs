//-----------------------------------------------------------------------
// <copyright file="StorageCredentials.cs" company="Microsoft">
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
//    Contains code for the StorageCredentials class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure
{
    using System.Net;

    /// <summary>
    /// Represents a set of credentials used to authenticate access to a Windows Azure storage account.
    /// </summary>
    public abstract class StorageCredentials
    {
        /// <summary>
        /// Gets the name of the storage account associated with the specified credentials.
        /// </summary>
        /// <value>The name of the account.</value>
        public abstract string AccountName { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="TransformUri"/> method should be called
        /// to transform a resource URI to a URI that includes a token for a shared access signature.
        /// </summary>
        /// <value><c>True</c> if the URI must be transformed; otherwise, <c>false</c>.</value>
        public abstract bool NeedsTransformUri { get; }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key authentication 
        /// scheme using the specified credentials.
        /// </summary>
        /// <value><c>True</c> if a request can be signed with these credentials; otherwise, <c>false</c>.</value>
        public abstract bool CanSignRequest { get; }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key Lite authentication
        /// scheme using the specified credentials.
        /// </summary>
        /// <value><c>True</c> if a request can be signed with these credentials; otherwise, <c>false</c>.</value>
        public abstract bool CanSignRequestLite { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ComputeHmac"/> method will return a valid
        /// HMAC-encoded signature string when called using the specified credentials.
        /// </summary>
        /// <value><c>True</c> if these credentials will yield a valid signature string; otherwise, <c>false</c>.</value>
        public abstract bool CanComputeHmac { get; }

        /// <summary>
        /// Transforms a resource URI into a shared access signature URI, by appending a
        /// shared access token. 
        /// </summary>
        /// <param name="resourceUri">The resource URI to be transformed.</param>
        /// <returns>The URI for a shared access signature, including the resource URI and the shared access token. </returns>
        public abstract string TransformUri(string resourceUri);

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key authentication scheme.
        /// </summary>
        /// <param name="request">The web request to be signed.</param>
        public abstract void SignRequest(HttpWebRequest request);

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key Lite authentication scheme.
        /// </summary>
        /// <param name="request">The web request to be signed.</param>
        public abstract void SignRequestLite(HttpWebRequest request);

        /// <summary>
        /// Encodes a Shared Key or Shared Key Lite signature string by using the HMAC-SHA256 algorithm over a UTF-8-encoded string-to-sign.
        /// </summary>
        /// <param name="value">A UTF-8-encoded string-to-sign.</param>
        /// <returns>An HMAC-encoded signature string.</returns>
        public abstract string ComputeHmac(string value);

        /// <summary>
        /// Performs the computation of the signature based on the private key.
        /// </summary>
        /// <param name="value">The string to be signed.</param>
        /// <returns>The signature for the string.</returns>
        /// <remarks> Need for D-SAS not public.</remarks>
        protected internal abstract string ComputeHmac512(string value);

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="exportSecrets">If set to <c>true</c> exports secrets.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        protected internal abstract string ToString(bool exportSecrets);
    }
}