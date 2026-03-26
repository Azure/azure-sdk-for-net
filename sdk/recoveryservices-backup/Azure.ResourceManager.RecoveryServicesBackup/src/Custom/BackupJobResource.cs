// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public partial class BackupJobResource : ArmResource
    {
        /// <summary>
        /// Cancels a job. This is an asynchronous operation. To know the status of the cancellation, call
        /// GetCancelOperationResult API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupJobs/{jobName}/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>JobCancellations_Trigger</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future release. Please use TriggerAsync instead.")]
        public virtual async Task<Response> TriggerJobCancellationAsync(CancellationToken cancellationToken = default)
            => await TriggerAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Cancels a job. This is an asynchronous operation. To know the status of the cancellation, call
        /// GetCancelOperationResult API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupJobs/{jobName}/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>JobCancellations_Trigger</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future release. Please use Trigger instead.")]
        public virtual Response TriggerJobCancellation(CancellationToken cancellationToken = default)
            => Trigger(cancellationToken);
    }
}
