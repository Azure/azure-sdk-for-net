// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSensitivityLabelCollection
    {
        /// <summary> Creates or updates a sensitivity label of a column. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlDatabaseSensitivityLabelResource> CreateOrUpdate(WaitUntil waitUntil, SensitivityLabelData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("CreateOrUpdate is no longer supported on this collection.");
        }

        /// <summary> Creates or updates a sensitivity label of a column. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SqlDatabaseSensitivityLabelResource>> CreateOrUpdateAsync(WaitUntil waitUntil, SensitivityLabelData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("CreateOrUpdateAsync is no longer supported on this collection.");
        }
    }
}
