// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure AD role definition.
    /// </summary>
    public interface IRoleDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.RoleDefinitionInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>
    {
        /// <summary>
        /// Gets role definition permissions.
        /// </summary>
        System.Collections.Generic.ISet<Models.Permission> Permissions { get; }

        /// <summary>
        /// Gets the role name.
        /// </summary>
        string RoleName { get; }

        /// <summary>
        /// Gets the role definition description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the role type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets role definition assignable scopes.
        /// </summary>
        System.Collections.Generic.ISet<string> AssignableScopes { get; }
    }
}