// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TypeSpec restricts construction of the discriminated abstract base to generated derived models,
// while the protected constructor preserves the shipped extensibility surface.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Authorization.Models
{
    public abstract partial class RoleManagementPolicyRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleManagementPolicyRule"/> class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected RoleManagementPolicyRule()
        {
        }
    }
}
