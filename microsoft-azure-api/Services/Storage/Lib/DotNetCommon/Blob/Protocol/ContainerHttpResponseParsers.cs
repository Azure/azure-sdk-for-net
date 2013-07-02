//-----------------------------------------------------------------------
// <copyright file="ContainerHttpResponseParsers.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// Provides a set of methods for parsing a response containing container data from the Blob service.
    /// </summary>
    public static partial class ContainerHttpResponseParsers
    {
        /// <summary>
        /// Gets the request ID from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A unique value associated with the request.</returns>
        public static string GetRequestId(HttpWebResponse response)
        {
            return Response.GetRequestId(response);
        }

        /// <summary>
        /// Gets the container's properties from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The container's attributes.</returns>
        public static BlobContainerProperties GetProperties(HttpWebResponse response)
        {
            // Set the container properties
            BlobContainerProperties containerProperties = new BlobContainerProperties();
            containerProperties.ETag = HttpResponseParsers.GetETag(response);
            containerProperties.LastModified = response.LastModified.ToUniversalTime();

            // Get lease properties
            containerProperties.LeaseStatus = BlobHttpResponseParsers.GetLeaseStatus(response);
            containerProperties.LeaseState = BlobHttpResponseParsers.GetLeaseState(response);
            containerProperties.LeaseDuration = BlobHttpResponseParsers.GetLeaseDuration(response);

            return containerProperties;
        }

        /// <summary>
        /// Gets the user-defined metadata.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <returns>A <see cref="System.Collections.Generic.IDictionary{T,K}"/> of the metadata.</returns>
        public static IDictionary<string, string> GetMetadata(HttpWebResponse response)
        {
            return HttpResponseParsers.GetMetadata(response);
        }

        /// <summary>
        /// Gets the ACL for the container from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A value indicating the public access level for the container.</returns>
        public static BlobContainerPublicAccessType GetAcl(HttpWebResponse response)
        {
            string acl = response.Headers[Constants.HeaderConstants.BlobPublicAccess];
            return GetContainerAcl(acl);
        }
    }
}
