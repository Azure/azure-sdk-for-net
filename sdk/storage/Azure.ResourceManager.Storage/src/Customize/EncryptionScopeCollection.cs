// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.Storage
{
    public partial class EncryptionScopeCollection
    {
        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EncryptionScopeResource> GetAllAsync(CancellationToken cancellationToken) =>
            GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EncryptionScopeResource> GetAll(CancellationToken cancellationToken) =>
            GetAll(null, null, null, cancellationToken);
    }
}
