// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to role assignment management API.
    /// </summary>
    public interface IRoleAssignments  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<RoleAssignment.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignmentsOperations>
    {
        /// <summary>
        /// Gets the information about a role assignment based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role assignment.</param>
        /// <param name="name">The name of the role assignment.</param>
        /// <return>An immutable representation of the role assignment.</return>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> GetByScopeAsync(string scope, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List role assignments in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role assignments.</param>
        /// <return>An observable of role assignments.</return>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> ListByScopeAsync(string scope, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List role assignments in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role assignments.</param>
        /// <return>A list of role assignments.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> ListByScope(string scope);

        /// <summary>
        /// Gets the information about a role assignment based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role assignment.</param>
        /// <param name="name">The name of the role assignment.</param>
        /// <return>An immutable representation of the role assignment.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment GetByScope(string scope, string name);
    }
}