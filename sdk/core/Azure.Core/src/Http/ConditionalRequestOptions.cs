// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Http
{
    /// <summary>
    /// Specifies HTTP options for conditional requests.
    /// </summary>
    public class ConditionalRequestOptions
    {
        /// <summary>
        /// Optionally limit requests to resources that have a matching ETag.
        /// </summary>
        public ETag? IfMatch { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that do not match the ETag.
        /// </summary>
        public ETag? IfNoneMatch { get; set; }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource has changed.
        /// </summary>
        /// <param name="etag">The version of the resource to compare to.</param>
        public virtual void SetIfModifiedCondition(ETag etag)
        {
            IfNoneMatch = etag;
        }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource has not changed.
        /// </summary>
        public virtual void SetIfUnmodifiedCondition(ETag etag)
        {
            IfMatch = etag;
        }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource is present.
        /// </summary>
        public virtual void SetIfExistsCondition()
        {
            IfMatch = ETag.All;
        }

        /// <summary>
        /// Set preconditions that indicate to apply an operation only if the
        /// target resource is not present.
        /// </summary>
        public virtual void SetIfNotExistsCondition()
        {
            IfNoneMatch = ETag.All;
        }
    }
}
