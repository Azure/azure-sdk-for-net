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

    public partial class ActiveDirectoryUsersImpl 
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <param name="callback">The callback to call on success or failure.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Rest.ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>.GetByIdAsync(string id, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> callback, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, callback, cancellationToken) as Microsoft.Rest.ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>.GetById(string id)
        {
            return this.GetById(id) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IActiveDirectoryUser>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IActiveDirectoryUser>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>.GetByName(string name)
        {
            return this.GetByName(name) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser;
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

        /// <summary>
        /// Gets the information about a resource based on the resource name.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByNameAsync<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await this.GetByNameAsync(name, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser;
        }
    }
}