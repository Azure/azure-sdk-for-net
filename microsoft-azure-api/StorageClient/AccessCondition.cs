//-----------------------------------------------------------------------
// <copyright file="AccessCondition.cs" company="Microsoft">
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
//    Contains code for the AccessCondition struct.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Globalization;
    using System.Net;
    using Protocol;

    /// <summary>
    /// Represents a set of access conditions to be used for operations against the storage services.
    /// </summary>
    public struct AccessCondition
    {
        /// <summary>
        /// Indicates that no access condition is set.
        /// </summary>
        public static readonly AccessCondition None = new AccessCondition();

        /// <summary>
        /// Gets or sets the header of the request to be set.
        /// </summary>
        /// <value>The access condition header.</value>
        private HttpRequestHeader? AccessConditionHeader { get; set; }

        /// <summary>
        /// Gets or sets the value of the access condition header.
        /// </summary>
        /// <value>The access condition header value.</value>
        private string AccessConditionValue { get; set; }

        /// <summary>
        /// Returns an access condition such that an operation will be performed only if the resource has been modified since the specified time.
        /// </summary>
        /// <param name="lastModifiedUtc">The last-modified time for the resource, expressed as a UTC value.</param>
        /// <returns>A structure specifying the if-modified-since condition.</returns>
        public static AccessCondition IfModifiedSince(DateTime lastModifiedUtc)
        {
            lastModifiedUtc = lastModifiedUtc.ToUniversalTime();
            return new AccessCondition
            {
                AccessConditionHeader = HttpRequestHeader.IfModifiedSince,

                // convert Date to String using RFC 1123 pattern
                AccessConditionValue = lastModifiedUtc.ToString("R", CultureInfo.InvariantCulture)
            };
        }

        /// <summary>
        /// Returns an access condition such that an operation will be performed only if the resource has not been modified since the specified time.
        /// </summary>
        /// <param name="lastModifiedUtc">The last-modified time for the resource, expressed as a UTC value.</param>
        /// <returns>A structure specifying the if-not-modified-since condition.</returns>
        public static AccessCondition IfNotModifiedSince(DateTime lastModifiedUtc)
        {
            lastModifiedUtc = lastModifiedUtc.ToUniversalTime();
            return new AccessCondition
            {
                AccessConditionHeader = HttpRequestHeader.IfUnmodifiedSince,

                // convert Date to String using RFC 1123 pattern
                AccessConditionValue = Request.ConvertDateTimeToHttpString(lastModifiedUtc)
            };
        }

        /// <summary>
        /// Returns an access condition such that an operation will be performed only if the resource's ETag value matches the ETag value provided.
        /// </summary>
        /// <param name="etag">The ETag value to check.</param>
        /// <returns>A structure specifying the if-match condition.</returns>
        public static AccessCondition IfMatch(string etag)
        {
            return new AccessCondition { AccessConditionHeader = HttpRequestHeader.IfMatch, AccessConditionValue = etag };
        }

        /// <summary>
        /// Returns an access condition such that an operation will be performed only if the resource's ETag value does not match the ETag value provided.
        /// </summary>
        /// <param name="etag">The ETag value to check.</param>
        /// <returns>A structure specifying the if-none-match condition.</returns>
        public static AccessCondition IfNoneMatch(string etag)
        {
            return new AccessCondition { AccessConditionHeader = HttpRequestHeader.IfNoneMatch, AccessConditionValue = etag };
        }

        /// <summary>
        /// Converts AccessCondition into a <see cref="ConditionHeaderKind"/> type for use as a source conditional to Copy.
        /// </summary>
        /// <param name="condition">The original condition.</param>
        /// <param name="header">The resulting header for the condition.</param>
        /// <param name="value">The value for the condition.</param>
        internal static void GetSourceConditions(
            AccessCondition condition,
            out Protocol.ConditionHeaderKind header,
            out string value)
        {
            header = Protocol.ConditionHeaderKind.None;
            value = null;

            if (condition.AccessConditionHeader != null)
            {
                switch (condition.AccessConditionHeader.GetValueOrDefault())
                {
                    case HttpRequestHeader.IfMatch:
                        header = Protocol.ConditionHeaderKind.IfMatch;
                        break;
                    case HttpRequestHeader.IfNoneMatch:
                        header = Protocol.ConditionHeaderKind.IfNoneMatch;
                        break;
                    case HttpRequestHeader.IfModifiedSince:
                        header = Protocol.ConditionHeaderKind.IfModifiedSince;
                        break;
                    case HttpRequestHeader.IfUnmodifiedSince:
                        header = Protocol.ConditionHeaderKind.IfUnmodifiedSince;
                        break;
                    default:
                        CommonUtils.ArgumentOutOfRange("condition", condition);
                        break;
                }

                value = condition.AccessConditionValue;
            }
        }

        /// <summary>
        /// Applies the condition to the web request.
        /// </summary>
        /// <param name="request">The request to be modified.</param>
        internal void ApplyCondition(HttpWebRequest request)
        {
            if (this.AccessConditionHeader != null)
            {
                if (this.AccessConditionHeader.Equals(HttpRequestHeader.IfModifiedSince))
                {
                    // Not using this property will cause Restricted property exception to be thrown
                    request.IfModifiedSince = DateTime.Parse(
                        this.AccessConditionValue,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AdjustToUniversal);
                }
                else
                {
                    request.Headers[(HttpRequestHeader)this.AccessConditionHeader] = this.AccessConditionValue;
                }
            }
        }

        /// <summary>
        /// Verifies the condition is satisfied.
        /// </summary>
        /// <param name="etag">The ETag to check.</param>
        /// <param name="lastModifiedTimeUtc">The last modified time UTC.</param>
        /// <returns><c>true</c> if the condition is satisfied, otherwise <c>false</c>.</returns>
        internal bool VerifyConditionHolds(string etag, DateTime lastModifiedTimeUtc)
        {
            switch (this.AccessConditionHeader.GetValueOrDefault())
            {
                case HttpRequestHeader.IfMatch:
                    return this.AccessConditionValue == etag || String.Equals(this.AccessConditionValue, "*");
                case HttpRequestHeader.IfNoneMatch:
                    return this.AccessConditionValue != etag;
                case HttpRequestHeader.IfModifiedSince:
                    {
                        var conditional = DateTime.Parse(
                            this.AccessConditionValue,
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.AdjustToUniversal);
                        return lastModifiedTimeUtc > conditional;
                    }

                case HttpRequestHeader.IfUnmodifiedSince:
                    {
                        var conditional = DateTime.Parse(
                            this.AccessConditionValue,
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.AdjustToUniversal);
                        return lastModifiedTimeUtc <= conditional;
                    }

                default:
                    CommonUtils.ArgumentOutOfRange("AccessConditionHeader", this.AccessConditionHeader);
                    return false;
            }
        }
    }
}
