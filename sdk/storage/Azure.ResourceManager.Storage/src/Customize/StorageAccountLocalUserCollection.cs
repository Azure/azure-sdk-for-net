// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="StorageAccountLocalUserResource"/> and their operations.
    /// Each <see cref="StorageAccountLocalUserResource"/> in the collection will belong to the same instance of <see cref="StorageAccountResource"/>.
    /// To get a <see cref="StorageAccountLocalUserCollection"/> instance call the GetStorageAccountLocalUsers method from an instance of <see cref="StorageAccountResource"/>.
    /// </summary>
    public partial class StorageAccountLocalUserCollection : ArmCollection, IEnumerable<StorageAccountLocalUserResource>, IAsyncEnumerable<StorageAccountLocalUserResource>
    {
        /// <summary>
        /// List the local users associated with the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LocalUsers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageAccountLocalUserResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StorageAccountLocalUserResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageAccountLocalUserResource> GetAllAsync(CancellationToken cancellationToken) =>
            GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List the local users associated with the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LocalUsers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageAccountLocalUserResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageAccountLocalUserResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageAccountLocalUserResource> GetAll(CancellationToken cancellationToken) =>
            GetAll(null, null, null, cancellationToken);
    }
}
