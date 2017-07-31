// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    public partial class RoleDefinitionsImpl 
    {
        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="roleName">The name of the role.</param>
        /// <return>An immutable representation of the role definition.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinitions.GetByScopeAndRoleNameAsync(string scope, string roleName, CancellationToken cancellationToken)
        {
            return await this.GetByScopeAndRoleNameAsync(scope, roleName, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition;
        }

        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="roleName">The name of the role.</param>
        /// <return>An immutable representation of the role definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinitions.GetByScopeAndRoleName(string scope, string roleName)
        {
            return this.GetByScopeAndRoleName(scope, roleName) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition;
        }

        /// <summary>
        /// List role definitions in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <return>A list of role definitions.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinitions.ListByScope(string scope)
        {
            return this.ListByScope(scope) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition>;
        }

        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="name">The name of the role definition.</param>
        /// <return>An immutable representation of the role definition.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinitions.GetByScopeAsync(string scope, string name, CancellationToken cancellationToken)
        {
            return await this.GetByScopeAsync(scope, name, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition;
        }

        /// <summary>
        /// List role definitions in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <return>An observable of role definitions.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinitions.ListByScopeAsync(string scope, CancellationToken cancellationToken)
        {
            return await this.ListByScopeAsync(scope, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition;
        }

        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="name">The name of the role definition.</param>
        /// <return>An immutable representation of the role definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinitions.GetByScope(string scope, string name)
        {
            return this.GetByScope(scope, name) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition;
        }
    }
}