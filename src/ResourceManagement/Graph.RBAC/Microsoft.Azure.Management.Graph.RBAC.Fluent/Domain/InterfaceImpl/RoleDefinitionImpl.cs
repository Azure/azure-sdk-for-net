// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    public partial class RoleDefinitionImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the role type.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets role definition permissions.
        /// </summary>
        System.Collections.Generic.ISet<Models.PermissionInner> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition.Permissions
        {
            get
            {
                return this.Permissions() as System.Collections.Generic.ISet<Models.PermissionInner>;
            }
        }

        /// <summary>
        /// Gets the role name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition.RoleName
        {
            get
            {
                return this.RoleName();
            }
        }

        /// <summary>
        /// Gets the role definition description.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets role definition assignable scopes.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition.AssignableScopes
        {
            get
            {
                return this.AssignableScopes() as System.Collections.Generic.ISet<string>;
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>.Manager
        {
            get
            {
                return this.Manager() as Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager;
            }
        }
    }
}