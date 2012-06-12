//-----------------------------------------------------------------------
// <copyright file="AccessCondition.cs" company="Microsoft">
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
// <summary>
//    Contains code for the AccessCondition class.
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
    public class AccessCondition
    {
        /// <summary>
        /// Time for IfModifiedSince.
        /// </summary>
        private DateTime? ifModifiedSinceDateTime;

        /// <summary>
        /// Time for IfUnmodifiedSince.
        /// </summary>
        private DateTime? ifNotModifiedSinceDateTime;

        /// <summary>
        /// Gets or sets an ETag that must match the ETag of a resource.
        /// </summary>
        /// <value>A quoted ETag string. If null, no condition exists.</value>
        public string IfMatchETag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets an ETag that must not match the ETag of a resource.
        /// </summary>
        /// <value>A quoted ETag string, or <c>"*"</c> to match any ETag. If null, no condition exists.</value>
        public string IfNoneMatchETag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a time that must be before the last modification of a resource.
        /// </summary>
        /// <value>A <c>DateTime</c> in UTC, or null if no condition exists.</value>
        public DateTime? IfModifiedSinceTime
        {
            get
            {
                return this.ifModifiedSinceDateTime;
            }

            set
            {
                this.ifModifiedSinceDateTime = value.HasValue ? value.Value.ToUniversalTime() : value;
            }
        }

        /// <summary>
        /// Gets or sets a time that must not be before the last modification of a resource.
        /// </summary>
        /// <value>A <c>DateTime</c> in UTC, or null if no condition exists.</value>
        public DateTime? IfNotModifiedSinceTime
        {
            get
            {
                return this.ifNotModifiedSinceDateTime;
            }

            set
            {
                this.ifNotModifiedSinceDateTime = value.HasValue ? value.Value.ToUniversalTime() : value;
            }
        }

        /// <summary>
        /// Gets or sets a lease ID that must match the lease on a resource.
        /// </summary>
        /// <value>A lease ID, or null if no condition exists.</value>
        public string LeaseId
        {
            get;
            set;
        }

        /// <summary>
        /// Constructs an empty access condition.
        /// </summary>
        /// <returns>An empty access condition.</returns>
        public static AccessCondition GenerateEmptyCondition()
        {
            return new AccessCondition();
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource's ETag value
        /// matches the specified ETag value.
        /// </summary>
        /// <param name="etag">The ETag value that must be matched.</param>
        /// <returns>An <c>AccessCondition</c> object that represents the If-Match condition.</returns>
        public static AccessCondition GenerateIfMatchCondition(string etag)
        {
            return new AccessCondition { IfMatchETag = etag };
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource has been
        /// modified since the specified time.
        /// </summary>
        /// <param name="modifiedTime">The time that must be before the last modified time of the resource.</param>
        /// <returns>An <c>AccessCondition</c> object that represents the If-Modified-Since condition.</returns>
        public static AccessCondition GenerateIfModifiedSinceCondition(DateTime modifiedTime)
        {
            return new AccessCondition { IfModifiedSinceTime = modifiedTime };
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource's ETag value
        /// does not match the specified ETag value.
        /// </summary>
        /// <param name="etag">The ETag value that must be matched, or <c>"*"</c>.</param>
        /// <returns>An <c>AccessCondition</c> object that represents the If-None-Match condition.</returns>
        /// <remarks>
        /// If <c>"*"</c> is specified as the parameter then this condition requires that the resource does not exist.
        /// </remarks>
        public static AccessCondition GenerateIfNoneMatchCondition(string etag)
        {
            return new AccessCondition { IfNoneMatchETag = etag };
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource has not been
        /// modified since the specified time.
        /// </summary>
        /// <param name="modifiedTime">The time that must not be before the last modified time of the resource.</param>
        /// <returns>An <c>AccessCondition</c> object that represents the If-Unmodified-Since condition.</returns>
        public static AccessCondition GenerateIfNotModifiedSinceCondition(DateTime modifiedTime)
        {
            return new AccessCondition { IfNotModifiedSinceTime = modifiedTime };
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the lease ID on the
        /// resource matches the specified lease ID.
        /// </summary>
        /// <param name="leaseId">The lease ID that must match the lease ID of the resource.</param>
        /// <returns>An <c>AccessCondition</c> object that represents the lease condition.</returns>
        public static AccessCondition GenerateLeaseCondition(string leaseId)
        {
            return new AccessCondition { LeaseId = leaseId };
        }

        /// <summary>
        /// Applies the condition to the web request.
        /// </summary>
        /// <param name="request">The request to be modified.</param>
        /// <param name="applyToSource">Whether to use the source headers when applying the request.</param>
        internal void ApplyCondition(HttpWebRequest request, bool applyToSource)
        {
            if (applyToSource)
            {
                if (!string.IsNullOrEmpty(this.IfMatchETag))
                {
                    request.Headers[Constants.HeaderConstants.SourceIfMatchHeader] = this.IfMatchETag;
                }

                if (this.IfModifiedSinceTime.HasValue)
                {
                    request.Headers[Constants.HeaderConstants.SourceIfModifiedSinceHeader]
                        = this.IfModifiedSinceTime.Value.ToString("R", CultureInfo.InvariantCulture);
                }

                if (!string.IsNullOrEmpty(this.IfNoneMatchETag))
                {
                    request.Headers[Constants.HeaderConstants.SourceIfNoneMatchHeader] = this.IfNoneMatchETag;
                }

                if (this.IfNotModifiedSinceTime.HasValue)
                {
                    request.Headers[Constants.HeaderConstants.SourceIfUnmodifiedSinceHeader]
                        = this.IfNotModifiedSinceTime.Value.ToString("R", CultureInfo.InvariantCulture);
                }

                if (!string.IsNullOrEmpty(this.LeaseId))
                {
                    throw new InvalidOperationException("A lease ID may not be specified as a source access condition.");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.IfMatchETag))
                {
                    request.Headers[HttpRequestHeader.IfMatch] = this.IfMatchETag;
                }

                if (this.IfModifiedSinceTime.HasValue)
                {
                    // Not using this property will cause Restricted property exception to be thrown
                    request.IfModifiedSince = this.IfModifiedSinceTime.Value;
                }

                if (!string.IsNullOrEmpty(this.IfNoneMatchETag))
                {
                    request.Headers[HttpRequestHeader.IfNoneMatch] = this.IfNoneMatchETag;
                }

                if (this.IfNotModifiedSinceTime.HasValue)
                {
                    request.Headers[HttpRequestHeader.IfUnmodifiedSince]
                        = this.IfNotModifiedSinceTime.Value.ToString("R", CultureInfo.InvariantCulture);
                }

                if (!string.IsNullOrEmpty(this.LeaseId))
                {
                    request.Headers[Constants.HeaderConstants.LeaseIdHeader] = this.LeaseId;
                }
            }
        }

        /// <summary>
        /// Verifies the condition is satisfied.
        /// </summary>
        /// <param name="etag">The ETag to check.</param>
        /// <param name="lastModifiedTime">The last modified time.</param>
        /// <returns><c>true</c> if the condition is satisfied, otherwise <c>false</c>.</returns>
        internal bool VerifyConditionHolds(string etag, DateTime lastModifiedTime)
        {
            if (!string.IsNullOrEmpty(this.IfMatchETag))
            {
                if (etag != this.IfMatchETag && this.IfMatchETag != "*")
                {
                    return false;
                }
            }

            if (this.IfModifiedSinceTime.HasValue && lastModifiedTime <= this.IfModifiedSinceTime.Value)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(this.IfNoneMatchETag))
            {
                if (etag == this.IfNoneMatchETag || this.IfNoneMatchETag == "*")
                {
                    return false;
                }
            }

            if (this.IfNotModifiedSinceTime.HasValue && lastModifiedTime > this.IfNotModifiedSinceTime.Value)
            {
                return false;
            }

            return true;
        }
    }
}
