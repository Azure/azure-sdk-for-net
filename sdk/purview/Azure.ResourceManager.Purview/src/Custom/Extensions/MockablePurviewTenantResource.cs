// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Purview.Models;

namespace Azure.ResourceManager.Purview.Mocking
{
    // Backward compatibility: old API used Guid for scopeTenantId parameter.
    // New generator uses string. These overloads bridge the old signatures.
    public partial class MockablePurviewTenantResource
    {
        /// <summary> Gets the default account information set for the scope. </summary>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DefaultPurviewAccountPayload>> GetDefaultAccountAsync(Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return await GetDefaultAccountAsync(scopeTenantId.ToString(), scopeType, scope, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the default account information set for the scope. </summary>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DefaultPurviewAccountPayload> GetDefaultAccount(Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return GetDefaultAccount(scopeTenantId.ToString(), scopeType, scope, cancellationToken);
        }

        /// <summary> Removes the default account from the scope. </summary>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RemoveDefaultAccountAsync(Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return await RemoveDefaultAccountAsync(scopeTenantId.ToString(), scopeType, scope, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Removes the default account from the scope. </summary>
        /// <param name="scopeTenantId"> The tenant ID. </param>
        /// <param name="scopeType"> The scope for the default account. </param>
        /// <param name="scope"> The Id of the scope object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RemoveDefaultAccount(Guid scopeTenantId, PurviewAccountScopeType scopeType, string scope = default, CancellationToken cancellationToken = default)
        {
            return RemoveDefaultAccount(scopeTenantId.ToString(), scopeType, scope, cancellationToken);
        }
    }
}
