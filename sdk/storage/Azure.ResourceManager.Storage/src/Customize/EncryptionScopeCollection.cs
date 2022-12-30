// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.Storage.Models;

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

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes
        /// Operation Id: EncryptionScopes_List
        /// </summary>
        /// <param name="maxpagesize"> Optional, specifies the maximum number of encryption scopes that will be included in the list response. </param>
        /// <param name="filter"> Optional. When specified, only encryption scope names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, when specified, will list encryption scopes with the specific state. Defaults to All. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EncryptionScopeResource> GetAllAsync(int? maxpagesize = null, string filter = null, EncryptionScopesIncludeType? include = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new EncryptionScopeCollectionGetAllOptions
            {
                Maxpagesize = maxpagesize,
                Filter = filter,
                Include = include
            }, cancellationToken);

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes
        /// Operation Id: EncryptionScopes_List
        /// </summary>
        /// <param name="maxpagesize"> Optional, specifies the maximum number of encryption scopes that will be included in the list response. </param>
        /// <param name="filter"> Optional. When specified, only encryption scope names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, when specified, will list encryption scopes with the specific state. Defaults to All. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EncryptionScopeResource> GetAll(int? maxpagesize = null, string filter = null, EncryptionScopesIncludeType? include = null, CancellationToken cancellationToken = default) =>
            GetAll(new EncryptionScopeCollectionGetAllOptions
            {
                Maxpagesize = maxpagesize,
                Filter = filter,
                Include = include
            }, cancellationToken);
    }
}
