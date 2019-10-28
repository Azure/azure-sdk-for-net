// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies append blob specific access conditions.
    /// </summary>
    public class AppendBlobRequestConditions : BlobRequestConditions
    {
        /// <summary>
        /// IfAppendPositionEqual ensures that the AppendBlock operation
        /// succeeds only if the append position is equal to a value.
        /// </summary>
        public long? IfAppendPositionEqual { get; set; }

        /// <summary>
        /// IfMaxSizeLessThanOrEqual ensures that the AppendBlock operation
        /// succeeds only if the append blob's size is less than or equal to
        /// a value.
        /// </summary>
        public long? IfMaxSizeLessThanOrEqual { get; set; }

        /// <summary>
        /// Collect any request conditions.  Conditions should be separated by
        /// a semicolon.
        /// </summary>
        /// <param name="conditions">The collected conditions.</param>
        internal override void AddConditions(StringBuilder conditions)
        {
            base.AddConditions(conditions);

            if (IfAppendPositionEqual != null)
            {
                conditions.Append(nameof(IfAppendPositionEqual)).Append('=').Append(IfAppendPositionEqual).Append(';');
            }

            if (IfMaxSizeLessThanOrEqual != null)
            {
                conditions.Append(nameof(IfMaxSizeLessThanOrEqual)).Append('=').Append(IfMaxSizeLessThanOrEqual).Append(';');
            }
        }
    }
}
