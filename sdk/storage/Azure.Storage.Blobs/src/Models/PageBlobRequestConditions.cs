// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies page blob specific access conditions.
    /// </summary>
    public class PageBlobRequestConditions : BlobRequestConditions
    {
        /// <summary>
        /// IfSequenceNumberLessThan ensures that the page blob operation
        /// succeeds only if the blob's sequence number is less than a value.
        /// </summary>
        public long? IfSequenceNumberLessThan { get; set; }

        /// <summary>
        /// IfSequenceNumberLessThanOrEqual ensures that the page blob
        /// operation succeeds only if the blob's sequence number is less than
        /// or equal to a value.
        /// </summary>
        public long? IfSequenceNumberLessThanOrEqual { get; set; }

        /// <summary>
        /// IfSequenceNumberEqual ensures that the page blob operation
        /// succeeds only if the blob's sequence number is equal to a value.
        /// </summary>
        public long? IfSequenceNumberEqual { get; set; }

        /// <summary>
        /// Collect any request conditions.  Conditions should be separated by
        /// a semicolon.
        /// </summary>
        /// <param name="conditions">The collected conditions.</param>
        internal override void AddConditions(StringBuilder conditions)
        {
            base.AddConditions(conditions);

            if (IfSequenceNumberLessThan != null)
            {
                conditions.Append(nameof(IfSequenceNumberLessThan)).Append('=').Append(IfSequenceNumberLessThan).Append(';');
            }

            if (IfSequenceNumberLessThanOrEqual != null)
            {
                conditions.Append(nameof(IfSequenceNumberLessThanOrEqual)).Append('=').Append(IfSequenceNumberLessThanOrEqual).Append(';');
            }

            if (IfSequenceNumberEqual != null)
            {
                conditions.Append(nameof(IfSequenceNumberEqual)).Append('=').Append(IfSequenceNumberEqual).Append(';');
            }
        }
    }
}
