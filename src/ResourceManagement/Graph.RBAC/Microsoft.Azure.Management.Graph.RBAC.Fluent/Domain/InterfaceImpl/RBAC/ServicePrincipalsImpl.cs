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
        /// Begins a definition for a new resource.
        /// <p>
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is {@link Creatable#create()}.
        /// <p>
        /// Note that the {@link Creatable#create()} method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see {@link Creatable#create()} among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">name the name of the new resource</param>
        /// <returns>the first stage of the new resource definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IBlank Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IBlank>.Define(string name) { 
            return this.Define( name) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IBlank;
        }

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