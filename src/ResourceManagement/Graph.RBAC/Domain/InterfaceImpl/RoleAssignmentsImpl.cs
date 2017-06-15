// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    public partial class RoleAssignmentsImpl 
    {
        /// <summary>
        /// List role assignments in a scope.
        /// </summary>
        /// <param name="scope">The scope of the role assignments.</param>
        /// <return>An observable of role assignments.</return>
        async Task<IPagedCollection<IRoleAssignment>> Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignments.ListByScopeAsync(string scope, CancellationToken cancellationToken)
        {
            return await this.ListByScopeAsync(scope, cancellationToken) as IPagedCollection<IRoleAssignment>;
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
        /// Gets the information about a role assignment based on scope and name.
        /// </summary>
        /// <param name="scope">The scope of the role assignment.</param>
        /// <param name="name">The name of the role assignment.</param>
        /// <return>An immutable representation of the role assignment.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignments.GetByScope(string scope, string name)
        {
            return this.GetByScope(scope, name) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment;
        }

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
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        RoleAssignment.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<RoleAssignment.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as RoleAssignment.Definition.IBlank;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment;
        }
        
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>.GetById(string id)
        {
            return this.GetById(id) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment;
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
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