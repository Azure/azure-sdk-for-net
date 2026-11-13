// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSensitivityLabelResource
    {
        /// <summary> Deletes the sensitivity label of a given column. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Delete is no longer supported on this resource.");
        }

        /// <summary> Deletes the sensitivity label of a given column. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("DeleteAsync is no longer supported on this resource.");
        }

        /// <summary> Updates the sensitivity label of a given column. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlDatabaseSensitivityLabelResource> Update(WaitUntil waitUntil, SensitivityLabelData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Update is no longer supported on this resource.");
        }

        /// <summary> Updates the sensitivity label of a given column. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SqlDatabaseSensitivityLabelResource>> UpdateAsync(WaitUntil waitUntil, SensitivityLabelData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("UpdateAsync is no longer supported on this resource.");
        }
    }
}
