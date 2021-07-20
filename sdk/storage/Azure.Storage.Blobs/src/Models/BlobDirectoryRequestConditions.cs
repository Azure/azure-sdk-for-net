// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for Blob Directory Requests
    /// </summary>
    public class BlobDirectoryRequestConditions
    {
        /// <summary>
        /// Optionally limit requests to resources that have only been modified since this
        /// point in time.
        /// </summary>
        public DateTimeOffset? IfModifiedSince { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that have remained unmodified.
        /// </summary>
        public DateTimeOffset? IfUnmodifiedSince { get; set; }
        /// <summary>
        /// Collect any request conditions.  Conditions should be separated by
        /// a semicolon.
        /// </summary>
        /// <param name="conditions">The collected conditions.</param>
        internal virtual void AddConditions(StringBuilder conditions)
        {
            if (IfModifiedSince != null)
            {
                conditions.Append(nameof(IfModifiedSince)).Append('=').Append(IfModifiedSince).Append(';');
            }

            if (IfUnmodifiedSince != null)
            {
                conditions.Append(nameof(IfUnmodifiedSince)).Append('=').Append(IfUnmodifiedSince).Append(';');
            }
        }
    }
}
