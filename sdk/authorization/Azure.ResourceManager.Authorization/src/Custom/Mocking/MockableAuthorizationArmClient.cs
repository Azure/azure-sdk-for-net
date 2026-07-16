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

namespace Azure.ResourceManager.Authorization.Mocking
{
    public partial class MockableAuthorizationArmClient
    {
        /// <inheritdoc cref="GetAuthorizationRoleDefinition(ResourceIdentifier, string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinition(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        [ForwardsClientCalls]
        public virtual Response<AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(ResourceIdentifier scope, ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return GetAuthorizationRoleDefinition(scope, roleDefinitionId.ToString(), cancellationToken);
        }

        /// <inheritdoc cref="GetAuthorizationRoleDefinitionAsync(ResourceIdentifier, string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinitionAsync(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        [ForwardsClientCalls]
        public virtual async Task<Response<AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(ResourceIdentifier scope, ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return await GetAuthorizationRoleDefinitionAsync(scope, roleDefinitionId.ToString(), cancellationToken).ConfigureAwait(false);
        }
    }
}
