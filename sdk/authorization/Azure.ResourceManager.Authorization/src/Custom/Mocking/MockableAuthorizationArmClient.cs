// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// AutoRest mapped roleDefinitionId to ResourceIdentifier although the service parameter is a name string.
// These hidden obsolete overloads preserve GA compatibility and forward to the generated string APIs.
// The generator also places variable-resource permissions on this type with redundant scope components.
// Targeted suppression removes those malformed virtual methods in favor of the shipped ResourceGroupResource surface.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Authorization.Mocking
{
    // The management generator exposes path components already represented by the extension operation's ResourceIdentifier scope.
    // Suppress these malformed convenience methods until the generator derives those values from scope: https://github.com/Azure/azure-sdk-for-net/issues/61113.
    [CodeGenSuppress("GetAzurePermissionsForResource", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAzurePermissionsForResourceAsync", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
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
