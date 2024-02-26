// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing a collection of <see cref="NetAppAccountBackupResource" /> and their operations.
    /// Each <see cref="NetAppAccountBackupResource" /> in the collection will belong to the same instance of <see cref="NetAppAccountResource" />.
    /// To get a <see cref="NetAppAccountBackupCollection" /> instance call the GetNetAppAccountBackups method from an instance of <see cref="NetAppAccountResource" />.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppAccountBackupCollection : ArmCollection, IEnumerable<NetAppAccountBackupResource>, IAsyncEnumerable<NetAppAccountBackupResource>
    {
        /// <summary>
        /// List all Backups for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetAppAccountBackupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetAppAccountBackupResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, cancellationToken);

        /// <summary>
        /// List all Backups for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetAppAccountBackupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetAppAccountBackupResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, cancellationToken);
    }
}
