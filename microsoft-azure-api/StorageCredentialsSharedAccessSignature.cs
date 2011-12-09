//-----------------------------------------------------------------------
// <copyright file="StorageCredentialsSharedAccessSignature.cs" company="Microsoft">
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
//    Contains code for the StorageCredentialsSharedAccessSignature class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure
{
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Web;
    using Microsoft.WindowsAzure.StorageClient.Protocol;

    /// <summary>
    /// Represents storage credentials for delegated access to Blob service resources
    /// via a shared access signature. 
    /// </summary>
    public class StorageCredentialsSharedAccessSignature : StorageCredentials
    {
        /// <summary>
        /// Stores the shared access signature token.
        /// </summary>
        private string token;

        /// <summary>
        /// Stores the internal <see cref="UriQueryBuilder"/> used to transform Uris.
        /// </summary>
        private UriQueryBuilder builder = new UriQueryBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCredentialsSharedAccessSignature"/> class 
        /// with the specified shared access token.
        /// </summary>
        /// <param name="token">A string token representing a shared access signature.</param>
        public StorageCredentialsSharedAccessSignature(string token)
        {
            NameValueCollection parameters = HttpUtility.ParseQueryString(token);

            for (int index = 0; index < parameters.Count; index++)
            {
                this.builder.Add(parameters.Keys[index], parameters[index]);
            }

            this.token = token;
        }

        /// <summary>
        /// Gets the name of the storage account associated with the specified credentials.
        /// </summary>
        /// <value>The name of the account.</value>
        public override string AccountName
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="TransformUri"/> method should be called
        /// to transform a resource URI to a URI that includes a token for a shared access signature.
        /// </summary>
        /// <value><c>True</c> for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.</value>
        public override bool NeedsTransformUri
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key authentication
        /// scheme using the specified credentials.
        /// </summary>
        /// <value><c>False</c> for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.</value>
        public override bool CanSignRequest
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether a request can be signed under the Shared Key Lite authentication
        /// scheme using the specified credentials.
        /// </summary>
        /// <value><c>False</c> for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.</value>
        public override bool CanSignRequestLite
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ComputeHmac"/> method will return a valid
        /// HMAC-encoded signature string when called using the specified credentials.
        /// </summary>
        /// <value><c>False</c> for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.</value>
        public override bool CanComputeHmac
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>The token.</value>
        internal string Token
        {
            get
            {
                return this.token;
            }
        }

        /// <summary>
        /// Transforms a resource URI into a shared access signature URI, by appending a
        /// shared access token.
        /// </summary>
        /// <param name="resourceUri">The resource URI to be transformed.</param>
        /// <returns>The URI for a shared access signature, including the resource URI and the shared access token.</returns>
        public override string TransformUri(string resourceUri)
        {
            // Simply concatenating token will not work if the uri has other parameters
            Uri transformedUri = this.builder.AddToUri(new Uri(resourceUri, UriKind.RelativeOrAbsolute));
            return transformedUri.AbsoluteUri;            
        }

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key authentication scheme.
        /// This is not a valid operation for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.
        /// </summary>
        /// <param name="request">The web request to be signed.</param>
        public override void SignRequest(HttpWebRequest request)
        {
            return; // No-op
        }

        /// <summary>
        /// Signs a request using the specified credentials under the Shared Key Lite authentication scheme.
        /// This is not a valid operation for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.
        /// </summary>
        /// <param name="request">The web request object to be signed.</param>
        public override void SignRequestLite(HttpWebRequest request)
        {
            return; // No-op
        }

        /// <summary>
        /// Encodes a Shared Key or Shared Key Lite signature string by using the HMAC-SHA256 algorithm over a UTF-8-encoded string-to-sign. 
        /// This is not a valid operation for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.
        /// </summary>
        /// <param name="value">A UTF-8-encoded string-to-sign.</param>
        /// <returns><c>Null</c> for objects of type <see cref="StorageCredentialsSharedAccessSignature"/>.</returns>
        public override string ComputeHmac(string value)
        {
            return null;
        }

        /// <summary>
        /// Encodes the signature string by using the HMAC-SHA-512 algorithm over 
        /// the UTF-8-encoded string-to-sign.
        /// </summary>
        /// <param name="value">The UTF-8-encoded string-to-sign.</param>
        /// <returns>The HMAC-encoded signature string.</returns>
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
            return String.Format("{0}={1}", CloudStorageAccount.SharedAccessSignatureName, exportSecrets ? this.token : "[signature hidden]");
        }
    }
}
