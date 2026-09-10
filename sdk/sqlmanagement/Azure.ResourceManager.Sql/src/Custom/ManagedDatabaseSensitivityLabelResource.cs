// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedDatabaseSensitivityLabelResource
    {
        /// <summary> Deletes the sensitivity label of a given column. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Delete is no longer supported on this resource.");
        }

        /// <summary> Deletes the sensitivity label of a given column. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("DeleteAsync is no longer supported on this resource.");
        }

        /// <summary> Updates the sensitivity label of a given column. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> The sensitivity label data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ManagedDatabaseSensitivityLabelResource> Update(WaitUntil waitUntil, SensitivityLabelData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Update is no longer supported on this resource.");
        }

        /// <summary> Updates the sensitivity label of a given column. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> The sensitivity label data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<ManagedDatabaseSensitivityLabelResource>> UpdateAsync(WaitUntil waitUntil, SensitivityLabelData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("UpdateAsync is no longer supported on this resource.");
        }
    }
}
