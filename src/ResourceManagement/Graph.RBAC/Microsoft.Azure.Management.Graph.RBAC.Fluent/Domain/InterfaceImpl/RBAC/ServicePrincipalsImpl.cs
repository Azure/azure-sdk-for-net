// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models ;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading;
    using Microsoft.Rest;
    public partial class ServicePrincipalsImpl 
    {
        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="objectId">objectId the unique object id</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByObjectId(string objectId) { 
            return this.GetByObjectId( objectId) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="spn">spn the service principal name</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByServicePrincipalName(string spn) { 
            return this.GetByServicePrincipalName( spn) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="spn">spn      the service principal name</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the Observable to the request</returns>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByServicePrincipalNameAsync(string spn, CancellationToken cancellationToken = default(CancellationToken)) { 
            return await this.GetByServicePrincipalNameAsync( spn) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="appId">appId the application id (or the client id)</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipals.GetByAppId(string appId) { 
            return this.GetByAppId( appId) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>.List() { 
            return this.List() as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>;
        }

    }
}