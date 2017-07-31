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

    public partial class RoleAssignmentsImpl 
    {
        /// <summary>
        /// List role assignments in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role assignments.</param>
        /// <return>A list of role assignments.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignments.ListByScope(string scope)
        {
            return this.ListByScope(scope) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>;
        }

        /// <summary>
        /// Gets the information about a role assignment based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role assignment.</param>
        /// <param name="name">The name of the role assignment.</param>
        /// <return>An immutable representation of the role assignment.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignments.GetByScopeAsync(string scope, string name, CancellationToken cancellationToken)
        {
            return await this.GetByScopeAsync(scope, name, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment;
        }

        /// <summary>
        /// List role assignments in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role assignments.</param>
        /// <return>An observable of role assignments.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignments.ListByScopeAsync(string scope, CancellationToken cancellationToken)
        {
            return await this.ListByScopeAsync(scope, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment;
        }

        /// <summary>
        /// Gets the information about a role assignment based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role assignment.</param>
        /// <param name="name">The name of the role assignment.</param>
        /// <return>An immutable representation of the role assignment.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignments.GetByScope(string scope, string name)
        {
            return this.GetByScope(scope, name) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment;
        }
    }
}