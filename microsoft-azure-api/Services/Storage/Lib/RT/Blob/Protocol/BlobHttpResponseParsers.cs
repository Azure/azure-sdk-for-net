// -----------------------------------------------------------------------------------------
// <copyright file="BlobHttpResponseParsers.cs" company="Microsoft">
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
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static partial class BlobHttpResponseParsers
    {
        /// <summary>
        /// Gets the blob's properties from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The blob's properties.</returns>
        public static BlobProperties GetProperties(HttpResponseMessage response)
        {
            BlobProperties properties = new BlobProperties();

            if (response.Content != null)
            {
                properties.LastModified = response.Content.Headers.LastModified;
                properties.ContentEncoding = HttpWebUtility.CombineHttpHeaderValues(response.Content.Headers.ContentEncoding);
                properties.ContentLanguage = HttpWebUtility.CombineHttpHeaderValues(response.Content.Headers.ContentLanguage);

                if (response.Content.Headers.ContentMD5 != null)
                {
                    properties.ContentMD5 = Convert.ToBase64String(response.Content.Headers.ContentMD5);
                }

                if (response.Content.Headers.ContentType != null)
                {
                    properties.ContentType = response.Content.Headers.ContentType.ToString();
                }

                // Get the content length. Prioritize range and x-ms over content length for the special cases.
                string contentLengthHeader = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.BlobContentLengthHeader);
                if ((response.Content.Headers.ContentRange != null) &&
                    response.Content.Headers.ContentRange.HasLength)
                {
                    properties.Length = response.Content.Headers.ContentRange.Length.Value;
                }
                else if (!string.IsNullOrEmpty(contentLengthHeader))
                {
                    properties.Length = long.Parse(contentLengthHeader);
                }
                else if (response.Content.Headers.ContentLength.HasValue)
                {
                    properties.Length = response.Content.Headers.ContentLength.Value;
                }
            }

            if (response.Headers.CacheControl != null)
            {
                properties.CacheControl = response.Headers.CacheControl.ToString();
            }

            if (response.Headers.ETag != null)
            {
                properties.ETag = response.Headers.ETag.ToString();
            }

            // Get blob type
            string blobType = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.BlobType);
            if (!string.IsNullOrEmpty(blobType))
            {
                properties.BlobType = (BlobType)Enum.Parse(typeof(BlobType), blobType, true);
            }

            // Get lease properties
            properties.LeaseStatus = GetLeaseStatus(response);
            properties.LeaseState = GetLeaseState(response);
            properties.LeaseDuration = GetLeaseDuration(response);

            // Get sequence number
            string sequenceNumber = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.BlobSequenceNumber);
            if (!string.IsNullOrEmpty(sequenceNumber))
            {
                properties.PageBlobSequenceNumber = long.Parse(sequenceNumber);
            }

            return properties;
        }

        /// <summary>
        /// Extracts the lease status from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A <see cref="LeaseStatus"/> enumeration from the web response.</returns>
        /// <remarks>If the appropriate header is not present, a status of <see cref="LeaseStatus.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The header contains an unrecognized value.</exception>
        public static LeaseStatus GetLeaseStatus(HttpResponseMessage response)
        {
            string leaseStatus = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.LeaseStatus);
            return GetLeaseStatus(leaseStatus);
        }

        /// <summary>
        /// Extracts the lease state from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A <see cref="LeaseState"/> enumeration from the web response.</returns>
        /// <remarks>If the appropriate header is not present, a status of <see cref="LeaseState.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The header contains an unrecognized value.</exception>
        public static LeaseState GetLeaseState(HttpResponseMessage response)
        {
            string leaseState = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.LeaseState);
            return GetLeaseState(leaseState);
        }

        /// <summary>
        /// Extracts the lease duration from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A <see cref="LeaseDuration"/> enumeration from the web response.</returns>
        /// <remarks>If the appropriate header is not present, a status of <see cref="LeaseDuration.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The header contains an unrecognized value.</exception>
        public static LeaseDuration GetLeaseDuration(HttpResponseMessage response)
        {
            string leaseDuration = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.LeaseDurationHeader);
            return GetLeaseDuration(leaseDuration);
        }

        /// <summary>
        /// Extracts the lease ID header from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The lease ID.</returns>
        public static string GetLeaseId(HttpResponseMessage response)
        {
            return response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.LeaseIdHeader);
        }

        /// <summary>
        /// Extracts the remaining lease time from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The remaining lease time, in seconds.</returns>
        public static int? GetRemainingLeaseTime(HttpResponseMessage response)
        {
            string leaseTime = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.LeaseTimeHeader);
            int remainingLeaseTime;
            if (int.TryParse(leaseTime, out remainingLeaseTime))
            {
                return remainingLeaseTime;
            }
            else
            {
                return null;
            }
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
        /// Extracts a <see cref="CopyState"/> object from the headers of a web response.
        /// </summary>
        /// <param name="response">The HTTP web response.</param>
        /// <returns>A <see cref="CopyState"/> object, or null if the web response does not contain a copy status.</returns>
        public static CopyState GetCopyAttributes(HttpResponseMessage response)
        {
            string copyStatusString = response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.CopyStatusHeader);
            if (!string.IsNullOrEmpty(copyStatusString))
            {
                return GetCopyAttributes(
                    copyStatusString,
                    response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.CopyIdHeader),
                    response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.CopySourceHeader),
                    response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.CopyProgressHeader),
                    response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.CopyCompletionTimeHeader),
                    response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.CopyDescriptionHeader));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the snapshot timestamp from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The snapshot timestamp.</returns>
        public static string GetSnapshotTime(HttpResponseMessage response)
        {
            return response.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.SnapshotHeader);
        }
    }
}
