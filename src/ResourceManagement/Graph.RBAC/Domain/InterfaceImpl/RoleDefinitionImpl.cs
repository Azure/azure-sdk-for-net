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
        /// Gets role definition permissions.
        /// </summary>
        System.Collections.Generic.ISet<Models.Permission> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition.Permissions
        {
            get
            {
                return this.Permissions() as System.Collections.Generic.ISet<Models.Permission>;
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
        /// Gets the role definition description.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition.Description
        {
            get
            {
                return this.Description();
            }
        }
    }
}