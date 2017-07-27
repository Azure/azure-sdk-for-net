// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to role definition management API.
    /// </summary>
    public interface IRoleDefinitions  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinitionsOperations>
    {
        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="name">The name of the role definition.</param>
        /// <return>An immutable representation of the role definition.</return>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByScopeAsync(string scope, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="roleName">The name of the role.</param>
        /// <return>An immutable representation of the role definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition GetByScopeAndRoleName(string scope, string roleName);

        /// <summary>
        /// List role definitions in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <return>An observable of role definitions.</return>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> ListByScopeAsync(string scope, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List role definitions in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <return>A list of role definitions.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> ListByScope(string scope);

        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="name">The name of the role definition.</param>
        /// <return>An immutable representation of the role definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition GetByScope(string scope, string name);

        /// <summary>
        /// Gets the information about a role definition based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role definition.</param>
        /// <param name="roleName">The name of the role.</param>
        /// <return>An immutable representation of the role definition.</return>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByScopeAndRoleNameAsync(string scope, string roleName, CancellationToken cancellationToken = default(CancellationToken));

    }
}