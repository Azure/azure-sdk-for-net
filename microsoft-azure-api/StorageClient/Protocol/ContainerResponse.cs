//-----------------------------------------------------------------------
// <copyright file="ContainerResponse.cs" company="Microsoft">
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
//    Contains code for the ContainerResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Specialized;
    using System.Net;

    /// <summary>
    /// Provides a set of methods for parsing responses from container operations.
    /// </summary>
    public static class ContainerResponse
    {
        /// <summary>
        /// Returns extended error information from the storage service, that is in addition to the HTTP status code returned with the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>An object containing extended error information returned with the response.</returns>
        public static StorageExtendedErrorInformation GetError(HttpWebResponse response)
        {
            return Response.GetError(response);
        }

        /// <summary>
        /// Gets a collection of user-defined metadata from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A collection of user-defined metadata, as name-value pairs.</returns>
        public static NameValueCollection GetMetadata(HttpWebResponse response)
        {
            return Response.GetMetadata(response);
        }

        /// <summary>
        /// Gets an array of values for a specified name-value pair from the user-defined metadata included in the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <param name="name">The name associated with the metadata values to return.</param>
        /// <returns>An array of metadata values.</returns>
        public static string[] GetMetadata(HttpWebResponse response, string name)
        {
            return Response.GetMetadata(response, name);
        }

        /// <summary>
        /// Gets the container's attributes, including its metadata and properties, from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The container's attributes.</returns>
        public static BlobContainerAttributes GetAttributes(HttpWebResponse response)
        {
            var containerAttributes = new BlobContainerAttributes();
            containerAttributes.Uri = new Uri(response.ResponseUri.GetLeftPart(UriPartial.Path));
            var segments = containerAttributes.Uri.Segments;
            containerAttributes.Name = segments[segments.Length - 1];

            var containerProperties = containerAttributes.Properties;
            containerProperties.ETag = response.Headers[HttpResponseHeader.ETag];
            containerProperties.LastModifiedUtc = response.LastModified.ToUniversalTime();

            containerAttributes.Metadata = GetMetadata(response);

            return containerAttributes;
        }

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
        /// Gets the ACL for the container from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A value indicating the public access level for the container.</returns>
        public static string GetAcl(HttpWebResponse response)
        {
            return Response.GetHeaders(response)[Constants.HeaderConstants.BlobPublicAccess];
        }

        /// <summary>
        /// Parses the response for a container listing operation.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>An object that may be used for parsing data from the results of a container listing operation.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Storage only supports HTTP")]
        public static ListContainersResponse List(HttpWebResponse response)
        {
            return new ListContainersResponse(response.GetResponseStream());
        }
    }
}
