// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;

namespace Azure.ResourceManager.Storage
{
    public partial class EncryptionScopeCollection
    {
        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes
        /// Operation Id: EncryptionScopes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EncryptionScopeResource> GetAllAsync(CancellationToken cancellationToken) =>
            GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes
        /// Operation Id: EncryptionScopes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EncryptionScopeResource> GetAll(CancellationToken cancellationToken) =>
            GetAll(null, null, null, cancellationToken);
    }
}
