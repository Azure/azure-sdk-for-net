// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Purview.Mocking;
using Azure.ResourceManager.Purview.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Purview
{
    // Backward compatibility: old API used Guid for scopeTenantId parameter.
    // New generator uses string. These overloads bridge the old signatures
    // and delegate through the mockable class for proper mocking support.
    public static partial class PurviewExtensions
    {
        /// <summary> Gets the default account information set for the scope. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response<DefaultPurviewAccountPayload>> GetDefaultAccountAsync(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return await GetMockablePurviewTenantResource(tenantResource).GetDefaultAccountAsync(scopeTenantId, scopeType, scope, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the default account information set for the scope. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response<DefaultPurviewAccountPayload> GetDefaultAccount(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return GetMockablePurviewTenantResource(tenantResource).GetDefaultAccount(scopeTenantId, scopeType, scope, cancellationToken);
        }

        /// <summary> Removes the default account from the scope. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response> RemoveDefaultAccountAsync(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return await GetMockablePurviewTenantResource(tenantResource).RemoveDefaultAccountAsync(scopeTenantId, scopeType, scope, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Removes the default account from the scope. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response RemoveDefaultAccount(this TenantResource tenantResource, Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return GetMockablePurviewTenantResource(tenantResource).RemoveDefaultAccount(scopeTenantId, scopeType, scope, cancellationToken);
        }
    }
}
