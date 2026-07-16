// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// AutoRest mapped roleDefinitionId to ResourceIdentifier although the service parameter is a name string.
// These hidden obsolete overloads preserve GA compatibility and forward to the generated string APIs.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Authorization
{
    public partial class AuthorizationRoleDefinitionCollection
    {
        /// <inheritdoc cref="CreateOrUpdate(WaitUntil, string, AuthorizationRoleDefinitionData, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use CreateOrUpdate(WaitUntil waitUntil, string roleDefinitionId, AuthorizationRoleDefinitionData data, CancellationToken cancellationToken = default) instead.")]
        public virtual ArmOperation<AuthorizationRoleDefinitionResource> CreateOrUpdate(WaitUntil waitUntil, ResourceIdentifier roleDefinitionId, AuthorizationRoleDefinitionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return CreateOrUpdate(waitUntil, roleDefinitionId.ToString(), data, cancellationToken);
        }

        /// <inheritdoc cref="CreateOrUpdateAsync(WaitUntil, string, AuthorizationRoleDefinitionData, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use CreateOrUpdateAsync(WaitUntil waitUntil, string roleDefinitionId, AuthorizationRoleDefinitionData data, CancellationToken cancellationToken = default) instead.")]
        public virtual async Task<ArmOperation<AuthorizationRoleDefinitionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, ResourceIdentifier roleDefinitionId, AuthorizationRoleDefinitionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return await CreateOrUpdateAsync(waitUntil, roleDefinitionId.ToString(), data, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="Exists(string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use Exists(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual Response<bool> Exists(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return Exists(roleDefinitionId.ToString(), cancellationToken);
        }

        /// <inheritdoc cref="ExistsAsync(string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use ExistsAsync(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual async Task<Response<bool>> ExistsAsync(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return await ExistsAsync(roleDefinitionId.ToString(), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="Get(string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use Get(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual Response<AuthorizationRoleDefinitionResource> Get(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return Get(roleDefinitionId.ToString(), cancellationToken);
        }

        /// <inheritdoc cref="GetAsync(string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetAsync(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual async Task<Response<AuthorizationRoleDefinitionResource>> GetAsync(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return await GetAsync(roleDefinitionId.ToString(), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="GetIfExists(string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetIfExists(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual NullableResponse<AuthorizationRoleDefinitionResource> GetIfExists(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return GetIfExists(roleDefinitionId.ToString(), cancellationToken);
        }

        /// <inheritdoc cref="GetIfExistsAsync(string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetIfExistsAsync(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual async Task<NullableResponse<AuthorizationRoleDefinitionResource>> GetIfExistsAsync(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return await GetIfExistsAsync(roleDefinitionId.ToString(), cancellationToken).ConfigureAwait(false);
        }
    }
}
