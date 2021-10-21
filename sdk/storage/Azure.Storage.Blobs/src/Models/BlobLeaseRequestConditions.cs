// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies access conditions for leasing operations on a container or blob.
    /// </summary>
    public class BlobLeaseRequestConditions : RequestConditions
    {
        /// <summary>
        /// Optional SQL statement to apply to the Tags of the Blob.
        /// </summary>
        public string TagConditions { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlobLeaseRequestConditions()
        {
        }

        internal BlobLeaseRequestConditions(BlobLeaseRequestConditions deepCopySource)
        {
            Argument.AssertNotNull(deepCopySource, nameof(deepCopySource));

            TagConditions = deepCopySource.TagConditions;

            // can't get to Azure.Core internals from here; copy it's values here

            // Azure.MatchConditions
            IfMatch = deepCopySource.IfMatch;
            IfNoneMatch = deepCopySource.IfNoneMatch;

            // Azure.RequestConditions
            IfModifiedSince = deepCopySource.IfModifiedSince;
            IfUnmodifiedSince = deepCopySource.IfUnmodifiedSince;
        }

        /// <summary>
        /// Creates a deep copy of the given instance, if any.
        /// </summary>
        /// <param name="deepCopySource">Instance to deep copy.</param>
        /// <returns>The deep copy, or null.</returns>
        internal static BlobLeaseRequestConditions CloneOrDefault(BlobLeaseRequestConditions deepCopySource)
        {
            if (deepCopySource == default)
            {
                return default;
            }
            return new BlobLeaseRequestConditions(deepCopySource);
        }
    }
}
