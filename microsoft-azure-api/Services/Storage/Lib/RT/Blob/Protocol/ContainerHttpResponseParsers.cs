// -----------------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static partial class ContainerHttpResponseParsers
    {
        /// <summary>
        /// Gets the container's properties from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The container's attributes.</returns>
        public static BlobContainerProperties GetProperties(HttpResponseMessage response)
        {
            // Set the container properties
            BlobContainerProperties containerProperties = new BlobContainerProperties();
            containerProperties.ETag = (response.Headers.ETag == null) ? null :
                response.Headers.ETag.ToString();

            if (response.Content != null)
            {
                containerProperties.LastModified = response.Content.Headers.LastModified;
            }
            else
            {
                containerProperties.LastModified = null;
            }

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
        /// <returns>A <see cref="IDictionary"/> of the metadata.</returns>
        public static IDictionary<string, string> GetMetadata(HttpResponseMessage response)
        {
            return HttpResponseParsers.GetMetadata(response);
        }

        /// <summary>
        /// Gets the ACL for the container from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A value indicating the public access level for the container.</returns>
        public static BlobContainerPublicAccessType GetAcl(HttpResponseMessage response)
        {
            string acl = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.BlobPublicAccess);
            return GetContainerAcl(acl);
        }
    }
}
