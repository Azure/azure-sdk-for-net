// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// AutoRest mapped roleDefinitionId to ResourceIdentifier although the service parameter is a name string.
// This hidden obsolete overload preserves GA compatibility and forwards to the generated string API.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Authorization
{
    public partial class AuthorizationRoleDefinitionResource
    {
        /// <inheritdoc cref="CreateResourceIdentifier(string, string)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use CreateResourceIdentifier(string scope, string roleDefinitionId) instead.")]
        public static ResourceIdentifier CreateResourceIdentifier(string scope, ResourceIdentifier roleDefinitionId)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return CreateResourceIdentifier(scope, roleDefinitionId.ToString());
        }
    }
}
