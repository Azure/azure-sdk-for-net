// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
#pragma warning disable SA1649 // File name should match first type name
    internal interface IRequestConditions
    {
        internal interface ILeaseId
        {
            /// <summary>
            /// Optionally limit requests to resources with an active lease
            /// matching this Id.
            /// </summary>
            public string LeaseId { get; set; }
        }

        internal interface ITags
        {
            /// <summary>
            /// Optional SQL statement to apply to the Tags of the Blob.
            /// </summary>
            public string TagConditions { get; set; }
        }

        internal interface IIfModifiedSince
        {
            /// <summary>
            /// Optionally limit requests to resources that have only been
            /// modified since this point in time.
            /// </summary>
            public DateTimeOffset? IfModifiedSince { get; set; }
        }

        internal interface IIfUnmodifiedSince
        {
            /// <summary>
            /// Optionally limit requests to resources that have remained
            /// unmodified.
            /// </summary>
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
        }

        internal interface IIfMatch
        {
            /// <summary>
            /// Optionally limit requests to resources that have a matching ETag.
            /// </summary>
            public ETag? IfMatch { get; set; }
        }

        internal interface IIfNoneMatch
        {
            /// <summary>
            /// Optionally limit requests to resources that do not match the ETag.
            /// </summary>
            public ETag? IfNoneMatch { get; set; }
        }
    }
}
