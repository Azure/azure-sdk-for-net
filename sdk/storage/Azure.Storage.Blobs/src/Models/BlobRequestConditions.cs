﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies blob lease access conditions for a container or blob.
    /// </summary>
    public class BlobRequestConditions : BlobLeaseRequestConditions
    {
        /// <summary>
        /// Optionally limit requests to resources with an active lease
        /// matching this Id.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Converts the value of the current RequestConditions object to
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the RequestConditions.
        /// </returns>
        public override string ToString()
        {
            StringBuilder conditions = new StringBuilder();
            conditions.Append('[').Append(GetType().Name);
            AddConditions(conditions);
            if (conditions[conditions.Length - 1] == ';')
            {
                conditions[conditions.Length - 1] = ']';
            }
            else
            {
                conditions.Append(']');
            }
            return conditions.ToString();
        }

        /// <summary>
        /// Collect any request conditions.  Conditions should be separated by
        /// a semicolon.
        /// </summary>
        /// <param name="conditions">The collected conditions.</param>
        internal virtual void AddConditions(StringBuilder conditions)
        {
            if (IfMatch != null)
            {
                conditions.Append(nameof(IfMatch)).Append('=').Append(IfMatch).Append(';');
            }

            if (IfNoneMatch != null)
            {
                conditions.Append(nameof(IfNoneMatch)).Append('=').Append(IfNoneMatch).Append(';');
            }

            if (IfModifiedSince != null)
            {
                conditions.Append(nameof(IfModifiedSince)).Append('=').Append(IfModifiedSince).Append(';');
            }

            if (IfUnmodifiedSince != null)
            {
                conditions.Append(nameof(IfUnmodifiedSince)).Append('=').Append(IfUnmodifiedSince).Append(';');
            }

            if (LeaseId != null)
            {
                conditions.Append(nameof(LeaseId)).Append('=').Append(LeaseId).Append(';');
            }

            if (TagConditions != null)
            {
                conditions.Append(nameof(TagConditions)).Append('=').Append(TagConditions).Append(';');
            }
        }
    }
}
