// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;

    internal partial class UsersImpl 
    {
        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">The user principal name.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsers.GetByUserPrincipalName(string upn)
        {
            return this.GetByUserPrincipalName(upn) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser;
        }

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">The user principal name.</param>
        /// <return>An Future based service call.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser> Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsers.GetByUserPrincipalNameAsync(string upn, CancellationToken cancellationToken)
        {
            return await this.GetByUserPrincipalNameAsync(upn, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser;
        }

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="objectId">The unique object id.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsers.GetByObjectId(string objectId)
        {
            return this.GetByObjectId(objectId) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IUser>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IUser>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IGraphRbacManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.IGraphRbacManager>.Manager
        {
            get
            {
                return this.Manager as Microsoft.Azure.Management.Graph.RBAC.Fluent.IGraphRbacManager;
            }
        }
    }
}