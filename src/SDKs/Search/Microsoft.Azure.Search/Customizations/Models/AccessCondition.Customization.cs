// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    public partial class AccessCondition
    {
        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource's current ETag value
        /// matches the specified resource's ETag value.
        /// </summary>
        /// <param name="resource">A resource with an ETag value to check against the resource's ETag.</param>
        /// <returns>An <see cref="Microsoft.Azure.Search.Models.AccessCondition" /> object that represents the If-Match condition.</returns>
        public static AccessCondition IfNotChanged(IResourceWithETag resource)
        {
            Throw.IfArgumentNull(resource, nameof(resource));
            Throw.IfArgumentNullOrEmpty(resource.ETag, $"{nameof(resource)}.{nameof(resource.ETag)}");

            return AccessCondition.GenerateIfMatchCondition(resource.ETag);
        }

        /// <summary>
        /// Constructs an empty access condition.
        /// </summary>
        /// <returns>An empty <see cref="Microsoft.Azure.Search.Models.AccessCondition" /> object.</returns>
        public static AccessCondition GenerateEmptyCondition()
        {
            return new AccessCondition();
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource exists.
        /// </summary>
        /// <returns>An <see cref="Microsoft.Azure.Search.Models.AccessCondition" /> object that represents a condition where a resource exists.</returns>
        /// <remarks>Setting this access condition modifies the request to include the HTTP <i>If-Match</i> conditional header set to <c>"*"</c>.</remarks>
        public static AccessCondition GenerateIfExistsCondition()
        {
            return new AccessCondition(ifMatch: "*");
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource's current ETag value
        /// matches the specified ETag value.
        /// </summary>
        /// <param name="eTag">The ETag value to check against the resource's ETag.</param>
        /// <returns>An <see cref="Microsoft.Azure.Search.Models.AccessCondition" /> object that represents the If-Match condition.</returns>
        public static AccessCondition GenerateIfMatchCondition(string eTag)
        {
            Throw.IfArgumentNullOrEmpty(eTag, nameof(eTag));

            return new AccessCondition(ifMatch: eTag);
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource does not exist.
        /// </summary>
        /// <returns>An <see cref="Microsoft.Azure.Search.Models.AccessCondition" /> object that represents a condition where a resource does not exist.</returns>
        /// <remarks>Setting this access condition modifies the request to include the HTTP <i>If-None-Match</i> conditional header set to <c>"*"</c>.</remarks>
        public static AccessCondition GenerateIfNotExistsCondition()
        {
            return new AccessCondition(ifNoneMatch: "*");
        }

        /// <summary>
        /// Constructs an access condition such that an operation will be performed only if the resource's current ETag value
        /// does not match the specified ETag value.
        /// </summary>
        /// <param name="eTag">The ETag value to check against the resource's ETag.</param>
        /// <returns>An <see cref="Microsoft.Azure.Search.Models.AccessCondition" /> object that represents the If-None-Match condition.</returns>
        public static AccessCondition GenerateIfNoneMatchCondition(string eTag)
        {
            Throw.IfArgumentNullOrEmpty(eTag, nameof(eTag));

            return new AccessCondition(ifNoneMatch: eTag);
        }
    }
}
