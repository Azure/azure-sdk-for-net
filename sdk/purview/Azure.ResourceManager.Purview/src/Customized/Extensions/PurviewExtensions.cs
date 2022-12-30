// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Purview.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Purview
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Purview. </summary>
    public static partial class PurviewExtensions
    {
        /// <summary>
        /// Get the default account for the scope.
        /// Request Path: /providers/Microsoft.Purview/getDefaultAccount
        /// Operation Id: DefaultAccounts_Get
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object, for example if the scope is &quot;Subscription&quot; then it is the ID of that subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response<DefaultPurviewAccountPayload>> GetDefaultAccountAsync(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = null, CancellationToken cancellationToken = default) =>
            await GetDefaultAccountAsync(tenantResource, new PurviewExtensionsGetDefaultAccountOptions(scopeTenantId, scopeType)
            {
                Scope = scope
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the default account for the scope.
        /// Request Path: /providers/Microsoft.Purview/getDefaultAccount
        /// Operation Id: DefaultAccounts_Get
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object, for example if the scope is &quot;Subscription&quot; then it is the ID of that subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response<DefaultPurviewAccountPayload> GetDefaultAccount(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = null, CancellationToken cancellationToken = default) =>
            GetDefaultAccount(tenantResource, new PurviewExtensionsGetDefaultAccountOptions(scopeTenantId, scopeType)
            {
                Scope = scope
            }, cancellationToken);

        /// <summary>
        /// Removes the default account from the scope.
        /// Request Path: /providers/Microsoft.Purview/removeDefaultAccount
        /// Operation Id: DefaultAccounts_Remove
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object, for example if the scope is &quot;Subscription&quot; then it is the ID of that subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response> RemoveDefaultAccountAsync(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = null, CancellationToken cancellationToken = default) =>
            await RemoveDefaultAccountAsync(tenantResource, new PurviewExtensionsRemoveDefaultAccountOptions(scopeTenantId, scopeType)
            {
                Scope = scope
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Removes the default account from the scope.
        /// Request Path: /providers/Microsoft.Purview/removeDefaultAccount
        /// Operation Id: DefaultAccounts_Remove
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object, for example if the scope is &quot;Subscription&quot; then it is the ID of that subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response RemoveDefaultAccount(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = null, CancellationToken cancellationToken = default) =>
            RemoveDefaultAccount(tenantResource, new PurviewExtensionsRemoveDefaultAccountOptions(scopeTenantId, scopeType)
            {
                Scope = scope
            }, cancellationToken);
    }
}
