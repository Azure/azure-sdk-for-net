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

    internal partial class ServicePrincipalsImpl 
    {
        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="objectId">The unique object id.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByObjectId(string objectId)
        {
            return this.GetByObjectId(objectId) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="spn">The service principal name.</param>
        /// <return>The Observable to the request.</return>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByServicePrincipalNameAsync(string spn, CancellationToken cancellationToken)
        {
            return await this.GetByServicePrincipalNameAsync(spn, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="appId">The application id (or the client id).</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByAppId(string appId)
        {
            return this.GetByAppId(appId) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="spn">The service principal name.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByServicePrincipalName(string spn)
        {
            return this.GetByServicePrincipalName(spn) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IServicePrincipal>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IServicePrincipal>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>;
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